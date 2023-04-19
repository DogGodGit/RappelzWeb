using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Sub_Game_MenuSetting : System.Web.UI.Page
{
	protected int mainmenuId = 0 ;
    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
		 mainmenuId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);

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

		DataTable dt = DacUser.SubMenus(conn, null, mainmenuId);
		DataRow dr = DacUser.MainMenu(conn, null, mainmenuId);

		DBUtil.CloseDBConn(conn);

		//선택된 메인메뉴 정보들.
		WTxtMainMenuId.Text = dr["menuId"].ToString();
		TextBox1.Text = dr["nameKey"].ToString();
		TextBox2.Text = dr["popupName"].ToString();

		//서브메뉴 등록시 노출되는 메인메뉴ID
		WLtlMainMenuIds.Text = dr["menuId"].ToString();

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
		string sprefab1Add = Wtxtprefab1Add.Text.Trim();
		string sprefab2Add = Wtxtprefab2Add.Text.Trim();

		//공백체크
		if (sSubMenuId.ToString() == "")
		{
			ComUtil.MsgBox("서브메뉴ID를 입력해주세요.");
			return;
		}

		SqlConnection conn = DBUtil.GetUserDBConn();

		nRet = DacUser.AddSubMenu(conn, null, mainmenuId, sSubMenuId, sSubnameKeyAdd, sprefab1Add, sprefab2Add, "", 0, 0, 0);

		DBUtil.CloseDBConn(conn);

		if (nRet == 0)
		{
			Response.Redirect(Request.Url.ToString());
			//ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
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
		}
	}

	protected void WRptSubMenu_OnItemCommands(object sender, RepeaterCommandEventArgs e)
	{
		int nRet = 0;
		int submenuId = Convert.ToInt32(e.CommandArgument.ToString());

		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.MainMenus(conn, null);

		switch (e.CommandName)
		{
			case "update":
					string subNameKey = ((TextBox)e.Item.FindControl("WTxtNameKey")).Text.Trim();
					string subPrefab1 = ((TextBox)e.Item.FindControl("WTxtprefab1")).Text.Trim();
					string subPrefab2 = ((TextBox)e.Item.FindControl("WTxtprefab2")).Text.Trim();

				nRet = DacUser.UpdateSubMenu(conn, null, mainmenuId, submenuId, subNameKey, subPrefab1, subPrefab2, "", 0, 0, 0);
				break;
			case "delete":

				nRet = DacUser.DeleteSubMenu(conn, null, mainmenuId, submenuId);
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
				ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
				break;
		}
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