<%@ WebHandler Language="C#" Class="Api" %>

using System;
using System.IO;
using System.Web;

public class Api : IHttpHandler {

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
			using (StreamReader reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
			{
				CommandHandler.Process(reader.ReadToEnd());
			}
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

}