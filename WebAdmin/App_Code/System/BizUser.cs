using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for BizUser
/// </summary>
public class BizUser
{
	public BizUser() { }

	public static int UpdateGameAssetBundleSelected(SqlConnection conn, bool bAndroid, bool biOS, string sBundleNos)
	{
		SqlTransaction tran = null;

		try
		{
			tran = conn.BeginTransaction();

			int nRetVal = DacUser.UpdateGameAssetBundleSelected(conn, tran, bAndroid, biOS, sBundleNos);
			if (nRetVal != 0)
			{
				tran.Rollback();
				tran.Dispose();
				return -1;
			}

			tran.Commit();
			tran.Dispose();

			return nRetVal;
		}
		catch (Exception ex)
		{
			if (tran != null)
			{
				tran.Rollback();
				tran.Dispose();
			}

			return -999;
		}
	}

	public static int ResetSupportedLanguage(SqlConnection conn, int[] nArrLanguageIds)
	{
		SqlTransaction tran = null;

		try
		{
			tran = conn.BeginTransaction();

			int nRetVal = DacUser.DeleteSupportedLanguages(conn, tran);

			if (nRetVal != 0)
			{
				tran.Rollback();
				tran.Dispose();
				return -1;
			}

			for (int i = 0; i < nArrLanguageIds.Length; i++)
			{
				nRetVal = DacUser.AddSupportedLanguage(conn, tran, nArrLanguageIds[i]);
				if (nRetVal != 0)
				{
					tran.Rollback();
					tran.Dispose();
					return -2;
				}
			}

			tran.Commit();
			tran.Dispose();

			return 0;
		}
		catch (Exception ex)
		{
			HttpContext.Current.Response.Write(ex.Message);
			HttpContext.Current.Response.Write(ex.StackTrace);
			if (tran != null)
			{
				tran.Rollback();
				tran.Dispose();
			}

			return -999;
		}
	}
}