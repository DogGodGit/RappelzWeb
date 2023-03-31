using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// DBUtil'的摘要描述.
/// </summary>
public static class DBUtil
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Static member functions

    public static void Close(ref SqlConnection conn)
    {
        if (conn == null)
            return;

        conn.Close();
        conn = null;
    }

    public static void Commit(ref SqlTransaction trans)
    {
        if (trans == null)
            return;

        trans.Commit();
        trans = null;
    }

    public static SqlConnection GetConnection(ConnectionStringSettings settings)
    {
        if (settings == null)
            return null;

        return new SqlConnection(settings.ConnectionString);
    }

    public static SqlConnection GetLogConnection()
    {
        return GetConnection(Config.logConnectionStringSettings);
    }

    public static void Rollback(ref SqlTransaction trans)
    {
        if (trans == null)
            return;

        trans.Rollback();
        trans = null;
    }

    public static string EscapeSingleQuote(string sValue)
    {
        return sValue == null ? null : sValue.Replace("'", "''");
    }

    public static object NullToDBNull(object value)
    {
        return value == null ? DBNull.Value : value;
    }

    //
    // DB 데이터 캐스팅 함수
    // DBNull인 경우 기본값을 반환한다.
    //

    public static T Convert<T>(object value)
    {
        return Convert<T>(value, default(T));
    }

    public static T Convert<T>(object value, T valueForDBNull)
    {
        return value == DBNull.Value ? valueForDBNull : (T)value;
    }
}
