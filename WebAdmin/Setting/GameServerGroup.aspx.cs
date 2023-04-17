using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Setting_GameServerGroup : System.Web.UI.Page
{
	protected int m_nGameServerRegionId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		//다국어 변환
		//======================================================================
		

		//======================================================================
		// 파라미터
		//======================================================================
		m_nGameServerRegionId = ComUtil.GetRequestInt("SVRR", RequestMethod.Get, 0);

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

        WBtnAdd.Text = "등록";
        WBtnAdd.Attributes.Add("onclick", string.Format("return confirm('{0}');", "등록하시겠습니까?"));

		SqlConnection conn = DBUtil.GetUserDBConn();
		DataTable dtRegion = DacUser.GameServerRegions(conn, null);
		DataTable dt = null;
		
		if(m_nGameServerRegionId > 0)
			dt = DacUser.GameServerGroups_RegionId(conn, null, m_nGameServerRegionId);
		
		DBUtil.CloseDBConn(conn);


		WDDLSRegion.Items.Add(new ListItem("== 서버지역 선택 == ", "0"));
		for (int i = 0; i < dtRegion.Rows.Count; i++)
		{
			WDDLSRegion.Items.Add(new ListItem(dtRegion.Rows[i]["_name"].ToString(), dtRegion.Rows[i]["regionId"].ToString()));
		}
		WDDLSRegion.SelectedValue = m_nGameServerRegionId.ToString();
		
		if (m_nGameServerRegionId == 0)
			return;
		
		WPHServerInfo.Visible = true;

		WRptList.DataSource = dt;
		WRptList.DataBind();
	}

	protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
        ((Button)e.Item.FindControl("WBtnUpdate")).Text = "수정";
        ((Button)e.Item.FindControl("WBtnDelete")).Text = "삭제";

		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			Button WBtnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
            WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "변경된 정보로 수정하시겠습니까?"));

			Button WBtnDelete = (Button)e.Item.FindControl("WBtnDelete");
            WBtnDelete.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));

			((CheckBox)e.Item.FindControl("WCBoxAuto")).Checked = Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "recommendServerAuto"));
			((CheckBox)e.Item.FindControl("WCBoxAccessRestriction")).Checked = Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "isAccessRestriction"));
			((DropDownList)e.Item.FindControl("WDDLConditionType")).SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "recommendServerConditionType");
		}
	}

	protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
	{
		SqlConnection conn = null;
		int nRet = 0;

		try
		{
			int nGroupId = Convert.ToInt32(e.CommandArgument.ToString());

			conn = DBUtil.GetUserDBConn();

			switch (e.CommandName)
			{
				case "update":
					string sName = ((TextBox)e.Item.FindControl("WTxtName")).Text.Trim();
                    string sNameKey = ((TextBox)e.Item.FindControl("WTxtNameKey")).Text.Trim();
                    int nSortNo = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtSortNo")).Text.Trim());
					bool recommendServerAuto = ((CheckBox)e.Item.FindControl("WCBoxAuto")).Checked;
					bool accessRestriction = ((CheckBox)e.Item.FindControl("WCBoxAccessRestriction")).Checked;
					DropDownList WDDLCType = ((DropDownList)e.Item.FindControl("WDDLConditionType"));

					nRet = DacUser.UpdateGameServerGroup(conn, null, nGroupId, m_nGameServerRegionId, nSortNo, sName, sNameKey, recommendServerAuto, Convert.ToInt32(WDDLCType.SelectedValue), accessRestriction);

					break;
				case "delete":

                    DataTable dt = DacUser.GameServers_GroupId(conn, null, nGroupId);

					if (dt != null && dt.Rows.Count > 0)
					{
						DBUtil.CloseDBConn(conn);
						ComUtil.MsgBox("그룹내에 게임서버가 있습니다.", "location.href='" + Request.Url.ToString() + "';");
						dt.Dispose();
						return;
					}

					nRet = DacUser.DeleteGameServerGroup(conn, null, nGroupId);
					break;
				default:
					nRet = 3;
					break;
			}

			DBUtil.CloseDBConn(conn);

			switch (nRet)
			{
				case 0:
					ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
					break;
				case 1:
					ComUtil.MsgBox("작업실패", "history.back();");
					break;
				case 2:
                    ComUtil.MsgBox("그룹에 게임서버가 존재합니다.", "history.back();");
					break;
				default:
					ComUtil.MsgBox("예외발생", "history.back();");
					break;
			}
		}
		catch (Exception ex)
		{
			if (conn != null)
				DBUtil.CloseDBConn(conn);

			ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
		}
	}

	protected void WBtnAdd_OnClick(object sender, EventArgs e)
	{
		try
		{
			int nGroupId = Convert.ToInt32(WTxtGroupId.Text.Trim());
			int nSortNo = Convert.ToInt32(WTxtSortNo.Text.Trim());
			string sName = WTxtName.Text.Trim();
            string sNameKey = WTxtNameKey.Text.Trim();
			if (sName == "" || sNameKey == "")
			{
				ComUtil.MsgBox("입력값이 필요합니다.", "history.back();");
				return;
			}
			bool recommendServerAuto = WCBoxAuto.Checked;
			bool accessRestriction = WCBoxAccessRestriction.Checked;

			SqlConnection conn = DBUtil.GetUserDBConn();
			int nRet = DacUser.AddGameServerGroup(conn, null, nGroupId, m_nGameServerRegionId, nSortNo, sName, sNameKey, recommendServerAuto, Convert.ToInt32(WDDLConditionType.SelectedValue), accessRestriction);
			DBUtil.CloseDBConn(conn);

			switch (nRet)
			{
				case 0:
					ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
					break;
				case 1:
					ComUtil.MsgBox("작업실패", "history.back();");
					break;
				default:
					//ComUtil.MsgBox("잘못된 접근입니다." + "(" + nRet + ")", "history.back();");
					break;
			}
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
		}
	}

	//서버지역 선택시 게임그룹출력
	protected void WDDLServerRegion_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("/Setting/GameServerGroup.aspx?SVRR=" + WDDLSRegion.SelectedValue);

	}

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}