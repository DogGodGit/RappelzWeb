using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// CommandHandler'的摘要描述.
/// </summary>
public abstract class CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Results

	public const int kResult_OK = 0;
	public const int kResult_Error = 1;
	public const int kResult_InvalidAccessToken = 2;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	public const string kFileName_MetaDataPath = "/MetaData";
	public const string kFileName_ClientText = "ClientText_{0}_{1}.compress";
	public const string kFileName_GameData = "GameData_{0}.compress";

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	protected JsonData m_joReq = null;
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Properties

	public virtual JsonData requestJson
	{
		get { return m_joReq; }
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	public JsonData Handle(JsonData joReq)
	{
		if (joReq == null)
			throw new ArgumentNullException("joReq");

		if (!joReq.IsObject)
			throw new ArgumentException(Resources.Message.Exception001);

        m_joReq = joReq;

		Parse();

		return HandleCommand();
	}

	protected virtual void Parse()
	{
	}

	protected abstract JsonData HandleCommand();

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static member functions

	public static JsonData CreateResponse()
	{
		return CreateResponse(CommandHandler.kResult_OK, null);
	}

	public static JsonData CreateResponse(int nResult)
	{
		return CreateResponse(nResult, null);
	}

	public static JsonData CreateResponse(int nResult, string sErrorMessage)
	{
		JsonData joRes = LitJsonUtil.CreateObject();
		joRes["result"] = nResult;

		if (sErrorMessage != null)
			joRes["errMsg"] = sErrorMessage;

		return joRes;
	}

	public static void WriteResponse(int nResult)
	{
		WriteResponse(nResult, null);
	}

	public static void WriteResponse(int nResult, string sErrorMessage)
	{
		Util.WriteResponse(CreateResponse(nResult, sErrorMessage));
	}

	public static void Process(string sReqJson)
	{
		JsonData joReq;
		try
		{
			joReq = JsonMapper.ToObject(sReqJson);
		}
		catch (Exception ex)
		{
			throw new CommandHandlerException(sReqJson, kResult_Error, Resources.Message.Exception002, ex);
		}

		if (!joReq.IsObject)
			throw new CommandHandlerException(sReqJson, kResult_Error, Resources.Message.Exception003);

		//
		// 命令
		//

		string sCmd;
		if (!LitJsonUtil.TryGetStringProperty(joReq, "cmd", out sCmd))
			throw new CommandHandlerException(sReqJson, kResult_Error, string.Format(Resources.Message.Exception006, "cmd"));

		if (string.IsNullOrEmpty(sCmd))
			throw new CommandHandlerException(sReqJson, kResult_Error, string.Format(Resources.Message.Exception006, "cmd"));

        //
        // 命令处理
        //

        CommandHandler handler = null;

		switch (sCmd)
		{
			case "CreateGuestUser": handler = new CreateGuestUserCommandHandler(); break;
			case "CreateFacebookUser": handler = new CreateFacebookUserCommandHandler(); break;
			case "CreateGoogleUser": handler = new CreateGoogleUserCommandHandler(); break;
			case "CreateEntermateUser": handler = new CreateEntermateUserCommandHandler(); break;
			case "Login": handler = new LoginCommandHandler(); break;
			case "GameAssetBundles": handler = new GameAssetBundlesCommandHandler(); break;
			case "GameServers": handler = new GameServersCommandHandler(); break;
			case "SystemSetting": handler = new SystemSettingCommandHandler(); break;
			case "SupportedLanguages": handler = new SupportedLanguagesCommandHandler(); break;
			case "UserHeros": handler = new UserHerosCommandHandler(); break;
			case "ClientTextMetaDataCreate": handler = new ClientTextMetaDataCreateCommandHandler(); break;
			case "GameMetaDataCreate": handler = new GameMetaDataCreateCommandHandler(); break;
			case "ClientTextMetaDatas": handler = new ClientTextMetaDatasCommandHandler(); break;
			case "GameMetaDatas": handler = new GameMetaDatasCommandHandler(); break;
			case "Announcements": handler = new AnnouncementsCommandHandler(); break;
			case "Purchase": handler = new PurchaseCommandHandler(); break;
			case "PurchaseExceptionalLog": handler = new PurchaseExceptionalLogCommandHandler(); break;
			default : break;
		}

		if (handler == null)
			throw new CommandHandlerException(sReqJson, kResult_Error, Resources.Message.Exception005);

		JsonData joRes = handler.Handle(joReq);

		HttpContext.Current.Response.Clear();

		Util.WriteResponse(joRes);
	}
}