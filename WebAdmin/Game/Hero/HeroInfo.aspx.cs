using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_Hero_HeroInfo : System.Web.UI.Page
{
	protected int m_nServerId;
	protected Guid m_heroId;

    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
		m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
		m_heroId = Guid.Parse(ComUtil.GetRequestString("HID", RequestMethod.Get, Guid.Empty.ToString()));

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
		if (m_nServerId == 0)
		{
			ComUtil.MsgBox("잘못된접근", "history.back();");
			return;
		}

		WBtnUpdate.Attributes.Add("onclick", "return confirm('수정하시겠습니까?');");

		SqlConnection connUser = DBUtil.GetUserDBConn();
		DataTable dtJobs = DacUser.Jobs(connUser, null);
		DBUtil.CloseDBConn(connUser);

		SqlConnection connGame = DBUtil.GetGameDBConn(m_nServerId);
		DataRow drHero = Dac.Hero(connGame, null, m_heroId);
		
		DBUtil.CloseDBConn(connGame);

		if (drHero == null)
			return;

		//Hero
		for (int i = 0; i < dtJobs.Rows.Count; i++)
			WDDLJob.Items.Add(new ListItem(dtJobs.Rows[i]["jobId"].ToString() + ". " + dtJobs.Rows[i]["_name"].ToString(), dtJobs.Rows[i]["jobId"].ToString()));

		//직업ID
		WDDLJob.SelectedValue = drHero["jobId"].ToString();
		//국가ID
		WLtlNationId.Text = drHero["nationId"].ToString();
		//이름
		WLtlName.Text = drHero["name"].ToString();
		//레벨
		WTxtLevel.Text = drHero["level"].ToString();
		
		//경험치
		WTxtExp.Text = drHero["exp"].ToString();
		//전투력
		WLtlBattlePower.Text = drHero["battlePower"].ToString();
		//골드
		WTxtGold.Text = drHero["gold"].ToString();
		//라크
		WTxtLak.Text = drHero["lak"].ToString();

		//귀속다이아
		WTxtOwnDia.Text = drHero["ownDia"].ToString();
		//VIP포인트
		WTxtVipPoint.Text = drHero["vipPoint"].ToString();
		//체력
		WTxtStamina.Text = drHero["stamina"].ToString();
		//공적점수
		WTxtExploitPoint.Text = drHero["exploitPoint"].ToString();

		//착용날개
		WLtlWing.Text = drHero["equippedWingId"].ToString();
		//날개단계
		WLtlWingStep.Text = drHero["wingStep"].ToString();
		//날개레벨
		WLtlWingLevel.Text = drHero["wingLevel"].ToString();
		//날개경험치
		WLtlWingExp.Text = drHero["wingExp"].ToString();



        //메인장비강화
        if (drHero["mainGearEnchantDate"] != DBNull.Value)
			WLtlMainGearEnchant.Text = drHero["mainGearEnchantCount"].ToString() + " (" + DateTimeUtil.ToDateString(DateTime.Parse(drHero["mainGearEnchantDate"].ToString())) + ")";
		else
			WLtlMainGearEnchant.Text = "X";
		//메인장비세련
		if (drHero["mainGearRefinementDate"] != DBNull.Value)
			WLtlMainGearRefinement.Text = drHero["mainGearRefinementCount"].ToString() + " (" + DateTimeUtil.ToDateString(DateTime.Parse(drHero["mainGearRefinementDate"].ToString())) + ")";
		else
			WLtlMainGearRefinement.Text = "X";
		//무료즉시부활
		if (drHero["freeImmediateRevivalDate"] != DBNull.Value)
			WLtlFreeImmediateRevival.Text = drHero["freeImmediateRevivalCount"].ToString() + " (" + DateTimeUtil.ToDateString(DateTime.Parse(drHero["freeImmediateRevivalDate"].ToString())) + ")";
		else
			WLtlFreeImmediateRevival.Text = "X";
		//유료부활
		if (drHero["paidImmediateRevivalDate"] != DBNull.Value)
			WLtlPaidImmediateRevival.Text = drHero["paidImmediateRevivalCount"].ToString() + " (" + DateTimeUtil.ToDateString(DateTime.Parse(drHero["paidImmediateRevivalDate"].ToString())) + ")";
		else
			WLtlPaidImmediateRevival.Text = "X";
		
		//휴식시간
		WLtlRestTime.Text = drHero["restTime"].ToString();
		//일일출석보상
		if (drHero["dailyAttendRewardDate"] != DBNull.Value)
			WLtlDailyAttendReward.Text = drHero["dailyAttendRewardDay"].ToString() + "day (" + DateTimeUtil.ToDateString(DateTime.Parse(drHero["dailyAttendRewardDate"].ToString())) + ")";
		else
			WLtlDailyAttendReward.Text = "X";
		//일일접속시간
		if (drHero["dailyAccessTimeUpdateTime"] != DBNull.Value)
			WLtlDailyAccessTime.Text = Convert.ToDouble(drHero["dailyAccessTime"]).ToString("#.###") + "<br />(" + DateTimeUtil.ToDateTimeOffsetString(DateTime.Parse(drHero["dailyAccessTimeUpdateTime"].ToString())) + ")";
		else
			WLtlDailyAccessTime.Text = "X";
		//탈것장비재강화
		if (drHero["mountGearRefinementDate"] != DBNull.Value)
			WLtlMountGearRefinement.Text = drHero["mountGearRefinementCount"].ToString() + " (" + DateTimeUtil.ToDateString(DateTime.Parse(drHero["mountGearRefinementDate"].ToString())) + ")";
		else
			WLtlMountGearRefinement.Text = "X";

		//구입인벤토리슬롯수
		WTxtPaidInventorySlotCount.Text = drHero["paidInventorySlotCount"].ToString();
		//메인장비(무기)
		WLtlWeaponHeroMainGearId.Text = drHero["weaponHeroMainGearId"].ToString();
		//메인장비(방어구)
		WLtlArmorHeroMainGearId.Text = drHero["armorHeroMainGearId"].ToString();
		//이름튜토리얼
		WLtlNamingTutorialCompleted.Text = (Convert.ToBoolean(drHero["namingTutorialCompleted"])) ? "완료" : "미완료";

		bool isConnected = false;

		if (drHero["lastLoginTime"] != DBNull.Value && drHero["lastLogoutTime"] == DBNull.Value)
			isConnected = true;
		if (drHero["lastLoginTime"] != DBNull.Value && drHero["lastLogoutTime"] != DBNull.Value)
			if (DateTimeOffset.Compare(DateTimeOffset.Parse(drHero["lastLoginTime"].ToString()), DateTimeOffset.Parse(drHero["lastLogoutTime"].ToString())) > 0)
				isConnected = true;

		//마지막로그인
		WLtlLastLoginTime.Text = (drHero["lastLoginTime"] != DBNull.Value) ? DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drHero["lastLoginTime"].ToString())) : "-";
		//마지막로그아웃
		WLtlLastLogoutTime.Text = (drHero["lastLogoutTime"] != DBNull.Value) ? DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drHero["lastLogoutTime"].ToString())) : "-";
		//상태
		WLtlStatus.Text = ((Convert.ToBoolean(drHero["deleted"])) ? "삭제됨" : "정상") + " " + ((isConnected) ? "<span class=\"red\">(접속중)</span>" : "(미접속)");
		//등록시각
		WLtlRegTime.Text = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drHero["regTime"].ToString()));

        //메인퀘스트
        WTxtGmTargetMainQuestNo_hidden.Text = drHero["gmTargetMainQuestNo"].ToString();
        WTxtGmTargetMainQuestNo.Text = drHero["gmTargetMainQuestNo"].ToString();
    }

	protected void WBtnUpdate_OnClick(object sender, EventArgs e)
	{
		SqlConnection connGame = null;
		SqlTransaction tranGame = null;

		try
		{
			int nJobId = Convert.ToInt32(WDDLJob.SelectedValue);
			int nLevel = Convert.ToInt32(WTxtLevel.Text.Trim());
			long lnExp = Convert.ToInt64(WTxtExp.Text.Trim());
			long lnGold = Convert.ToInt64(WTxtGold.Text.Trim());
			int nLak = Convert.ToInt32(WTxtLak.Text.Trim());
			int nOwnDia = Convert.ToInt32(WTxtOwnDia.Text.Trim());
			int nVipPoint = Convert.ToInt32(WTxtVipPoint.Text.Trim());
			int nStamina = Convert.ToInt32(WTxtStamina.Text.Trim());
			int nExploitPoint = Convert.ToInt32(WTxtExploitPoint.Text.Trim());
			int nPaidInventorySlotCount = Convert.ToInt32(WTxtPaidInventorySlotCount.Text.Trim());
			int nGmTargetMainQuestNo = Convert.ToInt32(WTxtGmTargetMainQuestNo.Text.Trim());
            int nGmTargetMainQuestNo_hidden = Convert.ToInt32(WTxtGmTargetMainQuestNo_hidden.Text.Trim());

            if (nGmTargetMainQuestNo_hidden > nGmTargetMainQuestNo) {
                ComUtil.MsgBox("현재 진행중인 메인퀘스트번호보다 낮습니다.", "history.back();");
                return;
            }
            // 게임디비 연결
            connGame = DBUtil.GetGameDBConn(m_nServerId);

			// 접속여부 확인
			if (Dac.Hero_Connection(connGame, null, m_heroId) != 0)
			{
				DBUtil.CloseDBConn(connGame);
				ComUtil.MsgBox("영웅이 접속중입니다.", "history.back();");
				return;
			}

			// 트랜잭션
			tranGame = connGame.BeginTransaction();

			if (Dac.UpdateHero(connGame, tranGame, m_heroId, nJobId, nLevel, lnExp, lnGold, nLak, nOwnDia, nVipPoint, nStamina, nExploitPoint, nPaidInventorySlotCount, nGmTargetMainQuestNo) != 0)
			{
				tranGame.Rollback();
				tranGame.Dispose();

				DBUtil.CloseDBConn(connGame);

				ComUtil.MsgBox("영웅 정보 수정 실패", "history.back();");
				return;
			}

			// 트랜잭션 커밋
			tranGame.Commit();
			tranGame.Dispose();

			// 연결해제
			DBUtil.CloseDBConn(connGame);

			ComUtil.MsgBox("영웅 정보가 수정되었습니다.", "location.href='" + Request.Url.ToString() + "';");
		}
		catch (Exception ex)
		{
			if (tranGame != null)
			{
				tranGame.Rollback();
				tranGame.Dispose();
			}
			if (connGame != null && connGame.State == ConnectionState.Connecting)
				DBUtil.CloseDBConn(connGame);

			ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
		}
	}
}