using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Setting_Popup_Popup_SharingEventSenderLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //======================================================================
        //브라우저 캐쉬 제거
        //======================================================================
        ComUtil.SetNoBrowserCache();

        //======================================================================
        //다국어 변환
        //======================================================================

        InitExcel();
    }
    private void InitExcel()
    {

        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        //
        DataTable dt = DacUser.SharingEventSenderLogs_Excel(conn, null);

        DBUtil.CloseDBConn(conn);


        //inviteCode, eventId, gameServerId, accountHeroId, regTime
        WDtGrid.Columns[0].HeaderText = "sortId";
        WDtGrid.Columns[1].HeaderText = "inviteCode";
        WDtGrid.Columns[2].HeaderText = "eventId";
        WDtGrid.Columns[3].HeaderText = "gameServerId";
        WDtGrid.Columns[4].HeaderText = "accountHeroId";
        WDtGrid.Columns[5].HeaderText = "regTime";


        if (dt != null)
        {
            WDtGrid.DataSource = dt;
            WDtGrid.DataBind();
        }

        string sFilePath = "SenderLog_" + DateTimeUtil.ToDateTimeString(DateTime.Now) + ".xls";
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

    }
}