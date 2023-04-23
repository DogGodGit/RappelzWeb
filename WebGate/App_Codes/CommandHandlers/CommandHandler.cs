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
			case "StageFarmVersion": handler = new StageFarmVersionCommandHandler(); break;
			
		}

		if (handler == null)
			throw new CommandHandlerException(sReqJson, kResult_Error, "커맨드가 존재하지 않습니다.");

		JsonData joRes = handler.Handle(joReq);

		HttpContext.Current.Response.Clear();
		Util.WriteResponse(joRes);
	}
}
