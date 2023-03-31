using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// Connect'的摘要描述.
/// </summary>
public static class Connect
{
	public static string VerificationEntermate(string sUserId, string sToken)
	{
		WebRequest webReq = null;
		Stream reqStream = null, resStream = null;
		StreamReader sr = null;
		Encoding encode = null;

		string sHtml = "";

		try
		{
			string sUrl = string.Format("http://gameapi.ilovegame.co.kr/user/me?username={0}&token={1}", sUserId, sToken);

			// 웹 요청
			webReq = WebRequest.Create(sUrl);
			webReq.Method = "GET";
			webReq.ContentType = "application/json";
			webReq.Headers.Add("X-API-KEY", "E69Vu71xzlDxb6JyWL9vBQrL823cvRsT");
			// Encoding 설정
			encode = Encoding.GetEncoding("utf-8");

			// 웹 페이지 읽기
			resStream = webReq.GetResponse().GetResponseStream();
			sr = new StreamReader(resStream, encode);
			sHtml = sr.ReadToEnd();

			sr.Close();
			sr = null;
		}
		catch (Exception e)
		{
			//throw (e);
			sHtml = null;
		}
		finally
		{
			if (reqStream != null)
				reqStream.Close();

			if (sr != null)
				sr.Close();
		}

		return sHtml;
	}
}