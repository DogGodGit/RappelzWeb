using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Log_Popup_Popup_PurchaseAllLog : System.Web.UI.Page
{

    private int m_nRowsPerPage = 2099999999;        // 페이지 목록 수
    private int n_nPageSize = 10;           // 페이징 수
    private int m_nTotalCount = 1;          // 전체수
    private int m_nTotalPage = 1;           // 전체페이지
    protected int m_nPage = 0;              // 페이지

    protected string m_sPopupUrl = "";

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

        //Response.Write(m_nTotalCount + ", " + m_nAccountHeroId + ", " + m_nItemId);

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
        Util.BadAccessCheckServerId(m_nServerId);

        DateTimeOffset dtoStart = DateTimeUtil.ToValidDateTimeOffset(m_sStartDto, DateTimeOffset.MinValue);
        DateTimeOffset dtoEnd = DateTimeUtil.ToValidDateTimeOffset(m_sEndDto, DateTimeOffset.Now);

        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        DataTable dt = DacUser.PurchaseAllLogs(conn, null, m_nServerId, m_nRowsPerPage, m_nPage, dtoStart, dtoEnd, out m_nTotalCount);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WDtGrid.Columns[0].HeaderText = "결제ID";
        WDtGrid.Columns[1].HeaderText = "게임서버ID";
        WDtGrid.Columns[2].HeaderText = "heroId";
        WDtGrid.Columns[3].HeaderText = "상품ID";
        WDtGrid.Columns[4].HeaderText = "구매데이터";
        WDtGrid.Columns[5].HeaderText = "스토어타입";
        WDtGrid.Columns[6].HeaderText = "주문번호";
        WDtGrid.Columns[7].HeaderText = "구매타입";
        WDtGrid.Columns[8].HeaderText = "상태";
        WDtGrid.Columns[9].HeaderText = "실패이유";
        WDtGrid.Columns[10].HeaderText = "수정시각";
        WDtGrid.Columns[11].HeaderText = "등록시각";
        WDtGrid.Columns[12].HeaderText = "예외";

        WDtGrid.DataSource = dt;
        WDtGrid.DataBind();

        string sFilePath = "PurchaseAllLog_" + DateTimeUtil.ToDateTimeString(DateTime.Now) + ".xls";
        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;fileName=" + sFilePath);
        Response.Charset = "utf-8";

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        WDtGrid.RenderControl(hw);

        Response.Write("<meta charset=\"utf-8\">");
        Response.Write(sw.GetStringBuilder().ToString());
        Response.End();

    }

    protected void WDtGrid_OnItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if ((ListItemType)e.Item.ItemType == ListItemType.AlternatingItem || (ListItemType)e.Item.ItemType == ListItemType.Item)
        {

            e.Item.Cells[5].Text = GetDataItem(e.Item.DataItem, "storeType");
            e.Item.Cells[7].Text = GetDataItem(e.Item.DataItem, "signature");
            e.Item.Cells[8].Text = GetDataItem(e.Item.DataItem, "status");
        }
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