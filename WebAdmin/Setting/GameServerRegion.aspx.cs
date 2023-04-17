using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Setting_GameServerRegion : System.Web.UI.Page
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

        WBtnAdd.Text = "등록";
        WBtnAdd.Attributes.Add("onclick", string.Format("return confirm('{0}');", "등록하시겠습니까?"));

        SqlConnection conn = DBUtil.GetUserDBConn();
        DataTable dt = DacUser.GameServerRegions(conn, null);
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dt;
        WRptList.DataBind();
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ((Button)e.Item.FindControl("WBtnUpdate")).Text = "수정";
        ((Button)e.Item.FindControl("WBtnDelete")).Text = "삭제";

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button WBtnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
            WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "수정하시겠습니까?"));

            Button WBtnDelete = (Button)e.Item.FindControl("WBtnDelete");
            WBtnDelete.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        int nRet = 0;

        try
        {
            int nRegionId = Convert.ToInt32(e.CommandArgument.ToString());

            conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "update":
                    string sName = ((TextBox)e.Item.FindControl("WTxtName")).Text.Trim();
                    string sNameKey = ((TextBox)e.Item.FindControl("WTxtNameKey")).Text.Trim();
                    int nSortNo = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtSortNo")).Text.Trim());

                    nRet = DacUser.UpdateGameServerRegion(conn, null, nRegionId, sName, sNameKey, nSortNo);

                    break;
                case "delete":
                    nRet = DacUser.DeleteGameServerRegion(conn, null, nRegionId);
                    break;
                default:
                    nRet = 3;
                    break;
            }

            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
                    break;
                case 1:
                    ComUtil.MsgBox("작업실패", "history.back();");
                    break;
                case 2:
                    ComUtil.MsgBox("그룹에 게임서버가 존재합니다.", "history.back();");
                    break;
                default:
                    ComUtil.MsgBox("예외발생", "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            if (conn != null)
                DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
        }
    }

    protected void WBtnAdd_OnClick(object sender, EventArgs e)
    {
        try
        {
            int nRegionId = Convert.ToInt32(WTxtRegionId.Text.Trim());
            string sName = WTxtName.Text.Trim();
            string sNameKey = WTxtNameKey.Text.Trim();
            if (sName == "")
            {
                ComUtil.MsgBox("입력값이 필요합니다.", "history.back();");
                return;
            }
            int nSortNo = Convert.ToInt32(WTxtSortNo.Text.Trim());

            SqlConnection conn = DBUtil.GetUserDBConn();
            int nRet = DacUser.AddGameServerRegion(conn, null, nRegionId, sName, sNameKey, nSortNo);
            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
                    break;
                case 1:
                    ComUtil.MsgBox("작업실패", "history.back();");
                    break;
                default:
                    //ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
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