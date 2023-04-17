using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_Development : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
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
		WBtnNationWarInit.Attributes.Add("onclick", "return confirm('반드시 서버를 정지한 후에 실행해야합니다.\\n초기화하시겠습니까?');");

		SqlConnection conn = DBUtil.GetUserDBConn();
		DataTable dt = DacUser.VirtualGameServers(conn, null);
		DBUtil.CloseDBConn(conn);

		WDDLServer.Items.Add(new ListItem("=가상서버선택=", "0"));
		for (int i = 0; i < dt.Rows.Count; i++)
			WDDLServer.Items.Add(new ListItem(dt.Rows[i]["displayName"].ToString(), dt.Rows[i]["serverId"].ToString()));
	}

	protected void WBtnNationWarInit_OnClick(object sender, EventArgs e)
	{
		if (WDDLServer.SelectedValue == "0")
		{
			ComUtil.MsgBox("서버를 선택해주세요.", "history.back();");
			return;
		}

		int nServerId = Convert.ToInt32(WDDLServer.SelectedValue);

		SqlConnection connGame = null;
		SqlTransaction tran = null;

		try
		{
			connGame = DBUtil.GetGameDBConn(nServerId);
			tran = connGame.BeginTransaction();

			if (Dac.NationWarInit(connGame, tran) != 0)
			{
				tran.Rollback();
				tran.Dispose();
				tran = null;
				DBUtil.CloseDBConn(connGame);
				ComUtil.MsgBox("초기화 실패", "history.back();");
				return;
			}

			tran.Commit();
			tran.Dispose();
			tran = null;
			DBUtil.CloseDBConn(connGame);
			ComUtil.MsgBox("초기화 성공", "location.href='" + Request.Url.ToString() + "';");
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox("초기화 예외발생(" + ex.Message + ")", "history.back();");
		}
		finally
		{
			if (tran != null)
			{
				tran.Rollback();
				tran.Dispose();
				tran = null;
			}
			if (connGame != null && connGame.State == ConnectionState.Open)
			{
				DBUtil.CloseDBConn(connGame);
			}
		}
	}
}