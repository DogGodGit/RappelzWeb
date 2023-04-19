using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Biz의 요약 설명입니다.
/// </summary>
public class Biz
{
    public Biz() { }

    public static int AddUserId(SqlConnection conn, Guid uidNewId, int nType, string sSecret, string sAccessSecret)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = DacUser.AddUser(conn, tran, uidNewId, nType, sSecret, sAccessSecret);

            //if (nType == 1)
            //{
            //    nRetVal = DacUser.AddGuestUser(conn, tran, uidNewId);
            //}

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

    public static int UpdateHeroMainQuest(SqlConnection conn, Guid heroId, int nToMainQuestNo)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = Dac.UpdateHeroMainQuest(conn, tran, heroId, nToMainQuestNo);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                return nRetVal;
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
    public static int DelFirstChargeEventRewardLog(SqlConnection conn, Guid heroId, bool bRewardReceived, string sReason, string sAdminId)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = Dac.DelFirstChargeEventRewardLog(conn, tran, heroId);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                return -1;
            }

            nRetVal = Dac.AddAdminFirstChargeEventLog(conn, tran, heroId, bRewardReceived, sReason, sAdminId);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                return -2;
            }

            tran.Commit();
            tran.Dispose();

            return 0;
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
    public static int UpdateHero_DailyAccumulateChargeDia(SqlConnection conn, Guid heroId, int nOldDailyAccumulateChargeDia, int nDailyAccumulateChargeDia, string sReason, string sAdminId)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = Dac.UpdateHero_DailyAccumulateChargeDia(conn, tran, heroId, nDailyAccumulateChargeDia);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                return -1;
            }

            nRetVal = Dac.AddAdminDailyAccumulateChargeDiaLog(conn, tran, heroId, nOldDailyAccumulateChargeDia, nDailyAccumulateChargeDia, sReason, sAdminId);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                return -2;
            }

            tran.Commit();
            tran.Dispose();

            return 0;
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

    public static int AddForcedDisconnectionTask(SqlConnection conn, Guid heroId, bool bRewardReceived, string sReason, DateTimeOffset date, string sUser)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = Dac.AddForcedDisconnectionTask(conn, tran, heroId);

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

    internal static int Hero_Update(SqlConnection conn, Guid m_nHeroId, int nLevel, long lnExp, int nBaseUnOwnDia, int nBonusUnOwnDia, int nOwnDia, long lnGold, int nJobPoint, int nLak, int nDeadCount)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = Dac.UpdateHero(conn, tran, m_nHeroId, 0, nLevel, lnExp, lnGold, nLak, nOwnDia, 0, 0, 0, 0, 0);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                return -1;
            }

            DataRow drHero = Dac.Hero(conn, null, m_nHeroId);
            if (drHero == null)
            {
                tran.Rollback();
                tran.Dispose();
                return -1;
            }

            if (Dac.UpdateAccount(conn, tran, Guid.Parse(drHero["accountId"].ToString()), nBaseUnOwnDia, nBonusUnOwnDia, 0) != 0)
            {
                tran.Rollback();
                tran.Dispose();

                ComUtil.MsgBox("영웅 정보 수정 실패", "history.back();");
                return -1;
            }

            tran.Commit();
            tran.Dispose();

            return nRetVal;
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

    internal static int AddInventoryGear(SqlConnection conn, Guid m_nHeroId, int nSlotIndex, int nGearId, int nGrade, bool isOwned)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = 0;// Dac.AddInventoryGear(conn, tran, heroId); UNDONE

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

    public static int DeleteInventorySlot(SqlConnection conn, Guid m_nHeroId, int nInventoryType, int nSlotNo, Guid uidHeroGearId)
    {
        SqlTransaction tran = null;

        try
        {
            tran = conn.BeginTransaction();

            int nRetVal = Dac.DeleteInventorySlot(conn, tran, m_nHeroId,nSlotNo);

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

    internal static int ManageHeroMainQuest(SqlConnection conn, Guid m_nHeroId, int nMainQuestNo)
    {
        throw new NotImplementedException();
    }
}