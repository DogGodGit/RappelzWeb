using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_Announcement : System.Web.UI.Page
{
    protected int nAddType = 1;
    protected int nUpdateType = 2;
    protected int nDeleteType = 3;

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
        WBtnAdd.Attributes.Add("onclick", "return confirm('공지팝업을 등록하시겠습니까?');");

        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 공지팝업목록 조회
        DataTable dt = DacUser.UserAnnouncements(conn, null);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dt;
        WRptList.DataBind();
        dt.Dispose();

        WTxtStartTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now.AddMinutes(1));
        WTxtEndTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now.AddDays(1));
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            ((Button)e.Item.FindControl("WBtnUpdate")).Attributes.Add("onclick", "return confirm('수정하시겠습니까?');");
            ((Button)e.Item.FindControl("WBtnDel")).Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");

            DropDownList WDDLVisible = (DropDownList)e.Item.FindControl("WDDLVisibleUpdate");
            WDDLVisible.SelectedValue = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "visible"))) ? "1" : "0";
            WDDLVisible.Items.FindByValue("0").Text = "불가능"; //Resources.resLang.GAMESLIST_aspx_txt_03;
            WDDLVisible.Items.FindByValue("1").Text = "가능";   //Resources.resLang.GAMESLIST_aspx_txt_04;
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        SqlTransaction tran = null;

        Guid logId = Guid.NewGuid();
        Guid announcementId = Guid.Parse(e.CommandArgument.ToString());
        
        string sTitleUpdate = ((TextBox)e.Item.FindControl("WTxtTitleUpdate")).Text.Trim();
        string sContentURLUpdate = ((TextBox)e.Item.FindControl("WTxtContentURLUpdate")).Text.Trim();
        string sStartTimeUpdate = ((TextBox)e.Item.FindControl("WTxtStartTimeUpdate")).Text.Trim();
        string sEndTimeUpdate = ((TextBox)e.Item.FindControl("WTxtEndTimeUpdate")).Text.Trim();
        bool bVisible = (((DropDownList)e.Item.FindControl("WDDLVisibleUpdate")).SelectedValue == "0") ? false : true;
        int nSortNo = Convert.ToInt32(((Literal)e.Item.FindControl("WLtlSortNoUpdate")).Text.Trim());

        DateTime startTime = DateTime.Parse(sStartTimeUpdate);
        DateTime endTime = DateTime.Parse(sEndTimeUpdate);

        int nRet = 0;
        int nRetLog = 0;
        // DB연결
        conn = DBUtil.GetUserDBConn();
        tran = conn.BeginTransaction();

        switch (e.CommandName)
        {
            case "update":
                nRet = DacUser.UpdateUserAnnouncement(conn, tran, announcementId, sTitleUpdate, sContentURLUpdate, startTime, endTime, bVisible);
                if (nRet != 0)
                {
                    tran.Rollback();
                    tran.Dispose();
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox("공지팝업 수정에 실패했습니다.", "history.back();");
                    return;
                }

                nRetLog = DacUser.AddUserAnnouncementLog(conn, tran, logId, announcementId, nUpdateType, sTitleUpdate, sContentURLUpdate, startTime, endTime, nSortNo, bVisible);
                if (nRetLog != 0)
                {
                    tran.Rollback();
                    tran.Dispose();
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox("공지팝업 수정로그 등록에 실패했습니다.", "history.back();");
                    return;
                }
                break;
            case "delete":
                nRet = DacUser.DeleteUserAnnouncement(conn, tran, announcementId);

                if (nRet != 0)
                {
                    tran.Rollback();
                    tran.Dispose();
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox("공지팝업 삭제에 실패했습니다.", "history.back();");
                    return;
                }

                nRetLog = DacUser.AddUserAnnouncementLog(conn, tran, logId, announcementId, nDeleteType, sTitleUpdate, sContentURLUpdate, startTime, endTime, nSortNo, bVisible);
                if (nRetLog != 0)
                {
                    tran.Rollback();
                    tran.Dispose();
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox("공지팝업 수정로그 등록에 실패했습니다.", "history.back();");
                    return;
                }
                break;
            default:
                nRet = 2;
                break;
        }

        // DB연결 해제
        tran.Commit();
        tran.Dispose();
        DBUtil.CloseDBConn(conn);

        switch (nRet)
        {
            case 0:
                if (e.CommandName == "update")
                    ComUtil.MsgBox("수정되었습니다.", "location.href='/Game/Announcement.aspx';");
                if (e.CommandName == "delete")
                    ComUtil.MsgBox("삭제되었습니다.", "location.href='/Game/Announcement.aspx';");
                break;

            default:
                ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
                break;
        }
    }

    protected void WBtnAdd_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        SqlTransaction tran = null;

        try
        {
            Guid logId = Guid.NewGuid();
            Guid announcementId = Guid.NewGuid();
            string sTitle = WTxtTitle.Text.Trim();
            string sContentUrl = WTxtContentURL.Text.Trim();
            string sStartTime = WTxtStartTime.Text.Trim();
            string sEndTime = WTxtEndTime.Text.Trim();
            int nSortNo = Convert.ToInt32(WTxtSortNo.Text.Trim());
            bool bVisible = Convert.ToBoolean(0);

            DateTime startTime = DateTime.Parse(sStartTime);
            DateTime endTime = DateTime.Parse(sEndTime);

            if (sContentUrl == "" || sTitle == "")
            {
                ComUtil.MsgBox("제목 혹은 내용URL을 입력해주세요.", "history.back();");
                return;
            }

            // DB연결
            conn = DBUtil.GetUserDBConn();

            // 공지팝업목록 조회
            DataTable dt = DacUser.UserAnnouncements(conn, null);

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (WTxtSortNo.Text.Trim() == dt.Rows[i]["sortNo"].ToString())
                {
                    ComUtil.MsgBox("SortNo 는 중복될 수 없습니다.", "history.back();");
                    return;
                }
            }

            // DB연결
            conn = DBUtil.GetUserDBConn();

            tran = conn.BeginTransaction();

            // 공지팝업 등록
            int nRet = DacUser.AddUserAnnouncement(conn, tran, announcementId, sTitle, sContentUrl, startTime, endTime, nSortNo);

            if (nRet != 0)
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("공지팝업 등록에 실패하였습니다.", "history.back();");
            }

            int nRetLog = DacUser.AddUserAnnouncementLog(conn, tran, logId, announcementId, nAddType, sTitle, sContentUrl, startTime, endTime, nSortNo, bVisible);

            if (nRetLog != 0)
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("공지팝업 로그 등록에 실패하였습니다.", "history.back();");
            }

            // DB연결 해제
            tran.Commit();
            tran.Dispose();
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("공지팝업이 등록되었습니다.", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "contentUrl":
                sRtn = ComUtil.GetDataItem(objData, sFieldNm).Replace("<", "&lt;").Replace(">", "&gt;");
                break;
            case "startTime":
                sRtn = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
                break;
            case "endTime":
                sRtn = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
                break;
            case "regTime":
                sRtn = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
                break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}