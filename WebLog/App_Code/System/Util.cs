using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using LitJson;
using System.Text.RegularExpressions;

/// <summary>
/// Util의 요약 설명입니다.
/// </summary>
public class Util
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Constants

    public const int kUserId_MaxLength = 12;
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
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 정규식

    public static bool RegexNumber(string sText)
    {
        Regex r = new Regex("[0-9]");

        return r.IsMatch(sText);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 기타

    //==========================================================================
    /// <summary>
    /// MD5 Hash
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    //==========================================================================
    public static string MD5Hash(string str)
    {
        MD5CryptoServiceProvider md5str = new MD5CryptoServiceProvider();
        byte[] data = ASCIIEncoding.Default.GetBytes(str);
        byte[] encode = md5str.ComputeHash(data);
        return BitConverter.ToString(encode).Replace("-", "");
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
}
