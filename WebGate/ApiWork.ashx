<%@ WebHandler Language="C#" Class="ApiWork" %>

using System;
using System.IO;
using System.Web;

using LitJson;

public class ApiWork : IHttpHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Properties
	
	public bool IsReusable
	{
		get { return false; }
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions
	
	public void ProcessRequest(HttpContext context)
	{
		try
		{
			string sReq = null;

            string sCode = "";
            
            if(context.Request.QueryString["CD"] != null)
                sCode = context.Request.QueryString["CD"].ToString();

            switch (sCode)
            {
				case "StageFarmVersion": sReq = CreateRequest_StageFarmVersion(1, "1.0.0", 1); break;
                
				default: break;
            }
            
			CommandHandler.Process(sReq);
		}
		catch (CommandHandlerException cmdHandlerEx)
		{
			LogUtil.Log(cmdHandlerEx);

			context.Response.Clear();
			CommandHandler.WriteResponse(cmdHandlerEx.result, cmdHandlerEx.Message);
		}
		catch (Exception ex)
		{
			LogUtil.Log(ex);

			context.Response.Clear();
			CommandHandler.WriteResponse(CommandHandler.kResult_Error, ex.Message);
		}
	}
	
	//
	// 유틸리티
	//
		
	public string CreateRequest_StageFarmVersion(int nPlatformId, string sVersionName, int nBuildNo)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "StageFarmVersion";
		joReq["platformId"] = nPlatformId;
		joReq["versionName"] = sVersionName;
		joReq["buildNo"] = nBuildNo;
		
		return joReq.ToJson();
	}

    //public string CreateRequest_UpdateLastGameServerId(string sAccessToken, int nGameServerId)
    //{
    //    JsonData joReq = LitJsonUtil.CreateObject();
    //    joReq["cmd"] = "UpdateLastGameServerId";
    //    joReq["accessToken"] = sAccessToken;
    //    joReq["gameServerId"] = nGameServerId;

    //    return joReq.ToJson();
    //}
}
