using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Config'的摘要描述.
/// </summary>
public static class Config
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static properties

	public static ConnectionStringSettings rappelzUserConnectionString
	{
		get { return ConfigurationManager.ConnectionStrings["User"]; }
	}

	public static string hashKey
	{
		get { return ConfigurationManager.AppSettings["HashKey"]; }
	}

	public static string aesKey
	{
		get { return ConfigurationManager.AppSettings["AesKey"]; }
	}
}
