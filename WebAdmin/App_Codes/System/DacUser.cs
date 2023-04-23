using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DacUser
/// </summary>
public class DacUser
{
    public DacUser() {}

	public static DataTable GetUserList(SqlConnection conn, SqlTransaction trans, string sUserId, int nRowsPerPage, int nPage, out int nTotalCount)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UserSearch";
			sc.Parameters.Clear();
			sc.Parameters.Add("@sUserId", SqlDbType.VarChar, 36).Value = sUserId;
			sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
			sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
			sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

			return dt;
		}
		catch (Exception ex)
		{
			nTotalCount = 0;
			return null;
		}
	}

	public static int AddUser(SqlConnection conn, SqlTransaction trans, Guid userId, int nType, string sSecret, string sAccessSecret)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddUser";
			sc.Parameters.Clear();
			sc.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;
			sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
			sc.Parameters.Add("@sSecret", SqlDbType.VarChar, sSecret.Length).Value = sSecret;
			sc.Parameters.Add("@sAccessSecret", SqlDbType.VarChar, sAccessSecret.Length).Value = sAccessSecret;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int AddGuestUser(SqlConnection conn, SqlTransaction trans, Guid userId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddGuestUser";
			sc.Parameters.Clear();
			sc.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataRow SystemSetting(SqlConnection conn, SqlTransaction trans)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_SystemSetting";

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static int UpdateSystemSetting(SqlConnection conn, SqlTransaction trans, string sAssetBundleUrl, string sTermsOfServiceUrl, string sPrivacyPolicyUrl,
		string sClientVersion, int nClientTextVersion, int nMetaDataVersion, bool isMaintenance, string sMaintenanceInfoUrl,
        int nRecommendGameServerId, string sAuthApiUrl, string sLoggingUrl, string sStatusLoggingUrl, bool loggingEnabled,
        string sHeroNameRegex, string sGuildNameRegex, int nDefaultLanguageId, bool recommendServerAuto, int nRecommendServerConditionType, int nMaxUserConnectionCount, int nStatusLoggingInterval,
        string sGooglePublicKey, bool bHelpshiftSdkEnabled, bool bHelpshiftWebViewEnabled, string sHelpshiftUrl, string sAppStoreId, string sAuthUrl, string sCsUrl, string sHomepageUrl)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateSystemSetting";
			sc.Parameters.Clear();
			sc.Parameters.Add("@sAssetBundleUrl", SqlDbType.VarChar, 200).Value = sAssetBundleUrl;
			sc.Parameters.Add("@sTermsOfServiceUrl", SqlDbType.VarChar, 200).Value = sTermsOfServiceUrl;
			sc.Parameters.Add("@sPrivacyPolicyUrl", SqlDbType.VarChar, 200).Value = sPrivacyPolicyUrl;
			sc.Parameters.Add("@sClientVersion", SqlDbType.VarChar, 12).Value = sClientVersion;
			sc.Parameters.Add("@nClientTextVersion", SqlDbType.Int).Value = nClientTextVersion;
			sc.Parameters.Add("@nMetaDataVersion", SqlDbType.Int).Value = nMetaDataVersion;
			sc.Parameters.Add("@isMaintenance", SqlDbType.Bit).Value = isMaintenance;
			sc.Parameters.Add("@sMaintenanceInfoUrl", SqlDbType.VarChar, 200).Value = sMaintenanceInfoUrl;
			sc.Parameters.Add("@nRecommendGameServerId", SqlDbType.Int).Value = nRecommendGameServerId;
			sc.Parameters.Add("@sAuthApiUrl", SqlDbType.VarChar, 200).Value = sAuthApiUrl;
			sc.Parameters.Add("@sLoggingUrl", SqlDbType.VarChar, 200).Value = sLoggingUrl;
            sc.Parameters.Add("@sStatusLoggingUrl", SqlDbType.VarChar, 200).Value = sStatusLoggingUrl;
			sc.Parameters.Add("@loggingEnabled", SqlDbType.Bit).Value = loggingEnabled;
			sc.Parameters.Add("@sHeroNameRegex", SqlDbType.NVarChar, 100).Value = sHeroNameRegex;
			sc.Parameters.Add("@sGuildNameRegex", SqlDbType.NVarChar, 100).Value = sGuildNameRegex;
			sc.Parameters.Add("@nDefaultLanguageId", SqlDbType.Int).Value = nDefaultLanguageId;
			sc.Parameters.Add("@recommendServerAuto", SqlDbType.Bit).Value = recommendServerAuto;
			sc.Parameters.Add("@nRecommendServerConditionType", SqlDbType.Int).Value = nRecommendServerConditionType;
			sc.Parameters.Add("@nMaxUserConnectionCount", SqlDbType.Int).Value = nMaxUserConnectionCount;
            sc.Parameters.Add("@nStatusLoggingInterval", SqlDbType.Int).Value = nStatusLoggingInterval;

            sc.Parameters.Add("@sGooglePublicKey", SqlDbType.NVarChar, 2000).Value = sGooglePublicKey;
            sc.Parameters.Add("@bHelpshiftSdkEnabled", SqlDbType.Bit).Value = bHelpshiftSdkEnabled;
            sc.Parameters.Add("@bHelpshiftWebViewEnabled", SqlDbType.Bit).Value = bHelpshiftWebViewEnabled;
            sc.Parameters.Add("@sHelpshiftUrl", SqlDbType.VarChar, 200).Value = sHelpshiftUrl;
            sc.Parameters.Add("@sAppStoreId", SqlDbType.VarChar, 40).Value = sAppStoreId;
            sc.Parameters.Add("@sAuthUrl", SqlDbType.VarChar, 200).Value = sAuthUrl;
            sc.Parameters.Add("@sCsUrl", SqlDbType.VarChar, 200).Value = sCsUrl;
            sc.Parameters.Add("@sHomepageUrl", SqlDbType.VarChar, 200).Value = sHomepageUrl;

			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataTable GameServerGroups(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_GameServerGroups";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

    public static int AddGameServerGroup(SqlConnection conn, SqlTransaction trans, int nGroupId, int nRegionId, int nSortNo, string sName, string sNameKey, bool recommendServerAuto, int nRecommendServerConditionType, bool accessRestriction)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddGameServerGroup";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
            sc.Parameters.Add("@nRegionId", SqlDbType.Int).Value = nRegionId;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
            sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
            sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
            sc.Parameters.Add("@recommendServerAuto", SqlDbType.Bit).Value = recommendServerAuto;
            sc.Parameters.Add("@nRecommendServerConditionType", SqlDbType.Int).Value = nRecommendServerConditionType;
            sc.Parameters.Add("@accessRestriction", SqlDbType.Bit).Value = accessRestriction;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static int UpdateGameServerGroup(SqlConnection conn, SqlTransaction trans, int nGroupId, int nRegionId, int nSortNo, string sName, string sNameKey, bool recommendServerAuto, int nRecommendServerConditionType, bool accessRestriction)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateGameServerGroup";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
            sc.Parameters.Add("@nRegionId", SqlDbType.Int).Value = nRegionId;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
            sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
            sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
            sc.Parameters.Add("@recommendServerAuto", SqlDbType.Bit).Value = recommendServerAuto;
            sc.Parameters.Add("@nRecommendServerConditionType", SqlDbType.Int).Value = nRecommendServerConditionType;
            sc.Parameters.Add("@accessRestriction", SqlDbType.Bit).Value = accessRestriction;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

	public static int DeleteGameServerGroup(SqlConnection conn, SqlTransaction trans, int nGroupId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteGameServerGroup";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataTable GameServers(SqlConnection conn, SqlTransaction trans, int nGroupId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_GameServers";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataTable GameServerAll(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_GameServerAll";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static int AddGameServer(SqlConnection conn, SqlTransaction trans, int nServerId, int nGroupId, string sApiUrl, 
		string sProxyServer, int nProxyServerPort, string sGameDBConnection, string sGameLogDBConnection)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddGameServer";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nServerId;
			sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
			sc.Parameters.Add("@sApiUrl", SqlDbType.VarChar, 200).Value = sApiUrl;
			sc.Parameters.Add("@sProxyServer", SqlDbType.VarChar, 200).Value = sProxyServer;
			sc.Parameters.Add("@nProxyServerPort", SqlDbType.Int).Value = nProxyServerPort;
			sc.Parameters.Add("@sGameDBConnection", SqlDbType.VarChar, 200).Value = sGameDBConnection;
			sc.Parameters.Add("@sGameLogDBConnection", SqlDbType.VarChar, 200).Value = sGameLogDBConnection;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
		return -99;
		}
	}

	public static int UpdateGameServer(SqlConnection conn, SqlTransaction trans, int nServerId, string sApiUrl,
        string sProxyServer, int nProxyServerPort, string sGameDBConnection, string sGameLogDBConnection, int nStatus, bool isNew, bool isMaintenance,
		bool recommendable, bool isPublic)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateGameServer";
			sc.Parameters.Clear();
            sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nServerId;
			sc.Parameters.Add("@sApiUrl", SqlDbType.VarChar, 200).Value = sApiUrl;
			sc.Parameters.Add("@sProxyServer", SqlDbType.VarChar, 200).Value = sProxyServer;
            sc.Parameters.Add("@nProxyServerPort", SqlDbType.Int).Value = nProxyServerPort;
            sc.Parameters.Add("@sGameDBConnection", SqlDbType.VarChar, 200).Value = sGameDBConnection;
            sc.Parameters.Add("@sGameLogDBConnection", SqlDbType.VarChar, 200).Value = sGameLogDBConnection;
			sc.Parameters.Add("@nStatus", SqlDbType.Int).Value = nStatus;
			sc.Parameters.Add("@isNew", SqlDbType.Bit).Value = isNew;
			sc.Parameters.Add("@isMaintenance", SqlDbType.Bit).Value = isMaintenance;
			sc.Parameters.Add("@recommendable", SqlDbType.Bit).Value = recommendable;
            sc.Parameters.Add("@isPublic", SqlDbType.Bit).Value = isPublic;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.Message);
			HttpContext.Current.Response.Write(ex.StackTrace);
			
			return -99;
		}
	}

	public static int DeleteGameServer(SqlConnection conn, SqlTransaction trans, int nServerId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteGameServer";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nServerId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataRow GameServer(SqlConnection conn, SqlTransaction trans, int nServerId)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_GameServer";
		sc.Parameters.Clear();
		sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nServerId;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static DataTable Languages(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Languages";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static int DeleteSupportedLanguages(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteSupportedLanguages";
			sc.Parameters.Clear();
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int AddSupportedLanguage(SqlConnection conn, SqlTransaction trans, int nLanguageId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddSupportedLanguage";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nLanguageId", SqlDbType.Int).Value = nLanguageId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataRow ClientText(SqlConnection conn, SqlTransaction trans, string sKey, int nLanguageId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_ClientText";
			sc.Parameters.Clear();
			sc.Parameters.Add("@sKey", SqlDbType.VarChar, 20).Value = sKey;
			sc.Parameters.Add("@nLanguageId", SqlDbType.Int).Value = nLanguageId;

			DataTable dt = new DataTable();

			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt.Rows.Count == 0 ? null : dt.Rows[0];
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataTable VirtualGameServers(SqlConnection conn, SqlTransaction trans)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_VirtualGameServers";

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt;
	}

	public static int AddVirtualGameServer(SqlConnection conn, SqlTransaction trans, int nVirtualGameServerId, int nServerId, string sDisplayName, int nDisplayNo)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddVirtualGameServer";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nVirtualGameServerId", SqlDbType.Int).Value = nVirtualGameServerId;
			sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nServerId;
			sc.Parameters.Add("@sDisplayName", SqlDbType.NVarChar, sDisplayName.Length).Value = sDisplayName;
			sc.Parameters.Add("@nDisplayNo", SqlDbType.Int).Value = nDisplayNo;

			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.ToString());
			return -99;
		}
	}

	public static int UpdateVirtualGameServer(SqlConnection conn, SqlTransaction trans, int nVirtualGameServerId, int nServerId, string sDisplayName, int nDisplayNo)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateVirtualGameServer";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nVirtualGameServerId", SqlDbType.Int).Value = nVirtualGameServerId;
			sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nServerId;
			sc.Parameters.Add("@sDisplayName", SqlDbType.NVarChar, sDisplayName.Length).Value = sDisplayName;
			sc.Parameters.Add("@nDisplayNo", SqlDbType.Int).Value = nDisplayNo;

			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.ToString());
			return -99;
		}
	}

	public static int DeleteVirtualGameServer(SqlConnection conn, SqlTransaction trans, int nVirtualGameServerId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteVirtualGameServer";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nVirtualGameServerId", SqlDbType.Int).Value = nVirtualGameServerId;

			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.ToString());
			return -99;
		}
	}

	public static DataTable WhiteIps(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_WhiteIps";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static int AddWhiteIp(SqlConnection conn, SqlTransaction trans, long lnStartIpNo, long lnEndIpNo, string sStartIp, string sEndIp, string sName)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddWhiteIp";
			sc.Parameters.Clear();
			sc.Parameters.Add("@bnStartIpNo", SqlDbType.BigInt).Value = lnStartIpNo;
			sc.Parameters.Add("@bnEndIpNo", SqlDbType.BigInt).Value = lnEndIpNo;
			sc.Parameters.Add("@sStartIp", SqlDbType.VarChar, 15).Value = sStartIp;
			sc.Parameters.Add("@sEndIp", SqlDbType.VarChar, 15).Value = sEndIp;
			sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.ToString());
			return -99;
		}
	}

	public static int DeleteWhiteIp(SqlConnection conn, SqlTransaction trans, long lnStartIpNo, long lnEndIpNo)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteWhiteIp";
			sc.Parameters.Clear();
			sc.Parameters.Add("@bnStartIpNo", SqlDbType.BigInt).Value = lnStartIpNo;
			sc.Parameters.Add("@bnEndIpNo", SqlDbType.BigInt).Value = lnEndIpNo;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataTable GameAssetBundles(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_GameAssetBundles";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static int UpdateGameAssetBundleSelected(SqlConnection conn, SqlTransaction trans, bool bAndroid, bool biOS, string sBundleNos)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateGameAssetBundleSelected";
			sc.Parameters.Clear();
			sc.Parameters.Add("@bAndroid", SqlDbType.Bit).Value = bAndroid;
			sc.Parameters.Add("@biOS", SqlDbType.Bit).Value = biOS;
			sc.Parameters.Add("@sBundlesNos", SqlDbType.VarChar, sBundleNos.Length).Value = sBundleNos;

			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.ToString());
			return -99;
		}
	}

	public static int AddGameAssetBundle(SqlConnection conn, SqlTransaction trans, int nBundleNo, string sFileName, int nAndroidVer, int niOSVer)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddGameAssetBundle";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nBundleNo", SqlDbType.Int).Value = nBundleNo;
			sc.Parameters.Add("@sFileName", SqlDbType.VarChar, 200).Value = sFileName;
			sc.Parameters.Add("@nAndroidVer", SqlDbType.Int).Value = nAndroidVer;
			sc.Parameters.Add("@niOSVer", SqlDbType.Int).Value = niOSVer;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.ToString());
			return -99;
		}
	}

	public static int UpdateGameAssetBundle(SqlConnection conn, SqlTransaction trans, int nBundleNo, string sFileName, int nAndroidVer, int niOSVer, bool bIsCommon)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateGameAssetBundle";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nBundleNo", SqlDbType.Int).Value = nBundleNo;
			sc.Parameters.Add("@sFileName", SqlDbType.VarChar, 200).Value = sFileName;
			sc.Parameters.Add("@nAndroidVer", SqlDbType.Int).Value = nAndroidVer;
			sc.Parameters.Add("@niOSVer", SqlDbType.Int).Value = niOSVer;
			sc.Parameters.Add("@bIsCommon", SqlDbType.Bit).Value = bIsCommon;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int DelGameAssetBundle(SqlConnection conn, SqlTransaction trans, int nBundleNo)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteGameAssetBundle";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nBundleNo", SqlDbType.Int).Value = nBundleNo;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataTable MainMenus(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_MainMenus";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataRow MainMenu(SqlConnection conn, SqlTransaction trans, int nMenuId)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_MainMenu";
		sc.Parameters.Clear();
		sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static int AddMainMenu(SqlConnection conn, SqlTransaction trans, int nMenuId, string sNameKey, string sPopupName)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddMainMenu";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
			sc.Parameters.Add("@sPopupName", SqlDbType.VarChar, 100).Value = sPopupName;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int UpdateMainMenu(SqlConnection conn, SqlTransaction trans, int nMenuId, string sNameKey, string sPopupName)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateMainMenu";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
			sc.Parameters.Add("@sPopupName", SqlDbType.VarChar, 100).Value = sPopupName;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int DeleteMainMenu(SqlConnection conn, SqlTransaction trans, int nMenuId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteMainMenu";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataTable SubMenus(SqlConnection conn, SqlTransaction trans, int nMenuId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_SubMenus";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static int AddSubMenu(SqlConnection conn, SqlTransaction trans, int nMenuId, int nSubMenuId, string sNameKey, string sPrefab1, string sPrefab2, string sPrefab3, int nLayout, int nSortNo, int nContentId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddSubMenu";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("@nSubMenuId", SqlDbType.Int).Value = nSubMenuId;
			sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
			sc.Parameters.Add("@sPrefab1", SqlDbType.VarChar, 100).Value = sPrefab1;
			sc.Parameters.Add("@sPrefab2", SqlDbType.VarChar, 100).Value = sPrefab2;
			sc.Parameters.Add("@sPrefab3", SqlDbType.VarChar, 100).Value = sPrefab3;
			sc.Parameters.Add("@nLayout", SqlDbType.Int).Value = nLayout;
			sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
			sc.Parameters.Add("@nContentId", SqlDbType.Int).Value = nContentId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int UpdateSubMenu(SqlConnection conn, SqlTransaction trans, int nMenuId, int nSubMenuId, string sNameKey, string sPrefab1, string sPrefab2, string sPrefab3, int nLayout, int nSortNo, int nContentId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateSubMenu";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("@nSubMenuId", SqlDbType.Int).Value = nSubMenuId;
			sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
			sc.Parameters.Add("@sPrefab1", SqlDbType.VarChar, 100).Value = sPrefab1;
			sc.Parameters.Add("@sPrefab2", SqlDbType.VarChar, 100).Value = sPrefab2;
			sc.Parameters.Add("@sPrefab3", SqlDbType.VarChar, 100).Value = sPrefab3;
			sc.Parameters.Add("@nLayout", SqlDbType.Int).Value = nLayout;
			sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
			sc.Parameters.Add("@nContentId", SqlDbType.Int).Value = nContentId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int DeleteSubMenu(SqlConnection conn, SqlTransaction trans, int nMenuId, int nSubMenuId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_DeleteSubMenu";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("@nSubMenuId", SqlDbType.Int).Value = nSubMenuId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int UpdateSubMenu_IsDefault(SqlConnection conn, SqlTransaction trans, int nMenuId, int nSubMenuId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateSubMenu_IsDefault";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMenuId", SqlDbType.Int).Value = nMenuId;
			sc.Parameters.Add("@nSubMenuId", SqlDbType.Int).Value = nSubMenuId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static DataTable Items(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Items";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

    public static DataTable Gears(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_Gears";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public static DataTable MainGears(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_MainGears";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataTable SubGears(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_SubGears";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataTable SubGearNames(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_SubGearNames";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataTable PickMainGearOptionAttrPoolEntry(SqlConnection conn, SqlTransaction trans, int nMainGearId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_PickMainGearOptionAttrPoolEntry";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nMainGearId", SqlDbType.Int).Value = nMainGearId;

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataRow GameConfig(SqlConnection conn, SqlTransaction trans)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_GameConfig";

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static DataTable Jobs(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Jobs";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public static DataRow JobLevelMaster(SqlConnection conn, SqlTransaction trans, int nLevel)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_JobLevelMaster";
		sc.Parameters.Clear();
		sc.Parameters.Add("@nLevel", SqlDbType.Int).Value = nLevel;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static DataTable MenuContents(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_MenuContents";
			sc.Parameters.Clear();

			DataTable dt = new DataTable();
			SqlDataAdapter sda = new SqlDataAdapter();
			sda.SelectCommand = sc;
			sda.Fill(dt);

			return dt;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

    public static DataTable UserGlobalNotices(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UserGlobalNotices";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static int AddUserGlobalNotice(SqlConnection conn, SqlTransaction trans, Guid noticeId, string sContent, DateTime displayTime, int displayInterval, int repetitionCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddUserGlobalNotice";
            sc.Parameters.Clear();
            sc.Parameters.Add("@noticeId", SqlDbType.UniqueIdentifier).Value = noticeId;
            sc.Parameters.Add("@sContent", SqlDbType.NVarChar, 400).Value = sContent;
            sc.Parameters.Add("@displayTime", SqlDbType.DateTime).Value = displayTime;
            sc.Parameters.Add("@displayInterval", SqlDbType.Int).Value = displayInterval;
            sc.Parameters.Add("@repetitionCount", SqlDbType.Int).Value = repetitionCount;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static int DeleteUserGlobalNotice(SqlConnection conn, SqlTransaction trans, Guid noticeId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DelUserGlobalNotice";
            sc.Parameters.Clear();
            sc.Parameters.Add("@noticeId", SqlDbType.UniqueIdentifier).Value = noticeId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static DataTable UserAnnouncements(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UserAnnouncements";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static int AddUserAnnouncement(SqlConnection conn, SqlTransaction trans, Guid announcementId, string sTitle, string sContentUrl, DateTime startTime, DateTime endTime, int nSortNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAnnouncement";
            sc.Parameters.Clear();
            sc.Parameters.Add("@announcementId", SqlDbType.UniqueIdentifier).Value = announcementId;
            sc.Parameters.Add("@sTitle", SqlDbType.NVarChar, 400).Value = sTitle;
            sc.Parameters.Add("@sContentUrl", SqlDbType.NVarChar, 400).Value = sContentUrl;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static int UpdateUserAnnouncement(SqlConnection conn, SqlTransaction trans, Guid announcementId, string sTitle, string sContentUrl, DateTime startTime, DateTime endTime, bool bVisible)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateUserAnnouncement";
            sc.Parameters.Clear();
            sc.Parameters.Add("@announcementId", SqlDbType.UniqueIdentifier).Value = announcementId;
            sc.Parameters.Add("@sTitle", SqlDbType.NVarChar, 400).Value = sTitle;
            sc.Parameters.Add("@sContentUrl", SqlDbType.NVarChar, 400).Value = sContentUrl;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@bVisible", SqlDbType.Bit).Value = bVisible;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static int DeleteUserAnnouncement(SqlConnection conn, SqlTransaction trans, Guid announcementId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DelUserAnnouncement";
            sc.Parameters.Clear();
            sc.Parameters.Add("@announcementId", SqlDbType.UniqueIdentifier).Value = announcementId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static int AddUserAnnouncementLog(SqlConnection conn, SqlTransaction trans,Guid logId, Guid announcementId, int nType, string sTitle, string sContentUrl, DateTime startTime, DateTime endTime, int nSortNo, bool bVisible)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAnnouncementLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@logId", SqlDbType.UniqueIdentifier).Value = logId;
            sc.Parameters.Add("@announcementId", SqlDbType.UniqueIdentifier).Value = announcementId;
            sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
            sc.Parameters.Add("@sTitle", SqlDbType.NVarChar, 400).Value = sTitle;
            sc.Parameters.Add("@sContentUrl", SqlDbType.NVarChar, 400).Value = sContentUrl;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
            sc.Parameters.Add("@bVisible", SqlDbType.Bit).Value = bVisible;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static DataRow UserInfoF(SqlConnection conn, SqlTransaction trans, Guid userId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UserInfoF";
            sc.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static DataTable AccountUserBlocks(SqlConnection conn, SqlTransaction trans, int nRowsPerPage, int nPage, out int nTotalCount)
    {

        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AccountUserBlocks";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }

    public static int AddAccountUserBlock(SqlConnection conn, SqlTransaction trans, Guid blockId, Guid userId, string sReason)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAccountUserBlock";
            sc.Parameters.Clear();
            sc.Parameters.Add("@blockId", SqlDbType.UniqueIdentifier).Value = blockId;
            sc.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userId;
            sc.Parameters.Add("@sReason", SqlDbType.NVarChar, sReason.Length).Value = sReason;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static int UpdateAccountUserBlock_Revocation(SqlConnection conn, SqlTransaction trans, Guid blockId, string sRevocationReason)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateAccountUserBlock_Revocation";
            sc.Parameters.Clear();
            sc.Parameters.Add("@blockId", SqlDbType.UniqueIdentifier).Value = blockId;
            sc.Parameters.Add("@sRevocationReason", SqlDbType.NVarChar, sRevocationReason.Length).Value = sRevocationReason;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static DataTable GameServerRegions(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_GameServerRegions";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static int UpdateGameServerGroup_RecommendGameServerId(SqlConnection conn, SqlTransaction trans, int nGroupId, int nRecommendGameServerId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateGameServerGroup_RecommendGameServerId";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
            sc.Parameters.Add("@nRecommendGameServerId", SqlDbType.Int).Value = nRecommendGameServerId;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static DataTable GameServers_GroupId(SqlConnection conn, SqlTransaction trans, int nGroupId)
    {
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.Transaction = trans;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "uspAdmin_GameServers_GroupId";
        sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;

        DataTable dt = new DataTable();

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sc;
        sda.Fill(dt);

        return dt;
    }

    public static DataTable GameServerGroups_RegionId(SqlConnection conn, SqlTransaction trans, int nRegionId)
    {
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.Transaction = trans;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "uspAdmin_GameServerGroups_RegionId";
        sc.Parameters.Add("@nRegionId", SqlDbType.Int).Value = nRegionId;

        DataTable dt = new DataTable();

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sc;
        sda.Fill(dt);

        return dt;
    }

    public static int AddGameServerRegion(SqlConnection conn, SqlTransaction trans, int nRegionId, string sName, string sNameKey, int nSortNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddGameServerRegion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRegionId", SqlDbType.Int).Value = nRegionId;
            sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
            sc.Parameters.Add("@sNameKey", SqlDbType.NVarChar, 20).Value = sNameKey;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static int UpdateGameServerRegion(SqlConnection conn, SqlTransaction trans, int nRegionId, string sName, string sNameKey, int nSortNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateGameServerRegion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRegionId", SqlDbType.Int).Value = nRegionId;
            sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
            sc.Parameters.Add("@sNameKey", SqlDbType.NVarChar, 20).Value = sNameKey;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static int DeleteGameServerRegion(SqlConnection conn, SqlTransaction trans, int nRegionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeleteGameServerRegion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRegionId", SqlDbType.Int).Value = nRegionId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static DataTable GeoIpCountryCodes(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_GeoIpCountryCodes";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static int DeleteGameServerGroupAllowedCountry(SqlConnection conn, SqlTransaction trans, int nGroupId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeleteGameServerGroupAllowedCountry";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static int AddGameServerGroupAllowedCountry(SqlConnection conn, SqlTransaction trans, int nGroupId, string sCountryCode)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddGameServerGroupAllowedCountry";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;
            sc.Parameters.Add("@sCountryCode", SqlDbType.VarChar, 2).Value = sCountryCode;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static DataTable GameServerGroupAllowedCountries(SqlConnection conn, SqlTransaction trans, int nGroupId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_GameServerGroupAllowedCountries";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGroupId", SqlDbType.Int).Value = nGroupId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static DataTable BlackIps(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_BlackIps";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static int AddBlackIp(SqlConnection conn, SqlTransaction trans, long lnStartIpNo, long lnEndIpNo, string sStartIp, string sEndIp, string sName)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddBlackIp";
            sc.Parameters.Clear();
            sc.Parameters.Add("@bnStartIpNo", SqlDbType.BigInt).Value = lnStartIpNo;
            sc.Parameters.Add("@bnEndIpNo", SqlDbType.BigInt).Value = lnEndIpNo;
            sc.Parameters.Add("@sStartIp", SqlDbType.VarChar, 15).Value = sStartIp;
            sc.Parameters.Add("@sEndIp", SqlDbType.VarChar, 15).Value = sEndIp;
            sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static int DeleteBlackIp(SqlConnection conn, SqlTransaction trans, long lnStartIpNo, long lnEndIpNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeleteBlackIp";
            sc.Parameters.Clear();
            sc.Parameters.Add("@bnStartIpNo", SqlDbType.BigInt).Value = lnStartIpNo;
            sc.Parameters.Add("@bnEndIpNo", SqlDbType.BigInt).Value = lnEndIpNo;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static DataTable Promotions(SqlConnection conn, SqlTransaction trans, string sName, string sCouponId, DateTime startTime, DateTime endTime, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_Promotions";
            sc.Parameters.Clear();
            sc.Parameters.Add("@sName", SqlDbType.VarChar, 20).Value = sName;
            sc.Parameters.Add("@sCouponId", SqlDbType.VarChar, 20).Value = sCouponId;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static DataTable Coupons(SqlConnection conn, SqlTransaction trans, Guid sPromotionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_Coupons";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = sPromotionId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataRow Promotion(SqlConnection conn, SqlTransaction trans, Guid sPromotionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_Promotion";
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = sPromotionId;

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable PromotionItems(SqlConnection conn, SqlTransaction trans, Guid sPromotionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_PromotionItems";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = sPromotionId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable PromotionTargets(SqlConnection conn, SqlTransaction trans, Guid sPromotionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_PromotionTargets";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = sPromotionId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static int AddPromotionTarget(SqlConnection conn, SqlTransaction trans, Guid nPromotionId, int nTargetRegionId, int nTargetGroupId, int nTargetServerId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddPromotionTarget";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = nPromotionId;
            sc.Parameters.Add("@nTargetRegionId", SqlDbType.Int).Value = nTargetRegionId;
            sc.Parameters.Add("@nTargetGroupId", SqlDbType.Int).Value = nTargetGroupId;
            sc.Parameters.Add("@nTargetServerId", SqlDbType.Int).Value = nTargetServerId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static int DeletePromotionTarget(SqlConnection conn, SqlTransaction trans, Guid nPromotionId, int nTargetRegionId, int nTargetGroupId, int nTargetServerId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeletePromotionTarget";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = nPromotionId;
            sc.Parameters.Add("@nTargetRegionId", SqlDbType.Int).Value = nTargetRegionId;
            sc.Parameters.Add("@nTargetGroupId", SqlDbType.Int).Value = nTargetGroupId;
            sc.Parameters.Add("@nTargetServerId", SqlDbType.Int).Value = nTargetServerId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static int UpdatePromotion(SqlConnection conn, SqlTransaction trans, Guid nPromotionId, DateTime startTime, DateTime endTime,
            int nMailTitleType, string sMailTitle, int nMailContentType, string sMailContent, bool enabled)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdatePromotion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = nPromotionId;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nMailTitleType", SqlDbType.Int).Value = nMailTitleType;
            sc.Parameters.Add("@sMailTitle", SqlDbType.NVarChar, 100).Value = sMailTitle;
            sc.Parameters.Add("@nMailContentType", SqlDbType.Int).Value = nMailContentType;
            sc.Parameters.Add("@sMailContent", SqlDbType.NVarChar, sMailContent.Length).Value = sMailContent;
            sc.Parameters.Add("@enabled", SqlDbType.Bit).Value = enabled;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static int AddPromotion(SqlConnection conn, SqlTransaction trans, string sName, int nType, DateTime startTime, DateTime endTime, int nCouponCount,
            int nMailTitleType, string sMailTitle, int nMailContentType, string sMailContent,  bool enabled, Guid nPromotionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddPromotion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@sName", SqlDbType.VarChar, 20).Value = sName;
            sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nCouponCount", SqlDbType.Int).Value = nCouponCount;
            sc.Parameters.Add("@nMailTitleType", SqlDbType.Int).Value = nMailTitleType;
            sc.Parameters.Add("@sMailTitle", SqlDbType.NVarChar, 100).Value = sMailTitle;
            sc.Parameters.Add("@nMailContentType", SqlDbType.Int).Value = nMailContentType;
            sc.Parameters.Add("@sMailContent", SqlDbType.NVarChar, sMailContent.Length).Value = sMailContent;
          //  sc.Parameters.Add("@nOwnDia", SqlDbType.Int).Value = nOwnDia;
          //  sc.Parameters.Add("@nOwnGold", SqlDbType.Int).Value = nOwnGold;
            sc.Parameters.Add("@enabled", SqlDbType.Bit).Value = enabled;
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = nPromotionId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

           // nPromotionId = Guid.Parse(Convert.ToString(sc.Parameters["@nPromotionId"].Value));

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static int AddPromotionItem(SqlConnection conn, SqlTransaction trans, Guid nPromotionId, int nNo, int nItemId, int nItemCount, bool itemOwned)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddPromotionItem";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = nPromotionId;
            sc.Parameters.Add("@nNo", SqlDbType.Int).Value = nNo;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@itemOwned", SqlDbType.Bit).Value = itemOwned;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static int AddCoupon(SqlConnection conn, SqlTransaction trans, string sCouponId, Guid nPromotionId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddCoupon";
            sc.Parameters.Clear();
            sc.Parameters.Add("@sCouponId", SqlDbType.VarChar, 20).Value = sCouponId;
            sc.Parameters.Add("@nPromotionId", SqlDbType.UniqueIdentifier).Value = nPromotionId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static DataTable SharingEventReceiverLogs_Excel(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEventReceiverLogs_Excel";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static DataTable SharingEventSenderLogs_Excel(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEventSenderLogs_Excel";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable ReviewLogs(SqlConnection conn, SqlTransaction trans, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ReviewLogs";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static DataTable SharingEvents(SqlConnection conn, SqlTransaction trans, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEvents";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static int UpdateSharingEvents(SqlConnection conn, SqlTransaction trans, int nEventId, int nContentType, string sContent, int nRewardRange, int nRewardLimitCount, int nTargetLevel,
                                            DateTime startTime, DateTime endTime, int nRewardMailTitleType, string sRewardMailTitle, int nRewardMailContentType, string sRewardMailContent, string sImageName)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateSharingEvents";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nContentType", SqlDbType.Int).Value = nContentType;
            sc.Parameters.Add("@sContent", SqlDbType.NVarChar, 100).Value = sContent;
            sc.Parameters.Add("@nRewardRange", SqlDbType.Int).Value = nRewardRange;
            sc.Parameters.Add("@nRewardLimitCount", SqlDbType.Int).Value = nRewardLimitCount;
            sc.Parameters.Add("@nTargetLevel", SqlDbType.Int).Value = nTargetLevel;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nRewardMailTitleType", SqlDbType.Int).Value = nRewardMailTitleType;
            sc.Parameters.Add("@sRewardMailTitle", SqlDbType.NVarChar, 100).Value = sRewardMailTitle;
            sc.Parameters.Add("@nRewardMailContentType", SqlDbType.Int).Value = nRewardMailContentType;
            sc.Parameters.Add("@sRewardMailContent", SqlDbType.NVarChar, sRewardMailContent.Length).Value = sRewardMailContent;
            sc.Parameters.Add("@sImageName", SqlDbType.VarChar, 80).Value = sImageName;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int AddSharingEvents(SqlConnection conn, SqlTransaction trans, int nEventId, int nContentType, string sContent, int nRewardRange, int nRewardLimitCount, int nTargetLevel,
                                            DateTime startTime, DateTime endTime, int nRewardMailTitleType, string sRewardMailTitle, int nRewardMailContentType, string sRewardMailContent, string sImageName)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddSharingEvents";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nContentType", SqlDbType.Int).Value = nContentType;
            sc.Parameters.Add("@sContent", SqlDbType.NVarChar, 100).Value = sContent;
            sc.Parameters.Add("@nRewardRange", SqlDbType.Int).Value = nRewardRange;
            sc.Parameters.Add("@nRewardLimitCount", SqlDbType.Int).Value = nRewardLimitCount;
            sc.Parameters.Add("@nTargetLevel", SqlDbType.Int).Value = nTargetLevel;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nRewardMailTitleType", SqlDbType.Int).Value = nRewardMailTitleType;
            sc.Parameters.Add("@sRewardMailTitle", SqlDbType.NVarChar, 100).Value = sRewardMailTitle;
            sc.Parameters.Add("@nRewardMailContentType", SqlDbType.Int).Value = nRewardMailContentType;
            sc.Parameters.Add("@sRewardMailContent", SqlDbType.NVarChar, sRewardMailContent.Length).Value = sRewardMailContent;
            sc.Parameters.Add("@sImageName", SqlDbType.VarChar, 80).Value = sImageName;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static DataTable SharingEventReceiverRewards(SqlConnection conn, SqlTransaction trans, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEventReceiverRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static int UpdateSharingEventReceiverRewards(SqlConnection conn, SqlTransaction trans, int nEventId, int nRewardNo, int nItemId, int nItemCount, bool bOwned, string type)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateSharingEventReceiverRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nRewardNo", SqlDbType.Int).Value = nRewardNo;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@bitemOwned", SqlDbType.Bit).Value = bOwned;
            sc.Parameters.Add("@type", SqlDbType.NVarChar, 10).Value = type;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int AddSharingEventReceiverRewards(SqlConnection conn, SqlTransaction trans, int nEventId, int nRewardNo, int nItemId, int nItemCount, bool bOwned)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddSharingEventReceiverRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nRewardNo", SqlDbType.Int).Value = nRewardNo;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@bitemOwned", SqlDbType.Bit).Value = bOwned;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static DataTable SharingEventReceiverLogs(SqlConnection conn, SqlTransaction trans, int m_nGameServerId, string m_sName, int m_nType, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEventReceiverLogs";
            sc.Parameters.Clear();

            sc.Parameters.Add("@m_nGameServerId", SqlDbType.Int).Value = m_nGameServerId;
            sc.Parameters.Add("@m_sName", SqlDbType.NVarChar, 50).Value = m_sName;
            sc.Parameters.Add("@m_nType", SqlDbType.Int).Value = m_nType;

            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static DataTable SharingEventSenderLogs(SqlConnection conn, SqlTransaction trans, int m_nGameServerId, string m_sName, int m_nType, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        //m_sName 검색어 , m_nType 카테고리 1 영웅아이디, 2 추천코드

        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEventSenderLogs";
            sc.Parameters.Clear();

            sc.Parameters.Add("@m_nGameServerId", SqlDbType.Int).Value = m_nGameServerId;
            sc.Parameters.Add("@m_sName", SqlDbType.NVarChar, 50).Value = m_sName;
            sc.Parameters.Add("@m_nType", SqlDbType.Int).Value = m_nType;

            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static DataTable SharingEventSenderRewards(SqlConnection conn, SqlTransaction trans, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SharingEventSenderRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static int UpdateSharingEventSenderRewards(SqlConnection conn, SqlTransaction trans, int nEventId, int nRewardNo, int nItemId, int nItemCount, bool bOwned, string type)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateSharingEventSenderRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nRewardNo", SqlDbType.Int).Value = nRewardNo;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@bitemOwned", SqlDbType.Bit).Value = bOwned;
            sc.Parameters.Add("@type", SqlDbType.NVarChar, 10).Value = type;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int AddSharingEventSenderRewards(SqlConnection conn, SqlTransaction trans, int nEventId, int nRewardNo, int nItemId, int nItemCount, bool bOwned)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddSharingEventSenderRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nRewardNo", SqlDbType.Int).Value = nRewardNo;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@bitemOwned", SqlDbType.Bit).Value = bOwned;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    //2018-10-10
    public static DataRow AdminAccountHeroRelocationLog(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AdminAccountHeroRelocationLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static int AddAdminAccountHeroRelocationLog(SqlConnection conn, SqlTransaction trans, int m_nServerId, Guid heroId, Guid accountId, Guid gmAccountId, string sAdminId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAdminAccountHeroRelocationLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nGameServerId", SqlDbType.Int).Value = m_nServerId;
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@accountId", SqlDbType.UniqueIdentifier).Value = accountId;
            sc.Parameters.Add("@gmAccountId", SqlDbType.UniqueIdentifier).Value = gmAccountId;
            sc.Parameters.Add("@sAdminId", SqlDbType.VarChar, 20).Value = sAdminId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int UpdateAdminAccountHeroRelocationLog_Recovery(SqlConnection conn, SqlTransaction trans, long lnLogNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateAdminAccountHeroRelocationLog_Recovery";
            sc.Parameters.Clear();
            sc.Parameters.Add("@biLogNo", SqlDbType.BigInt).Value = lnLogNo;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    //클라이언트 텍스트 시작
    public static DataTable ClientTextLanguageLists(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ClientTextLanguageList";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable ClientTextGetListForNews(SqlConnection conn, SqlTransaction trans, int nStandardLanguageId, int nLanguageId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ClientTextGetListForNew";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nStandardLanguageId", SqlDbType.Int).Value = nStandardLanguageId;
            sc.Parameters.Add("@nLanguageId", SqlDbType.Int).Value = nLanguageId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable Admin_ClientTextGetLists(SqlConnection conn, SqlTransaction trans, int nStandardLanguageId, int nLanguageId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ClientTextGetList";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nStandardLanguageId", SqlDbType.Int).Value = nStandardLanguageId;
            sc.Parameters.Add("@nLanguageId", SqlDbType.Int).Value = nLanguageId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable ClientTextDiff(SqlConnection conn, SqlTransaction trans, int nLanguageId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ClientTextDiff";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nLanguageId", SqlDbType.Int).Value = nLanguageId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static string ClientTextUpdateStandard(SqlConnection conn, SqlTransaction trans, int nStandardLanguageId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ClientTextUpdateStandard";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nStandardLanguageId", SqlDbType.Int).Value = nStandardLanguageId;

            sc.ExecuteNonQuery();
            return "";
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return ex.Message;
        }
    }
    public static int TruncateClientTextTemp(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_TruncateClientText$";
            sc.Parameters.Clear();
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

    public static int SqlBulkCopy(SqlConnection conn, DataTable dt, String sTargetTableName)
    {
        try
        {
            var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, null);

            foreach (DataColumn col in dt.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = 600;
            bulkCopy.DestinationTableName = sTargetTableName;
            bulkCopy.WriteToServer(dt);

            return 0;
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static DataTable SystemSettings(SqlConnection conn, SqlTransaction trans)
    {
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.Transaction = trans;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "uspAdmin_SystemSettings";

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sc;
        sda.Fill(dt);

        return dt;
    }
    public static string ClientTextUpdateLocal(SqlConnection conn, SqlTransaction trans, int nLanguageId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ClientTextUpdateLocal";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nLanguageId", SqlDbType.Int).Value = nLanguageId;
            sc.ExecuteNonQuery();

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public static int UpdateSystemSetting(SqlConnection conn, SqlTransaction trans, int nSettingId, string sValue)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateSystemSetting";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nSettingId", SqlDbType.Int).Value = nSettingId;
            sc.Parameters.Add("@sValue", SqlDbType.NVarChar, sValue.Length).Value = sValue;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    //클라이언트 텍스트 끝
    //접속유저 메일 시작
    public static DataTable TimeDesignationEvents(SqlConnection conn, SqlTransaction trans, int nSearchType, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_TimeDesignationEvents";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nSearchType", SqlDbType.Int).Value = nSearchType;
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static int DeleteTimeDesignationEvent(SqlConnection conn, SqlTransaction trans, int nEventId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeleteTimeDesignationEvent";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int DeleteTimeDesignationEventReward_All(SqlConnection conn, SqlTransaction trans, int nEventId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeleteTimeDesignationEventReward_All";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static DataRow TimeDesignationEvent(SqlConnection conn, SqlTransaction trans, int nEventId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_TimeDesignationEvent";
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;

            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt.Rows.Count == 0 ? null : dt.Rows[0];
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable TimeDesignationEventRewards(SqlConnection conn, SqlTransaction trans, int nEventId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_TimeDesignationEventRewards";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static int UpdateTimeDesignationEvent(SqlConnection conn, SqlTransaction trans, int nEventId, string sEventName, int nTitleType, string sTitle, int nContentType, string sContent,
            DateTime startTime, DateTime endTime)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateTimeDesignationEvent";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@_name", SqlDbType.NVarChar, 100).Value = sEventName;
            sc.Parameters.Add("@nMailTitleType", SqlDbType.Int).Value = nTitleType;
            sc.Parameters.Add("@sMailTitle", SqlDbType.NVarChar, 100).Value = sTitle;
            sc.Parameters.Add("@nMailContentType", SqlDbType.Int).Value = nContentType;
            sc.Parameters.Add("@sMailContent", SqlDbType.NVarChar, sContent.Length).Value = sContent;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static int AddTimeDesignationEvent(SqlConnection conn, SqlTransaction trans, string sEventName, int nTitleType, string sTitle, int nContentType, string sContent,
        DateTime startTime, DateTime endTime, out int nEventId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddTimeDesignationEvent";
            sc.Parameters.Clear();
            sc.Parameters.Add("@_name", SqlDbType.NVarChar, 100).Value = sEventName;
            sc.Parameters.Add("@nMailTitleType", SqlDbType.Int).Value = nTitleType;
            sc.Parameters.Add("@sMailTitle", SqlDbType.NVarChar, 100).Value = sTitle;
            sc.Parameters.Add("@nMailContentType", SqlDbType.Int).Value = nContentType;
            sc.Parameters.Add("@sMailContent", SqlDbType.NVarChar, sContent.Length).Value = sContent;
            sc.Parameters.Add("@startTime", SqlDbType.DateTime).Value = startTime;
            sc.Parameters.Add("@endTime", SqlDbType.DateTime).Value = endTime;
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Direction = ParameterDirection.Output;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            nEventId = Convert.ToInt32(sc.Parameters["@nEventId"].Value);

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            nEventId = 0;
            return -99;
        }
    }
    public static int AddTimeDesignationEventReward(SqlConnection conn, SqlTransaction trans, int nEventId, int nRewardNo, long nItemRewardId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddTimeDesignationEventReward";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nEventId", SqlDbType.Int).Value = nEventId;
            sc.Parameters.Add("@nRewardNo", SqlDbType.Int).Value = nRewardNo;
            sc.Parameters.Add("@nItemRewardId", SqlDbType.BigInt).Value = nItemRewardId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static DataTable ItemReward(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ItemReward";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    //접속유저 메일 끝

    //충전(구입) 시작
    public static DataTable CashProducts(SqlConnection conn, SqlTransaction trans, int nRowsPerPage, int nPage, out int nTotalCount)
    {

        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_CashProducts";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static DataTable InAppProducts(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_InAppProducts";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static int AddCashProduct(SqlConnection conn, SqlTransaction trans, string sName, string sNameKey, string nInAppProductKey, string sImageName, int nType,
            int nUnOwnDia, int nItemId, bool bItemOwned, int nItemCount, int nVipPoint, int nFirstPurchaseBonusUnOwnDia, bool bSaleable, int nSortNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddCashProduct";
            sc.Parameters.Clear();
            sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;
            sc.Parameters.Add("@sNameKey", SqlDbType.VarChar, 20).Value = sNameKey;
            sc.Parameters.Add("@sInAppProductKey", SqlDbType.VarChar, 100).Value = nInAppProductKey;
            sc.Parameters.Add("@sImageName", SqlDbType.VarChar, 100).Value = sImageName;
            sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
            sc.Parameters.Add("@nUnOwnDia", SqlDbType.Int).Value = nUnOwnDia;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@bItemOwned", SqlDbType.Bit).Value = bItemOwned;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@nVipPoint", SqlDbType.Int).Value = nVipPoint;
            sc.Parameters.Add("@nFirstPurchaseBonusUnOwnDia", SqlDbType.Int).Value = nFirstPurchaseBonusUnOwnDia;
            sc.Parameters.Add("@bSaleable", SqlDbType.Bit).Value = bSaleable;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int UpdateCashProduct(SqlConnection conn, SqlTransaction trans, int nProductId, string sName, string sNameKey, string nInAppProductKey, string sImageName, int nType, 
            int nUnOwnDia, int nItemId, bool bItemOwned, int nItemCount, int nVipPoint, int nFirstPurchaseBonusUnOwnDia,  bool bSaleable, int nSortNo)
    {
        try
        {  
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateCashProduct";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nProductId", SqlDbType.Int).Value = nProductId;
            sc.Parameters.Add("@sName", SqlDbType.NVarChar,20).Value = sName;
            sc.Parameters.Add("@sNameKey", SqlDbType.VarChar,20).Value = sNameKey;
            sc.Parameters.Add("@sInAppProductKey", SqlDbType.VarChar, 100).Value = nInAppProductKey;
            sc.Parameters.Add("@sImageName", SqlDbType.VarChar, 100).Value = sImageName;
            sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
            sc.Parameters.Add("@nUnOwnDia", SqlDbType.Int).Value = nUnOwnDia;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@bItemOwned", SqlDbType.Bit).Value = bItemOwned;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@nVipPoint", SqlDbType.Int).Value = nVipPoint;
            sc.Parameters.Add("@nFirstPurchaseBonusUnOwnDia", SqlDbType.Int).Value = nFirstPurchaseBonusUnOwnDia;
            sc.Parameters.Add("@bSaleable", SqlDbType.Bit).Value = bSaleable;
            sc.Parameters.Add("@nSortNo", SqlDbType.Int).Value = nSortNo;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int UpdateGameEnvSetting_PurchaseProductDataVersion(SqlConnection conn, SqlTransaction trans, int nPurchaseProductDataVersion)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateGameEnvSetting_PurchaseProductDataVersion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nPurchaseProductDataVersion", SqlDbType.Int).Value = nPurchaseProductDataVersion;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    //충전(구입) 끝

    //다이아상점 시작
    public static DataTable DiaShopCategory(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DiaShopCategory";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable DiaShopProducts(SqlConnection conn, SqlTransaction trans, int nCategoryId, int nRowsPerPage, int nPage, out int nTotalCount)
    {

        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DiaShopProducts";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nCategoryId", SqlDbType.Int).Value = nCategoryId;
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }
    public static int DeleteDiaShopProduct(SqlConnection conn, SqlTransaction trans, int nProductId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DeleteDiaShopProduct";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nProductId", SqlDbType.Int).Value = nProductId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int UpdateDiaShopProduct(SqlConnection conn, SqlTransaction trans, int nProductId, int nCategoryId, int nCostumeProductType, int nItemId, bool bItemOwned
    , int nTagType, int nMoneyType, int nMoneyItemId, int nOriginalPrice, int nPrice, int nPeriodType, DateTime dPeriodStartTime, DateTime dPeriodEndTime
    , int nPeriodDayOfWeek, bool bRecommended, bool bIsLimitEdition, bool bSellable, int nCategorySortNo, int nLimitEditionSortNo, int nBuyLimitType, int nBuyLimitCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateDiaShopProduct";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nProductId", SqlDbType.Int).Value = nProductId;
            sc.Parameters.Add("@nCategoryId", SqlDbType.Int).Value = nCategoryId;
            sc.Parameters.Add("@nCostumeProductType", SqlDbType.Int).Value = nCostumeProductType;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@bItemOwned", SqlDbType.Bit).Value = bItemOwned;
            sc.Parameters.Add("@nTagType", SqlDbType.Int).Value = nTagType;
            sc.Parameters.Add("@nMoneyType", SqlDbType.Int).Value = nMoneyType;
            sc.Parameters.Add("@nMoneyItemId", SqlDbType.Int).Value = nMoneyItemId;
            sc.Parameters.Add("@nOriginalPrice", SqlDbType.Int).Value = nOriginalPrice;
            sc.Parameters.Add("@nPrice", SqlDbType.Int).Value = nPrice;
            sc.Parameters.Add("@nPeriodType", SqlDbType.Int).Value = nPeriodType;
            sc.Parameters.Add("@dPeriodStartTime", SqlDbType.DateTime).Value = dPeriodStartTime;           
            sc.Parameters.Add("@dPeriodEndTime", SqlDbType.DateTime).Value = dPeriodEndTime;
            sc.Parameters.Add("@nPeriodDayOfWeek", SqlDbType.Int).Value = nPeriodDayOfWeek;
            sc.Parameters.Add("@bRecommended", SqlDbType.Bit).Value = bRecommended;
            sc.Parameters.Add("@bIsLimitEdition", SqlDbType.Bit).Value = bIsLimitEdition;
            sc.Parameters.Add("@bSellable", SqlDbType.Bit).Value = bSellable;
            sc.Parameters.Add("@nCategorySortNo", SqlDbType.Int).Value = nCategorySortNo;
            sc.Parameters.Add("@nLimitEditionSortNo", SqlDbType.Int).Value = nLimitEditionSortNo;
            sc.Parameters.Add("@nBuyLimitType", SqlDbType.Int).Value = nBuyLimitType;
            sc.Parameters.Add("@nBuyLimitCount", SqlDbType.Int).Value = nBuyLimitCount;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    public static int AddDiaShopProduct(SqlConnection conn, SqlTransaction trans, int nCategoryId, int nCostumeProductType, int nItemId, bool bItemOwned
       , int nTagType, int nMoneyType, int nMoneyItemId, int nOriginalPrice, int nPrice, int nPeriodType, DateTime dPeriodStartTime, DateTime dPeriodEndTime
       , int nPeriodDayOfWeek, bool bRecommended, bool bIsLimitEdition, bool bSellable, int nCategorySortNo, int nLimitEditionSortNo, int nBuyLimitType, int nBuyLimitCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddDiaShopProduct";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nCategoryId", SqlDbType.Int).Value = nCategoryId;
            sc.Parameters.Add("@nCostumeProductType", SqlDbType.Int).Value = nCostumeProductType;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@bItemOwned", SqlDbType.Bit).Value = bItemOwned;
            sc.Parameters.Add("@nTagType", SqlDbType.Int).Value = nTagType;
            sc.Parameters.Add("@nMoneyType", SqlDbType.Int).Value = nMoneyType;
            sc.Parameters.Add("@nMoneyItemId", SqlDbType.Int).Value = nMoneyItemId;
            sc.Parameters.Add("@nOriginalPrice", SqlDbType.Int).Value = nOriginalPrice;
            sc.Parameters.Add("@nPrice", SqlDbType.Int).Value = nPrice;
            sc.Parameters.Add("@nPeriodType", SqlDbType.Int).Value = nPeriodType;
            sc.Parameters.Add("@dPeriodStartTime", SqlDbType.DateTime).Value = dPeriodStartTime;
            sc.Parameters.Add("@dPeriodEndTime", SqlDbType.DateTime).Value = dPeriodEndTime;
            sc.Parameters.Add("@nPeriodDayOfWeek", SqlDbType.Int).Value = nPeriodDayOfWeek;
            sc.Parameters.Add("@bRecommended", SqlDbType.Bit).Value = bRecommended;
            sc.Parameters.Add("@bIsLimitEdition", SqlDbType.Bit).Value = bIsLimitEdition;
            sc.Parameters.Add("@bSellable", SqlDbType.Bit).Value = bSellable;
            sc.Parameters.Add("@nCategorySortNo", SqlDbType.Int).Value = nCategorySortNo;
            sc.Parameters.Add("@nLimitEditionSortNo", SqlDbType.Int).Value = nLimitEditionSortNo;
            sc.Parameters.Add("@nBuyLimitType", SqlDbType.Int).Value = nBuyLimitType;
            sc.Parameters.Add("@nBuyLimitCount", SqlDbType.Int).Value = nBuyLimitCount;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }
    public static int UpdateGameEnvSetting_DiaShopProductDataVersion(SqlConnection conn, SqlTransaction trans, int nDiaShopProductDataVersion)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateGameEnvSetting_DiaShopProductDataVersion";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nDiaShopProductDataVersion", SqlDbType.Int).Value = nDiaShopProductDataVersion;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.ToString());
            return -99;
        }
    }

    //다이아상점 끝
    public static DataTable PurchaseAllLogs(SqlConnection conn, SqlTransaction trans, int nGameServerId, int nRowsPerPage, int nPage, DateTimeOffset dtoStart, DateTimeOffset dtoEnd, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_PurchaseAllLogs";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nServerId", SqlDbType.Int).Value = nGameServerId;
            sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = nRowsPerPage;
            sc.Parameters.Add("@nPage", SqlDbType.Int).Value = nPage;
            sc.Parameters.Add("@dtoStartDate", SqlDbType.DateTimeOffset).Value = dtoStart;
            sc.Parameters.Add("@dtoEndDate", SqlDbType.DateTimeOffset).Value = dtoEnd;
            sc.Parameters.Add("@nTotalCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            nTotalCount = Convert.ToInt32(sc.Parameters["@nTotalCount"].Value);

            return dt;
        }
        catch (Exception ex)
        {
            nTotalCount = 0;
            return null;
        }
    }

    public static DataTable Grades(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_Grades";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static DataTable GearRoyalTypes(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_GearRoyalTypes";
            sc.Parameters.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sc;
            sda.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    internal static DataTable GearOptionAttrGrades(SqlConnection connUser, object value, int nGearId)
    {
        throw new NotImplementedException();
    }

    internal static DataTable MainQuests(SqlConnection connUser, object value, int nNation)
    {
        throw new NotImplementedException();
    }
}