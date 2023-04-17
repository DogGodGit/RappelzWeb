﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_Notice_Global : System.Web.UI.Page
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
        WBtnAdd.Attributes.Add("onclick", "return confirm('인게임공지를 등록하시겠습니까?');");
        WtxtDisplayInterval.Text = "60";
        WtxtRepetitionCount.Text = "1";
        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 서버목록 조회
        DataTable dt = DacUser.UserGlobalNotices(conn, null);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dt;
        WRptList.DataBind();
        dt.Dispose();

        WTxtDisplayTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now.AddMinutes(1));

    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ((Button)e.Item.FindControl("WBtnDel")).Text = "삭제";
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button btnDel = (Button)e.Item.FindControl("WBtnDel");
            btnDel.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));
        }
    }

    protected void WBtnAdd_OnClick(object sender, EventArgs e)
    {
        try
        {
            Guid noticeId = Guid.NewGuid();
            string sContent = WTxtContent.Text.Trim();
            string sDisplayTime = WTxtDisplayTime.Text.Trim();
            int nDisplayInterval = Convert.ToInt32(WtxtDisplayInterval.Text.Trim());
            int nRePetitionCount = Convert.ToInt32(WtxtRepetitionCount.Text.Trim());

            if (sContent == "")
            {
                ComUtil.MsgBox("내용을 입력해주세요.", "history.back();");
                return;
            }
            DateTime displayTime = DateTime.Parse(sDisplayTime);
            ;

            if (WtxtRepetitionCount.Text.Trim() == "" || WtxtDisplayInterval.Text.Trim() == "")
            {
                ComUtil.MsgBox("표시간격 혹은 반복횟수의 값을 확인해주세요.", "history.back();");
                return;
            }

            // DB연결
            SqlConnection conn = DBUtil.GetUserDBConn();

            // 인게임 공지 등록
            int nRet = DacUser.AddUserGlobalNotice(conn, null, noticeId, sContent, displayTime, nDisplayInterval, nRePetitionCount);

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet == 0)
                ComUtil.MsgBox("공지가 등록되었습니다.", "location.href='" + Request.Url.ToString() + "';");
            else
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "공지 등록에 실패하였습니다.", "오류코드", "history.back();"));

        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            int nRet = 0;
            Guid noticeId = Guid.Parse(e.CommandArgument.ToString());

            // DB연결
            SqlConnection conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "delete":
                    // 인게임 공지 삭제
                    nRet = DacUser.DeleteUserGlobalNotice(conn, null, noticeId);
                    break;
                default:
                    nRet = 9;
                    break;
            }

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("공지가 삭제되었습니다.", "location.href='" + Request.Url.ToString() + "';");
                    break;
                default:
                    ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "공지삭제에 실패하였습니다.", "오류코드", "history.back();"));
                    break;
            }
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "공지 삭제 중 시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "content":
                sRtn = ComUtil.GetDataItem(objData, sFieldNm).Replace("<", "&lt;").Replace(">", "&gt;");
                break;
            case "displayTime":
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