using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_MenuSetting : System.Web.UI.Page
{
	protected int mainMenuId = 0;

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
		WBtnAdd.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");

		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.MainMenus(conn, null);

		DBUtil.CloseDBConn(conn);

		WRptMainMenu.DataSource = dt;
		WRptMainMenu.DataBind();
	}

	protected void WBtnAdd_OnClick(object sender, EventArgs e)
	{
		string mainMenuId = WTxtmenuIdAdd.Text.Trim();
		string nameKey = WtxtnameKeyAdd.Text.Trim();
		string popupName = WtxtpopUpNameAdd.Text.Trim();

		//공백체크
		if (mainMenuId == "")
		{
			ComUtil.MsgBox("메뉴ID를 입력해주세요.");
			return;
		}

		int menuId = Convert.ToInt32(mainMenuId);
		int nRet = 0;

		SqlConnection conn = DBUtil.GetUserDBConn();

		nRet = DacUser.AddMainMenu(conn, null, menuId, nameKey, popupName);

		DBUtil.CloseDBConn(conn);

		if (nRet == 0)
		{
			Response.Redirect(Request.Url.ToString());
		}
		else
		{
			ComUtil.MsgBox("작업실패", "history.back();");
		}

	}

	protected void WRptMainMenu_OnItemDataBounds(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			((Button)e.Item.FindControl("WBtnMainMenuUpdate")).Attributes.Add("onclick", "return confirm('수정하시겠습니까?');");
			((Button)e.Item.FindControl("WBtnMainMenuDel")).Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");
		}
	}
	protected void WRptMainMenu_OnItemCommands(object sender, RepeaterCommandEventArgs e)
	{
		int nRet = 0;
		mainMenuId = Convert.ToInt32(e.CommandArgument.ToString());

		SqlConnection conn = DBUtil.GetUserDBConn();

		
		switch (e.CommandName)
		{
			case "SubMenuBtn":
				Response.Redirect("/Game/SubMenuSetting.aspx?MID=" + mainMenuId.ToString());
				break;

			case "update":
				string sNameKey = ((TextBox)e.Item.FindControl("WTxtNameKey")).Text.Trim();
				string spopUpName = ((TextBox)e.Item.FindControl("WTxtPopName")).Text.Trim();

				nRet = DacUser.UpdateMainMenu(conn, null, mainMenuId, sNameKey, spopUpName);
				break;
			case "delete":
				//if(서브메뉴의 로그가 남아있지 않다면 메인메뉴삭제)
				DataTable sdt = DacUser.SubMenus(conn, null, mainMenuId);
				if (sdt.Rows.Count == 0)
				{
					nRet = DacUser.DeleteMainMenu(conn, null, mainMenuId);
				}
				else
				{
					nRet = 3;
				}

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
			case 3:
				ComUtil.MsgBox("서브메뉴가 존재하여 삭제에 실패했습니다.", "history.back();");
				break;
			default:
				ComUtil.MsgBox("잘못된 접근입니다.(" + nRet.ToString() + ")", "history.back();");
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