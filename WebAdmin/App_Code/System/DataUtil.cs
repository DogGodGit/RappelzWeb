using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataUtil
/// </summary>
public class DataUtil
{
    public DataUtil()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetGameServerConnectionString(int nGameServerId)
    {
        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 서버목록 조회
        DataTable drcGameServers = DacUser.GameServerAll(conn, null);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        DataRowCollection drcGameServer = drcGameServers.Rows;
        for (int i = 0; i < drcGameServer.Count; i++)
            if (Convert.ToInt32(drcGameServer[i]["serverId"]) == nGameServerId)
                return drcGameServer[i]["gameDBConnection"].ToString();
        return null;
    }

    internal static List<GearAttr> GetGearOptionAttr(int nGearOptionAttrCount, DataTable dtGearOptionAttrGrades)
    {
        throw new NotImplementedException();
    }
}