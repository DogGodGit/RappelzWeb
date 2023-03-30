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

    public static ConnectionStringSettings logConnectionStringSettings
    {
        get { return ConfigurationManager.ConnectionStrings["Log"]; }
    }
}
