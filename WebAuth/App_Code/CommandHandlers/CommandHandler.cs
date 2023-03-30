using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// CommandHandler의 요약 설명입니다.
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
			throw new ArgumentException("JsonData 인스턴스가 Object형식이 아닙니다.");

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
		JsonData joReq = null;

		try
		{
			joReq = JsonMapper.ToObject(sReqJson);
		}
		catch (Exception ex)
		{
			throw new CommandHandlerException(sReqJson, kResult_Error, "유효한 Json형식이 아닙니다.", ex);
		}

		if (!joReq.IsObject)
			throw new CommandHandlerException(sReqJson, kResult_Error, "프로토콜 오류입니다.");

		//
		// 커맨드
		//

		string sCmd = null;

		if (!LitJsonUtil.TryGetStringProperty(joReq, "cmd", out sCmd))
			throw new CommandHandlerException(sReqJson, kResult_Error, "'cmd' 프로퍼티가 유효하지 않습니다.");

		if (string.IsNullOrEmpty(sCmd))
			throw new CommandHandlerException(sReqJson, kResult_Error, "'cmd' 프로퍼티가 유효하지 않습니다.");

		//
		// 커맨드 처리.
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
			throw new CommandHandlerException(sReqJson, kResult_Error, "커맨드가 존재하지 않습니다.");

		JsonData joRes = handler.Handle(joReq);

		HttpContext.Current.Response.Clear();

		Util.WriteResponse(joRes);
	}
}