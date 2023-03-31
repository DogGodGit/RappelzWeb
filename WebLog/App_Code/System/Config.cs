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

    public static ConnectionStringSettings logConnectionStringSettings
    {
        get { return ConfigurationManager.ConnectionStrings["Log"]; }
    }
}
