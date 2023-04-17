using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Setting_GameSystem : System.Web.UI.Page
{
	protected int m_nServerId;

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

		SqlConnection conn = DBUtil.GetUserDBConn();
		DataTable dt = DacUser.GameServerAll(conn, null);
		DBUtil.CloseDBConn(conn);

		WDDLServer.Items.Add(new ListItem("===서버선택===", "0"));
		for (int i = 0; i < dt.Rows.Count; i++)
			WDDLServer.Items.Add(new ListItem("서버 ID - " + dt.Rows[i]["serverId"].ToString(), dt.Rows[i]["serverId"].ToString()));

		WDDLServer.SelectedValue = m_nServerId.ToString();

		WPHForm.Visible = false;

		if (m_nServerId == 0)
			return;

		SqlConnection connGame = DBUtil.GetGameDBConn(m_nServerId);
		DataRow drServerTime = Dac.ServerTime(connGame, null);
		DataRow drSystem = Dac.System(connGame, null);
		DBUtil.CloseDBConn(connGame);

		WLtlServerTime.Text = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drServerTime["serverTime"].ToString()));

		WPHForm.Visible = true;

		if (drSystem == null)
		{
			WBtnUpdate.Visible = false;
			WLtlWarning.Text = "게임시스템 기본데이터가 입력되어있지 않습니다.";
			return;
		}
		WTxtServerOpenDate.Text = DateTimeUtil.ToDateString(DateTime.Parse(drSystem["serverOpenDate"].ToString()));
	}

	protected void WDDLServer_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("/Setting/GameSystem.aspx?SVR=" + WDDLServer.SelectedValue);
	}

	protected void WBtnUpdate_OnClick(object sender, EventArgs e)
	{
		if (m_nServerId == 0)
		{
			ComUtil.MsgBox("서버를 선택해주세요.", "history.back();");
			return;
		}

		SqlConnection connGame = null;
		SqlTransaction tran = null;
		
		try
		{
			string sServerOpenDate = WTxtServerOpenDate.Text.Trim();

			DateTime dt = DateTime.Parse(sServerOpenDate);

			// 연결정보 가져오기 (DB커넥션 포함됨)
			connGame = DBUtil.GetGameDBConn(m_nServerId);
			tran = connGame.BeginTransaction();

			if (Dac.UpdateSystem(connGame, tran, dt) != 0)
			{
				tran.Rollback();
				tran.Dispose();
				DBUtil.CloseDBConn(connGame);

				ComUtil.MsgBox("수정에 실패하였습니다.", "history.back();");
				return;
			}

			tran.Commit();
			tran.Dispose();

			DBUtil.CloseDBConn(connGame);

			ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
		}
		catch (Exception ex)
		{
			if (tran != null)
			{
				tran.Rollback();
				tran.Dispose();
			}
			if (connGame != null && connGame.State == ConnectionState.Connecting)
				DBUtil.CloseDBConn(connGame);

			Response.Write(ex.StackTrace);

			ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
		}
	}
}