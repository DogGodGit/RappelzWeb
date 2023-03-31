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
	public Dac()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

	public static DataRow StageFarmVersion(SqlConnection conn, SqlTransaction trans, int nPlatformId, string sVersionName, int nBuildNo)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspApi_StageFarmVersion";
			sc.Parameters.Add("@nPlatformId", SqlDbType.Int).Value = nPlatformId;
			sc.Parameters.Add("@sVersionName", SqlDbType.VarChar, 20).Value = sVersionName;
			sc.Parameters.Add("@nBuildNo", SqlDbType.Int).Value = nBuildNo;

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

	public static DataRow StageFarm(SqlConnection conn, SqlTransaction trans, int nFarmId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspApi_StageFarm";
			sc.Parameters.Add("@nFarmId", SqlDbType.Int).Value = nFarmId;

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

	public static DataRow Platform(SqlConnection conn, SqlTransaction trans, int nPlatformId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspApi_Platform";
			sc.Parameters.Add("@nPlatformId", SqlDbType.Int).Value = nPlatformId;

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

	public static DataRowCollection WhiteIps(SqlConnection conn, SqlTransaction trans, long lnIpNo)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspApi_WhiteIps";
		sc.Parameters.Add("@bnIpNo", SqlDbType.BigInt).Value = lnIpNo;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows;
	}
}