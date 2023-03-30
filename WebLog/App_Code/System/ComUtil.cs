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

    ///=========================================================================
    /// <summary>
    /// 브라우저 노캐쉬
    /// </summary>
    ///=========================================================================
    public static void SetNoBrowserCache()
    {
        HttpResponse hr = HttpContext.Current.Response;

        hr.Cache.SetCacheability(HttpCacheability.Private);
        hr.Cache.SetExpires(DateTime.MinValue);
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

	public static string GetIpAddress()
	{
		string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CF_CONNECTING_IP"];
		if (String.IsNullOrEmpty(ipAddress))
		{
			ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
			if (String.IsNullOrEmpty(ipAddress))
			{
				ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
				if (String.IsNullOrEmpty(ipAddress))
				{
					ipAddress = HttpContext.Current.Request.UserHostAddress;
				}
			}
		}
		return ipAddress;
	}
}
