using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using LitJson;

public partial class Setting_SharingEvents_SharingEventSenderReward : System.Web.UI.Page
{
    private int m_nRowsPerPage = 10;        // 페이지 목록 수
    private int n_nPageSize = 10;           // 페이징 수
    private int m_nTotalCount = 1;          // 전체수
    private int m_nTotalPage = 1;           // 전체페이지
    protected int m_nPage = 0;              // 페이지

   // private int nTotCnt = 0;        // 전체페이지
   // private int nTotPage = 1;       // 전체페이지

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
        m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);

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
        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        DataTable drcGameServer = DacUser.GameServerAll(conn, null);

        DataTable dt = DacUser.SharingEventSenderRewards(conn, null, m_nRowsPerPage, m_nPage, out m_nTotalCount);

        int nSelectedGameServerId = -1;

        foreach (DataRow dr in drcGameServer.Rows)
        {
            if (!Convert.ToBoolean(dr["deleted"]))
            {
                nSelectedGameServerId = Convert.ToInt32(dr["serverId"]);
                break;
            }
        }

        if (nSelectedGameServerId == -1)
        {
            ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_02, "history.back();");
            return;
        }
        DataTable dtItems = DacUser.Items(conn, null);

        DBUtil.CloseDBConn(conn);

        // 아이템 선택 컨트롤 채우기
        for (int i = 0; i < dtItems.Rows.Count; i++)
            WDDLItem.Items.Add(new ListItem("" + dtItems.Rows[i]["itemId"].ToString() + " " + dtItems.Rows[i]["_name"].ToString(), dtItems.Rows[i]["itemId"].ToString()));

		WRptList.DataSource = dt;
        WRptList.DataBind();
        WRptList.Dispose();

        m_nTotalPage = (m_nTotalCount - 1) / m_nRowsPerPage + 1;

        if (m_nTotalCount > 0 && m_nTotalPage < m_nPage)
            m_nPage = m_nTotalPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = m_nTotalPage;
        WPageNavigator.CurrentPage = m_nPage;
        WPageNavigator.UrlParam = string.Format("");
        WPageNavigator.PageListSize = n_nPageSize;
        WPageNavigator.FirstPageItem = Resources.ResLang.COMMON_page_txt_01;
        WPageNavigator.PrevPageItem = Resources.ResLang.COMMON_page_txt_02;
        WPageNavigator.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigator.NextPageItem = Resources.ResLang.COMMON_page_txt_03;
        WPageNavigator.LastPageItem = Resources.ResLang.COMMON_page_txt_04;
        WPageNavigator.SNumberDecoLeft = "<span>";
        WPageNavigator.SNumberDecoRight = "</span>";
        WPageNavigator.Dispose();
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        DataTable drcGameServer = DacUser.GameServerAll(conn, null);

        int nSelectedGameServerId = -1;

        foreach (DataRow dr in drcGameServer.Rows)
        {
            if (!Convert.ToBoolean(dr["deleted"]))
            {
                nSelectedGameServerId = Convert.ToInt32(dr["serverId"]);
                break;
            }
        }

        if (nSelectedGameServerId == -1)
        {
            ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_02, "history.back();");
            return;
        }

        DataTable dtItems = DacUser.Items(conn, null);
        DBUtil.CloseDBConn(conn);

        DropDownList WDDLItems = (DropDownList)e.Item.FindControl("WDDLItems");

        // 아이템 선택 컨트롤 채우기
        for (int i = 0; i < dtItems.Rows.Count; i++)
            WDDLItems.Items.Add(new ListItem("" + dtItems.Rows[i]["itemId"].ToString() + " " + dtItems.Rows[i]["_name"].ToString(), dtItems.Rows[i]["itemId"].ToString()));

        WDDLItems.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "itemId");

        CheckBox WCBoxOwned = (CheckBox)e.Item.FindControl("WCBoxOwnItems");
        TextBox WTxtItemCounts = (TextBox)e.Item.FindControl("WTxtItemCounts");


        WCBoxOwned.Checked = Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "itemOwned"));
        WTxtItemCounts.Text = ComUtil.GetDataItem(e.Item.DataItem, "itemCount");

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
			Button WBtnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
			WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.COMMON_cfrm_01));

            Button WBtnDelete = (Button)e.Item.FindControl("WBtnDelete");
            WBtnDelete.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        int nRet = 0;

        try
        {
            TextBox WTxtRewardNos = (TextBox)e.Item.FindControl("WTxtRewardNos");
            DropDownList WDDLItems = (DropDownList)e.Item.FindControl("WDDLItems");
            TextBox WTxtItemCounts = (TextBox)e.Item.FindControl("WTxtItemCounts");
            CheckBox WCBoxOwnItems = (CheckBox)e.Item.FindControl("WCBoxOwnItems");

            int nEventId = Convert.ToInt32(e.CommandArgument.ToString());
            int nRewardNo = Convert.ToInt32(WTxtRewardNos.Text.Trim());
            int nItemId = Convert.ToInt32(WDDLItems.SelectedValue);
            int nItemCount = Convert.ToInt32(WTxtItemCounts.Text.Trim());
            bool bOwned = Convert.ToBoolean(WCBoxOwnItems.Checked);


            conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "update":

                    nRet = DacUser.UpdateSharingEventSenderRewards(conn, null, nEventId, nRewardNo, nItemId, nItemCount, bOwned, "update");

                    break;
                case "delete":

                    nRet = DacUser.UpdateSharingEventSenderRewards(conn, null, nEventId, nRewardNo, nItemId, nItemCount, bOwned, "delete");

                    break;
                default:
                    nRet = 2;
                    break;
            }

            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox(Resources.ResLang.ACCHRE_cs_mbox_02, "location.href='" + Request.Url.ToString() + "';");
                    break;
                case 1:
                    ComUtil.MsgBox(Resources.ResLang.SENDMAIL_cs_mbox_03, "history.back();");
                    break;
                default:
                    ComUtil.MsgBox(Resources.ResLang.COMMON_mbox_01, "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            if (conn != null)
                DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(String.Format("{0} {1}", Resources.ResLang.COMMON_mbox_02, ex.Message), "history.back();");
        }
    }

    protected void WBtnAddSharingEventSenderReward_OnClick(object sender, EventArgs e)
    {
        int nEventId = Convert.ToInt32(WTxtEventId.Text.Trim());
        int nRewardNo = Convert.ToInt32(WTxtRewardNo.Text.Trim());

        int nItemId = Convert.ToInt32(WDDLItem.SelectedValue);
        int nItemCount = Convert.ToInt32(WTxtItemCount.Text.Trim());
        bool bOwned = Convert.ToBoolean(WCBoxOwnItem.Checked);
        //값 체크
        if (nEventId <= 0)
        {
            ComUtil.MsgBox("0이하의 값은 설정할 수 없습니다.");
            return;
        }
        
        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        SqlTransaction tran = conn.BeginTransaction();

        // 공유하기 이벤트 등록
        int nRetVal = DacUser.AddSharingEventSenderRewards(conn, tran, nEventId, nRewardNo, nItemId, nItemCount, bOwned);

        if (nRetVal != 0)
        {
            tran.Rollback();
            tran.Dispose();
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("등록에 실패하였습니다.", "history.back();");
            return;
        }
        // 트랜잭션 정리
        tran.Commit();
        tran.Dispose();

        // DB연결해제
        DBUtil.CloseDBConn(conn);

        ComUtil.MsgBox("작업성공", "location.href='/Setting/SharingEvents/SharingEventSenderReward.aspx';");

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