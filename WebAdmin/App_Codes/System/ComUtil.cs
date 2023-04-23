using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Xml;
using System.Net.Mail;
using System.Data;

public enum RequestMethod : int
{
    Get, Post, All
}

/// <summary>
/// ComUtil의 요약 설명입니다.
/// </summary>
public class ComUtil
{
	public ComUtil()
	{
	}

	public static string GetUserId()
	{
		HttpRequest request = HttpContext.Current.Request;

		string sAdmID1 = CookiesString2(request.Cookies, "MNGR", "FST");
		string sAdmID2 = CookiesString2(request.Cookies, "MNGR", "SND");

		if (sAdmID1 == "" || sAdmID2 == "")
			return "";

		sAdmID1 = GetHashValue(sAdmID1, "D", "1125");
		sAdmID2 = GetHashValue(sAdmID2, "D", "5511");

		if (sAdmID1 == sAdmID2)
			return sAdmID1;
		else
			return "";
	}

	public static int GetAuthority()
	{
		HttpRequest request = HttpContext.Current.Request;

		int nAuthority = -1;
		string sAuthority = CookiesString2(request.Cookies, "MNGR", "AUT");

		sAuthority = GetHashValue(sAuthority, "D", "1525");

		try
		{
			nAuthority = Convert.ToInt32(sAuthority);
		}
		catch (Exception ex)
		{
			nAuthority = -1;
		}

		return nAuthority;
	}

    ///=========================================================================
    /// <summary>
    /// AES128 Decrypt
    /// </summary>
    /// <param name="textToDecrypt"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    ///=========================================================================
    public static string GetHashValue(string sMsg, string sType, string key)
    {
        try
        { 
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;

            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
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

    ///=========================================================================
    /// <summary>
    /// 브라우저 노캐쉬
    /// </summary>
    ///=========================================================================
    public static void SetNoBrowserCache()
    {
        HttpResponse hr = HttpContext.Current.Response;

        //hr.Cache.SetCacheability(HttpCacheability.Private);
        //hr.Cache.SetExpires(DateTime.MinValue);
    }

    public static string PrintByteArray(byte[] array)
    {
        int i;
        StringBuilder sb = new StringBuilder();

        for (i = 0; i < array.Length; i++)
        {
            sb.Append(String.Format("{0:X2}", array[i]));
            //if ((i % 4) == 3) Response.Write(" ");
        }
        return sb.ToString();
    }

    //==========================================================================
    /// <summary>
    /// Get 10 Number
    /// </summary>
    /// <param name="nNum"></param>
    /// <returns>
    /// 1 -> 01
    /// 11 -> 11r
    /// </returns>
    //==========================================================================
    public static string Get10Num(int nNum)
    {
        if (nNum < 10)
            return "0" + nNum.ToString();
        else
            return nNum.ToString();
    }

    //==========================================================================
    /// <summary>
    /// Get Date String
    /// </summary>
    /// <returns>
    /// YYYYMMDDhhmm
    /// </returns>
    //==========================================================================
    public static string GetDateString()
    {
        return DateTime.Now.Year.ToString() + Get10Num(DateTime.Now.Month) + Get10Num(DateTime.Now.Day) + Get10Num(DateTime.Now.Hour) + Get10Num(DateTime.Now.Minute);
    }

    //==========================================================================
    /// <summary>
    /// Get Date String
    /// </summary>
    /// <returns>
    /// YYYYMMDDhhmm
    /// </returns>
    //==========================================================================
    public static string GetDateString2(double dbValue)
    {
        DateTime dtNow = DateTime.Now.AddDays(dbValue);
        return dtNow.Year.ToString() + "-" + Get10Num(dtNow.Month) + "-" + Get10Num(dtNow.Day);
    }

    public static double DateDiff(string Interval, DateTime Date1, DateTime Date2)
    {
        double diff = 0;
        TimeSpan ts = Date2 - Date1;

        switch (Interval.ToLower())
        {
            case "y":
                ts = DateTime.Parse(Date2.ToString("yyyy-01-01")) - DateTime.Parse(Date1.ToString("yyyy-01-01"));
                diff = Convert.ToDouble(ts.TotalDays / 365);
                break;
            case "m":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-01")) - DateTime.Parse(Date1.ToString("yyyy-MM-01"));
                diff = Convert.ToDouble((ts.TotalDays / 365) * 12);
                break;
            case "d":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd"));
                diff = ts.Days;
                break;
            case "h":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:00:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:00:00"));
                diff = ts.TotalHours;
                break;
            case "n":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:00"));
                diff = ts.TotalMinutes;
                break;
            case "s":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:ss"));
                diff = ts.TotalSeconds;
                break;
            case "ms":
                diff = ts.TotalMilliseconds;
                break;

        }
        return diff;
    }

    //==========================================================================
    /// <summary>
    /// Get Date Time
    /// </summary>
    /// <param name="?"></param>
    /// <returns>
    /// YYYYMMDDhhmm -> YYYY-MM-DD hh:mm:00
    /// </returns>
    //==========================================================================
    public static DateTime GetDateTime(string sDate)
    {
        try
        {
            DateTime dt = DateTime.Parse(sDate);
            return dt;
        }
        catch (Exception e)
        {
            return DateTime.Now;
        }
    }

    //==========================================================================
    /// <summary>
    /// Get Date Time
    /// </summary>
    /// <param name="?"></param>
    /// <returns>
    /// YYYYMMDDhhmm -> YYYY-MM-DD hh:mm:00
    /// </returns>
    //==========================================================================
    public static DateTime GetDateTimeDetail(string sDate)
    {
        try
        {
            DateTime dt = DateTime.ParseExact(sDate, "yyyy-MM-dd HH:mm:ss.fff", null);

            return dt;
        }
        catch (Exception e)
        {
            return DateTime.Now;
        }
    }

    //==========================================================================
    /// <summary>
    /// 내용에 불가요소 제거
    /// </summary>
    /// <param name="sStr"></param>
    /// <returns></returns>
    //==========================================================================
    public static string GetValidateString(string sStr)
    {
        string[] sArr = new string[] { "script", "onclick", "ondatabinding", "ondbclick", "ondisposed", "oninit", "onkeydown", "onkeypress", "onkeyup", "onload", "onmousedown", "onmousemove", "onmouseout", "onmouseover", "onmouseup", "onprerender", "onunload" };
        for (int i = 0; i < sArr.Length; i++)
        {
            sStr = Regex.Replace(sStr, sArr[i], "noscript", RegexOptions.IgnoreCase);
        }
        return sStr;
    }

    ///=====================================================================
    /// <summary>
    /// (LONG) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="rm">방식</param>
    /// <param name="nDefault">기본값</param>
    /// <returns>파라메터값</returns>
    ///=====================================================================
    public static long GetRequestLong(string sName, RequestMethod rm, int nDefault)
    {
        try
        {
            return Convert.ToInt64(GetRequestString(sName, rm, nDefault.ToString()));
        }
        catch
        {
            return nDefault;
        }
    }

    ///=====================================================================
    /// <summary>
    /// (LONG) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="rm">방식</param>
    /// <returns>파라메터값</returns>
    ///=====================================================================
    public static long GetRequestLong(string sName, RequestMethod rm)
    {
        try
        {
            return Convert.ToInt64(GetRequestString(sName, rm, "0"));
        }
        catch
        {
            return 0;
        }
    }

    ///=====================================================================
    /// <summary>
    /// (LONG) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="nDefault">기본값</param>
    /// <returns>파라메터값</returns>
    ///=====================================================================
    public static long GetRequestLong(string sName, int nDefault)
    {
        try
        {
            return Convert.ToInt64(GetRequestString(sName, RequestMethod.All, nDefault.ToString()));
        }
        catch
        {
            return 0;
        }
    }

    ///=====================================================================
    /// <summary>
    /// (LONG) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <returns>파라메터값</returns>
    ///=====================================================================
    public static long GetRequestLong(string sName)
    {
        try
        {
            return Convert.ToInt64(GetRequestString(sName, RequestMethod.All, "0"));
        }
        catch
        {
            return 0;
        }
    }

    ///=========================================================================
    /// <summary>
    /// Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="rm">방식</param>
    /// <param name="sDefault">기본값</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static string GetRequestString(string sName, RequestMethod rm, string sDefault)
    {
        string sParamValue = null;
        HttpRequest hr = HttpContext.Current.Request;

        switch (rm)
        {
            case RequestMethod.All:
                sParamValue = hr[sName];
                break;

            case RequestMethod.Get:
                sParamValue = hr.QueryString[sName];
                break;

            case RequestMethod.Post:
                sParamValue = hr.Form[sName];
                break;

            default:
                sParamValue = sDefault;
                break;
        }

        return (sParamValue == null) ? sDefault : sParamValue;
    }

    ///=========================================================================
    /// <summary>
    /// Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="sDefault">기본값</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static string GetRequestString(string sName, string sDefault)
    {
        return GetRequestString(sName, RequestMethod.All, sDefault);
    }

    ///=========================================================================
    /// <summary>
    /// Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="rm">방식</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static string GetRequestString(string sName, RequestMethod rm)
    {
        return GetRequestString(sName, rm, "");
    }

    ///=========================================================================
    /// <summary>
    /// Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static string GetRequestString(string sName)
    {
        return GetRequestString(sName, RequestMethod.All, "");
    }


    ///=========================================================================
    /// <summary>
    /// (INT) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="rm">방식</param>
    /// <param name="nDefault">기본값</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static int GetRequestInt(string sName, RequestMethod rm, int nDefault)
    {
        try
        {
            return Convert.ToInt32(GetRequestString(sName, rm, nDefault.ToString()));
        }
        catch
        {
            return nDefault;
        }
    }

    ///=========================================================================
    /// <summary>
    /// (INT) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="rm">방식</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static int GetRequestInt(string sName, RequestMethod rm)
    {
        try
        {
            return Convert.ToInt32(GetRequestString(sName, rm, "0"));
        }
        catch
        {
            return 0;
        }
    }

    ///=========================================================================
    /// <summary>
    /// (INT) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <param name="nDefault">기본값</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static int GetRequestInt(string sName, int nDefault)
    {
        try
        {
            return Convert.ToInt32(GetRequestString(sName, RequestMethod.All, nDefault.ToString()));
        }
        catch
        {
            return 0;
        }
    }

    ///=========================================================================
    /// <summary>
    /// (INT) Request 파라메터값 얻기
    /// </summary>
    /// <param name="sName">파라메터명</param>
    /// <returns>파라메터값</returns>
    ///=========================================================================
    public static int GetRequestInt(string sName)
    {
        try
        {
            return Convert.ToInt32(GetRequestString(sName, RequestMethod.All, "0"));
        }
        catch
        {
            return 0;
        }
    }

    public static bool TryParseGuid(string str, out Guid result)
    {
        try
        {
            result = new Guid(str);
            return true;
        }
        catch (Exception)
        {
            result = Guid.Empty;
            return false;
        }
    }

    ///=========================================================================
    /// <summary>
    /// (GUID) Request Getting parameter values
    /// </summary>
    /// <param name="sName">Parameter Name</param>
    /// <param name="rm">Methods</param>
    /// <param name="nDefault">Default</param>
    /// <returns>Parameter values</returns>
    ///=========================================================================
    public static Guid GetRequestGuid(string sName, RequestMethod rm, string nDefault = "00000000-0000-0000-0000-000000000000")
    {
        Guid result;
        TryParseGuid(GetRequestString(sName, rm, nDefault.ToString()), out result);
        return result;
    }

    ///=========================================================================
    /// <summary>
    /// (GUID) Request Getting parameter values
    /// </summary>
    /// <param name="sName">Parameter Name</param>
    /// <param name="nDefault">Default</param>
    /// <returns>Parameter values</returns>
    ///=========================================================================
    public static Guid GetRequestGuid(string sName, string nDefault = "00000000-0000-0000-0000-000000000000")
    {
        Guid result;
        TryParseGuid(GetRequestString(sName, RequestMethod.All, nDefault.ToString()), out result);
        return result;
    }

    ///=====================================================================
    /// <summary>
    /// (문자열) 2차원 쿠키값 가져오기
    /// </summary>
    /// <param name="sGrpNm">1차쿠키명</param>
    /// <param name="sKeyNm">2차쿠키명</param>
    /// <param name="sDefault">기본값</param>
    /// <returns>쿠키값</returns>
    ///=====================================================================
    public static string GetArrCookiesString(string sGrpNm, string sKeyNm, string sDefault)
    {
        HttpServerUtility hsu = HttpContext.Current.Server;
        HttpCookieCollection hcc = HttpContext.Current.Request.Cookies;
        HttpCookie hc = hcc[sGrpNm];

        sKeyNm = sKeyNm.Replace("_", "%5F").ToString();

        return (hc != null && hc[sKeyNm] != null) ? hsu.UrlDecode(hc[sKeyNm].ToString()) : sDefault;
    }

    ///=====================================================================
    /// <summary>
    /// (문자열) 2차원 쿠키값 가져오기
    /// </summary>
    /// <param name="sGrpNm">1차쿠키명</param>
    /// <param name="sKeyNm">2차쿠키명</param>
    /// <returns>쿠키값</returns>
    ///=====================================================================
    public static string GetArrCookiesString(string sGrpNm, string sKeyNm)
    {
        return GetArrCookiesString(sGrpNm, sKeyNm, "");
    }

    /// <summary>
    /// Get Cookies String
    /// </summary>
    /// <param name="cookies">HttpCookieCollection</param>
    /// <param name="sCkNm">Cookie name</param>
    /// <returns></returns>
    public static string CookiesString(HttpCookieCollection cookies, string sCkNm)
    {
        return CookiesString(cookies, sCkNm, "");
    }

    /// <summary>
    /// Get Cookie String
    /// </summary>
    /// <param name="cookies"></param>
    /// <param name="sCkNm">HttpCookieCollection</param>
    /// <param name="sDefault">default return value</param>
    /// <returns></returns>
    public static string CookiesString(HttpCookieCollection cookies, string sCkNm, string sDefault)
    {
        HttpCookie cookie = cookies[sCkNm];

        return cookie == null ? sDefault : cookie.Value;
    }

    /// <summary>
    /// 2 array cookies string
    /// </summary>
    /// <param name="cookies">HttpCookieCollection</param>
    /// <param name="sCkNm1">1</param>
    /// <param name="sCkNm2">2</param>
    /// <returns></returns>
    public static string CookiesString2(HttpCookieCollection cookies, string sCkNm1, string sCkNm2)
    {
        return CookiesString2(cookies, sCkNm1, sCkNm2, "").Replace(" ", "+");
    }

    /// <summary>
    /// 2 array cookies string
    /// </summary>
    /// <param name="cookies">HttpCookieCollection</param>
    /// <param name="sCkNm1">1</param>
    /// <param name="sCkNm2">2</param>
    /// <param name="sDefault">default return value</param>
    /// <returns></returns>
    public static string CookiesString2(HttpCookieCollection cookies, string sCkNm1, string sCkNm2, string sDefault)
    {
        HttpCookie cookie = cookies[sCkNm1];
        sCkNm2 = sCkNm2.Replace("_", "%5F").ToString();
        string sCkValue = sDefault;

        if ((cookie != null) && (cookie[sCkNm2] != null))
            sCkValue = HttpUtility.UrlDecode(cookie[sCkNm2].ToString());

        return sCkValue;
    }

    //==========================================================================
    // 작 성 : 김동완(2007-04-06)
    // 용 도 : 메시지박스를 띄운 후, 확인을 누르면 해당 자바스크립트를 사용한다.
    // 인 수 : string 메시지, string 자바스크립트
    // 리 턴 : 없음
    //==========================================================================
    public static void MsgBox(string sMsg, string sAction)
    {
        HttpResponse hr = HttpContext.Current.Response;
        hr.Write("<script language='javascript' type='text/javascript'>");
        hr.Write("alert('" + sMsg.Replace("'", @"\'") + "'); ");
        hr.Write(sAction);
        hr.Write("</script>");
    }

    //==========================================================================
    // 작 성 : 김동완(2007-04-06)
    // 용 도 : 메시지박스를 띄운다.
    // 인 수 : string 메시지
    // 리 턴 : 없음
    //==========================================================================
    public static void MsgBox(string sMsg)
    {
        HttpResponse hr = HttpContext.Current.Response;
        hr.Write("<script language='javascript' type='text/javascript'>");
        hr.Write("alert('" + sMsg.Replace("'", @"\'") + "'); ");
        hr.Write("</script>");
    }

    //==========================================================================
    /// <summary>
    /// 에러 발생시 결과 출력 후 종료
    /// </summary>
    /// <param name="e"></param>
    //==========================================================================
    public static void ErrorLogMsg(object e)
    {
        HttpResponse response = HttpContext.Current.Response;

        response.Write("(" + e.ToString().Replace("\n", "<br />") + ")");
    }

    ///=====================================================================
    /// <summary>
    /// 데이터 아이템
    /// </summary>
    /// <param name="objData"></param>
    /// <param name="sFieldNm"></param>
    /// <returns></returns>
    ///=====================================================================
    public static string GetDataItem(object objData, string sFieldNm)
    {
        object objTmpData = null;
        string sRtnStr = "";

        sRtnStr = ((objTmpData = DataBinder.Eval(objData, sFieldNm)) == DBNull.Value) ? "" : Convert.ToString(objTmpData);
        return sRtnStr;
    }

    public static string Base64Decode(string sStr)
    {
        byte[] decbuff = Convert.FromBase64String(sStr);

        return Encoding.UTF8.GetString(decbuff);
    }

    public static string GetIpAddress()
    {
        string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
        if (String.IsNullOrEmpty(ipAddress))
        {
            ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Current.Request.UserHostAddress;
            }
        }
        return ipAddress;
    }
}
