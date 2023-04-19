using System;
using System.Data;
using System.Data.SqlClient;

public partial class Game_AccountHero_Info : System.Web.UI.Page
{
    protected int m_nGameServerId = 0;
    protected Guid m_nHeroId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //======================================================================
        ComUtil.SetNoBrowserCache();

        //======================================================================
        // 파라미터
        //======================================================================
        m_nGameServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_nHeroId = ComUtil.GetRequestGuid("AHID", RequestMethod.Get);

        if (IsPostBack)
            return;

        try
        {
            PageLoad();
        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception ex)
        {
            ComUtil.ErrorLogMsg(ex);
        }
    }

    private void PageLoad()
    {
        WBtnUpdate.Attributes.Add("onclick", "return confirm('수정하시겠습니까?');");

        //DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(m_nGameServerId));
        DataRow dr = Dac.Hero(conn, null, m_nHeroId);
        //DB연결끊기
        DBUtil.CloseDBConn(conn);

        if (dr == null)
            return;

        WLtlJobId.Text = Convert.ToString(dr["jobId"]);
        WLtlNationId.Text = Convert.ToString(dr["nationId"]);
        WLtlName.Text = Convert.ToString(dr["name"]);
        WTxtLevel.Text = Convert.ToString(dr["level"]);

        WTxtExp.Text = Convert.ToString(dr["exp"]);
        WLtlBattlePower.Text = Convert.ToString(dr["battlePower"]);
        WLtlHp.Text = Convert.ToString(dr["hp"]);
        WLtlRealMaxHp.Text = Convert.ToString(dr["realMaxHp"]);

        WLtlRealPhysicalOffense.Text = Convert.ToString(dr["realPhysicalOffense"]);
        WLtlRealMagicalOffense.Text = Convert.ToString(dr["realMagicalOffense"]);
        WLtlRealPhysicalDefense.Text = Convert.ToString(dr["realPhysicalDefense"]);
        WLtlRealMagicalDefense.Text = Convert.ToString(dr["realMagicalDefense"]);

        WTxtBaseUnOwnDia.Text = Convert.ToString(dr["baseUnOwnDia"]);
        WTxtBonusUnOwnDia.Text = Convert.ToString(dr["bonusUnOwnDia"]);
        WTxtOwnDia.Text = Convert.ToString(dr["ownDia"]);
        WTxtGold.Text = Convert.ToString(dr["gold"]);

        WLtlInventorySlotCount.Text = Convert.ToString(dr["inventorySlotCount"]);
        WTxtJobPoint.Text = Convert.ToString(dr["jobPoint"]);
        WTxtLak.Text = Convert.ToString(dr["lak"]);
        WLtlNamingTutorialCompleted.Text = Convert.ToBoolean(dr["namingTutorialCompleted"]) ? "완료" : "미완료";

        WLtlLastLoginTime.Text = Convert.ToString(dr["lastLoginTime"]);
        WLtlLastLogoutTime.Text = Convert.ToString(dr["lastLogoutTime"]);
        WLtlPrevContinentDeadTime.Text = Convert.ToString(dr["prevContinentDeadTime"]);
        WLtlLastContinentDeadTime.Text = Convert.ToString(dr["lastContinentDeadTime"]);

        WLtlLastLocationId.Text = Convert.ToString(dr["lastLocationId"]);
        WLtlLastLocationParam.Text = Convert.ToString(dr["lastLocationParam"]);
        WLtlLastInstanceId.Text = Convert.ToString(dr["lastInstanceId"]);
        WLtlLastPosition.Text = string.Format("x:{0}<br />y:{1}<br />z:{2}<br />yR:{3}", Convert.ToString(dr["lastXPosition"]), Convert.ToString(dr["lastYPosition"]), Convert.ToString(dr["lastZPosition"]), Convert.ToString(dr["lastYRotation"]));

        WLtlPreviousContinentId.Text = Convert.ToString(dr["previousContinentId"]);
        WLtlPreviousPosition.Text = string.Format("x:{0}<br />y:{1}<br />z:{2}<br />yR:{3}", Convert.ToString(dr["previousXPosition"]), Convert.ToString(dr["previousYPosition"]), Convert.ToString(dr["previousZPosition"]), Convert.ToString(dr["previousYRotation"]));
        WLtlAccumulationLoginDayCount.Text = Convert.ToString(dr["accumulationLoginDayCount"]);
        WTxtDeadCount.Text = Convert.ToString(dr["deadCount"]);

        WLtlWeeklyQuestFeverStep.Text = Convert.ToString(dr["weeklyQuestFeverStep"]);
        WLtlWeeklyQuestFeverStartTime.Text = Convert.ToString(dr["weeklyQuestFeverStartTime"]);
        WLtlWeeklyQuestFeverProgressCount.Text = Convert.ToString(dr["weeklyQuestFeverProgressCount"]);
        WLtlChattingBubbleDisplayed.Text = Convert.ToString(dr["chattingBubbleDisplayed"]);

        WLtlEquippedSkinId.Text = Convert.ToString(dr["equippedSkinId"]);
        WLtlSkinHelmetVisible.Text = Convert.ToString(dr["skinHelmetVisible"]);
        WLtlLevelUpdateTime.Text = Convert.ToString(dr["levelUpdateTime"]);
        WLtlBattlePowerUpdateTime.Text = Convert.ToString(dr["battlePowerUpdateTime"]);

        WLtlHpPotionAutoEnabled.Text = Convert.ToString(dr["hpPotionAutoEnabled"]);
        WLtlAutoCountattackEnabled.Text = Convert.ToString(dr["autoCountattackEnabled"]);
        WLtlMonsterBattleEvasionEnabled.Text = Convert.ToString(dr["monsterBattleEvasionEnabled"]);
        WLtlBattleAreaType.Text = Convert.ToString(dr["battleAreaType"]);

        WLtlLootingGearMinGrade.Text = Convert.ToString(dr["lootingGearMinGrade"]);
        WLtlLootingItemMinGrade.Text = Convert.ToString(dr["lootingItemMinGrade"]);

        //===
        WLtlRegTime.Text = Convert.ToString(dr["regTime"]);
        WLtlCreated.Text = Convert.ToString(dr["created"]);
        WLtlDeleted.Text = Convert.ToString(dr["deleted"]);
        WLtlDelTime.Text = Convert.ToString(dr["delTime"]);
    }

    protected void WBtnUpdate_OnClick(object sender, EventArgs e)
    {
        try
        {
            int nLevel = Convert.ToInt32(WTxtLevel.Text.Trim());
            long lnExp = Convert.ToInt64(WTxtExp.Text.Trim());
            int nBaseUnOwnDia = Convert.ToInt32(WTxtBaseUnOwnDia.Text.Trim());
            int nBonusUnOwnDia = Convert.ToInt32(WTxtBonusUnOwnDia.Text.Trim());
            int nOwnDia = Convert.ToInt32(WTxtOwnDia.Text.Trim());
            long lnGold = Convert.ToInt64(WTxtGold.Text.Trim());
            int nJobPoint = Convert.ToInt32(WTxtJobPoint.Text.Trim());
            int nLak = Convert.ToInt32(WTxtLak.Text.Trim());
            int nDeadCount = Convert.ToInt32(WTxtDeadCount.Text.Trim());

            //DB연결
            SqlConnection conn = DBUtil.GetGameDBConn(m_nGameServerId);

            // 접속중 체크
            if (Dac.Hero_Connection(conn, null, m_nHeroId) != 0)
            {
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("영웅이 접속중입니다.", "history.back();");
                return;
            }

            // 메인퀘스트 변경.
            int nRet = Biz.Hero_Update(conn, m_nHeroId, nLevel, lnExp, nBaseUnOwnDia, nBonusUnOwnDia, nOwnDia, lnGold, nJobPoint, nLak, nDeadCount);

            //DB연결 끊기
            DBUtil.CloseDBConn(conn);

            //등록결과
            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("영웅이 수정되었습니다.", "location.href='" + Request.Url.ToString() + "';");
                    break;

                default:
                    ComUtil.MsgBox("영웅 수정중 오류가 발생하였습니다." + nRet.ToString(), "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("예외오류 오류내용 : {0}", ex.Message), "history.back();");
        }
    }
}