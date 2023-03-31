using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using LitJson;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

/// <summary>
/// VerifyReceiptGoogle'的摘要描述.
/// </summary>
public class VerifyReceiptGoogle
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	public const string SCOPE_AUTH_ANDROIDPUBLISHER = "https://www.googleapis.com/auth/androidpublisher";

	public VerifyReceiptGoogle()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

	public static JsonData VerifyGoogle(string sPurchaseData, string sSignature)
	{
		try
		{
			//{"result":1,
			//"signature":"X\/9UiV1WaeXav1Ok+U9v\/0CoT3I5nxzWtIvWTG4NvHrJg8+4dTVN6YCPuABAxoITlOTrF2kwvdR8n7Df27rxvHzGbY9IuoetkfxCEJV0GxBuejAjwsDsTxJ4U3UnJ9krs6FhsWg5d\/q3EFUWAWSBkRLtPmQeGjKQQRuzX6+IAUjanS2CCONL5v60qwmy6BD7mqU1IR8IqDr9N3usuiDaRlVUZwoX\/leHEVjhkD9brsRZ8uUXREbNTTFzTihNTzDle6A5skj+FwtGbCKbd+5Mo754Xre9YJtfWd+8OoRKWLyxilGw\/rxmMUuekRTPMkTNumoTEK3akRRDYZfYvV8IGQ==",
			//"purchaseData":
			//"{
			//\"orderId\":\"12999763169054705758.1347898238725248\",
			//\"packageName\":\"com.mobblo.lib.devapp\",
			//\"productId\":\"com.mobblo.lib.devapp.p1\",
			//\"purchaseTime\":1423464146528,
			//\"purchaseState\":0,
			//\"purchaseToken\":\"acdijajecjaiemgkannphmea.AO-J1Owm7p2rmfZlPqjolCykhVzp07WNz5KYdL7C7DQ0xXCJkUmbbqqtzr5VnXtfRG3oovlOEkOPIbhykmpbqobD8Gi1GJSl5JAzgU_TF8AU0-REt2o1GPosE054pF07UOt6M5ZdUKjy\"
			//}",
			//"productId":"com.mobblo.lib.devapp.p1"}



			return null;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static bool VerifyGoogleLocal(string sPurchaseData, string sSignature)
	{
		try
		{
			JsonData jData = JsonMapper.ToObject<JsonData>(sPurchaseData);

			string sOrderId = jData["orderId"].ToString();// obj["orderId"].GetValue().ToString();
			string sPackageName = jData["packageName"].ToString();//obj["packageName"].GetValue().ToString();
			string sProductId = jData["productId"].ToString();//obj["productId"].GetValue().ToString();

			string sPdtKey = sPackageName + ".google";

			string sPubKey = System.Configuration.ConfigurationManager.AppSettings[sPdtKey];

			if (sPubKey == null)
			{
				return false;
			}

			RsaKeyParameters rsaParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(sPubKey));

			if (rsaParameters == null)
			{

				return false;
			}

			byte[] rsaExp = rsaParameters.Exponent.ToByteArray();
			byte[] Modulus = rsaParameters.Modulus.ToByteArray();

			int nPos = 0;
			for (int i = 0; i < Modulus.Length; i++)
			{
				if (Modulus[i] == 0)
					nPos++;
				else
					break;
			}

			byte[] rsaMod = new byte[Modulus.Length - nPos];
			Array.Copy(Modulus, nPos, rsaMod, 0, Modulus.Length - nPos);

			//Fill the Microsoft parameters
			RSAParameters rsaKeyInfo = new RSAParameters()
			{
				Exponent = rsaExp,
				Modulus = rsaMod
			};

			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(rsaKeyInfo);

				return rsa.VerifyData(Encoding.ASCII.GetBytes(sPurchaseData), "SHA1", Convert.FromBase64String(sSignature.Replace(" ", "+")));
			}

			return false;
		}
		catch (Exception ex)
		{
			return false;
		}
	}

	public static string VerifyGoogleServer(string sPackageName, string sProductId, string sToken)
	{
		try
		{
			String URL = string.Format("https://www.googleapis.com/androidpublisher/v2/applications/{0}/purchases/products/{1}/tokens/{2}", sPackageName, sProductId, sToken);

			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
			req.Method = "GET";
			req.Accept = "application/json";
			WebResponse res = req.GetResponse();
			StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
			string result = reader.ReadToEnd();

			// 검증 및 처리...

			return result;
		}
		catch (Exception e)
		{
			return null;
		}
	}
}