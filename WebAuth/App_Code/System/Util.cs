using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using LitJson;

/// <summary>
/// Util의 요약 설명입니다.
/// </summary>
public class Util
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	public const int kUserSecret_MaxLength = 20;
	public const int kAccessSecret_MaxLength = 20;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static member variables

	private static Random s_random = new Random();

	private static char[] s_codeElements = new char[] {
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
		'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
		'u', 'v', 'w', 'x', 'y', 'z'
	};

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static properties

	public static Random random
	{
		get { return s_random; }
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// 응답 관련

	public static void WriteResponse(JsonData jo)
	{
		if (jo == null)
			throw new ArgumentNullException("jo");
		
		jo.ToJson(new JsonWriter(HttpContext.Current.Response.Output));
		//HttpContext.Current.Response.Write(System.Text.RegularExpressions.Regex.Unescape(jo.ToJson()));
	}

	public static void WriteResponseEncrypt(JsonData jo)
	{
		if (jo == null)
			throw new ArgumentNullException("jo");

		HttpContext.Current.Response.Write(GetHashValue(jo.ToJson(), "E"));
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// 사용자 및 인증 관련

	public static string CreateUserSecret()
	{
		return CreateCode(kUserSecret_MaxLength);
	}

	public static string CreateAccessSecret()
	{
		return CreateCode(kAccessSecret_MaxLength);
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// 기타

	public static long GetIpNum(string sIp)
	{
		string[] sArrIp = sIp.Split('.');

		long val1 = 16777216;
		long val2 = 65536;
		long val3 = 256;

		return (Convert.ToInt64(sArrIp[0]) * val1) + (Convert.ToInt64(sArrIp[1]) * val2) + (Convert.ToInt64(sArrIp[2]) * val3) + Convert.ToInt64(sArrIp[3]);
	}

	public static string CreateCode(int nLength)
	{
		int nElementCount = s_codeElements.Length;

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < nLength; i++)
		{
			sb.Append(s_codeElements[s_random.Next(nElementCount)]);
		}

		return sb.ToString();
	}

	public static string ToString(Exception ex)
	{
		if (ex == null)
			return null;

		StringBuilder sb = new StringBuilder();

		sb.AppendFormat("[{0}: {1}]", ex.GetType().ToString(), ex.Message);

		if (ex is CommandHandlerException)
		{
			CommandHandlerException cmdHandlerEx = (CommandHandlerException)ex;

			sb.Append(Environment.NewLine);
			sb.AppendFormat("# result : {0}", cmdHandlerEx.result);

			string sReqJson = null;

			if (!string.IsNullOrEmpty(cmdHandlerEx.reqJson))
				sReqJson = cmdHandlerEx.reqJson;
			else if (cmdHandlerEx.handler != null && cmdHandlerEx.handler.requestJson != null)
				sReqJson = cmdHandlerEx.handler.requestJson.ToJson();

			if (sReqJson != null)
			{
				sb.Append(Environment.NewLine);
				sb.AppendFormat("# Reqquest Json : {0}", sReqJson);
			}
		}

		sb.Append(Environment.NewLine);
		sb.AppendFormat("# StackTrace");
		sb.Append(Environment.NewLine);
		sb.Append(ex.StackTrace);

		if (ex.InnerException != null)
		{
			sb.Append(Environment.NewLine);
			sb.Append(ToString(ex.InnerException));
		}

		return sb.ToString();
	}

	public static string GetHashValue(string sMsg, string sType)
	{
		try
		{
			RijndaelManaged rijndaelCipher = new RijndaelManaged();
			rijndaelCipher.Mode = CipherMode.CBC;
			rijndaelCipher.Padding = PaddingMode.PKCS7;

			rijndaelCipher.KeySize = 128;
			rijndaelCipher.BlockSize = 128;

			byte[] pwdBytes = Encoding.UTF8.GetBytes(Config.aesKey);
			byte[] keyBytes = new byte[16];

			int len = pwdBytes.Length;

			if (len > keyBytes.Length)
			{
				len = keyBytes.Length;
			}

			Array.Copy(pwdBytes, keyBytes, len);
			rijndaelCipher.Key = keyBytes;
			rijndaelCipher.IV = keyBytes;

			ICryptoTransform transform = rijndaelCipher.CreateEncryptor();

			byte[] plainText = (sType == "E") ? Encoding.UTF8.GetBytes(sMsg) : rijndaelCipher.CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(sMsg), 0, Convert.FromBase64String(sMsg).Length);

			return (sType == "E") ? Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length)) : Encoding.UTF8.GetString(plainText);
		}
		catch (Exception ex)
		{
			return "";
		}
	}
}