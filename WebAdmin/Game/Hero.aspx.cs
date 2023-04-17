using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_Hero : System.Web.UI.Page
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

		SqlConnection connGame = DBUtil.GetGameDBConn(m_nServerId);
		DataRow drHero = Dac.Hero(connGame, null, m_heroId);
		if (drHero == null)
		{
			DBUtil.CloseDBConn(connGame);
			ComUtil.MsgBox("영웅정보 없음", "history.back();");
			return;
		}
		DataRow drAccount = Dac.Account(connGame, null, Guid.Parse(drHero["accountId"].ToString()));
		if (drAccount == null)
		{
			DBUtil.CloseDBConn(connGame);
			ComUtil.MsgBox("계정정보 없음", "history.back();");
			return;
		}
		DataTable dtHeros = Dac.Heros_AccountId(connGame, null, Guid.Parse(drHero["accountId"].ToString()));
		DataTable dtVipLevelRewards = Dac.VipLevelRewards(connGame, null, Guid.Parse(drHero["accountId"].ToString()));
		DBUtil.CloseDBConn(connGame);

		WRptList.DataSource = dtHeros;
		WRptList.DataBind();

		//Account
		WLtlAccountId.Text = Convert.ToString(drAccount["accountId"]);
		WLtlUserId.Text = Convert.ToString(drAccount["userId"]);
		WLtlVirtualGameServerId.Text = Convert.ToString(drAccount["virtualGameServerId"]);
		if (Convert.ToBoolean(drAccount["deleted"]))
			WLtlDeleted.Text = "삭제(" + DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drAccount["delTime"].ToString())) + ")";
		else
			WLtlDeleted.Text = "정상";

		WTxtBaseUnOwnDia.Text = drAccount["baseUnOwnDia"].ToString();
		WTxtBonusUnOwnDia.Text = drAccount["bonusUnOwnDia"].ToString();
		WTxtVipPoint.Text = drAccount["vipPoint"].ToString();

		WLtlLastLoginTime.Text = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drAccount["lastLoginTime"].ToString()));
		WLtlLastLoginIp.Text = Convert.ToString(drAccount["lastLoginIp"]);
		WLtlRegTime.Text = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drAccount["regTime"].ToString()));

		//Hero
		WLtlHeroId.Text = m_heroId.ToString();

		WRptVipRewardList.DataSource = dtVipLevelRewards;
		WRptVipRewardList.DataBind();
	}

	protected void WBtnUpdate_OnClick(object sender, EventArgs e)
	{
		SqlConnection connGame = null;
		SqlTransaction tranGame = null;

		try
		{
			int nBaseUnOwnDia = Convert.ToInt32(WTxtBaseUnOwnDia.Text.Trim());
			int nBonusUnOwnDia = Convert.ToInt32(WTxtBonusUnOwnDia.Text.Trim());
			int nVipPoint = Convert.ToInt32(WTxtVipPoint.Text.Trim());

			// 게임디비 연결
			connGame = DBUtil.GetGameDBConn(m_nServerId);

			// 접속여부 확인
			if (Dac.Hero_Connection(connGame, null, m_heroId) != 0)
			{
				DBUtil.CloseDBConn(connGame);
				ComUtil.MsgBox("영웅이 접속중입니다.", "history.back();");
				return;
			}

			DataRow drHero = Dac.Hero(connGame, null, m_heroId);
			if (drHero == null)
			{
				DBUtil.CloseDBConn(connGame);
				ComUtil.MsgBox("영웅정보 없음", "history.back();");
				return;
			}

			// 트랜잭션
			tranGame = connGame.BeginTransaction();

			if (Dac.UpdateAccount(connGame, tranGame, Guid.Parse(drHero["accountId"].ToString()), nBaseUnOwnDia, nBonusUnOwnDia, nVipPoint) != 0)
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

			ComUtil.MsgBox("정보가 수정되었습니다.", "location.href='" + Request.Url.ToString() + "';");
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
    protected void WBtnGMTrans_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        SqlTransaction tran = null;
        SqlConnection connUser = null;
        SqlTransaction tranUser = null;

        try
        {
            WLtlGMInfo.Text = "";

            string sGmNickName = WTxtGMNickName.Text.Trim();

            if (sGmNickName == "")
            {
                ComUtil.MsgBox("GM 닉네임을 입력해주세요.", "history.back();");
                return;
            }

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetGameDBConn(sConnectionString);

            DataTable dt = Dac.Heros_Search(conn, null, Define.kHeroSearchType_Name, sGmNickName);
            DataRow dr = dt.Rows[0];
            if (dr == null)
            {
                DBUtil.CloseDBConn(conn);
                WLtlGMInfo.Text = "존재하지 않는 GM";
                return;
            }

            if (!Convert.ToBoolean(dr["isGm"]))
            {
                DBUtil.CloseDBConn(conn);
                WLtlGMInfo.Text = "GM이 아닙니다.";
                return;
            }

            WHFGMAccount.Value = dr["accountId"].ToString();
            WBtnGMTrans.Visible = true;

            Guid accountId = Guid.Parse(WLtlAccountId.Text);
            Guid gmAccountId = Guid.Parse(dr["accountId"].ToString());

            // 접속중 체크
            if (Dac.Hero_Connection(conn, null, m_heroId) != 0)
            {
                DBUtil.CloseDBConn(conn);
                WLtlGMInfo.Text = "이전하려는 영웅이 접속중입니다.";
                return;
            }

            // 유저 DB연결
            connUser = DBUtil.GetUserDBConn();

            // 계정 이전 이력 조회
            DataRow drRelocation = DacUser.AdminAccountHeroRelocationLog(connUser, null, m_heroId);

            if (drRelocation != null)
            {
                DBUtil.CloseDBConn(connUser);
                DBUtil.CloseDBConn(conn);
                WLtlGMInfo.Text = "이미 GM에게 이전된 영웅입니다.";
                return;
            }

            tran = conn.BeginTransaction();
            tranUser = connUser.BeginTransaction();

            // 계정 이전
            if (Dac.UpdateHero_Account(conn, tran, m_heroId, gmAccountId) != 0)
            {
                tranUser.Rollback();
                tranUser.Dispose();

                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(connUser);
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("계정이전에 실패했습니다.", "history.back();");
                return;
            }

            // 계정 이전 로그 등록
            if (DacUser.AddAdminAccountHeroRelocationLog(connUser, tranUser, m_nServerId, m_heroId, accountId, gmAccountId, ComUtil.GetUserId()) != 0)
            {
                tranUser.Rollback();
                tranUser.Dispose();

                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(connUser);
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("계정이전 로그 등록에 실패했습니다.", "history.back();");
                return;
            }

            tranUser.Commit();
            tranUser.Dispose();

            tran.Commit();
            tran.Dispose();

            //유저 DB연결 해제
            DBUtil.CloseDBConn(connUser);

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("계정이전이 완료되었습니다.", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            WLtlGMInfo.Text = "예외발생";

            if (tran != null)
            {
                tran.Rollback();
                tran.Dispose();
            }
            if (tranUser != null)
            {
                tran.Rollback();
                tran.Dispose();
            }
            if (conn != null)
                DBUtil.CloseDBConn(conn);
            if (connUser != null)
                DBUtil.CloseDBConn(connUser);
        }
    }
    protected void WBtnRecovery_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        SqlTransaction tran = null;
        SqlConnection connUser = null;
        SqlTransaction tranUser = null;

        try
        {
            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetGameDBConn(sConnectionString);

            // 접속중 체크
            if (Dac.Hero_Connection(conn, null, m_heroId) != 0)
            {
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("복구하려는 영웅이 접속중입니다.", "history.back();");
                return;
            }

            // 유저 DB연결
            connUser = DBUtil.GetUserDBConn();

            // 계정 이전 이력 조회
            DataRow drRelocation = DacUser.AdminAccountHeroRelocationLog(connUser, null, m_heroId);
            if (drRelocation == null)
            {
                DBUtil.CloseDBConn(connUser);
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("계정영웅 이전 내역이 없습니다.", "history.back();");
                return;
            }

            long lnLogNo = Convert.ToInt64(drRelocation["logNo"]);
            Guid accountId = Guid.Parse(drRelocation["accountId"].ToString());
            Guid gmAccountId = Guid.Parse(drRelocation["gmAccountId"].ToString());

            tran = conn.BeginTransaction();
            tranUser = connUser.BeginTransaction();

            // 계정 회수(원래계정으로)
            if (Dac.UpdateHero_Account(conn, tran, m_heroId, accountId) != 0)
            {
                tranUser.Rollback();
                tranUser.Dispose();
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(connUser);
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("계정영웅 복구에 실패했습니다.", "history.back();");
                return;
            }

            // 계정 이전 회수 업데이트
            if (DacUser.UpdateAdminAccountHeroRelocationLog_Recovery(connUser, tranUser, lnLogNo) != 0)
            {
                tranUser.Rollback();
                tranUser.Dispose();
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(connUser);
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("계정영웅 이전 복구 로그 등록에 실패했습니다.", "history.back();");
                return;
            }

            tranUser.Commit();
            tranUser.Dispose();

            tran.Commit();
            tran.Dispose();

            // DB연결 해제
            DBUtil.CloseDBConn(connUser);
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("계정영웅 복구가 완료되었습니다.", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            WLtlGMInfo.Text = "예외발생";

            if (tran != null)
            {
                tran.Rollback();
                tran.Dispose();
            }
            if (tranUser != null)
            {
                tran.Rollback();
                tran.Dispose();
            }
            if (conn != null)
                DBUtil.CloseDBConn(conn);
            if (connUser != null)
                DBUtil.CloseDBConn(connUser);
        }
    }


    protected void WBtnGMSearch_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;

        try
        {
            WHFGMAccount.Value = "";
            WLtlGMInfo.Text = "";
            WBtnGMTrans.Visible = false;

            string sGmNickName = WTxtGMNickName.Text.Trim();

            if (sGmNickName == "")
            {
                ComUtil.MsgBox("GM 닉네임을 입력해주세요.", "history.back();");
                return;
            }

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetGameDBConn(sConnectionString);

           // DataRow dr = Dac.AccountHero_SearchName(conn, null, sGmNickName);

            DataTable dt = Dac.Heros_Search(conn, null, Define.kHeroSearchType_Name, sGmNickName);
            DataRow dr = dt.Rows[0];

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            if (dr == null)
            {
                WLtlGMInfo.Text = "존재하지 않는 GM";
                return;
            }

            if (!Convert.ToBoolean(dr["isGm"]))
            {
                WLtlGMInfo.Text = "GM이 아닙니다.";
                return;
            }

            WHFGMAccount.Value = dr["accountId"].ToString();
            WBtnGMTrans.Visible = true;
        }
        catch (Exception ex)
        {
            WLtlGMInfo.Text = "예외발생";

            if (conn != null)
                DBUtil.CloseDBConn(conn);
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "heroInfo":

				string sStyle = "";
				if (Convert.ToBoolean(ComUtil.GetDataItem(objData, "deleted")))
					sStyle = "background:#999999;";

				if (ComUtil.GetDataItem(objData, "heroId") == m_heroId.ToString())
					sStyle += "background:#476600;color:#FFFFFF";

				sRtn = "<input type=\"button\" value=\"" + ComUtil.GetDataItem(objData, "name") + "\" class=\"btnMenu\" onclick=\"location.href='/Game/Hero.aspx?SVR=" + m_nServerId.ToString() + "&HID=" + ComUtil.GetDataItem(objData, "heroId") + "';\" style=\"" + sStyle + "\" />";
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
		return sRtn;
	}
}