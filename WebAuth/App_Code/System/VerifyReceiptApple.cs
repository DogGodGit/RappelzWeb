using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using LitJson;

/// <summary>
/// VerifyReceiptApple'的摘要描述.
/// </summary>
public class VerifyReceiptApple
{
	public VerifyReceiptApple()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

	public static JsonData VerifyApple(string sRequestData)
	{
		try
		{
			string sSandboxUrl = "https://sandbox.itunes.apple.com/verifyReceipt";
			string sProductUrl = "https://buy.itunes.apple.com/verifyReceipt";

			string result = VerifyAppleServer(sProductUrl, sRequestData);

			JsonData req = JsonMapper.ToObject(result);

			if (LitJsonUtil.GetIntValue(req["status"]) != 0)
			{
				//라이브 실패시 샌드박스로 테스트
				result = VerifyAppleServer(sSandboxUrl, sRequestData);

				req = JsonMapper.ToObject(result);
			}

			if (LitJsonUtil.GetIntValue(req["status"]) != 0)
				return null;

			return LitJsonUtil.GetObjectProperty(req, "receipt");
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static string VerifyAppleServer(string sUrl, string receiptData)
	{
		string returnmessage = "";
		try
		{
			// var json = "{ 'receipt-data': '" + receiptData + "'}";
			string json = string.Format("{{\"receipt-data\":\"{0}\"}}", receiptData);

			ASCIIEncoding ascii = new ASCIIEncoding();
			byte[] postBytes = Encoding.UTF8.GetBytes(json);

			//  HttpWebRequest request;
			var request = System.Net.HttpWebRequest.Create(sUrl);
			request.Method = "POST";
			request.ContentType = "application/json";
			request.ContentLength = postBytes.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(postBytes, 0, postBytes.Length);
				stream.Flush();
			}
			var sendresponse = request.GetResponse();

			string sendresponsetext = "";
			using (var streamReader = new StreamReader(sendresponse.GetResponseStream()))
			{
				sendresponsetext = streamReader.ReadToEnd().Trim();
			}
			returnmessage = sendresponsetext;

		}
		catch (Exception ex)
		{
			LogUtil.Log("VerifyAppleServer error:" + ex.Message.ToString());
		}
		return returnmessage;
	}
}