using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Config'的摘要描述.
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