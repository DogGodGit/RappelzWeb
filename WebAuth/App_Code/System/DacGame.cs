using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// DacGame의 요약 설명입니다.
/// </summary>
public class DacGame
{
	public static DataRow Hero_NickName(SqlConnection conn, SqlTransaction trans, string sName)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspApi_Hero_NickName";
		sc.Parameters.Add("@sName", SqlDbType.NVarChar, 20).Value = sName;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static DataRow Account_HeroId(SqlConnection conn, SqlTransaction trans, Guid heroId)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspApi_Account_HeroId";
		sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}
	

	public static int AddMail(SqlConnection conn, SqlTransaction trans, Guid mailId, Guid heroId, int nTitleType, string sTitle, int nContentType, string sContent, int nDurationDay)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspApi_AddMail";
			sc.Parameters.Clear();
			sc.Parameters.Add("@mailId", SqlDbType.UniqueIdentifier).Value = mailId;
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
			sc.Parameters.Add("@nTitleType", SqlDbType.Int).Value = nTitleType;
			sc.Parameters.Add("@sTitle", SqlDbType.NVarChar, 100).Value = sTitle;
			sc.Parameters.Add("@nContentType", SqlDbType.Int).Value = nContentType;
			sc.Parameters.Add("@sContent", SqlDbType.NVarChar, sContent.Length).Value = sContent;
			sc.Parameters.Add("@nDurationDay", SqlDbType.Int).Value = nDurationDay;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.Message);
			return -99;
		}
	}

	public static int AddMailAttachment(SqlConnection conn, SqlTransaction trans, Guid mailId, int nAttachmentNo, int nItemId, int nItemCount, bool itemOwned)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspApi_AddMailAttachment";
			sc.Parameters.Clear();
			sc.Parameters.Add("@mailId", SqlDbType.UniqueIdentifier).Value = mailId;
			sc.Parameters.Add("@nAttachmentNo", SqlDbType.Int).Value = nAttachmentNo;
			sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
			sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
			sc.Parameters.Add("@itemOwned", SqlDbType.Bit).Value = itemOwned;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.Message);
			return -99;
		}
	}
}