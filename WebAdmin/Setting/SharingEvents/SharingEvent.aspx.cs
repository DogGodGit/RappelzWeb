using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using LitJson;

public partial class Setting_SharingEvents_SharingEvent : System.Web.UI.Page
{
    private int m_nRowsPerPage = 10;        // 페이지 목록 수
    private int n_nPageSize = 10;           // 페이징 수
    private int m_nTotalCount = 1;          // 전체수
    private int m_nTotalPage = 1;           // 전체페이지
    protected int m_nPage = 0;              // 페이지

    private int nTotCnt = 0;        // 전체페이지
    private int nTotPage = 1;       // 전체페이지

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
        SqlConnection conn = DBUtil.GetUserDBConn();
        DataTable dt = DacUser.SharingEvents(conn, null, m_nRowsPerPage, m_nPage, out nTotCnt);
        DBUtil.CloseDBConn(conn);

		WRptList.DataSource = dt;
        WRptList.DataBind();
        WRptList.Dispose();

        nTotPage = (nTotCnt - 1) / m_nRowsPerPage + 1;

        if (nTotCnt > 0 && nTotPage < m_nPage)
            m_nPage = nTotPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = nTotPage;
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

    private void SetType(DropDownList ddl, DropDownList ddl2, DropDownList ddl3)
    {
        ddl.Items.Add(new ListItem("일반텍스트", "1"));
        ddl.Items.Add(new ListItem("스트링키", "2"));

        ddl2.Items.Add(new ListItem("일반텍스트", "1"));
        ddl2.Items.Add(new ListItem("스트링키", "2"));

        ddl3.Items.Add(new ListItem("일반텍스트", "1"));
        ddl3.Items.Add(new ListItem("스트링키", "2"));
    }

    private void SetRewardRange(DropDownList ddl)
    {
        ddl.Items.Add(new ListItem("모두", "1"));
        ddl.Items.Add(new ListItem("초대한 사람", "2"));
        ddl.Items.Add(new ListItem("초대 받은사람", "3"));
        ddl.Items.Add(new ListItem("없음", "4"));
    }


    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
		((Button)e.Item.FindControl("WBtnUpdate")).Text = "수정";
        DropDownList WDDLContentType = (DropDownList)e.Item.FindControl("WDDLContentType");
        DropDownList WDDLMailTitleType = (DropDownList)e.Item.FindControl("WDDLMailTitleType");
        DropDownList WDDLMailContentType = (DropDownList)e.Item.FindControl("WDDLMailContentType");
        DropDownList WDDLRewardRange = (DropDownList)e.Item.FindControl("WDDLRewardRange");

        SetType(WDDLContentType, WDDLMailTitleType, WDDLMailContentType);
        SetRewardRange(WDDLRewardRange);

        WDDLContentType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "contentType");
        WDDLMailTitleType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "rewardMailTitleType");
        WDDLMailContentType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "rewardMailContentType");
        WDDLRewardRange.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "rewardRange");

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
			Button WBtnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
			WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.COMMON_cfrm_01));
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        int nRet = 0;

        try
        {
            TextBox WTxtStartTimeRpt = (TextBox)e.Item.FindControl("WTxtStartTime");
            TextBox WTxtEndTimeRpt = (TextBox)e.Item.FindControl("WTxtEndTime");

            DropDownList WDDLContentType = (DropDownList)e.Item.FindControl("WDDLContentType");
            TextBox WTxtContent = (TextBox)e.Item.FindControl("WTxtContent");

            DropDownList WDDLRewardRange = (DropDownList)e.Item.FindControl("WDDLRewardRange");
            TextBox WTxtRewardLimitCount = (TextBox)e.Item.FindControl("WTxtRewardLimitCount");
            TextBox WTxtTargetLevel = (TextBox)e.Item.FindControl("WTxtTargetLevel");

            DropDownList WDDLMailTitleType = (DropDownList)e.Item.FindControl("WDDLMailTitleType");
            TextBox WTxtMailTitle = (TextBox)e.Item.FindControl("WTxtMailTitle");
            DropDownList WDDLMailContentType = (DropDownList)e.Item.FindControl("WDDLMailContentType");
            TextBox WTxtMailContent = (TextBox)e.Item.FindControl("WTxtMailContent");
            TextBox WTxtImageName = (TextBox)e.Item.FindControl("WTxtImageName");

            int nEventId = Convert.ToInt32(e.CommandArgument.ToString());

            int nContentType = Convert.ToInt32(WDDLContentType.SelectedValue);
            string sContent = WTxtContent.Text.Trim();

            int nRewardRange = Convert.ToInt32(WDDLRewardRange.SelectedValue);
            int nRewardLimitCount = Convert.ToInt32(WTxtRewardLimitCount.Text.Trim());
            int nTargetLevel = Convert.ToInt32(WTxtTargetLevel.Text.Trim());

            string sStartTime = WTxtStartTimeRpt.Text.Trim();
            string sEndTime = WTxtEndTimeRpt.Text.Trim();

            int nRewardMailTitleType = Convert.ToInt32(WDDLMailTitleType.SelectedValue);
            string sRewardMailTitle = WTxtMailTitle.Text.Trim();
            int nRewardMailContentType = Convert.ToInt32(WDDLMailContentType.SelectedValue);
            string sRewardMailContent = WTxtMailContent.Text.Trim();
            string sImageName = WTxtImageName.Text.Trim();

            DateTime startTime = DateTime.MinValue;
            DateTime endTime = DateTime.MinValue;

            if (!DateTime.TryParse(sStartTime, out startTime) || !DateTime.TryParse(sEndTime, out endTime))
            {
                ComUtil.MsgBox("입력한 값을 다시 확인해주세요." + " Time", "history.back();");
                return;
            }

            conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "update":

                    nRet = DacUser.UpdateSharingEvents(conn, null, nEventId, nContentType, sContent, nRewardRange, nRewardLimitCount, nTargetLevel, startTime, endTime, nRewardMailTitleType, sRewardMailTitle, nRewardMailContentType, sRewardMailContent, sImageName);

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