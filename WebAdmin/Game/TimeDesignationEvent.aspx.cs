using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_TimeDesignationEvent : System.Web.UI.Page
{
    private int m_nRowsPerPage = 10;        // 페이지 목록 수
    private int n_nPageSize = 10;           // 페이징 수
    private int m_nTotalCount = 1;          // 전체수
    private int m_nTotalPage = 1;           // 전체페이지
    protected int m_nPage = 0;              // 페이지

    private string m_sEventName = "";
    private string m_sStartTime = "";
    private string m_sEndTime = "";

    private int m_nServerId = 0;
    private int m_nEventId = 0;
    private int m_nState = 0;
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
        m_sEventName = ComUtil.GetRequestString("NM", RequestMethod.Get, "");
        m_sStartTime = ComUtil.GetRequestString("ST", RequestMethod.Get, "");
        m_sEndTime = ComUtil.GetRequestString("ET", RequestMethod.Get, "");
        m_nEventId = ComUtil.GetRequestInt("CID", RequestMethod.Get, 0);
        m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_nState = ComUtil.GetRequestInt("STT", RequestMethod.Get, 0);

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
        WBtnSerch.Text = "검색";

        WDDLState.Items.Add(new ListItem("전체", "0"));
        WDDLState.Items.Add(new ListItem("예약", "1"));

        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 게임목록 조회
        DataTable sdt = DacUser.GameServerAll(conn, null);

        WDDLServer.Items.Add(new ListItem("== " + "서버선택" + " ==", "0"));

        DataRowCollection drc = sdt.Rows;
        for (int i = 0; i < drc.Count; i++)
            WDDLServer.Items.Add(new ListItem(drc[i]["displayName"].ToString(), drc[i]["serverId"].ToString()));

        if (m_nServerId == 0)
            return;

        WDDLServer.SelectedValue = m_nServerId.ToString();
        WDDLState.SelectedValue = m_nState.ToString();
        int States = Convert.ToInt32(WDDLState.SelectedValue);

        DataTable dt = DacUser.TimeDesignationEvents(conn, null, States, m_nRowsPerPage, m_nPage, out m_nTotalCount);

        //DB연결해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dt;
        WRptList.DataBind();

        //======================================================================
        // 페이징
        //======================================================================
        m_nTotalPage = Util.CalcTotalPage(m_nTotalCount, m_nRowsPerPage);
        m_nPage = Util.CalcPage(m_nTotalCount, m_nTotalPage, m_nPage);

        WPageNavigator.PageCount = m_nTotalPage;
        WPageNavigator.CurrentPage = m_nPage;
        WPageNavigator.UrlParam = String.Format("SVR={0}&NM={1}&ST={2}&ET={3}&CID={4}", m_nServerId, m_sEventName, m_sStartTime, m_sEndTime, m_nEventId);
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

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button btnDel = (Button)e.Item.FindControl("WBtnDel");
            btnDel.Text = "삭제";
            btnDel.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));
        }
    }

    protected void WDDLServer_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Game/TimeDesignationEvent.aspx?SVR=" + WDDLServer.SelectedValue);
    }

    protected void WBtnSerch_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Game/TimeDesignationEvent.aspx?SVR=" + WDDLServer.SelectedValue + "&STT=" + WDDLState.SelectedValue);
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        int nRet = 0;
        int m_neventId = Convert.ToInt32(e.CommandArgument.ToString());

        try
        {
            SqlConnection conn = DBUtil.GetUserDBConn();
            SqlTransaction tran = conn.BeginTransaction();

            switch (e.CommandName)
            {
                case "delete":

                    nRet = DacUser.DeleteTimeDesignationEvent(conn, tran, m_neventId);

                    if (nRet != 0)
                    {
                        tran.Rollback();
                        tran.Dispose();
                        DBUtil.CloseDBConn(conn);

                        ComUtil.MsgBox("삭제에 실패하였습니다.", "history.back();");
                        return;
                    }

                    nRet = DacUser.DeleteTimeDesignationEventReward_All(conn, tran, m_neventId);

                    if (nRet != 0)
                    {
                        tran.Rollback();
                        tran.Dispose();
                        DBUtil.CloseDBConn(conn);

                        ComUtil.MsgBox("삭제에 실패하였습니다.", "history.back();");
                        return;
                    }
                    break;
                default:
                    nRet = 9;
                    break;
            }

            if (nRet == 9)
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("삭제에 실패하였습니다.", "history.back();");
                return;
            }
            tran.Commit();
            tran.Dispose();
            DBUtil.CloseDBConn(conn);
            Response.Redirect("/Game/TimeDesignationEvent.aspx?SVR=" + m_nServerId);
        }
        catch (Exception ex)
        {
            ComUtil.ErrorLogMsg(ex);
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "_name":
                sRtn = "<a href=\"/Game/TimeDesignationEventForm.aspx?SVR=" + WDDLServer.SelectedValue + string.Format("&NM={0}&ST={1}&ET={2}&CID={3}&PG={4}", m_sEventName, m_sStartTime, m_sEndTime, ComUtil.GetDataItem(objData, "eventId"), m_nPage) + "\" >" + ComUtil.GetDataItem(objData, sFieldNm) + "</a>";
                break;
            case "startTime":
            case "endTime":
                sRtn = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
                break;
            case "type":
                if (ComUtil.GetDataItem(objData, sFieldNm) == "1")
                    sRtn = "예약";
                else
                    sRtn = "전체";
                break;

            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}