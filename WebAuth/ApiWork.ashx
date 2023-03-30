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
			
			int nLanguageId = 22;
            
			if(context.Request.QueryString["CD"] != null)
                sCode = context.Request.QueryString["CD"].ToString();

            switch (sCode)
            {
				case "CreateGuestUser": sReq = CreateRequest_CreateGuestUser(); break;
				case "CreateFacebookUser": sReq = CreateRequest_CreateFacebookUser("TestFacebookApp1", "TestFacebookUser1"); break;
				case "CreateGoogleUser": sReq = CreateRequest_CreateGoogleUser("TestGoogleUser1"); break;
				case "CreateEntermateUser": sReq = CreateRequest_CreateEntermateUser("7420940", "c040566a6a8abe7028999e5795923e5154a660af331371e358786ef8c64ef74e"); break;
				case "Login": sReq = CreateRequest_Login("cb26888d-bed2-4655-8a3e-c885119be0e9", "z0nq9txytlrjg3rmygm2", nLanguageId); break;
				
				case "GameAssetBundles": sReq = CreateRequest_GameAssetBundles(); break;
				case "SystemSetting": sReq = CreateRequest_SystemSetting(); break;
				case "GameServers": sReq = CreateRequest_GameServers(); break;
				case "UserGameServers": sReq = CreateRequest_UserGameServers("{\"userId\":\"a0640c7e-256d-4fcb-9d64-2ba588109f5a\",\"accessSecret\":\"01vvj4onlww8owc1g323\",\"checkCode\":\"a92ba4989b2e9257059b7449575a5d48\"}"); break;
				
				case "ClientTextMetaDataCreate": sReq = CreateRequest_ClientTextMetaDataCreate(); break;
				case "ClientTextMetaDatas": sReq = CreateRequest_ClientTextMetaDatas(); break;
	
				case "GameMetaDataCreate":sReq = CreateRequest_GameMetaDataCreate(); break;
				case "GameMetaDatas": sReq = CreateRequest_GameMetaDatas(); break;
				default: 
					break;
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

	public string CreateRequest_GameMetaDatas()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "GameMetaDatas";

		return joReq.ToJson();
	}

	public string CreateRequest_GameMetaDataCreate()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "GameMetaDataCreate";
		joReq["version"] = "0";

		return joReq.ToJson();
	}

	public string CreateRequest_ClientTextMetaDatas()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "ClientTextMetaDatas";
		joReq["languageId"] = 11;

		return joReq.ToJson();
	}

	public string CreateRequest_ClientTextMetaDataCreate()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "ClientTextMetaDataCreate";
		joReq["version"] = "0";

		return joReq.ToJson();
	}

	public string CreateRequest_UserGameServers(string sUserAccessToken)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "UserGameServers";
		joReq["userAccessToken"] = sUserAccessToken;
		return joReq.ToJson();
	}

	public string CreateRequest_GameDatas()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "GameDatas";
		return joReq.ToJson();
	}

	public string CreateRequest_SystemSetting()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "SystemSetting";
		return joReq.ToJson();
	}

	public string CreateRequest_GameServers()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "GameServers";
		return joReq.ToJson();
	}
	
	public string CreateRequest_GameAssetBundles()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "GameAssetBundles";
		return joReq.ToJson();
	}

	public string CreateRequest_ClientTexts(int nLanguageId)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "ClientTexts";
		joReq["languageId"] = nLanguageId;
		return joReq.ToJson();
	}

	public string CreateRequest_CreateEntermateUser(string sUserId, string sPrivateKey)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "CreateEntermateUser";
		joReq["entermateUserId"] = sUserId;
		joReq["entermatePrivateKey"] = sPrivateKey;
		return joReq.ToJson();
	}

	public string CreateRequest_CreateFacebookUser(string sFacebookAppId, string sFacebookUserId)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "CreateFacebookUser";
		joReq["facebookAppId"] = sFacebookAppId;
		joReq["facebookUserId"] = sFacebookUserId;

		return joReq.ToJson();
	}

	public string CreateRequest_CreateGoogleUser(string sGoogleUserId)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "CreateGoogleUser";
		joReq["googleUserId"] = sGoogleUserId;

		return joReq.ToJson();
	}

	public string CreateRequest_Login(string sUserId, string sUserSecret, int nLanguageId)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "Login";
		joReq["userId"] = sUserId;
		joReq["userSecret"] = sUserSecret;
		joReq["languageId"] = nLanguageId;

		return joReq.ToJson();
	}

	public string CreateRequest_CreateGuestUser()
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"]	= "CreateGuestUser";

		return joReq.ToJson();
	}
}
