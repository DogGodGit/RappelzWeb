using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class Setting_CouponForm : System.Web.UI.Page
{
	private string m_sName = "";
	private string m_sStartTime = "";
	private string m_sEndTime = "";
	private string m_sCouponId = "";
	protected int m_nPage = 0;              // 페이지

	private string m_sPromotionId = "";
	protected string m_sVisibleString = "";

	protected string sScript = "";

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
        m_sPromotionId = ComUtil.GetRequestString("PID", RequestMethod.Get, "");
		m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
		m_sName = ComUtil.GetRequestString("NM", RequestMethod.Get, "");
		m_sStartTime = ComUtil.GetRequestString("ST", RequestMethod.Get, "");
		m_sEndTime = ComUtil.GetRequestString("ET", RequestMethod.Get, "");
		m_sCouponId = ComUtil.GetRequestString("CID", RequestMethod.Get, "");

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
		WPHTargetServer.Visible = false;
		WBtnAddTarget.Attributes.Add("onclick", "return confirm('대상을 추가하시겠습니까?')");
		WDDLRegion.Attributes.Add("onchange", "selChange(this);");
		WDDLGroup.Attributes.Add("onchange", "selChange(this);");
		WDDLServer.Attributes.Add("onchange", "selChange(this);");

		WBtnAddPromotion.Text = Resources.ResLang.CouponAdd_aspx_txt_01;
		WBtnAddPromotion.Attributes.Add("onclick", "return sendMail();");
		
		// 유저DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

        //DataRowCollection drcGameServer = DacUser.GameServers(conn, null, nGroupId);
        DataTable drcGameServer = DacUser.GameServerAll(conn, null);

        DataRow drPromotion = null;
		DataTable dtPromotionItems = null;
		DataTable dtPromotionTargets = null;
		if (m_sPromotionId != "")
		{
            Guid sPromotionId = Guid.Parse(m_sPromotionId);
            drPromotion = DacUser.Promotion(conn, null, sPromotionId);
			
			if (drPromotion == null)
			{
				ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_01, "history.back();");
				DBUtil.CloseDBConn(conn);
				return;
			}

			dtPromotionItems = DacUser.PromotionItems(conn, null, sPromotionId);
			dtPromotionTargets = DacUser.PromotionTargets(conn, null, sPromotionId);
		}

		DataTable dtRegion = DacUser.GameServerRegions(conn, null);
		DataTable dtGroup = DacUser.GameServerGroups(conn, null);
        //DataRowCollection drcServer = DacUser.GameServers(conn, null); //서버목록
        DataTable drcServer = DacUser.GameServerAll(conn, null);

		int nIndex = 0;

		StringBuilder sb = new StringBuilder();

		sb.Append("var arrRegion = [");
		foreach (DataRow dr in dtRegion.Rows)
		{
			if (nIndex > 0)
				sb.Append(",");
			sb.Append("{regionId:" + dr["regionId"].ToString() + ", name:'" + dr["_name"].ToString() + "'}");
			nIndex++;
		}
		sb.Append("];");

		sb.AppendLine();

		nIndex = 0;

		sb.Append("var arrGroup = [");
		foreach (DataRow dr in dtGroup.Rows)
		{
			if (nIndex > 0)
				sb.Append(",");
			sb.Append("{groupId:" + dr["groupId"].ToString() + ", name:'" + dr["_name"].ToString() + "', regionId:" + dr["regionId"].ToString() + "}");
			nIndex++;
		}	
		sb.Append("];");

		sb.AppendLine();

		nIndex = 0;

		sb.Append("var arrServer = [");

        //DataRowCollection drcServer = DacUser.GameServers(conn, null); //서버목록

        foreach (DataRow dr in drcServer.Rows)
		{
			if (nIndex > 0)
				sb.Append(",");
			sb.Append("{serverId:" + dr["serverId"].ToString() + ", name:'" + dr["displayName"].ToString() + "', groupId:" + dr["groupId"].ToString() + "}");
			nIndex++;
		}
		sb.Append("];");

		sScript = sb.ToString();
		sb.Clear();

        WDDLMailTitleType.Items.Add(new ListItem("일반텍스트", "1"));
        WDDLMailTitleType.Items.Add(new ListItem("스트링키", "2"));
        WDDLMailContentType.Items.Add(new ListItem("일반텍스트", "1"));
        WDDLMailContentType.Items.Add(new ListItem("스트링키", "2"));
        /*
		WDDLMailTitleType.Items.Add(new ListItem(Resources.ResLang.SendMail_aspx_txt_09, "1"));
		WDDLMailTitleType.Items.Add(new ListItem(Resources.ResLang.SendMail_aspx_txt_08, "2"));
		WDDLMailContentType.Items.Add(new ListItem(Resources.ResLang.SendMail_aspx_txt_09, "1"));
		WDDLMailContentType.Items.Add(new ListItem(Resources.ResLang.SendMail_aspx_txt_08, "2"));
        */
        int nSelectedserverId = -1;

		foreach (DataRow dr in drcGameServer.Rows)
		{
			if (!Convert.ToBoolean(dr["deleted"]))
			{
				nSelectedserverId = Convert.ToInt32(dr["serverId"]);
				break;
			}
		}

		if (nSelectedserverId == -1)
		{
			ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_02, "history.back();");
			return;
		}

        // 연결정보 가져오기 (DB커넥션 포함됨)
        //string sConnectionString = DataUtil.GetGameServerConnectionString(nSelectedserverId);

        // DB연결
        // SqlConnection connGame = DBUtil.GetGameDBConn(sConnectionString);-- UserDB에 테이블이 있음. 디비 안바꿔도 됨 
       
        DataTable dtItems = DacUser.Items(conn, null);

		DBUtil.CloseDBConn(conn);
		
		// 아이템 선택 컨트롤 채우기
		for (int i = 0; i < dtItems.Rows.Count; i++)
			WDDLItem.Items.Add(new ListItem("" + dtItems.Rows[i]["itemId"].ToString() + " " + dtItems.Rows[i]["_name"].ToString(), dtItems.Rows[i]["itemId"].ToString()));

		WTxtStartTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now);
		WTxtEndTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now);
		CouponTitle.InnerText = Resources.ResLang.CouponAdd_aspx_txt_03;
		ItemNames.Visible = false;
		if (m_sPromotionId != "")
		{
			WPHTargetServer.Visible = true;
			WLtlTargetGuide.Text = "";

			CouponTitle.InnerText = Resources.ResLang.CouponUpdate_aspx_txt_06;
			ItemNames.Visible = true;
			WBtnAddPromotion.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.CouponPopup_cs_txt_03));
			WBtnAddPromotion.Text = Resources.ResLang.CouponUpdate_aspx_txt_04;

			WTxtName.Text = drPromotion["_name"].ToString();
			WTxtCouponCount.Text = drPromotion["couponCount"].ToString();
			WCBoxType.Checked = (drPromotion["type"].ToString() == "1") ? false : true;
			WTxtStartTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(drPromotion["startTime"].ToString()));
			WTxtEndTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(drPromotion["endTime"].ToString()));
			WCBoxEnabled.Checked = Convert.ToBoolean(drPromotion["enabled"]);
			WDDLMailTitleType.SelectedValue = drPromotion["mailTitleType"].ToString();
			WTxtMailTitle.Text = drPromotion["mailTitle"].ToString();
			WDDLMailContentType.SelectedValue = drPromotion["mailContentType"].ToString();
			WTxtMailContent.Text = drPromotion["mailContent"].ToString();

			m_sVisibleString = "display:none;";

			WTxtName.Enabled = false;
			WCBoxType.Enabled = false;

			WRptList.DataSource = dtPromotionItems;
			WRptList.DataBind();

			WRptTarget.DataSource = dtPromotionTargets;
			WRptTarget.DataBind();

			WLtlList.Text = "<input type=\"button\"" + "value=\"" + Resources.ResLang.CouponUpdate_aspx_txt_05 + "\" class=\"button\" onclick=\"location.href='/Setting/CouponSystem.aspx?" + string.Format("NM={0}&ST={1}&ET={2}&CID={3}&PG={4}", m_sName, m_sStartTime, m_sEndTime, m_sCouponId, m_nPage) + "';\" />";
		}
		else
		{
			WLtlTargetGuide.Text = "<span class=\"red\">대상은 캠페인 등록 후 추가하실 수 있습니다.</span>";
		}
	}

	protected void WBtnAddTarget_OnClick(object sender, EventArgs e)
	{
        if (m_sPromotionId != "")
        {
			int nTargetRegionId = Convert.ToInt32(WHFSelectedRegion.Value);
			int nTargetGroupId = Convert.ToInt32(WHFSelectedGroup.Value);
			int nTargetServerId = Convert.ToInt32(WHFSelectedServer.Value);

			if (nTargetRegionId < 0)
			{
				ComUtil.MsgBox("설정할 값이 없습니다.", "history.back();");
				return;
			}

			// 유저DB연결
			SqlConnection conn = DBUtil.GetUserDBConn();
			SqlTransaction tran = conn.BeginTransaction();

            Guid sPromotionId = Guid.Parse(m_sPromotionId);
            if (DacUser.AddPromotionTarget(conn, tran, sPromotionId, nTargetRegionId, nTargetGroupId, nTargetServerId) != 0)
			{
				tran.Rollback();
				tran.Dispose();
				DBUtil.CloseDBConn(conn);

				ComUtil.MsgBox("대상등록 실패", "history.back();");
				return;
			}

			// 트랜잭션 정리
			tran.Commit();
			tran.Dispose();

			// DB연결해제
			DBUtil.CloseDBConn(conn);

			Response.Redirect(Request.Url.ToString());
		}
	}

	protected void WBtnAddPromotion_OnClick(object sender, EventArgs e)
	{
		//int nTargetRegionId = Convert.ToInt32(WDDLRegion.SelectedValue);
		//int nTargetGroupId = Convert.ToInt32(WDDLGroup.SelectedValue);
		//int nTargetServerId = Convert.ToInt32(WDDLServer.SelectedValue);

		if (m_sPromotionId != "")
		{
			string sStartTime = WTxtStartTime.Text.Trim();
			string sEndTime = WTxtEndTime.Text.Trim();
			bool enabled = WCBoxEnabled.Checked;

			int nMailTitleType = Convert.ToInt32(WDDLMailTitleType.SelectedValue);
			string sMailTitle = WTxtMailTitle.Text.Trim();
			int nMailContentType = Convert.ToInt32(WDDLMailContentType.SelectedValue);
			string sMailContent = WTxtMailContent.Text.Trim();

			DateTime dtStartTime;
			DateTime dtEndTime;

			// 값 체크
			if (sStartTime == "" || sEndTime == "" || !DateTime.TryParse(sStartTime, out dtStartTime) || !DateTime.TryParse(sEndTime, out dtEndTime) || sMailTitle == "" || sMailContent == "" || DateTime.Compare(dtStartTime, dtEndTime) > -1)
			{
				ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_04);
				return;
			}
			// 유저DB연결
			SqlConnection conn = DBUtil.GetUserDBConn();

			SqlTransaction tran = conn.BeginTransaction();
            Guid sPromotionId = Guid.Parse(m_sPromotionId);
            // 프로모션 등록
            int nRetVal = DacUser.UpdatePromotion(conn, tran, sPromotionId, dtStartTime, dtEndTime, nMailTitleType, sMailTitle, nMailContentType, sMailContent, enabled);

			if (nRetVal != 0)
			{
				tran.Rollback();
				tran.Dispose();
				DBUtil.CloseDBConn(conn);

				ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_05, "history.back();");
				return;
			}
			// 트랜잭션 정리
			tran.Commit();
			tran.Dispose();

			// DB연결해제
			DBUtil.CloseDBConn(conn);

			Response.Redirect(Request.Url.ToString());
		}
		else
		{
			string sName = WTxtName.Text.Trim();
			int nCouponLength = Convert.ToInt32(WDDLCouponLength.SelectedValue);
			int nCouponCount = Convert.ToInt32(WTxtCouponCount.Text.Trim());
			int nType = (WCBoxType.Checked) ? 2 : 1;
			string sStartTime = WTxtStartTime.Text.Trim();
			string sEndTime = WTxtEndTime.Text.Trim();
			bool enabled = WCBoxEnabled.Checked;

			string sCouponCodeHeader = WTxtCouponHeader.Text.Trim();

			int nMailTitleType = Convert.ToInt32(WDDLMailTitleType.SelectedValue);
			string sMailTitle = WTxtMailTitle.Text.Trim();
			int nMailContentType = Convert.ToInt32(WDDLMailContentType.SelectedValue);
			string sMailContent = WTxtMailContent.Text.Trim();

			//int nOwnDia = Convert.ToInt32(WTxtOwnDia.Text.Trim());
			//int nOwnGold = Convert.ToInt32(WTxtOwnGold.Text.Trim());

			string sAttachment = WHFMailAttachment.Value;

			DateTime dtStartTime;
			DateTime dtEndTime;

			// 값 체크
			if (nCouponCount < 1 || sName == "" || sStartTime == "" || sEndTime == "" || !DateTime.TryParse(sStartTime, out dtStartTime) || !DateTime.TryParse(sEndTime, out dtEndTime) || sMailTitle == "" || sMailContent == "" || DateTime.Compare(dtStartTime, dtEndTime) > -1)
			{
				ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_04);
				return;
			}
			// 쿠폰생성
			string[] sArrCoupon = new string[nCouponCount];

			string[] sArrCharacters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

			int nIndex = 0;
			nCouponLength = nCouponLength - sCouponCodeHeader.Length;
			string sCouponId = "";
			bool isExists = false;

			StringBuilder sb = new StringBuilder();

			while (nIndex < nCouponCount)
			{
				for (int i = 0; i < nCouponLength; i++)
				{
					sb.Append(sArrCharacters[Util.GetRandomIntValue(Util.random, 0, sArrCharacters.Length)]);
				}

				sCouponId = sb.ToString();
				sb.Clear();
				isExists = false;

				// 중복체크
				for (int i = 0; i < sArrCoupon.Length; i++)
				{
					if (sCouponId == sArrCoupon[i])
					{
						isExists = true;
						break;
					}
				}

				if (!isExists)
				{
					sArrCoupon[nIndex] = sCouponId;
					nIndex++;
				}
			}
			// 유저DB연결
			SqlConnection conn = DBUtil.GetUserDBConn();

			SqlTransaction tran = conn.BeginTransaction();

			Guid sPromotionId = Guid.NewGuid();

            // 프로모션 등록
            int nRetVal = DacUser.AddPromotion(conn, tran, sName, nType, dtStartTime, dtEndTime, nCouponCount, nMailTitleType, sMailTitle, nMailContentType, sMailContent, enabled, sPromotionId);

			if (nRetVal != 0)
			{
				tran.Rollback();
				tran.Dispose();
				DBUtil.CloseDBConn(conn);

				ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_06, "history.back();");
				return;
			}
			// 프로모션 아이템 등록
			if (sAttachment != "")
			{
				string[] sArr = sAttachment.Split('`');
				for (int i = 0; i < sArr.Length; i++)
				{
					string[] sItem = sArr[i].Split('|');
					if (sItem[0] == "2")
					{
						// 아이템
						nRetVal = DacUser.AddPromotionItem(conn, tran, sPromotionId, i + 1, Convert.ToInt32(sItem[1]), Convert.ToInt32(sItem[3]), Convert.ToBoolean(Convert.ToInt32(sItem[2])));

                        if (nRetVal != 0)
						{
							tran.Rollback();
							tran.Dispose();
							DBUtil.CloseDBConn(conn);

							ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_07, "history.back();");
							return;
						}
					}
				}
			}
			// 쿠폰 등록
			for (int i = 0; i < sArrCoupon.Length; i++)
			{
				nRetVal = DacUser.AddCoupon(conn, tran, sCouponCodeHeader + sArrCoupon[i], sPromotionId);
				if (nRetVal != 0)
				{
					tran.Rollback();
					tran.Dispose();
					DBUtil.CloseDBConn(conn);

					ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_08, "history.back();");
					return;
				}
			}
			// 트랜잭션 정리
			tran.Commit();
			tran.Dispose();

			// DB연결해제
			DBUtil.CloseDBConn(conn);

			Response.Redirect("/Setting/CouponSystem.aspx");
		}
	}
	protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			Literal WLtlItemName = (Literal)e.Item.FindControl("WLtlItemName");

			if (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "itemOwned")))
                WLtlItemName.Text = "<img src=\"/Common/Images/ico_lock.png\" width=\"10\" height=\"10\" align=\"absmiddle\">" + GetItemName(ComUtil.GetDataItem(e.Item.DataItem, "itemId"));
            else
                WLtlItemName.Text = "<img src=\"/Common/Images/_blank.gif\" width=\"10\" height=\"10\" align=\"absmiddle\">" + GetItemName(ComUtil.GetDataItem(e.Item.DataItem, "itemId"));
		}
	}

	protected void WRptTarget_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			Button WBtnDelTarget = (Button)e.Item.FindControl("WBtnDelTarget");
			WBtnDelTarget.Attributes.Add("onclick", string.Format("return confirm('{0}');", "대상을 삭제하시겠습니까?"));
		}
	}

	protected void WRptTarget_OnItemCommand(object sender, RepeaterCommandEventArgs e)
	{
		SqlConnection conn = null;

		try
		{
			string[] sArr = e.CommandArgument.ToString().Split(',');

			int nTargetRegionId = Convert.ToInt32(sArr[0]);
			int nTargetGroupId = Convert.ToInt32(sArr[1]);
			int nTargetServerId = Convert.ToInt32(sArr[2]);

			conn = DBUtil.GetUserDBConn();

			switch (e.CommandName)
			{
				case "delete":
                    Guid sPromotionId = Guid.Parse(m_sPromotionId);
                    if (DacUser.DeletePromotionTarget(conn, null, sPromotionId, nTargetRegionId, nTargetGroupId, nTargetServerId) != 0)
					{
						DBUtil.CloseDBConn(conn);
						ComUtil.MsgBox("대상 삭제 실패", "history.back();");
						return;
					}
					
					break;
				default:
					break;
			}

			DBUtil.CloseDBConn(conn);

			ComUtil.MsgBox("대상 삭제 성공", "location.href='" + Request.Url.ToString() + "';");
		}
		catch (Exception ex)
		{
			if (conn != null)
				DBUtil.CloseDBConn(conn);

			ComUtil.MsgBox(String.Format("{0} {1}", Resources.ResLang.COMMON_mbox_02, ex.Message), "history.back();");
		}
	}

	private string GetItemName(string nItemId)
	{
		for (int i = 0; i < WDDLItem.Items.Count; i++)
		{
			if (WDDLItem.Items[i].Value == nItemId)
				return WDDLItem.Items[i].Text;
		}
		return "Unknown";
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "regionName":
			case "groupName":
			case "serverName":
				if (ComUtil.GetDataItem(objData, sFieldNm) != "")
					sRtn += " : ";
				sRtn += ComUtil.GetDataItem(objData, sFieldNm);
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}

		return sRtn;
	}
}