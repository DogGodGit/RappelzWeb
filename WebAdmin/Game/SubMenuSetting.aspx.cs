using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_SubMenuSetting : System.Web.UI.Page
{
	protected int m_nMainMenuId = 0;
	protected void Page_Load(object sender, EventArgs e)
	{
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
		m_nMainMenuId = ComUtil.GetRequestInt("MID", RequestMethod.Get, 0);

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
		WBtnAdd.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");

		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.SubMenus(conn, null, m_nMainMenuId);
		DataRow dr = DacUser.MainMenu(conn, null, m_nMainMenuId);
		DataTable dtMenuContents = DacUser.MenuContents(conn, null);

		DBUtil.CloseDBConn(conn);

		//선택된 메인메뉴 정보들.
		WTxtMainMenuId.Text = dr["menuId"].ToString();
		WTxtNameKey.Text = dr["nameKey"].ToString();
		WTxtPopupName.Text = dr["popupName"].ToString();

		//서브메뉴 등록시 노출되는 메인메뉴ID
		WLtlMainMenuIds.Text = dr["menuId"].ToString();

		WDDLSubMenus.Items.Add(new ListItem("===선택===", "0"));

		for (int i = 0; i < dt.Rows.Count; i++)
		{
			WDDLSubMenus.Items.Add(new ListItem(dt.Rows[i]["subMenuId"].ToString(), dt.Rows[i]["subMenuId"].ToString()));
			if (Convert.ToBoolean(dt.Rows[i]["isDefault"]))
				WDDLSubMenus.SelectedValue = dt.Rows[i]["subMenuId"].ToString();
		}

		if (WDDLSubMenus.SelectedIndex == 0)
			WLtlWarning.Text = "기본선택된 메뉴를 설정해야합니다.";

		WDDLMenuContents.Items.Insert(0, new ListItem("===선택===", "0"));

		for (int i = 0; i < dtMenuContents.Rows.Count; i++)
			WDDLMenuContents.Items.Add(new ListItem(dtMenuContents.Rows[i]["menuId"].ToString() + "[" + dtMenuContents.Rows[i]["menuName"].ToString() + "]-" + dtMenuContents.Rows[i]["contentId"].ToString() + "[" + dtMenuContents.Rows[i]["_name"].ToString() + "]", dtMenuContents.Rows[i]["contentId"].ToString()));

		WRptsubMenu.DataSource = dt;
		WRptsubMenu.DataBind();
	}

	protected void WBtnBack_OnClick(object sender, EventArgs e)
	{
		Response.Redirect("/Game/MenuSetting.aspx");
	}

	protected void WBtnAdd_OnClick(object sender, EventArgs e)
	{
		int nRet = 0;
		int sSubMenuId = Convert.ToInt32(WTxtSubmenuIdAdd.Text.Trim());
		string sSubnameKeyAdd = WtxtSubnameKeyAdd.Text.Trim();
		string sPrefab1Add = WTxtPrefab1Add.Text.Trim();
		string sPrefab2Add = WTxtPrefab2Add.Text.Trim();
		string sPrefab3Add = WTxtPrefab3Add.Text.Trim();
		int nLayout = Convert.ToInt32(WTxtLayout.Text.Trim());
		int nSortNo = Convert.ToInt32(WTxtSortNo.Text.Trim());
		int nContentId = Convert.ToInt32(WDDLMenuContents.SelectedValue);

		//공백체크
		if (sSubMenuId.ToString() == "")
		{
			ComUtil.MsgBox("서브메뉴ID를 입력해주세요.");
			return;
		}

		SqlConnection conn = DBUtil.GetUserDBConn();

		nRet = DacUser.AddSubMenu(conn, null, m_nMainMenuId, sSubMenuId, sSubnameKeyAdd, sPrefab1Add, sPrefab2Add, sPrefab3Add, nLayout, nSortNo, nContentId);

		DBUtil.CloseDBConn(conn);

		if (nRet == 0)
		{
			ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
		}
		else
		{
			ComUtil.MsgBox("작업실패", "history.back();");
		}
	}

	protected void WRptSubMenu_OnItemDataBounds(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			((Button)e.Item.FindControl("WBtnMainMenuUpdate")).Attributes.Add("onclick", "return confirm('수정하시겠습니까?');");
			((Button)e.Item.FindControl("WBtnMainMenuDel")).Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");

			DropDownList WDDL = (DropDownList)e.Item.FindControl("WDDLMenuContents");

			for (int i = 0; i < WDDLMenuContents.Items.Count; i++)
			{
				WDDL.Items.Add(new ListItem(WDDLMenuContents.Items[i].Text, WDDLMenuContents.Items[i].Value));
			}

			WDDL.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "contentId").ToString();
		}
	}

	protected void WRptSubMenu_OnItemCommands(object sender, RepeaterCommandEventArgs e)
	{
		int nRet = 0;
		int submenuId = Convert.ToInt32(e.CommandArgument.ToString());

		SqlConnection conn = DBUtil.GetUserDBConn();

		switch (e.CommandName)
		{
			case "update":
				string sNameKey = ((TextBox)e.Item.FindControl("WTxtNameKey")).Text.Trim();
				string sPrefab1 = ((TextBox)e.Item.FindControl("WTxtPrefab1")).Text.Trim();
				string sPrefab2 = ((TextBox)e.Item.FindControl("WTxtPrefab2")).Text.Trim();
				string sPrefab3 = ((TextBox)e.Item.FindControl("WTxtPrefab3")).Text.Trim();
				int nLayout = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtLayout")).Text.Trim());
				int nSortNo = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtSortNo")).Text.Trim());
				int nContentId = Convert.ToInt32(((DropDownList)e.Item.FindControl("WDDLMenuContents")).SelectedValue);

				nRet = DacUser.UpdateSubMenu(conn, null, m_nMainMenuId, submenuId, sNameKey, sPrefab1, sPrefab2, sPrefab3, nLayout, nSortNo, nContentId);
				break;
			case "delete":
				nRet = DacUser.DeleteSubMenu(conn, null, m_nMainMenuId, submenuId);
				break;
			default:
				nRet = 2;
				break;
		}

		DBUtil.CloseDBConn(conn);

		switch (nRet)
		{
			case 0:
				if (e.CommandName == "update")
					ComUtil.MsgBox("수정에 성공하였습니다.", "location.href='" + Request.Url.ToString() + "';");
				if (e.CommandName == "delete")
					Response.Redirect(Request.Url.ToString());
				break;
			case 1:
				if (e.CommandName == "update")
					ComUtil.MsgBox("수정에 실패했습니다.", "history.back();");
				if (e.CommandName == "delete")
					ComUtil.MsgBox("삭제에 실패했습니다.", "history.back();");
				break;
			default:
				ComUtil.MsgBox("잘못된 접근입니다.(" + nRet.ToString() + ")", "history.back();");
				break;
		}
	}

	protected void WBtnSubMenuDefault_OnClick(object sender, EventArgs e)
	{
		int nSubMenuId = Convert.ToInt32(WDDLSubMenus.SelectedValue);

		//공백체크
		if (nSubMenuId == 0)
		{
			ComUtil.MsgBox("서브메뉴를 선택해주세요.");
			return;
		}

		SqlConnection conn = DBUtil.GetUserDBConn();

		int nRet = DacUser.UpdateSubMenu_IsDefault(conn, null, m_nMainMenuId, nSubMenuId);

		DBUtil.CloseDBConn(conn);

		if (nRet == 0)
		{
			ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
		}
		else
		{
			ComUtil.MsgBox("작업실패", "history.back();");
		}
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "isDefault":
				if(Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
					sRtn = "O";
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
		return sRtn;
	}
}