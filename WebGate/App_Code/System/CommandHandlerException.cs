using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CommandHandlerException의 요약 설명입니다.
/// </summary>
public class CommandHandlerException : Exception
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private string m_sReqJson = null;
	private CommandHandler m_handler = null;
	private int m_nResult = 0;

	private bool m_bLoggingEnabled = true;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Properties

	public string reqJson
	{
		get { return m_sReqJson; }
	}

	public CommandHandler handler
	{
		get { return m_handler; }
	}

	public int result
	{
		get { return m_nResult; }
	}

	public bool loggingEnabled
	{
		get { return m_bLoggingEnabled; }
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constructors

	//
	//
	//

	public CommandHandlerException(string sReqJson, int nResult, string sMessage)
		: this(sReqJson, nResult, sMessage, null)
	{
	}

	public CommandHandlerException(string sReqJson, int nResult, string sMessage, Exception innerException)
		: this(sReqJson, nResult, sMessage, innerException, true)
	{
	}

	public CommandHandlerException(string sReqJson, int nResult, string sMessage, Exception innerException, bool bLoggingEnabled)
		: this(sReqJson, null, nResult, sMessage, innerException, bLoggingEnabled)
	{
	}

	//
	//
	//

	public CommandHandlerException(CommandHandler handler, int nResult, string sMessage)
		: this(handler, nResult, sMessage, null)
	{
	}

	public CommandHandlerException(CommandHandler handler, int nResult, string sMessage, Exception innerException)
		: this(handler, nResult, sMessage, innerException, true)
	{
	}

	public CommandHandlerException(CommandHandler handler, int nResult, string sMessage, Exception innerException, bool bLoggingEnabled)
		: this(null, handler, nResult, sMessage, innerException, bLoggingEnabled)
	{
	}

	//
	//
	//

	public CommandHandlerException(string sReqJson, CommandHandler handler, int nResult, string sMessage)
		: this(sReqJson, handler, nResult, sMessage, null)
	{
	}

	public CommandHandlerException(string sReqJson, CommandHandler handler, int nResult, string sMessage, Exception innerException)
		: this(sReqJson, handler, nResult, sMessage, innerException, true)
	{
	}

	public CommandHandlerException(string sReqJson, CommandHandler handler, int nResult, string sMessage, Exception innerException, bool bLoggingEnabled)
		: base(sMessage, innerException)
	{
		m_sReqJson = sReqJson;
		m_handler = handler;
		m_nResult = nResult;
		m_bLoggingEnabled = bLoggingEnabled;
	}
}
