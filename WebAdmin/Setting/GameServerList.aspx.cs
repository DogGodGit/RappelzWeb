using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Setting_GameServerList : System.Web.UI.Page
{
    protected int m_nGameServerGroupId = 0;
    protected string m_sServerState = "";

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
        m_nGameServerGroupId = ComUtil.GetRequestInt("SVRG", RequestMethod.Get, 0);

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
        WBtnVAdd.Text = "등록";
        WBtnAdd.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.GAMESLIST_cs_cfrm_01));
        WBtnVAdd.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.ResLang.GAMESLIST_cs_cfrm_01));

        SqlConnection conn = DBUtil.GetUserDBConn();
        DataTable dtGroup = DacUser.GameServerGroups(conn, null);

        DataTable dtV = DacUser.VirtualGameServers(conn, null);
        DataTable dt = DacUser.GameServers_GroupId(conn, null, m_nGameServerGroupId);

        DBUtil.CloseDBConn(conn);

        if (m_nGameServerGroupId > 0)
            WPHServerInfo.Visible = true;

        WLtlGameServerGroupIdAdd.Text = m_nGameServerGroupId.ToString();

        WDDLSGroup.Items.Add(new ListItem("==서버그룹 선택==", "0"));
        for (int i = 0; i < dtGroup.Rows.Count; i++)
        {
            WDDLSGroup.Items.Add(new ListItem(dtGroup.Rows[i]["_name"].ToString(), dtGroup.Rows[i]["groupId"].ToString()));
        }

        WDDLSGroup.SelectedValue = m_nGameServerGroupId.ToString();

        WRptList.DataSource = dt;
        WRptList.DataBind();

        WRptVList.DataSource = dtV;
        WRptVList.DataBind();
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ((Button)e.Item.FindControl("WBtnGameServerUpdate")).Text = Resources.ResLang.GAMESLIST_aspx_th_11;

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal LtlGameServerGroupId = (Literal)e.Item.FindControl("WLtlGameServerGroupId");
            LtlGameServerGroupId.Text = m_nGameServerGroupId.ToString();

            DropDownList WDDLStatus = (DropDownList)e.Item.FindControl("WDDLStatus");
            WDDLStatus.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "status");
            WDDLStatus.Items.FindByValue("1").Text = "원활";
            WDDLStatus.Items.FindByValue("2").Text = "혼잡";
            WDDLStatus.Items.FindByValue("3").Text = "포화";

            DropDownList WDDLIsNew = (DropDownList)e.Item.FindControl("WDDLIsNew");
            WDDLIsNew.SelectedValue = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "isNew"))) ? "1" : "0";
            WDDLIsNew.Items.FindByValue("0").Text = "비활성화";
            WDDLIsNew.Items.FindByValue("1").Text = "활성화";

            DropDownList WDDLMaintenance = (DropDownList)e.Item.FindControl("WDDLMaintenance");
            WDDLMaintenance.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "isMaintenance") == "1" ? "1" : "0";
            WDDLMaintenance.Items.FindByValue("0").Text = Resources.ResLang.GAMESLIST_aspx_txt_03;
            WDDLMaintenance.Items.FindByValue("1").Text = Resources.ResLang.GAMESLIST_aspx_txt_04;

            DropDownList WDDLPublic = (DropDownList)e.Item.FindControl("WDDLPublic");
            WDDLPublic.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "isPublic") == "1" ? "1" : "0";
            WDDLPublic.Items.FindByValue("0").Text = "비공개";
            WDDLPublic.Items.FindByValue("1").Text = "공개";

            CheckBox WCBoxRecommendable = (CheckBox)e.Item.FindControl("WCBoxRecommendable");
            WCBoxRecommendable.Checked = ComUtil.GetDataItem(e.Item.DataItem, "recommendable") == "1";
            if (!Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "deleted")))
            {
                ((Button)e.Item.FindControl("WBtnGameServerUpdate")).Attributes.Add("onclick", "return confirm('수정하시겠습니까?');");
                ((Button)e.Item.FindControl("WBtnGameServerDel")).Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");
            }
            else
            {
                ((Button)e.Item.FindControl("WBtnGameServerUpdate")).Visible = false;
                ((Button)e.Item.FindControl("WBtnGameServerDel")).Visible = false;
                ((Literal)e.Item.FindControl("WLtlDeleted")).Text = "<span class=\"red\">삭제됨</span>";
            }
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        int nRet = 0;

        try
        {
            int nServerId = Convert.ToInt32(e.CommandArgument.ToString());

            conn = DBUtil.GetUserDBConn();

            DataRow drSystemSetting = DacUser.SystemSetting(conn, null);
            int nRecommendGameServerId = Convert.ToInt32(drSystemSetting["recommendGameServerId"]);

            switch (e.CommandName)
            {
                case "update":
                    string sApiUrl = ((TextBox)e.Item.FindControl("WTxtApiUrl")).Text.Trim();
                    string sGameServerIp = ((TextBox)e.Item.FindControl("WTxtGameServerIp")).Text.Trim();
                    int nGameServerPort = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtGameServerPort")).Text.Trim());
                    int nStatus = Convert.ToInt32(((DropDownList)e.Item.FindControl("WDDLStatus")).SelectedValue);
                    bool bIsNew = (((DropDownList)e.Item.FindControl("WDDLIsNew")).SelectedValue == "0") ? false : true;
                    bool bIsMaintenance = (((DropDownList)e.Item.FindControl("WDDLMaintenance")).SelectedValue == "0") ? false : true;
                    bool bIsPublic = (((DropDownList)e.Item.FindControl("WDDLPublic")).SelectedValue == "0") ? false : true;
                    bool recommendable = ((CheckBox)e.Item.FindControl("WCBoxRecommendable")).Checked;
                    string sGameDBConnection = ((TextBox)e.Item.FindControl("WTxtGameServerDBConn")).Text.Trim();
                    string sGameLogDBConnection = ((TextBox)e.Item.FindControl("WTxtGameLogServerDBConn")).Text.Trim();

                    nRet = DacUser.UpdateGameServer(conn, null, nServerId, sApiUrl, sGameServerIp, nGameServerPort, sGameDBConnection, sGameLogDBConnection, nStatus, bIsNew, bIsMaintenance, recommendable, bIsPublic);

                    break;

                case "delete":
                    if (nRecommendGameServerId == nServerId)
                    {
                        DBUtil.CloseDBConn(conn);
                        ComUtil.MsgBox("추천서버는 삭제할 수 없습니다.", "history.back();");
                        return;
                    }

                    nRet = DacUser.DeleteGameServer(conn, null, nServerId);
                    break;

                default:
                    nRet = 2;
                    break;
            }

            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox(Resources.ResLang.ACCHRE_cs_mbox_02, "location.href='" + Request.Url.ToString() + "';");
                    break;

                case 1:
                    ComUtil.MsgBox(Resources.ResLang.SENDMAIL_cs_mbox_03, "history.back();");
                    break;

                default:
                    ComUtil.MsgBox(Resources.ResLang.COMMON_mbox_01, "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            if (conn != null)
                DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(String.Format("{0} {1}", Resources.ResLang.COMMON_mbox_02, ex.Message), "history.back();");
        }
    }

    protected void WRptVList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button btnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
            btnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "변경된 정보로 수정하시겠습니까?"));
            btnUpdate.Text = "수정";
            Button btnDelete = (Button)e.Item.FindControl("WBtnDelete");
            btnDelete.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));
            btnDelete.Text = "삭제";
        }
    }

    protected void WRptVList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        int nRet = 0;

        try
        {
            int nVirtualGameServerId = Convert.ToInt32(e.CommandArgument.ToString());

            conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "update":
                    int nGameServerId = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtGameServerId")).Text.Trim());
                    int nDisplayNo = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtDisplayNo")).Text.Trim());
                    string sDisplayName = ((TextBox)e.Item.FindControl("WTxtName")).Text.Trim();
                    nRet = DacUser.UpdateVirtualGameServer(conn, null, nVirtualGameServerId, nGameServerId, sDisplayName, nDisplayNo);
                    break;

                case "delete":
                    nRet = DacUser.DeleteVirtualGameServer(conn, null, nVirtualGameServerId);
                    break;

                default:
                    nRet = 2;
                    break;
            }

            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
                    break;

                case 1:
                    ComUtil.MsgBox("실패", "history.back();");
                    break;

                default:
                    ComUtil.MsgBox("예외", "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(String.Format("{0} {1}", "예외", ex.Message), "history.back();");
        }
    }

    protected void WBtnVAdd_OnClick(object sender, EventArgs e)
    {
        try
        {
            int nVirtualGameServerId = Convert.ToInt32(WTxtVirtualGameServerId.Text.Trim());
            int nGameServerId = Convert.ToInt32(WTxtVGameServerId.Text.Trim());
            int nDisplayNo = Convert.ToInt32(WTxtVDisplayNo.Text.Trim());
            string sDisplayName = WTxtVName.Text.Trim();
            if (sDisplayName == "")
            {
                ComUtil.MsgBox("이름을 입력해주세요.", "history.back();");
                return;
            }

            SqlConnection conn = DBUtil.GetUserDBConn();
            int nRet = DacUser.AddVirtualGameServer(conn, null, nVirtualGameServerId, nGameServerId, sDisplayName, nDisplayNo);
            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
                    break;

                case 1:
                    ComUtil.MsgBox("실패", "history.back();");
                    break;

                default:
                    ComUtil.MsgBox("예외발생", "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("{0} {1}", "예외", ex.Message), "history.back();");
        }
    }

    //게임서버 생성
    protected void WBtnGameServerAdd_OnClick(object sender, EventArgs e)
    {
        string nServerId = WTxtGameServerIdAdd.Text.Trim();
        string sApiUrl = WTxtApiAdd.Text.Trim();
        string sProxyServer = WTxtProxyAdd.Text.Trim();
        string sProxyServerPort = WTxtProxyPortAdd.Text.Trim();
        string sGameDBConnection = WTxtGameDBConnection.Text.Trim();
        string sGameLogDBConnection = WTxtGameLogDBConnection.Text.Trim();

        //공백체크
        if (nServerId == "" || sApiUrl == "" || sProxyServer == "" || sProxyServerPort == "" || sGameDBConnection == "" || sGameLogDBConnection == "")
        {
            ComUtil.MsgBox("빈 데이터가 존재합니다. 확인해주세요.");
            return;
        }

        int nServerAddId = Convert.ToInt32(nServerId);
        int sProxyServerPortAdd = Convert.ToInt32(sProxyServerPort);

        int nRet = 0;

        //DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        nRet = DacUser.AddGameServer(conn, null, nServerAddId, m_nGameServerGroupId, sApiUrl, sProxyServer, sProxyServerPortAdd, sGameDBConnection, sGameLogDBConnection);

        //DB연결해제
        DBUtil.CloseDBConn(conn);

        if (nRet == 0)
        {
            ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
        }
        else
        {
            ComUtil.MsgBox("작업실패", "history.back();");
        }
    }

    //서버그룹 선택시 게임서버출력
    protected void WDDLServerGroup_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Setting/GameServerList.aspx?SVRG=" + WDDLSGroup.SelectedValue);
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "isRecommend":
                if (Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
                    sRtn = "V";
                break;

            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}