using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Game_AccountHeroList : System.Web.UI.Page
{
	protected int m_nGameServerGroupId = 0;
	protected int m_nGameServerId = 0;
	protected void Page_Load(object sender, EventArgs e)
	{

		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
		m_nGameServerGroupId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
		m_nGameServerId = ComUtil.GetRequestInt("GSID", RequestMethod.Get, 0);

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
		//WBtnServerGroupAdd.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");
		//WBtnGameServerAdd.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");

		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.GameServerGroups(conn, null);
		DataTable dtServer = DacUser.GameServers(conn, null, m_nGameServerGroupId);

		DBUtil.CloseDBConn(conn);

		//서버그룹 DropDownList 생성
		WDDLServerGropList.Items.Add(new ListItem("--서버그룹선택--", "0"));
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			WDDLServerGropList.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["groupId"].ToString()));
		}

		WDDLServerList.Items.Add(new ListItem("--게임서버선택--", "0"));
		for (int i = 0; i < dtServer.Rows.Count; i++)
		{
			WDDLServerList.Items.Add(new ListItem(dtServer.Rows[i]["name"].ToString(), dtServer.Rows[i]["serverId"].ToString()));
		}

		WDDLSearch.Items.Add(new ListItem("영웅ID", "1"));

		//게임서버그룹 바인딩
		WDDLServerGropList.SelectedValue = m_nGameServerGroupId.ToString();
		WDDLServerList.SelectedValue = m_nGameServerId.ToString();
	}

	protected void WBtnSearch_OnClick(object sender, EventArgs e)
	{
		if (WDDLServerList.SelectedValue == "0")
		{
			ComUtil.MsgBox("서버리스트를 선택해주세요.");
			return;
		}
		try
		{
			int nSearchType = Convert.ToInt32(WDDLSearch.SelectedValue);
			int sSearch = Convert.ToInt32(WTxtsearch.Text.Trim());

			if (sSearch.ToString() == "")
				return;
			
			//연결정보 가져오기 (DB커넥션 포함됨)
				// conn = DBUtil.GetGameDBConn(WDDLServerList.SelectedValue);
				//conn = DBUtil.GetGameDBConn(WDDLServerList.SelectedValue);
				//conn = DBUtil.GetGameDBConn(DBUtil.GetUserDBConn().ConnectionString);
			
			SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(WDDLServerList.SelectedValue));
		
			DataTable dt = Dac.SearchHeros(conn, null, nSearchType, sSearch);

			DBUtil.CloseDBConn(conn);

			WrptList.DataSource = dt;
			WrptList.DataBind();
			WrptList.Dispose();
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox(ex.Message);
		}
	}
	//서버그룹 선택시 게임서버목록출력
	protected void WDDLServerGroup_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("/Game/AccountHeroList.aspx?SVR=" + WDDLServerGropList.SelectedValue);
	}
	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "name":
				sRtn = "<a href=\"/Game/AccountHero.aspx?SVR=" + WDDLServerList.SelectedValue + "&AHID=" + ComUtil.GetDataItem(objData, "HeroId") + "\">" + ComUtil.GetDataItem(objData, sFieldNm) + "</a>";
				break;
			default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }
        return sRtn;
	}

}