using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

/// <summary>
/// DBUtil의 요약 설명입니다.
/// </summary>
public class DBUtil
{
	public DBUtil() {}

    ///=====================================================================
    /// <summary>
    /// Log DB 연결
    /// </summary>
    /// <returns>
    /// SqlConnection	: (오픈된) 연결객체
    /// null			: 연결 또는 오픈 실패시
    /// </returns>
    ///=====================================================================

    public static SqlConnection GetUserDBConn()
    {
        SqlConnection scConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["USER"].ConnectionString);
        scConn.Open();
        return scConn;
    }

    public static SqlConnection GetGameDBConn(string sConnectionString)
    {
        SqlConnection scConn = new SqlConnection(sConnectionString);
        scConn.Open();
        return scConn;
    }

	public static SqlConnection GetGameDBConn(int nServerId)
	{
	    // DB연결
	    SqlConnection conn = DBUtil.GetUserDBConn();

	    // 서버목록 조회
	    DataRow drGameServer = DacUser.GameServer(conn, null, nServerId);

	    // DB연결 해제
	    DBUtil.CloseDBConn(conn);

		if (drGameServer == null)
			return null;

		return GetGameDBConn(drGameServer["gameDBConnection"].ToString());
	}

    //==========================================================================
    /// <summary>
    /// DB 연결 해제
    /// </summary>
    /// <param name="scConn">연결객체</param>
    //==========================================================================    
    public static void CloseDBConn(SqlConnection scConn)
    {
        try
        {
            scConn.Close();
            scConn.Dispose();
            scConn = null;
        }
        catch { }
    }
}