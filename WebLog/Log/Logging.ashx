<%@ WebHandler Language="C#" Class="Logging" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using LitJson;

public class Logging : IHttpHandler 
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants
	private const int kResult_OK = 1;
	private const int kResult_Error = 0;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables
	private HttpRequest m_Req;
	private int m_nServiceId = 0;
	private string m_sAppId = "";
	private string m_sUdid = "";
	private string m_sBrand = "";
	private string m_sModel = "";
	private string m_sOsName = "";
	private string m_sOsVersion = "";
	private string m_sVersion = "";
	private string m_sVersionCode = "";
	private string m_sLanguage = "";
	private string m_sCountry = "";
	private string m_sCpuUsage = "";
	private string m_sFreeMemory = "";
	private string m_sContent = "";
	private string m_sIpAddress = "";
		
    public void ProcessRequest (HttpContext context) {
		SqlConnection conn = null;

		try
		{
			m_Req = context.Request;

			//===============================================================================================
			// 파라미터
			//===============================================================================================
			m_nServiceId = ComUtil.GetRequestInt("serviceId", RequestMethod.Post, 0);
			m_sAppId = ComUtil.GetRequestString("appId", RequestMethod.Post, "");
			m_sUdid = ComUtil.GetRequestString("udid", RequestMethod.Post, "");
			m_sBrand = ComUtil.GetRequestString("brand", RequestMethod.Post, "");
			m_sModel = ComUtil.GetRequestString("model", RequestMethod.Post, "");
			m_sOsName = ComUtil.GetRequestString("osName", RequestMethod.Post, "");
			m_sOsVersion = ComUtil.GetRequestString("osVersion", RequestMethod.Post, "");
			m_sVersion = ComUtil.GetRequestString("version", RequestMethod.Post, "");
			m_sVersionCode = ComUtil.GetRequestString("versionCode", RequestMethod.Post, "");
			m_sLanguage = ComUtil.GetRequestString("language", RequestMethod.Post, "");
			m_sCountry = ComUtil.GetRequestString("country", RequestMethod.Post, "");
			m_sCpuUsage = ComUtil.GetRequestString("cpuUsage", RequestMethod.Post, "");
			m_sFreeMemory = ComUtil.GetRequestString("freeMemory", RequestMethod.Post, "");
			m_sContent = ComUtil.GetRequestString("content", RequestMethod.Post, "");
			m_sIpAddress = ComUtil.GetIpAddress();
			
			//===============================================================================================
			// DB 연결
			//===============================================================================================
			conn = DBUtil.GetLogConnection();
			conn.Open();

			//===============================================================================================
			// 로깅
			//===============================================================================================
			int nRet = Dac.AddLog(conn, null, m_nServiceId, m_sAppId, m_sUdid, m_sBrand, m_sModel, m_sOsName, m_sOsVersion, m_sVersion, m_sVersionCode, m_sLanguage, m_sCountry, m_sCpuUsage, m_sFreeMemory, m_sContent, m_sIpAddress);
			
			//===============================================================================================
			// DB 연결 해제
			//===============================================================================================
			DBUtil.Close(ref conn);

			if (nRet == 0)
				WriteResponse(kResult_OK);
			else
				WriteResponse(kResult_Error, "logging failed.");
		}
        catch (Exception ex)
        {
			LogUtil.Log(Util.ToString(ex));
			
            DBUtil.Close(ref conn);
			
            WriteResponse(kResult_Error, ex);
        }
	}

	private void WriteResponse(int nResult)
	{
		Util.WriteResponse(CreateResponse(nResult, "success"));
	}

	private void WriteResponse(int nResult, string sResult)
	{
		Util.WriteResponse(CreateResponse(nResult, sResult));
	}

	private void WriteResponse(int nResult, Exception ex)
	{
		LogUtil.Log(Util.ToString(ex));

		Util.WriteResponse(CreateResponse(nResult, ex.Message));
	}

	private JsonData CreateResponse(int nResult, string sErrorMessage)
	{
		JsonData joRes = LitJsonUtil.CreateObject();
		joRes["result"] = nResult;
		joRes["error"] = sErrorMessage;

		return joRes;
	}
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}