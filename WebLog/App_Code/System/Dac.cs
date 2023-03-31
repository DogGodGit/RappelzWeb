using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Dac'的摘要描述.
/// </summary>
public class Dac
{
	public Dac() {}

	public static int AddLog(SqlConnection conn, SqlTransaction trans,
		int nServiceId, string sAppId, string sUdid, string sBrand, string sModel, string sOsName, string sOsVersion, string sVersion, string sVersionCode,
		string sLanguage, string sCountry, string sCpuUsage, string sFreeMemory,
		string sContent, string sIpAddress)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspApi_AddLog";
		sc.Parameters.Clear();
		sc.Parameters.Add("@nServiceId", SqlDbType.Int).Value = nServiceId;
		sc.Parameters.Add("@sAppId", SqlDbType.VarChar, 50).Value = sAppId;
		sc.Parameters.Add("@sUdid", SqlDbType.VarChar, 50).Value = sUdid;
		sc.Parameters.Add("@sBrand", SqlDbType.NVarChar, 20).Value = sBrand;
		sc.Parameters.Add("@sModel", SqlDbType.NVarChar, 20).Value = sModel;
		sc.Parameters.Add("@sOsName", SqlDbType.NVarChar, 20).Value = sOsName;
		sc.Parameters.Add("@sOsVersion", SqlDbType.NVarChar, 20).Value = sOsVersion;
		sc.Parameters.Add("@sVersion", SqlDbType.NVarChar, 20).Value = sVersion;
		sc.Parameters.Add("@sVersionCode", SqlDbType.NVarChar, 20).Value = sVersionCode;
		sc.Parameters.Add("@sLanguage", SqlDbType.NVarChar, 20).Value = sLanguage;
		sc.Parameters.Add("@sCountry", SqlDbType.NVarChar, 20).Value = sCountry;
		sc.Parameters.Add("@sCpuUsage", SqlDbType.NVarChar, 50).Value = sCpuUsage;
		sc.Parameters.Add("@sFreeMemory", SqlDbType.NVarChar, 50).Value = sFreeMemory;
		sc.Parameters.Add("@sContent", SqlDbType.NVarChar, sContent.Length).Value = sContent;
		sc.Parameters.Add("@sIpAddress", SqlDbType.VarChar, 20).Value = sIpAddress;

		sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

		sc.ExecuteNonQuery();

		return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
	}

	public static int AddStatusLog(SqlConnection conn, SqlTransaction trans,
		string sAppId, string sUdid, string sBrand, string sModel, string sOsName, string sOsVersion, string sVersion, string sVersionCode,
		string sLanguage, string sCountry, string sCpuUsage, string sFreeMemory,
		string sPing, string sFrameRate, string sBatteryStatus, string sChargeType, string sNetworkType, string sSignalStrength, string sUserId, string sHeroId, string sIpAddress)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspApi_AddStatusLog";
		sc.Parameters.Clear();
		sc.Parameters.Add("@sAppId", SqlDbType.VarChar, 50).Value = sAppId;
		sc.Parameters.Add("@sUdid", SqlDbType.VarChar, 50).Value = sUdid;
		sc.Parameters.Add("@sBrand", SqlDbType.NVarChar, 20).Value = sBrand;
		sc.Parameters.Add("@sModel", SqlDbType.NVarChar, 50).Value = sModel;
		sc.Parameters.Add("@sOsName", SqlDbType.NVarChar, 20).Value = sOsName;
		sc.Parameters.Add("@sOsVersion", SqlDbType.NVarChar, 20).Value = sOsVersion;
		sc.Parameters.Add("@sVersion", SqlDbType.NVarChar, 20).Value = sVersion;
		sc.Parameters.Add("@sVersionCode", SqlDbType.NVarChar, 20).Value = sVersionCode;
		sc.Parameters.Add("@sLanguage", SqlDbType.NVarChar, 20).Value = sLanguage;
		sc.Parameters.Add("@sCountry", SqlDbType.NVarChar, 20).Value = sCountry;
		sc.Parameters.Add("@sCpuUsage", SqlDbType.NVarChar, 50).Value = sCpuUsage;
		sc.Parameters.Add("@sFreeMemory", SqlDbType.NVarChar, 50).Value = sFreeMemory;
		sc.Parameters.Add("@sPing", SqlDbType.NVarChar, sPing.Length).Value = sPing;
		sc.Parameters.Add("@sFrameRate", SqlDbType.NVarChar, sFrameRate.Length).Value = sFrameRate;
		sc.Parameters.Add("@sBatteryStatus", SqlDbType.NVarChar, sBatteryStatus.Length).Value = sBatteryStatus;
		sc.Parameters.Add("@sChargeType", SqlDbType.VarChar, sChargeType.Length).Value = sChargeType;
		sc.Parameters.Add("@sNetworkType", SqlDbType.NVarChar, sNetworkType.Length).Value = sNetworkType;
		sc.Parameters.Add("@sSignalStrength", SqlDbType.VarChar, sSignalStrength.Length).Value = sSignalStrength;
		sc.Parameters.Add("@sUserId", SqlDbType.VarChar, sUserId.Length).Value = sUserId;
		sc.Parameters.Add("@sHeroId", SqlDbType.VarChar, sHeroId.Length).Value = sHeroId;
		sc.Parameters.Add("@sIpAddress", SqlDbType.VarChar, 20).Value = sIpAddress;

		sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

		sc.ExecuteNonQuery();

		return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
	}
}