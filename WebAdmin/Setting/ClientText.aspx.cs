using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;

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
        WBtnInit.Attributes.Add("onclick", string.Format("return confirm('{0}');", "한국어 이외의 데이터가 모두 초기화됩니다.\n진행하시겠습니까?"));

        WBtnInit.Visible = false;

        WBtnInit.Text = "한국어 기준 데이터 초기화";

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

        if (m_nStandardLanguageId > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int nTempLanguageId = Convert.ToInt32(dt.Rows[i]["languageId"]);

                if (nTempLanguageId != m_nStandardLanguageId)
                {
                    DataTable dtNewText = DacUser.ClientTextGetListForNews(conn, null, m_nStandardLanguageId, nTempLanguageId);

                    if (dtNewText != null && dtNewText.Rows.Count > 0)
                        dtAll.Merge(dtNewText);
                }
            }
        }

        // DB연결해제
        DBUtil.CloseDBConn(conn);

        WDDLStandardLanguage.Items.Add(new ListItem(string.Format("---언어선택---"), "0"));
        WDDLStandardLanguage.Items.Add(new ListItem(string.Format("Korean"), "23"));
        WDDLStandardLanguage.Items.Add(new ListItem(string.Format("English"), "11"));

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

            ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
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
            ((Button)e.Item.FindControl("WBtnDownLoad")).Attributes.Add("onclick", string.Format("return confirm('{0}');", "엑셀로 다운로드 받으시겠습니까?"));
            ((Button)e.Item.FindControl("WBtnUpload")).Attributes.Add("onclick", string.Format("return confirm('{0}');", "엑셀로 데이터를 업로드 하시겠습니까?"));
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
                        ComUtil.MsgBox("StandardLanguageID 를 선택해주세요", "hitory.back();");
                        return;
                    }

                    Response.Redirect(String.Format("/Setting/Popup/Popup_ClientText_Excel.aspx?SID={0}&LID={1}", m_nStandardLanguageId, m_nLanguageId));
                    break;

                case "NewTextDown":

                    m_nLanguageId = nLanguageId;

                    //StandardLanguageId 체크
                    if (WDDLStandardLanguage.SelectedValue == "0")
                    {
                        ComUtil.MsgBox("StandardLanguageID 를 선택해주세요", "hitory.back();");
                        return;
                    }

                    Response.Redirect(String.Format("/Setting/Popup/Popup_ClientNewText_Excel.aspx?SID={0}&LID={1}", m_nStandardLanguageId, m_nLanguageId));
                    break;

                case "update":

                    FileUpload WFUUpload = (FileUpload)e.Item.FindControl("WFUUpload");

                    if (WFUUpload.PostedFile == null || WFUUpload.PostedFile.FileName == "")
                    {
                        ComUtil.MsgBox("파일을 선택해주세요.", "hitory.back();");
                        return;
                    }

                    string sFileName = WFUUpload.PostedFile.FileName;
                    string sSheetName = sFileName.Substring(0, sFileName.LastIndexOf('.'));

                    if (WFUUpload.PostedFile.ContentType == "application/vnd.ms-excel" || WFUUpload.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        string filename = WFUUpload.FileName;

                        string targetpath = Server.MapPath("~/Doc/");
			

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
                            ComUtil.MsgBox("테이블 초기화 실패", "history.back();");
                            return;
                        }
                        if (DacUser.SqlBulkCopy(conn, dt, "s_ClientText$") != 0)
                        {
                            DBUtil.CloseDBConn(conn);
                            ComUtil.MsgBox("데이터 입력 실패", "history.back();");
                            return;
                        }
                        DBUtil.CloseDBConn(conn);

                        FileInfo fi = new FileInfo(targetpath + filename);
                        if (fi.Exists)
                            fi.Delete();

                        ComUtil.MsgBox("데이터 입력 완료", "location.href='/Setting/ClientTextChanges.aspx?SID=" + m_nStandardLanguageId + "&LID=" + nLanguageId + "';");
                    }
                    else
                    {
                        ComUtil.MsgBox("파일 형식이 올바르지 않습니다.", "history.back();");
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