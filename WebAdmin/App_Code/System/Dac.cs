using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DocumentFormat.OpenXml.Drawing.Charts;
using DataTable = System.Data.DataTable;
using DocumentFormat.OpenXml.ExtendedProperties;

/// <summary>
/// Data의 요약 설명입니다.
/// </summary>
public class Dac
{
	public Dac() { }

	public static DataTable Heros_Search(SqlConnection conn, SqlTransaction trans, int nType, string sText)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Heros_Search";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
			sc.Parameters.Add("@sText", SqlDbType.NVarChar, 100).Value = sText;

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

	public static DataRow Hero(SqlConnection conn, SqlTransaction trans, Guid heroId)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_Hero";
		sc.Parameters.Clear();
		sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}
	

	public static DataRow Account(SqlConnection conn, SqlTransaction trans, Guid accountId)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_Account";
		sc.Parameters.Clear();
		sc.Parameters.Add("@accountId", SqlDbType.UniqueIdentifier).Value = accountId;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static DataTable Heros_AccountId(SqlConnection conn, SqlTransaction trans, Guid accountId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Heros_AccountId";
			sc.Parameters.Clear();
			sc.Parameters.Add("@accountId", SqlDbType.UniqueIdentifier).Value = accountId;

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

	public static DataTable InventorySlots(SqlConnection conn, SqlTransaction trans, Guid heroId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_InventorySlots";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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

	public static int AddInventorySlot(SqlConnection conn, SqlTransaction trans, 
		Guid heroId, int nSlotIndex, int nSlotType, Guid heroMainGearId, int nSubGearId, int nItemId, int nItemCount, bool itemOwned)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddInventorySlot";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
			sc.Parameters.Add("@nSlotIndex", SqlDbType.Int).Value = nSlotIndex;
			sc.Parameters.Add("@nSlotType", SqlDbType.Int).Value = nSlotType;
			sc.Parameters.Add("@heroMainGearId", SqlDbType.UniqueIdentifier).Value = heroMainGearId;
			sc.Parameters.Add("@nSubGearId", SqlDbType.Int).Value = nSubGearId;
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

	public static int AddHeroMainGear(SqlConnection conn, SqlTransaction trans, 
		Guid heroMainGearid, Guid heroId, int nMainGearId, int nEnchantLevel, bool owned)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddHeroMainGear";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroMainGearid", SqlDbType.UniqueIdentifier).Value = heroMainGearid;
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
			sc.Parameters.Add("@nMainGearId", SqlDbType.Int).Value = nMainGearId;
			sc.Parameters.Add("@nEnchantLevel", SqlDbType.Int).Value = nEnchantLevel;
			sc.Parameters.Add("@owned", SqlDbType.Bit).Value = owned;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int AddHeroMainGearOptionAttr(SqlConnection conn, SqlTransaction trans, 
		Guid heroMainGearId, int nIndex, int nGrade, int nAttrId, long lnAttrValueId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddHeroMainGearOptionAttr";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroMainGearId", SqlDbType.UniqueIdentifier).Value = heroMainGearId;
			sc.Parameters.Add("@nIndex", SqlDbType.Int).Value = nIndex;
			sc.Parameters.Add("@nGrade", SqlDbType.Int).Value = nGrade;
			sc.Parameters.Add("@nAttrId", SqlDbType.Int).Value = nAttrId;
			sc.Parameters.Add("@lnAttrValueId", SqlDbType.BigInt).Value = lnAttrValueId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}
	public static int Hero_Connection(SqlConnection conn, SqlTransaction trans, Guid heroId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Hero_Connection";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			return -99;
		}
	}

	public static int AddHeroSubGear(SqlConnection conn, SqlTransaction trans, Guid heroId, int nSubGearId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddHeroSubGear";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
			sc.Parameters.Add("@nSubGearId", SqlDbType.Int).Value = nSubGearId;
			sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			sc.ExecuteNonQuery();

			return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.StackTrace);
			return -99;
		}
	}

	public static int AddMail(SqlConnection conn, SqlTransaction trans, Guid mailId, Guid heroId, int nTitleType, string sTitle, int nContentType, string sContent, int nDurationDay)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_AddMail";
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

    public static int AddGMMail(SqlConnection conn, SqlTransaction trans, Guid mailId, Guid heroId, int nTitleType, string sTitle, int nContentType, string sContent, int nDurationDay, int nAttachmentType,
    int nItemId, int nItemCount, bool itemOwned, int nGearId, int nGearGrade, bool gearOwned, int nGearEnchantLevel, int nGearLevel, int nGearRoyalType)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdminGame_AddMail";
            sc.Parameters.Clear();
            sc.Parameters.Add("@mailId", SqlDbType.UniqueIdentifier).Value = mailId;
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nTitleType", SqlDbType.Int).Value = nTitleType;
            sc.Parameters.Add("@sTitle", SqlDbType.NVarChar, 100).Value = sTitle;
            sc.Parameters.Add("@nContentType", SqlDbType.Int).Value = nContentType;
            sc.Parameters.Add("@sContent", SqlDbType.NVarChar, sContent.Length).Value = sContent;
            sc.Parameters.Add("@nDurationDay", SqlDbType.Int).Value = nDurationDay;
            sc.Parameters.Add("@nAttachmentType", SqlDbType.Int).Value = nAttachmentType;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nItemCount", SqlDbType.Int).Value = nItemCount;
            sc.Parameters.Add("@itemOwned", SqlDbType.Int).Value = itemOwned;
            sc.Parameters.Add("@nGearId", SqlDbType.Int).Value = nGearId;
            sc.Parameters.Add("@nGearGrade", SqlDbType.Int).Value = nGearGrade;
            sc.Parameters.Add("@gearOwned", SqlDbType.Int).Value = gearOwned;
            sc.Parameters.Add("@nGearEnchantLevel", SqlDbType.Int).Value = nGearEnchantLevel;
            sc.Parameters.Add("@nGearLevel", SqlDbType.Int).Value = nGearLevel;
            sc.Parameters.Add("@nGearRoyalType", SqlDbType.Int).Value = nGearRoyalType;
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


    public static DataTable HeroSearchTargets(SqlConnection conn, SqlTransaction trans, int nType, string sTargets)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_HeroSearchTargets";
			sc.Parameters.Clear();
			sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
			sc.Parameters.Add("@sTargets", SqlDbType.NVarChar, sTargets.Length).Value = sTargets;

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

	public static int UpdateHero(SqlConnection conn, SqlTransaction trans, Guid heroId, int nJobId, int nLevel, long lnExp, long lnGold, int nLak, 
		int nOwnDia, int nVipPoint, int nStamina, int nExploitPoint, int nPaidInventorySlotCount, int nGmTargetMainQuestNo)
    {
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateHero";
			sc.Parameters.Clear();
			sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
			sc.Parameters.Add("@nJobId", SqlDbType.Int).Value = nJobId;
			sc.Parameters.Add("@nLevel", SqlDbType.Int).Value = nLevel;
			sc.Parameters.Add("@lnExp", SqlDbType.BigInt).Value = lnExp;
			sc.Parameters.Add("@lnGold", SqlDbType.BigInt).Value = lnGold;
			sc.Parameters.Add("@nLak", SqlDbType.Int).Value = nLak;
			sc.Parameters.Add("@nOwnDia", SqlDbType.Int).Value = nOwnDia;
			sc.Parameters.Add("@nVipPoint", SqlDbType.Int).Value = nVipPoint;
			sc.Parameters.Add("@nStamina", SqlDbType.Int).Value = nStamina;
			sc.Parameters.Add("@nExploitPoint", SqlDbType.Int).Value = nExploitPoint;
			sc.Parameters.Add("@nPaidInventorySlotCount", SqlDbType.Int).Value = nPaidInventorySlotCount;
			sc.Parameters.Add("@nGmTargetMainQuestNo", SqlDbType.Int).Value = nGmTargetMainQuestNo;
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

	public static int UpdateAccount(SqlConnection conn, SqlTransaction trans, Guid accountId, int nBaseUnOwnDia, int nBonusUnOwnDia, int nVipPoint)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateAccount";
			sc.Parameters.Clear();
			sc.Parameters.Add("@accountId", SqlDbType.UniqueIdentifier).Value = accountId;
			sc.Parameters.Add("@nBaseUnOwnDia", SqlDbType.Int).Value = nBaseUnOwnDia;
			sc.Parameters.Add("@nBonusUnOwnDia", SqlDbType.Int).Value = nBonusUnOwnDia;
			sc.Parameters.Add("@nVipPoint", SqlDbType.Int).Value = nVipPoint;
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

	public static DataTable VipLevelRewards(SqlConnection conn, SqlTransaction trans, Guid accountId)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_VipLevelRewards";
			sc.Parameters.Clear();
			sc.Parameters.Add("@accountId", SqlDbType.UniqueIdentifier).Value = accountId;

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

	public static DataTable Heros(SqlConnection conn, SqlTransaction trans)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_Heros";
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

	public static int SqlBulkCopy(SqlConnection conn, SqlTransaction tran, DataTable dt)
	{
		try
		{
			var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, tran);

			foreach (DataColumn col in dt.Columns)
			{
				bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
			}

			bulkCopy.BulkCopyTimeout = 600;
			bulkCopy.DestinationTableName = dt.TableName;
			bulkCopy.WriteToServer(dt);

			return 0;
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.Message);
			HttpContext.Current.Response.Write(ex.StackTrace);
			return -99;
		}
	}

	public static DataRow ServerTime(SqlConnection conn, SqlTransaction trans)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_ServerTime";
		sc.Parameters.Clear();

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static DataRow System(SqlConnection conn, SqlTransaction trans)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspAdmin_System";
		sc.Parameters.Clear();

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows.Count == 0 ? null : dt.Rows[0];
	}

	public static int UpdateSystem(SqlConnection conn, SqlTransaction trans, DateTime dtServerOpenDate)
	{
		try
		{
			SqlCommand sc = new SqlCommand();
			sc.Connection = conn;
			sc.Transaction = trans;
			sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_UpdateSystem_ServerOpenTime";
			sc.Parameters.Clear();
			sc.Parameters.Add("dtServerOpenDate", SqlDbType.Date).Value = dtServerOpenDate;
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

    public static DataTable HeroMainQuests(SqlConnection conn, SqlTransaction trans, Guid heroId, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_HeroMainQuest";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
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

    public static int UpdateHeroMainQuest(SqlConnection conn, SqlTransaction trans, Guid heroId, int nToMainQuestNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateHeroMainQuest";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nToMainQuestNo", SqlDbType.Int).Value = nToMainQuestNo;

            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }

	public static int NationWarInit(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
			sc.CommandText = "uspAdmin_NationWarInit";
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

    public static DataTable ServerNotices(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ServerNotices";
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

    public static int AddServerNotice(SqlConnection conn, SqlTransaction trans, Guid noticeId, string sContent, DateTime displayTime, int displayInterval, int repetitionCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddServerNotice";
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
            HttpContext.Current.Response.Write(ex.Message);
            return -99;
        }
    }
    public static int DeleteServerNotice(SqlConnection conn, SqlTransaction trans, Guid noticeId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DelServerNotice";
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

    public static int AddMailAttachment(SqlConnection conn, SqlTransaction trans, Guid mailId, int nAttachmentNo, int nItemId, int nItemCount, bool itemOwned)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddMailAttachment";
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
    //2018-10-10
  
    public static int UpdateHero_Account(SqlConnection conn, SqlTransaction trans, Guid heroId, Guid accountId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateHero_Account";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@accountId", SqlDbType.UniqueIdentifier).Value = accountId;
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

    public static int UpdateHero_Stat(SqlConnection conn, SqlTransaction trans, Guid heroId, int nStatStrength, int nStatAgility, int nStatStamina, int nStatIntelligence, int nStatPoint, int nStrength, int nAgility, int nStamina, int nIntelligence)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateAccountHero_Stat";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.Int).Value = heroId;
            sc.Parameters.Add("@nStatStrength", SqlDbType.Int).Value = nStatStrength;
            sc.Parameters.Add("@nStatAgility", SqlDbType.Int).Value = nStatAgility;
            sc.Parameters.Add("@nStatStamina", SqlDbType.Int).Value = nStatStamina;
            sc.Parameters.Add("@nStatIntelligence", SqlDbType.Int).Value = nStatIntelligence;
            sc.Parameters.Add("@nStatPoint", SqlDbType.Int).Value = nStatPoint;
            sc.Parameters.Add("@nStrength", SqlDbType.Int).Value = nStrength;
            sc.Parameters.Add("@nAgility", SqlDbType.Int).Value = nAgility;
            sc.Parameters.Add("@nStamina", SqlDbType.Int).Value = nStamina;
            sc.Parameters.Add("@nIntelligence", SqlDbType.Int).Value = nIntelligence;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static DataTable HeroConstellations(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AccountHeroConstellations";
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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

    public static int HeroConstellationStepEntryReset(SqlConnection conn, SqlTransaction trans, Guid heroId, int nConstellationId, int nStep, int nCycle, int nEntryId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AccountHeroConstellationStepEntryReset";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nConstellationId", SqlDbType.Int).Value = nConstellationId;
            sc.Parameters.Add("@nStep", SqlDbType.Int).Value = nStep;
            sc.Parameters.Add("@nCycle", SqlDbType.Int).Value = nCycle;
            sc.Parameters.Add("@nEntryId", SqlDbType.Int).Value = nEntryId;

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
    public static DataTable MonsterBooks(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_MonsterBooks";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static DataTable Friends(SqlConnection conn, SqlTransaction trans, Guid heroId, int nRowsPerPage, int nPage, out int nTotalCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_Friends";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            //sc.Parameters.Add("@nFriendType", SqlDbType.Int).Value = nFriendType;
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
    public static int DelFriend(SqlConnection conn, SqlTransaction trans, Guid heroId, Guid friendId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DelFriend";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@friendId", SqlDbType.UniqueIdentifier).Value = friendId;
            sc.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            sc.ExecuteNonQuery();

            return Convert.ToInt32(sc.Parameters["ReturnValue"].Value);
        }
        catch (Exception ex)
        {
            return -99;
        }
    }
    public static DataTable ForcedDisconnectionTasks(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_ForcedDisconnectionTasks";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    //10-12
    public static DataRow FirstChargeEventRewardLog(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_FirstChargeEventRewardLog";
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

    public static int DelFirstChargeEventRewardLog(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DelFirstChargeEventRewardLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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

    public static DataTable AdminFirstChargeEventLogs(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AdminFirstChargeEventLogs";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static DataTable DailyChargeEntryRewardLogs(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DailyChargeEntryRewardLogs";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static DataTable AdminDailyAccumulateChargeDiaLogs(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AdminDailyAccumulateChargeDiaLogs";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static int UpdateHero_DailyAccumulateChargeDia(SqlConnection conn, SqlTransaction trans, Guid heroId, int nDailyAccumulateChargeDia)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateAccountHero_DailyAccumulateChargeDia";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nDailyAccumulateChargeDia", SqlDbType.Int).Value = nDailyAccumulateChargeDia;

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
    public static DataRow SystemDateTimeOffset(SqlConnection conn, SqlTransaction trans)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_SystemDateTimeOffset";

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
    public static int AddAdminFirstChargeEventLog(SqlConnection conn, SqlTransaction trans, Guid heroId, bool bRewardReceived, string sReason, string sAdminId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAdminFirstChargeEventLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@bRewardReceived", SqlDbType.Bit).Value = bRewardReceived;
            sc.Parameters.Add("@sReason", SqlDbType.NVarChar, 100).Value = sReason;
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
    public static int AddAdminDailyAccumulateChargeDiaLog(SqlConnection conn, SqlTransaction trans, Guid heroId, int nOldDailyAccumulateChargeDia, int nDailyAccumulateChargeDia, string sReason, string sAdminId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAdminDailyAccumulateChargeDiaLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nOldDailyAccumulateChargeDia", SqlDbType.Int).Value = nOldDailyAccumulateChargeDia;
            sc.Parameters.Add("@nDailyAccumulateChargeDia", SqlDbType.Int).Value = nDailyAccumulateChargeDia;
            sc.Parameters.Add("@sReason", SqlDbType.NVarChar, 100).Value = sReason;
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
    public static int AddForcedDisconnectionTask(SqlConnection conn, SqlTransaction trans,  Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddForcedDisconnectionTask";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static int AddHeroBlock(SqlConnection conn, SqlTransaction trans,  Guid heroId, string sReason, int nType, string sAdminId, DateTimeOffset dtoBlockTime)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAccountHeroBlock";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@sReason", SqlDbType.NVarChar, sReason.Length).Value = sReason;
            sc.Parameters.Add("@nType", SqlDbType.Int).Value = nType;
            sc.Parameters.Add("@sAdminId", SqlDbType.VarChar, sAdminId.Length).Value = sAdminId;
            sc.Parameters.Add("@dtoBlockTime", SqlDbType.DateTimeOffset).Value = dtoBlockTime;

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
    public static DataTable WarehouseSlots(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_WarehouseSlots";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static int UpdateInventoryWarehouse(SqlConnection conn, SqlTransaction trans, Guid heroId, int nSlotNo, int nCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_UpdateInventoryWarehouseSlots";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nSlotNo", SqlDbType.Int).Value = nSlotNo;
            sc.Parameters.Add("@nCount", SqlDbType.Int).Value = nCount;

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
    public static int DelInventoryWarehouse(SqlConnection conn, SqlTransaction trans, Guid heroId, int nSlotNo)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_DelInventoryWarehouseSlots";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nSlotNo", SqlDbType.Int).Value = nSlotNo;

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
    public static int AddAdminInventoryWarehouseSlotLog(SqlConnection conn, SqlTransaction trans, Guid heroId, int nSlotNo, int nSlotType, Guid uidHeroGearId,
        int nItemId, int nCount, bool bOwned, int nLogType, int nModifiedItemCount, string sReason, string sAdminId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AddAdminInventoryWarehouseSlotsLog";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nSlotNo", SqlDbType.Int).Value = nSlotNo;
            sc.Parameters.Add("@nSlotType", SqlDbType.Int).Value = nSlotType;
            sc.Parameters.Add("@uidHeroGearId", SqlDbType.UniqueIdentifier).Value = uidHeroGearId;
            sc.Parameters.Add("@nItemId", SqlDbType.Int).Value = nItemId;
            sc.Parameters.Add("@nCount", SqlDbType.Int).Value = nCount;
            sc.Parameters.Add("@bOwned", SqlDbType.Bit).Value = bOwned;
            sc.Parameters.Add("@nLogType", SqlDbType.Int).Value = nLogType;
            sc.Parameters.Add("@nModifiedItemCount", SqlDbType.Int).Value = nModifiedItemCount;
            sc.Parameters.Add("@sReason", SqlDbType.NVarChar, 100).Value = sReason;
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
    public static DataTable EquippedGears(SqlConnection conn, SqlTransaction trans, Guid heroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_EquippedGears"; 
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;

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
    public static DataRow AccountHeroGear(SqlConnection conn, SqlTransaction trans, Guid heroGearId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AccountHeroGear";
            sc.Parameters.Add("@heroGearId", SqlDbType.UniqueIdentifier).Value = heroGearId;

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
    //별자리
    public static DataTable AccountHeroConstellations(SqlConnection conn, SqlTransaction trans, Guid nAccountHeroId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AccountHeroConstellations";
            sc.Parameters.Add("@nAccountHeroId", SqlDbType.Int).Value = nAccountHeroId;

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
    public static int AccountHeroConstellationStepEntryReset(SqlConnection conn, SqlTransaction trans, Guid nAccountHeroId, int nConstellationId, int nStep, int nCycle, int nEntryId)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdmin_AccountHeroConstellationStepEntryReset";
            sc.Parameters.Clear();
            sc.Parameters.Add("@nAccountHeroId", SqlDbType.Int).Value = nAccountHeroId;
            sc.Parameters.Add("@nConstellationId", SqlDbType.Int).Value = nConstellationId;
            sc.Parameters.Add("@nStep", SqlDbType.Int).Value = nStep;
            sc.Parameters.Add("@nCycle", SqlDbType.Int).Value = nCycle;
            sc.Parameters.Add("@nEntryId", SqlDbType.Int).Value = nEntryId;

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

    public static int UpdateInventorySlot_ItemCount(SqlConnection conn, SqlTransaction trans, Guid m_nHeroId, int nSlotIndex, int nItemCount)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdminGame_UpdateInventorySlot_ItemCount";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = m_nHeroId;
            sc.Parameters.Add("@nSlotIndex", SqlDbType.Int).Value = nSlotIndex;
            sc.Parameters.Add("@nItemCount\t", SqlDbType.Int).Value = nItemCount;
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

    public static int DeleteInventorySlot(SqlConnection conn, SqlTransaction trans, Guid heroId, int nSlotIndex)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = trans;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdminGame_DeleteInventorySlot";
            sc.Parameters.Clear();
            sc.Parameters.Add("@heroId", SqlDbType.UniqueIdentifier).Value = heroId;
            sc.Parameters.Add("@nSlotIndex", SqlDbType.Int).Value = nSlotIndex;
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

    public static int AddMailAttachmentGearOptionAttr(SqlConnection conn, SqlTransaction tran, Guid mailId, int nOptionIndex, int nAttrId, int @nValue)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = tran;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdminGame_AddMailAttachmentGearOptionAttr";
            sc.Parameters.Clear();
            sc.Parameters.Add("@mailId", SqlDbType.UniqueIdentifier).Value = mailId;
            sc.Parameters.Add("@nOptionIndex", SqlDbType.Int).Value = nOptionIndex;
            sc.Parameters.Add("@nAttrId", SqlDbType.Int).Value = nAttrId;
            sc.Parameters.Add("@nValue", SqlDbType.Int).Value = @nValue;

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

    public static DataRow HeroMainQuest_Last(SqlConnection conn, SqlTransaction trans, Guid m_nHeroId)
    {
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.Transaction = trans;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "uspAdmin_HeroMainQuest";
        sc.Parameters.Clear();
        sc.Parameters.Add("@mailId", SqlDbType.UniqueIdentifier).Value = m_nHeroId;
        sc.Parameters.Add("@nRowsPerPage", SqlDbType.Int).Value = 9999;
        sc.Parameters.Add("@nPage", SqlDbType.Int).Value = 1;
        DataTable dt = new DataTable();

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sc;
        sda.Fill(dt);

        return dt.Rows.Count == 0 ? null : dt.Rows[dt.Rows.Count - 1];
    }

    public static int AddMailTextArgument(SqlConnection conn, SqlTransaction tran, Guid mailId, int nArgsType, int nArgsIndex, int nValueType, string sValue)
    {
        try
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            sc.Transaction = tran;
            sc.CommandType = CommandType.StoredProcedure;
            sc.CommandText = "uspAdminGame_AddMailTextArgument";
            sc.Parameters.Clear();
            sc.Parameters.Add("@mailId", SqlDbType.UniqueIdentifier).Value = mailId;
            sc.Parameters.Add("@nType", SqlDbType.Int).Value = nArgsType;
            sc.Parameters.Add("@nIndex", SqlDbType.Int).Value = nArgsIndex;
            sc.Parameters.Add("@nValueType", SqlDbType.Int).Value = nValueType;
            sc.Parameters.Add("@sValue", SqlDbType.Int).Value = sValue;

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
}