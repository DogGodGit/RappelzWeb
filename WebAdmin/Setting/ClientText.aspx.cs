using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

public partial class Setting_ClientText : System.Web.UI.Page
{
    protected string m_sPopupUrl = "";

    protected int m_nStandardLanguageId = 0;
    protected int m_nLanguageId = 0;

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
        WBtnInit.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.ClientText_aspx_05));

        WBtnInit.Visible = false;

        WBtnInit.Text = Resources.ResLang.ClientText_aspx_06;

        string sMyIp = Request.UserHostAddress;
        string[] sInternalIps = Config.InternalIp.Split('|');

        for (int i = 0; i < sInternalIps.Length; i++)
        {
            if (sMyIp == sInternalIps[i])
            {
                WBtnInit.Visible = true;
                break;
            }
        }

        //Response.Write(ComUtil.GetIpAddress().ToString());

        //if ( ComUtil.GetIpAddress().ToString() != "10.255.161.18")
        //{
        //    WBtnInit.Visible = false;
        //}

        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        DataTable dt = DacUser.ClientTextLanguageLists(conn, null);

        DataTable dtAll = new DataTable();
        WDDLStandardLanguage.Items.Add(new ListItem(string.Format(Resources.ResLang.ClientText_aspx_01), "0"));
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int nTempLanguageId = Convert.ToInt32(dt.Rows[i]["languageId"]);
                WDDLStandardLanguage.Items.Add(new ListItem(dt.Rows[i]["languageName"].ToString(), nTempLanguageId.ToString()));
                if (m_nStandardLanguageId > 0 && nTempLanguageId != m_nStandardLanguageId)
                {
                    DataTable dtNewText = DacUser.ClientTextGetListForNews(conn, null, m_nStandardLanguageId, nTempLanguageId);
                    dt.Rows[i]["NewTextCount"] = dtNewText.Rows.Count;
                    if (dtNewText != null && dtNewText.Rows.Count > 0)
                        dtAll.Merge(dtNewText);
                }
            }
        }

        // DB연결해제
        DBUtil.CloseDBConn(conn);

        WDDLStandardLanguage.SelectedValue = m_nStandardLanguageId.ToString();

        WRptList.DataSource = dt;
        WRptList.DataBind();

        //WLtlTitleName.Text = " - " + WDDLStandardLanguage.SelectedItem.Text.Trim();

        //if (dtAll.Rows.Count > 0)
        //{
        //    WRptList_NewText.DataSource = dtAll.Rows.Cast<DataRow>().Take(10).CopyToDataTable();
        //    WRptList_NewText.DataBind();
        //}


    }

    //스탠다드랭귀지 선택시 값들 출력
    protected void WDDLStandardLanguage_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Setting/ClientText.aspx?SID=" + WDDLStandardLanguage.SelectedValue);

    }

    protected void WBtnInit_OnClick(object sender, EventArgs e)
    {
        // 유저DB연결
        SqlConnection conn = null;
        SqlTransaction tran = null;

        try
        {
            conn = DBUtil.GetUserDBConn();
            tran = conn.BeginTransaction();

            string sMsg = DacUser.ClientTextUpdateStandard(conn, tran, 23);

            if (sMsg != "")
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("Error. (" + sMsg + ")", "history.back();");
                return;
            }

            tran.Commit();
            tran.Dispose();

            // DB연결해제
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_04, "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            if (tran != null)
            {
                tran.Rollback();
                tran.Dispose();
            }
            if (conn != null && conn.State == ConnectionState.Connecting)
                DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("Error. (" + ex.Message + ")", "history.back();");
        }
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            ((Button)e.Item.FindControl("WBtnDownLoad")).Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.ClientText_aspx_02));
            ((Button)e.Item.FindControl("WBtnUpload")).Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.ClientText_aspx_03));
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            int nLanguageId = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case "download":

                    m_nLanguageId = nLanguageId;

                    //StandardLanguageId 체크
                    if (WDDLStandardLanguage.SelectedValue == "0")
                    {
                        ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_07, "hitory.back();");
                        return;
                    }

                    Response.Redirect(String.Format("/Setting/Popup/Popup_ClientText_Excel.aspx?SID={0}&LID={1}", m_nStandardLanguageId, m_nLanguageId));
                    break;

                case "NewTextDown":

                    m_nLanguageId = nLanguageId;

                    //StandardLanguageId 체크
                    if (WDDLStandardLanguage.SelectedValue == "0")
                    {
                        ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_07, "hitory.back();");
                        return;
                    }

                    Response.Redirect(String.Format("/Setting/Popup/Popup_ClientNewText_Excel.aspx?SID={0}&LID={1}", m_nStandardLanguageId, m_nLanguageId));
                    break;

                case "update":

                    FileUpload WFUUpload = (FileUpload)e.Item.FindControl("WFUUpload");

                    if (WFUUpload.PostedFile == null || WFUUpload.PostedFile.FileName == "")
                    {
                        ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_08, "hitory.back();");
                        return;
                    }

                    string sFileName = WFUUpload.PostedFile.FileName;
                    string sSheetName = sFileName.Substring(0, sFileName.LastIndexOf('.'));

                    if (WFUUpload.PostedFile.ContentType == "application/vnd.ms-excel" || WFUUpload.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        string filename = WFUUpload.FileName;

                        string targetpath = Server.MapPath("~/Doc/");

                        if (!Directory.Exists(targetpath))
                            Directory.CreateDirectory(targetpath);

                        WFUUpload.SaveAs(targetpath + filename);

                        string pathToExcelFile = targetpath + filename;
                        var connectionString = "";
                        if (filename.EndsWith(".xls"))
                        {
                            connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                        }
                        else if (filename.EndsWith(".xlsx"))
                        {
                            connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                        }

                        OleDbConnection connOle = new OleDbConnection(connectionString);
                        connOle.Open();

                        DataTable dtExcelSchema = connOle.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("select languageId, name, value from [" + dtExcelSchema.Rows[0]["TABLE_NAME"].ToString() + "]", connOle);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        connOle.Close();

                        foreach (DataRow dr in dt.Rows)
                        {
                            bool values = dr.IsNull("value");

                            if (values)
                            {
                                dr["value"] = " ";
                                //ComUtil.MsgBox(Resources.resLang.ClientText_aspx_01, "history.back();");
                                //return;
                            }

                        }

                        SqlConnection conn = DBUtil.GetUserDBConn();
                        if (DacUser.TruncateClientTextTemp(conn, null) != 0)
                        {
                            DBUtil.CloseDBConn(conn);
                            ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_09, "history.back();");
                            return;
                        }
                        if (DacUser.SqlBulkCopy(conn, dt, "s_ClientText") != 0)
                        {
                            DBUtil.CloseDBConn(conn);
                            ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_10, "history.back();");
                            return;
                        }
                        DBUtil.CloseDBConn(conn);

                        FileInfo fi = new FileInfo(targetpath + filename);
                        if (fi.Exists)
                            fi.Delete();

                        ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_11, "location.href='/Setting/ClientTextChanges.aspx?SID=" + m_nStandardLanguageId + "&LID=" + nLanguageId + "';");
                    }
                    else
                    {
                        ComUtil.MsgBox(Resources.ResLang.ClientText_aspx_12, "history.back();");
                    }

                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox("Error. (" + ex.Message + ")", "history.back();");
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