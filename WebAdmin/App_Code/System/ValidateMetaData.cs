using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// ValidateMetaData의 요약 설명입니다.
/// </summary>
public class ValidateMetaData
{
	public ValidateMetaData()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

	public static void Validate(StringBuilder sb, string sFkTable, string sPkTable, string[] sArrFkColumns, string sSelectConditions)
	{
		ValidateMetaData.Validate(sb, sFkTable, sPkTable, sArrFkColumns, sArrFkColumns, sSelectConditions);
	}

	public static void Validate(StringBuilder sb, string sFkTable, string sPkTable, string[] sArrFkColumns, string[] sArrPkColumns, string sSelectConditions)
	{
		DataRowCollection drc = null;

		StringBuilder sbColumns = new StringBuilder();
		StringBuilder sbJoinConditions = new StringBuilder();
		StringBuilder sbSelectConditions = new StringBuilder();

		try
		{
			for (int i = 0; i < sArrFkColumns.Length; i++)
			{
				if (sbColumns.Length > 0)
					sbColumns.Append(",");
				sbColumns.Append(string.Format("{0}.{1}", sFkTable, sArrFkColumns[i]));

				if (sbJoinConditions.Length > 0)
					sbJoinConditions.Append(" AND ");
				sbJoinConditions.Append(string.Format("{0}.{1} = {2}.{3}", sFkTable, sArrFkColumns[i], sPkTable, sArrPkColumns[i]));
			}

			sbSelectConditions.Append(string.Format("{0}.{1} is null", sPkTable, sArrPkColumns[sArrPkColumns.Length - 1]));
			if (sSelectConditions != "")
				sbSelectConditions.Append(" AND " + sSelectConditions);

			SqlConnection conn = DBUtil.GetUserDBConn();
			drc = InvalidatedDatas(conn, null, sPkTable, sFkTable, sbColumns.ToString(), sbJoinConditions.ToString(), sbSelectConditions.ToString());
			DBUtil.CloseDBConn(conn);

			if (drc.Count > 0)
			{
				sb.Append("<span class=\"red\">");
				sb.AppendLine("================================================================================================");
				sb.AppendLine("Invalidated : <strong>" + sbJoinConditions.ToString().Replace("=", "에는 있고 ").Replace("AND", "에는 없음. ") + " 에는 없음.</strong>");
				sb.AppendLine("------------------------------------------------------------------------------------------------");
				for (int i = 0; i < drc.Count; i++)
				{
					sb.Append("[" + sFkTable + "] - ");
					for (int j = 0; j < sArrFkColumns.Length; j++)
						sb.Append(sArrFkColumns[j] + "(" + drc[i][sArrFkColumns[j]].ToString() + ") ");

					sb.AppendLine();
				}
				//sb.Append("================================================================================================");
				sb.AppendLine("</span>");
			}
			//else
			//{
			//    sb.Append("<span class=\"green\"> Validated : ");
			//    sb.AppendLine("[" + sFkTable + "] - [" + sPkTable + "]");
			//    sb.Append("</span>");
			//}

			sbColumns.Clear();
			sbJoinConditions.Clear();
			sbSelectConditions.Clear();

		}
		catch (Exception ex)
		{
			sb.Append("<span class=\"black\">Error : ");
			//sb.AppendLine(sbColumns.ToString());
			sb.AppendLine(sbJoinConditions.ToString());
			//sb.AppendLine(sbSelectConditions.ToString());
			sb.Append("</span>");
		}
	}

	public static DataRowCollection InvalidatedDatas(SqlConnection conn, SqlTransaction trans, string sPkTable, string sFkTable, string sColumns, string sJoinConditions, string sSelectConditions)
	{
		SqlCommand sc = new SqlCommand();
		sc.Connection = conn;
		sc.Transaction = trans;
		sc.CommandType = CommandType.StoredProcedure;
		sc.CommandText = "uspTool_ValidateMetaData";
		sc.Parameters.Clear();
		sc.Parameters.Add("@sPkTable", SqlDbType.VarChar, 40).Value = sPkTable;
		sc.Parameters.Add("@sFkTable", SqlDbType.VarChar, 40).Value = sFkTable;
		sc.Parameters.Add("@sColumns", SqlDbType.VarChar, sColumns.Length).Value = sColumns;
		sc.Parameters.Add("@sJoinConditions", SqlDbType.VarChar, sJoinConditions.Length).Value = sJoinConditions;
		sc.Parameters.Add("@sSelectConditions", SqlDbType.VarChar, sSelectConditions.Length).Value = sSelectConditions;

		DataTable dt = new DataTable();

		SqlDataAdapter sda = new SqlDataAdapter();
		sda.SelectCommand = sc;
		sda.Fill(dt);

		return dt.Rows;
	}
}