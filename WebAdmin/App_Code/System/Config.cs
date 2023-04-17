using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Config의 요약 설명입니다.
/// </summary>
public static class Config
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Static properties

    public static ConnectionStringSettings flyffUserConnectionStringSettings
    {
        get { return ConfigurationManager.ConnectionStrings["User"]; }
    }

	public static string hashKey
	{
		get { return ConfigurationManager.AppSettings["HashKey"]; }
	}

	public static string Users
	{
		get { return ConfigurationManager.AppSettings["USER"]; }
	}

	public static string Languages
	{
		get { return ConfigurationManager.AppSettings["Languages"]; }
	}
    public static string InternalIp
    {
		get { return ConfigurationManager.AppSettings["INTERNAL_IP"]; }
	}
}