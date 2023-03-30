using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// LogUtil의 요약 설명입니다.
/// </summary>
public static class LogUtil
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static member functions

	public static void Log(string sMessage)
	{
		Log(sMessage, false);
	}

	public static void Log(string sMessage, bool bStackTrace)
	{
		try
		{
			DateTime dtNow = DateTime.Now;

			//
			// 로그 내용
			//

			StringBuilder sb = new StringBuilder();
			sb.Append("-------------------------------------------------------------------------------------");

			sb.Append(Environment.NewLine);
			sb.AppendFormat("[{0}]", DateTimeUtil.ToDateTimeString(dtNow));

			sb.Append(Environment.NewLine);
			sb.Append(sMessage);

			if (bStackTrace)
			{
				StackTrace stackTrace = new StackTrace(true);

				sb.Append(Environment.NewLine);
				sb.Append("# StackTrace");
				sb.Append(Environment.NewLine);
				sb.Append(stackTrace.ToString());
			}

			sb.Append(Environment.NewLine);
			sb.Append(Environment.NewLine);

			//
			// 로그 파일에 기록
			//

			string sDir = HttpContext.Current.Server.MapPath("/Error");
			Directory.CreateDirectory(sDir);

			string sSuffix = dtNow.ToString("yyyyMMdd");
			string sFilePath = sDir + "/Log_" + sSuffix + ".txt";

			using (StreamWriter writer = new StreamWriter(sFilePath, true, Encoding.UTF8))
			{
				writer.Write(sb.ToString());
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Log(Exception ex)
	{
		if (ex == null)
			return;

		if (ex is CommandHandlerException)
		{
			if (!((CommandHandlerException)ex).loggingEnabled)
				return;
		}

		Log(Util.ToString(ex));
	}

	public static void Log(SqlCommand cmd)
	{
		if (cmd == null)
			return;

		try
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat("# CommandType : {0}", cmd.CommandType);

			sb.Append(Environment.NewLine);
			sb.AppendFormat("# CommandText : {0}", cmd.CommandText);

			sb.Append(Environment.NewLine);
			sb.AppendFormat("# Parameters : {0}", cmd.Parameters.Count);

			foreach (SqlParameter param in cmd.Parameters)
			{
				sb.Append(Environment.NewLine);
				sb.Append("{");

				sb.Append(Environment.NewLine);
				sb.AppendFormat("  Name : {0}", param.ParameterName);

				sb.Append(Environment.NewLine);
				sb.AppendFormat("  Type : {0}", param.SqlDbType);

				sb.Append(Environment.NewLine);
				sb.AppendFormat("  Size : {0}", param.Size);

				sb.Append(Environment.NewLine);
				sb.AppendFormat("  Direction : {0}", param.Direction);

				sb.Append(Environment.NewLine);
				sb.AppendFormat("  Value : {0}", param.Value);

				sb.Append(Environment.NewLine);
				sb.Append("}");
			}

			Log(sb.ToString(), true);
		}
		catch (Exception)
		{
		}
	}
}