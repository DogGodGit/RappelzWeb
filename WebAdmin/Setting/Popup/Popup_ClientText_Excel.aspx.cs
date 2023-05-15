using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using ClosedXML.Excel;

public partial class Setting_Popup_Popup_ClientText_Excel : System.Web.UI.Page
{
    private int m_nStandardLanguageId = 0;
    private int m_nLanguageId = 0;

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
        m_nStandardLanguageId = ComUtil.GetRequestInt("SID", RequestMethod.Get, 0);
        m_nLanguageId = ComUtil.GetRequestInt("LID", RequestMethod.Get, 0);

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

        DataTable dtLanguage = DacUser.ClientTextLanguageLists(conn, null);
        DataTable dt = DacUser.Admin_ClientTextGetLists(conn, null, m_nStandardLanguageId, m_nLanguageId);

        // DB연결해제
        DBUtil.CloseDBConn(conn);

        string sLanguageName = "";

        for (int i = 0; i < dtLanguage.Rows.Count; i++)
        {
            if (m_nLanguageId == Convert.ToInt32(dtLanguage.Rows[i]["languageId"]))
            {
                sLanguageName = dtLanguage.Rows[i]["languageName"].ToString();
                break;
            }
        }

        string sFilePath = "ClientText_" + sLanguageName + "_" + DateTimeUtil.ToDateTimeString(DateTime.Now) + ".xlsx";

        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt, "ClientText");

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + sFilePath);
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
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