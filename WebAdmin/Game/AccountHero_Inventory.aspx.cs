using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

public partial class Game_Inventory : System.Web.UI.Page
{
	private const int LogType_Modify = 1;
	private const int LogType_Delete = 2;

	protected int m_nGameServerId = 0;
	protected int m_nHeroId = 0;

	protected string[] names;
	
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
		m_nHeroId = ComUtil.GetRequestInt("AHID", RequestMethod.Get, 0);

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
		WBtnAddItem.Attributes.Add("onclick", string.Format("return confirm('{0}');", "아이템을 등록하시겠습니까?"));
		WBtnAddGear.Attributes.Add("onclick", string.Format("return confirm('{0}');", "장비를 등록하시겠습니까?"));

		//DB연결
		SqlConnection uConn = DBUtil.GetUserDBConn();
		SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(m_nGameServerId));

		DataTable dtAccountHeros = Dac.SearchHeros(conn, null, 1, m_nHeroId);
		DataTable dtInventory = Dac.InventorySlots(conn, null, m_nHeroId);
		DataRow dr = Dac.Hero(conn, null, m_nHeroId);
		DataTable dtItems = DacUser.Items(uConn, null);
		DataTable dtGears = DacUser.Gears(uConn, null);
		DataTable dtGrades = DacUser.Grades(uConn, null);
		
		//DB연결끊기
		DBUtil.CloseDBConn(conn);
	
		//계정정보
		int nInventorySlotCount = Convert.ToInt32(dr["inventorySlotCount"]);
		int nIdx = 0;

		// 아이템 선택 컨트롤 채우기
		WDDLItem.Items.Add(new ListItem("아이템 선택", "0"));
		for (int i = 0; i < dtItems.Rows.Count; i++)
		{
			WDDLItem.Items.Add(new ListItem("" + dtItems.Rows[i]["itemId"].ToString() + " " + dtItems.Rows[i]["_name"], dtItems.Rows[i]["itemId"].ToString()));
		}

		//장비 선택 컨트롤 채우기
		WDDLGear.Items.Add(new ListItem("장비 선택", "0"));
		for (int i = 0; i < dtGears.Rows.Count; i++)
		{
			WDDLGear.Items.Add(new ListItem("" + dtGears.Rows[i]["gearId"].ToString() + " " + dtGears.Rows[i]["_name"], dtGears.Rows[i]["gearId"].ToString()));
		}

		//등급 선택 컨트롤 채우기
		WDDLGearGrade.Items.Add(new ListItem("등급 선택", "0"));
		for (int i = 0; i < dtGrades.Rows.Count; i++)
		{
			WDDLGearGrade.Items.Add(new ListItem("" + dtGrades.Rows[i]["grade"].ToString() + " " + dtGrades.Rows[i]["_name"], dtGrades.Rows[i]["grade"].ToString()));
		}

		//슬롯 선택 컨트롤 채우기
		for (int i = 0; i < nInventorySlotCount; i++)
		{
			if (dtInventory.Rows.Count > 0 && dtInventory.Rows.Count > nIdx && Convert.ToInt32(dtInventory.Rows[nIdx]["slotIndex"]) == i)
				nIdx++;
			else
				// 인벤토리 슬롯이 비어있는 경우
				WDDLEmptySlot.Items.Add(new ListItem("Slot " + i.ToString(), i.ToString()));
		}

		WRptList.DataSource = dtInventory;
		WRptList.DataBind();

	}

	//인벤토리에 장비 등록
	protected void WBtnAddGear_OnClick(object sender, EventArgs e)
	{
		try
		{
			int nSlotIndex = Convert.ToInt32(WDDLEmptySlot.SelectedValue);
			int nGearId = Convert.ToInt32(WDDLGear.SelectedValue);
			int nGrade = Convert.ToInt32(WDDLGearGrade.SelectedValue);
			bool isOwned = WCBoxOwnGear.Checked;
			
			//예외처리
			if (nGearId == 0)
			{
				ComUtil.MsgBox("장비를 선택해주세요.", "historyback()");
				return;
			}
			if (nGrade <= 0)
			{
				ComUtil.MsgBox("등급을 선택해주세요.", "historyback()");
				return;
			}

			//DB연결
			SqlConnection conn = DBUtil.GetGameDBConn(m_nGameServerId);


			//인벤토리에 장비 등록
			int nRet = Biz.AddInventoryGear(conn, m_nHeroId, nSlotIndex, nGearId, nGrade, isOwned);

			//DB연결 끊기
			DBUtil.CloseDBConn(conn);

			//등록결과
			switch (nRet)
			{
				case 0: ComUtil.MsgBox("장비가 등록되었습니다.", "location.href='" + Request.Url.ToString() + "';");
					break;
				default: //ComUtil.MsgBox(String.Format("오류내용 : {0}", nRet), "history.back();");
					break;
			}
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox(String.Format("예외오류 오류내용 : {0}", ex.Message), "history.back();");
		}
	}

	// 인벤토리에 아이템 등록
	protected void WBtnAddItem_OnClick(object sender, EventArgs e)
	{
		try
		{
			// 값가져오기
			int nSlotIndex = Convert.ToInt32(WDDLEmptySlot.SelectedValue);
			int nItemId = Convert.ToInt32(WDDLItem.SelectedValue);
			bool isOwned = WCBoxOwnItem.Checked;
			int nCount = Convert.ToInt32(WTxtItemCount.Text.Trim());
			Guid uidHeroGearId = Guid.Empty;

			//예외처리
			if (nItemId == 0)
			{
				ComUtil.MsgBox("아이템을 선택해주세요.", "historyback()");
				return;
			}
			if (nCount <= 0)
			{
				ComUtil.MsgBox("수량은 1개이상을 입력해주세요.", "historyback()");
				return;
			}

			//DB연결
			SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(m_nGameServerId));
		
			// 인벤토리에 아이템 등록
			int nRet = Dac.AddInventorySlot(conn, null, m_nHeroId, nSlotIndex, 2, uidHeroGearId, nItemId, nCount, isOwned);

			//DB연결 끊기
			DBUtil.CloseDBConn(conn);

			// 등록결과
			switch (nRet)
			{
				case 0: ComUtil.MsgBox("아이템이 등록되었습니다.", "location.href='" + Request.Url.ToString() + "';");
					break;
				default: ComUtil.MsgBox(String.Format("오류내용 : {0}", nRet), "history.back();");
					break;
			}

			// Response.Redirect(Request.Url.ToString());
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox(String.Format("예외오류 오류내용 : {0}", ex.Message), "history.back();");
		}
	}

	protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			((Button)e.Item.FindControl("WBtnDel")).Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));

			((HiddenField)e.Item.FindControl("WHFInventoryType")).Value = ComUtil.GetDataItem(e.Item.DataItem, "Type");

			//아이템,장비 잠금표시 체크
			if (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "itemOwned")))
			{
				((Image)e.Item.FindControl("WImagelock")).Visible = true;
			}
			
			if (ComUtil.GetDataItem(e.Item.DataItem, "Type") == "2")
			{
				//타입이 아이템일 경우
				((TextBox)e.Item.FindControl("WTxtCount")).Text = ComUtil.GetDataItem(e.Item.DataItem, "itemCount");
				((Button)e.Item.FindControl("WBtnUpdate")).Attributes.Add("onclick", string.Format("return confirm('{0}');", "수정하시겠습니까?"));
				((Button)e.Item.FindControl("WBtnUpdate")).Visible = true;

				((HiddenField)e.Item.FindControl("WHFItemId")).Value = ComUtil.GetDataItem(e.Item.DataItem, "ItemId");
				((HiddenField)e.Item.FindControl("WHFCount")).Value = ComUtil.GetDataItem(e.Item.DataItem, "itemCount");
				((HiddenField)e.Item.FindControl("WHFOwned")).Value = ComUtil.GetDataItem(e.Item.DataItem, "itemOwned");
				((Literal)e.Item.FindControl("WLitName")).Text = GetWDDLItem(ComUtil.GetDataItem(e.Item.DataItem, "ItemId"));
			}
			else
			{
				//타입이 장비일 경우
				((TextBox)e.Item.FindControl("WTxtCount")).Visible = false;
				((Literal)e.Item.FindControl("WLitName")).Text = GetWDDLGear(ComUtil.GetDataItem(e.Item.DataItem, "gearId"));
				((HiddenField)e.Item.FindControl("WHFAccountHeroGearId")).Value = ComUtil.GetDataItem(e.Item.DataItem, "heroGearId");
			}
		}
	}

	private string GetWDDLGear(string sGearId)
	{
		for (int i = 0; i < WDDLGear.Items.Count; i++)
			if (WDDLGear.Items[i].Value == sGearId && sGearId != "0")
				return WDDLGear.Items[i].Text;

			return "미확인";
	}

	private string GetWDDLItem(string sItemId)
	{
		for (int i = 0; i < WDDLItem.Items.Count; i++)
			if (WDDLItem.Items[i].Value == sItemId && sItemId != "0")
				return WDDLItem.Items[i].Text;

		return "미확인";
	}

	protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
	{
		try
		{
			int nRet = 0;
			int nSlotNo = Convert.ToInt32(e.CommandArgument.ToString()); //슬롯번호
			int nInventoryType = Convert.ToInt32(((HiddenField)e.Item.FindControl("WHFInventoryType")).Value);
			int nItemId = Convert.ToInt32(((HiddenField)e.Item.FindControl("WHFItemId")).Value);
			int nItemCount = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtCount")).Text.Trim());
			bool bOwned = Convert.ToBoolean(((HiddenField)e.Item.FindControl("WHFOwned")).Value);

			string sHeroGearId = ((HiddenField)e.Item.FindControl("WHFAccountHeroGearId")).Value;
			Guid uidHeroGearId = Guid.Empty;
			if (sHeroGearId != "")
				uidHeroGearId = Guid.Parse(sHeroGearId);

			// 연결정보 가져오기 (DB커넥션 포함됨)
			SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(m_nGameServerId));
		
			switch (e.CommandName)
			{
				case "update":
					nRet = Dac.UpdateInventorySlot_ItemCount(conn, null, m_nHeroId, nSlotNo, nItemCount);
					break;
				case "delete":
					nRet = Biz.DeleteInventorySlot(conn, m_nHeroId, nInventoryType, nSlotNo, uidHeroGearId);
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
						ComUtil.MsgBox("수정 되었습니다.", "location.href='" + Request.Url.ToString() + "';");
					if (e.CommandName == "delete")
						ComUtil.MsgBox("삭제되었습니다.", "location.href='" + Request.Url.ToString() + "';");
					break;
				case 1:
					if (e.CommandName == "update")
						ComUtil.MsgBox("수정실패.", "history.back();");
					if (e.CommandName == "delete")
						ComUtil.MsgBox("삭제실패.", "history.back();");
					break;
				case 2:
					if (e.CommandName == "update")
						ComUtil.MsgBox("수정실패.", "history.back();");
					if (e.CommandName == "delete")
						ComUtil.MsgBox("삭제실패.", "history.back();");
					break;
				default:
					ComUtil.MsgBox("예외발생(" + nRet + ")", "history.back();");
					break;
			}
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox(String.Format("예외 \\n예외내용 : {0}", ex.Message), "history.back();");
		}
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{

			case "type":
				switch (Convert.ToInt32(ComUtil.GetDataItem(objData, "Type")))
				{
					case 1: sRtn = "장비";
						break;
					case 2: sRtn = "아이템";
						break;
				}
				break;
			case "heroGearId":
				switch (Convert.ToInt32(ComUtil.GetDataItem(objData, "Type")))
				{
					case 1: sRtn = "<a href=\"javascript:;\" onclick=\"window.open('/Game/Popup_AccountHeroGear.aspx?SVR=" + m_nGameServerId.ToString() + "&AHGID=" + ComUtil.GetDataItem(objData, "HeroGearId") + "', 'AHG', 'width=400,height=400,scrollbars=yes,resizable=no');\">" + ComUtil.GetDataItem(objData, "HeroGearId") + "</a>";
						break;
					case 2: sRtn = ComUtil.GetDataItem(objData, "ItemId");
						break;
				}
				break;
		default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
		return sRtn;
	}
}