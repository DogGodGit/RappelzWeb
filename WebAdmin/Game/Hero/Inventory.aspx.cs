using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_Hero_Inventory : System.Web.UI.Page
{
	protected int m_nServerId;
	protected Guid m_heroId;

	private const int kInventorySlotType_MainGear = 1;
	private const int kInventorySlotType_SubGear = 2;
	private const int kInventorySlotType_Item = 3;

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

		WBtnItemAdd.Attributes.Add("onclick", "return confirm('아이템을 추가하시겠습니까?')");
		WBtnMainGearAdd.Attributes.Add("onclick", "return confirm('메인장비를 추가하시겠습니까?')");
		WBtnSubGearAdd.Attributes.Add("onclick", "return confirm('서브장비를 보유중인 경우 메인퀘스트가 진행되지 않을 수 있습니다.\\n서브장비를 추가하시겠습니까?')");

		SqlConnection connGame = DBUtil.GetGameDBConn(m_nServerId);
		DataRow drHero = Dac.Hero(connGame, null, m_heroId);
		DataTable dtInventorySlots = Dac.InventorySlots(connGame, null, m_heroId);
		DBUtil.CloseDBConn(connGame);

		SqlConnection connUser = DBUtil.GetUserDBConn();
		DataRow drJobLevelMaster = DacUser.JobLevelMaster(connUser, null, Convert.ToInt32(drHero["level"]));
		DataTable dtItems = DacUser.Items(connUser, null);
		DataTable dtMainGears = DacUser.MainGears(connUser, null);
		DataTable dtSubGears = DacUser.SubGears(connUser, null);
		DataTable dtSubGearNames = DacUser.SubGearNames(connUser, null);
		DBUtil.CloseDBConn(connUser);

		int nInventorySlotCount = Convert.ToInt32(drJobLevelMaster["inventorySlotAccCount"]);
		int nPaidInventorySlotCount = Convert.ToInt32(drHero["paidInventorySlotCount"]);

		int nTotalInventorySlotCount = nInventorySlotCount + nPaidInventorySlotCount;

		// 인벤토리 슬롯 추가
		for (int i = 0; i < nTotalInventorySlotCount; i++)
			WDDLSlot.Items.Add(new ListItem("Slot " + i.ToString(), i.ToString()));

		// 인벤토리 슬롯에서 보유슬롯을 삭제
		for (int i = 0; i < dtInventorySlots.Rows.Count; i++)
			WDDLSlot.Items.Remove(WDDLSlot.Items.FindByValue(dtInventorySlots.Rows[i]["slotIndex"].ToString()));

		// 아이템
		for (int i = 0; i < dtItems.Rows.Count; i++)
			WDDLItem.Items.Add(new ListItem(dtItems.Rows[i]["itemId"].ToString() + " - " + dtItems.Rows[i]["_name"].ToString(), dtItems.Rows[i]["itemId"].ToString()));

		// 메인장비
		for (int i = 0; i < dtMainGears.Rows.Count; i++)
			WDDLMainGear.Items.Add(new ListItem(dtMainGears.Rows[i]["mainGearId"].ToString() + " - " + dtMainGears.Rows[i]["_name"].ToString(), dtMainGears.Rows[i]["mainGearId"].ToString()));

		// 서브장비
		for (int i = 0; i < dtSubGears.Rows.Count; i++)
		{
			DataRow[] drNames = dtSubGearNames.Select("subGearId = " + dtSubGears.Rows[i]["subGearId"].ToString() + " AND grade = 1");
			WDDLSubGear.Items.Add(new ListItem(dtSubGears.Rows[i]["subGearId"].ToString() + " - " + drNames[0]["_name"].ToString(), dtSubGears.Rows[i]["subGearId"].ToString()));
		}

		dtSubGearNames.Dispose();

		WRptList.DataSource = dtInventorySlots;
		WRptList.DataBind();
	}

	protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
			Literal WLtlName = ((Literal)e.Item.FindControl("WLtlName"));
			Literal WLtlId = ((Literal)e.Item.FindControl("WLtlId"));
			string sId = ComUtil.GetDataItem(e.Item.DataItem, "id");

			switch (Convert.ToInt32(ComUtil.GetDataItem(e.Item.DataItem, "slotType")))
			{
				case 1 :
					WLtlId.Text = ComUtil.GetDataItem(e.Item.DataItem, "heroMainGearId");
					for (int i = 0; i < WDDLMainGear.Items.Count; i++)
					{
						if (WDDLMainGear.Items[i].Value == sId)
						{
							WLtlName.Text = WDDLMainGear.Items[i].Text;
							break;
						}
					}
					break;
				case 2 :
					WLtlId.Text = ComUtil.GetDataItem(e.Item.DataItem, "subGearId");
					for (int i = 0; i < WDDLSubGear.Items.Count; i++)
					{
						if (WDDLSubGear.Items[i].Value == sId)
						{
							WLtlName.Text = WDDLSubGear.Items[i].Text;
							break;
						}
					}
					break;
				case 3 :
					WLtlId.Text = ComUtil.GetDataItem(e.Item.DataItem, "itemId");
					for (int i = 0; i < WDDLItem.Items.Count; i++)
					{
						if (WDDLItem.Items[i].Value == sId)
						{
							WLtlName.Text = WDDLItem.Items[i].Text;
							break;
						}
					}
					break;
				default:
					WLtlId.Text = "해당없음";
					break;
			}
        }
    }

	protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
	{

	}

	protected void WBtnItemAdd_OnClick(object sender, EventArgs e)
	{
		int nSlotIndex = Convert.ToInt32(WDDLSlot.SelectedValue);
		int nItemId = Convert.ToInt32(WDDLItem.SelectedValue);
		int nItemCount = Convert.ToInt32(WTxtItemCount.Text.Trim());
		bool itemOwned = WCBoxItemOwned.Checked;

		Guid heroMainGearId = Guid.Empty;
		int nSubGearId = 0;

		SqlConnection connGame = DBUtil.GetGameDBConn(m_nServerId);
		if (Dac.Hero_Connection(connGame, null, m_heroId) != 0)
		{
			DBUtil.CloseDBConn(connGame);
			ComUtil.MsgBox("영웅이 접속중입니다.", "history.back();");
			return;
		}
		int nRet = Dac.AddInventorySlot(connGame, null, m_heroId, nSlotIndex, kInventorySlotType_Item, heroMainGearId, nSubGearId, nItemId, nItemCount, itemOwned);
		DBUtil.CloseDBConn(connGame);

		if (nRet == 0)
		{
			Response.Redirect(Request.Url.ToString());
		}
		
		ComUtil.MsgBox("오류(" + nRet.ToString() + ")", "history.back();");
	}

	protected void WBtnMainGearAdd_OnClick(object sender, EventArgs e)
	{
		SqlConnection connGame = null;
		SqlConnection connUser = null;

		SqlTransaction tranGame = null;

		try
		{
			int nSlotIndex = Convert.ToInt32(WDDLSlot.SelectedValue);
			int nItemId = 0;
			int nItemCount = 0;
			bool itemOwned = false;
			int nSubGearId = 0;

			Guid heroMainGearId = Guid.NewGuid();
			int nMainGearid = Convert.ToInt32(WDDLMainGear.SelectedValue);
			bool owned = WCBoxMainGearOwned.Checked;
			int nOptionCount = Util.GetRandomIntValue(1, 5);

			// 옵션속성 뽑기(5개)
			connUser = DBUtil.GetUserDBConn();
			DataTable dtMainGearOptionAttrs = DacUser.PickMainGearOptionAttrPoolEntry(connUser, null, nMainGearid);
			DBUtil.CloseDBConn(connUser);

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

			// 인벤토리 추가
			if (Dac.AddInventorySlot(connGame, tranGame, m_heroId, nSlotIndex, kInventorySlotType_MainGear, heroMainGearId, nSubGearId, nItemId, nItemCount, itemOwned) != 0)
			{
				tranGame.Rollback();
				tranGame.Dispose();

				DBUtil.CloseDBConn(connGame);

				ComUtil.MsgBox("인벤토리 등록 실패", "history.back();");
				return;
			}

			// 메인장비 등록
			if (Dac.AddHeroMainGear(connGame, tranGame, heroMainGearId, m_heroId, nMainGearid, 0, owned) != 0)
			{
				tranGame.Rollback();
				tranGame.Dispose();

				DBUtil.CloseDBConn(connGame);

				ComUtil.MsgBox("메인장비 등록 실패", "history.back();");
				return;
			}

			// 메인장비 속성 등록
			for (int i = 0; i < nOptionCount; i++)
			{
				if (Dac.AddHeroMainGearOptionAttr(connGame, tranGame, heroMainGearId, i, Convert.ToInt32(dtMainGearOptionAttrs.Rows[i]["grade"]), Convert.ToInt32(dtMainGearOptionAttrs.Rows[i]["attrId"]), Convert.ToInt64(dtMainGearOptionAttrs.Rows[i]["attrValueId"])) != 0)
				{
					tranGame.Rollback();
					tranGame.Dispose();

					DBUtil.CloseDBConn(connGame);

					ComUtil.MsgBox("메인장비 옵션 속성 등록 실패", "history.back();");
					return;
				}
			}

			tranGame.Commit();
			tranGame.Dispose();

			DBUtil.CloseDBConn(connGame);

			Response.Redirect(Request.Url.ToString());
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
			if (connUser != null && connUser.State == ConnectionState.Connecting)
				DBUtil.CloseDBConn(connUser);
		}
	}

	protected void WBtnSubGearAdd_OnClick(object sender, EventArgs e)
	{
		SqlConnection connGame = null;
		SqlTransaction tranGame = null;

		try
		{
			int nSlotIndex = Convert.ToInt32(WDDLSlot.SelectedValue);
			int nItemId = 0;
			int nItemCount = 0;
			bool itemOwned = false;
			int nSubGearId = Convert.ToInt32(WDDLSubGear.SelectedValue);

			Guid heroMainGearId = Guid.Empty;
			int nMainGearid = Convert.ToInt32(WDDLMainGear.SelectedValue);
			bool owned = WCBoxMainGearOwned.Checked;
			int nOptionCount = Util.GetRandomIntValue(1, 5);

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

			// 인벤토리 추가
			if (Dac.AddInventorySlot(connGame, tranGame, m_heroId, nSlotIndex, kInventorySlotType_SubGear, heroMainGearId, nSubGearId, nItemId, nItemCount, itemOwned) != 0)
			{
				tranGame.Rollback();
				tranGame.Dispose();

				DBUtil.CloseDBConn(connGame);

				ComUtil.MsgBox("인벤토리 등록 실패", "history.back();");
				return;
			}

			// 서브장비 등록
			int nRet = Dac.AddHeroSubGear(connGame, tranGame, m_heroId, nSubGearId);
			if (nRet != 0)
			{
				tranGame.Rollback();
				tranGame.Dispose();

				DBUtil.CloseDBConn(connGame);

				if(nRet == 2)
					ComUtil.MsgBox("보유중인 서브장비입니다.", "history.back();");
				else
					ComUtil.MsgBox("서브장비 등록 실패(" + nRet.ToString() + ")", "history.back();");
				return;
			}

			tranGame.Commit();
			tranGame.Dispose();

			DBUtil.CloseDBConn(connGame);

			Response.Redirect(Request.Url.ToString());
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
		}
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "slotType":
				switch (ComUtil.GetDataItem(objData, sFieldNm))
				{
					case "1": sRtn = "메인장비";
						break;
					case "2": sRtn = "서브장비";
						break;
					case "3": sRtn = "아이템";
						break;
					default: sRtn = "unknown";
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