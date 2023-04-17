using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Log_PurchaseAllLog : System.Web.UI.Page
{
    private int m_nRowsPerPage = 10;        //페이지 목록 수
    private int n_nPageSize = 10;           //페이징 수
    private int m_nTotalCount = 1;          //전체수
    private int m_nTotalPage = 1;           //전체페이지
    protected int m_nPage = 0;              //페이지

    protected string m_sPopupUrl = "";
    private string m_sName = "";
    private string m_sStartDto = "";
    private string m_sEndDto = "";

    protected int m_nServerId = 0;

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
        m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
        m_sStartDto = ComUtil.GetRequestString("SDT", RequestMethod.Get, "");
        m_sEndDto = ComUtil.GetRequestString("EDT", RequestMethod.Get, "");

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
        WBtnSearch.Text = "검색";

        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 서버목록 조회
        DataTable sdt = DacUser.GameServerAll(conn, null);

        DataRowCollection drc = sdt.Rows;
        WDDLServer.Items.Add(new ListItem("== " + "서버선택" + " ==", "0"));

        for (int i = 0; i < drc.Count; i++)
            WDDLServer.Items.Add(new ListItem(drc[i]["displayName"].ToString(), drc[i]["virtualGameServerId"].ToString()));

        if (m_nServerId == 0)
            return;

        WDDLServer.SelectedValue = m_nServerId.ToString();

        DateTimeOffset dtoStart = DateTimeUtil.ToValidDateTimeOffset(m_sStartDto, DateTimeOffset.MinValue);
        DateTimeOffset dtoEnd = DateTimeUtil.ToValidDateTimeOffset(m_sEndDto, DateTimeOffset.Now);

        DataTable dt = DacUser.PurchaseAllLogs(conn, null, m_nServerId, m_nRowsPerPage, m_nPage, dtoStart, dtoEnd, out m_nTotalCount);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WTxtStart.Text = DateTimeUtil.ToDateTimeOffsetSearchString(dtoStart);
        WTxtEnd.Text = DateTimeUtil.ToDateTimeOffsetSearchString(dtoEnd);

        WRptList.DataSource = dt;
        WRptList.DataBind();
        WRptList.Dispose();

        m_sPopupUrl = String.Format("/Log/Popup/Popup_PurchaseAllLog.aspx?SVR={0}&SDT={1}&EDT={2}&TOTAL={3}", m_nServerId, DateTimeUtil.ToDateTimeOffsetSearchString(dtoStart), DateTimeUtil.ToDateTimeOffsetSearchString(dtoEnd), m_nTotalCount);

        //======================================================================
        // 페이징
        //======================================================================
        m_nTotalPage = Util.CalcTotalPage(m_nTotalCount, m_nRowsPerPage);
        m_nPage = Util.CalcPage(m_nTotalCount, m_nTotalPage, m_nPage);

        WPageNavigator.PageCount = m_nTotalPage;
        WPageNavigator.CurrentPage = m_nPage;
        WPageNavigator.UrlParam = String.Format("SVR={0}&SDT={1}&EDT={2}", m_nServerId, DateTimeUtil.ToDateTimeOffsetSearchString(dtoStart), DateTimeUtil.ToDateTimeOffsetSearchString(dtoEnd));
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

    protected void WBtnSearch_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Log/PurchaseAllLog.aspx?SVR=" + WDDLServer.SelectedValue + "&SDT=" + WTxtStart.Text.Trim() + "&EDT=" + WTxtEnd.Text.Trim());
    }

    protected void WDDLServer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Log/PurchaseAllLog.aspx?SVR=" + WDDLServer.SelectedValue);
    }
    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "storeType":
                switch (Convert.ToInt32(ComUtil.GetDataItem(objData, sFieldNm)))
                {
                    case 1:
                        sRtn = "구글";
                        break;
                    case 2:
                        sRtn = "애플";
                        break;
                    case 3:
                        sRtn = "원";
                        break;
                }
                break;
            case "purchaseType":
                switch (Convert.ToInt32(ComUtil.GetDataItem(objData, sFieldNm)))
                {
                    case 1:
                        sRtn = "첫구매";
                        break;
                    case 2:
                        sRtn = "이벤트";
                        break;
                    case 3:
                        sRtn = "일반";
                        break;
                }
                break;
            case "status":
                switch (Convert.ToInt32(ComUtil.GetDataItem(objData, sFieldNm)))
                {
                    case 0:
                        sRtn = "구매시작";
                        break;
                    case 1:
                        sRtn = "결제완료";
                        break;
                    case 2:
                        sRtn = "지급완료";
                        break;
                    case 3:
                        sRtn = "취소";
                        break;
                    case 4:
                        sRtn = "구매실패";
                        break;
                }
                break;
            case "statusUpdateTime":
            case "regTime":
                if (ComUtil.GetDataItem(objData, sFieldNm) != "")
                    sRtn = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
                break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}