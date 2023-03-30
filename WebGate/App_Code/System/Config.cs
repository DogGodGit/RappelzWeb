using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Config의 요약 설명입니다.
/// </summary>
public class Config
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static properties

	public static ConnectionStringSettings gateConnectionStringSettings
	{
		get { return ConfigurationManager.ConnectionStrings["Gate"]; }
	}

	public static string aesKey
	{
		get { return ConfigurationManager.AppSettings["AesKey"]; }
	}
}