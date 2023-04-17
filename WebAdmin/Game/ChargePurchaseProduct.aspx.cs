using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Game_ChargePurchaseProduct : System.Web.UI.Page
{
    protected int m_nServerId = 0;
    protected int m_nType = 0;
    protected int nPage = 0;        // 페이지
    private int nTotCnt = 0;        // 전체페이지
    private int nTotPage = 1;       // 전체페이지

    private const int N_PG_MX = 20;     //페이지 목록 수
    private const int N_PG_SZ = 10;     //페이징 수

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
        nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
        m_nType = ComUtil.GetRequestInt("TP", RequestMethod.Get, 0);

        //if (m_nServerId > 0)
            WPHAddForm.Visible = true;

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

        //WBtnApplyServer.Attributes.Add("onclick", string.Format("return confirm('{0}');", "데이터가 서버에 실시간 반영됩니다.\n메타정보를 업데이트 하시겠습니까?"));
        //WBtnApplyServer.Text = "메타버전 업데이트";

        WBtnAdd.Attributes.Add("onclick", string.Format("return confirm('{0}');", "등록하시겠습니까?"));
        WBtnAdd.Text = "등록";
        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();


        /*
        // 서버목록 조회
        DataTable sdt = DacUser.GameServerAll(conn, null);

        // DB연결해제
       // DBUtil.CloseDBConn(conn);

        WDDLServer.Items.Add(new ListItem("== " + "서버선택" + " ==", "0"));

        DataRowCollection drc = sdt.Rows;
        for (int i = 0; i < drc.Count; i++)
            WDDLServer.Items.Add(new ListItem(drc[i]["displayName"].ToString(), drc[i]["serverId"].ToString()));

        if (m_nServerId == 0)
            return;

        WDDLServer.SelectedValue = m_nServerId.ToString();

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
       // SqlConnection connGame = DBUtil.GetGameDBConn(sConnectionString);

        // 
        */

        DataTable dt = DacUser.CashProducts(conn, null, N_PG_MX, nPage, out nTotCnt);
        DataTable dtInAppProducts = DacUser.InAppProducts(conn, null);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WDDLType.Items.Add(new ListItem("다이아", "1"));
        WDDLType.Items.Add(new ListItem("아이템", "2"));

        for (int i = 0; i < dtInAppProducts.Rows.Count; i++)
            WDDLInApp.Items.Add(new ListItem("(" + dtInAppProducts.Rows[i]["inAppProductKey"].ToString() + ") " + dtInAppProducts.Rows[i]["inAppProductKey"].ToString(), dtInAppProducts.Rows[i]["inAppProductKey"].ToString()));

        // 목록
        WRptList.DataSource = dt;
        WRptList.DataBind();

        
        // DataRow dr = Dac.GameEnvSetting(connGame, null);
        //WHFPurchaseProductMetaVersion.Value = dr["PurchaseProductDataVersion"].ToString();
        //WTxtPurchaseProductMetaVersion.Text = dr["PurchaseProductDataVersion"].ToString();

        nTotPage = (nTotCnt - 1) / N_PG_MX + 1;

        if (nTotCnt > 0 && nTotPage < nPage)
            nPage = nTotPage;

        //WLtlDateSample1.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString()));
        //WLtlDateSample2.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(DateTime.Now.AddDays(8).ToShortDateString()));

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = nTotPage;
        WPageNavigator.CurrentPage = nPage;
        WPageNavigator.UrlParam = String.Format("SVR={0}", m_nServerId);
        WPageNavigator.PageListSize = N_PG_SZ;
        WPageNavigator.FirstPageItem = Resources.ResLang.COMMON_page_txt_01;
        WPageNavigator.PrevPageItem = Resources.ResLang.COMMON_page_txt_02;
        WPageNavigator.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigator.NextPageItem = Resources.ResLang.COMMON_page_txt_03;
        WPageNavigator.LastPageItem = Resources.ResLang.COMMON_page_txt_04;
        WPageNavigator.SNumberDecoLeft = "<span>";
        WPageNavigator.SNumberDecoRight = "</span>";
        WPageNavigator.Dispose();
    }

    protected void WBtnAdd_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;

        try
        {
            string nInAppProductKey = WDDLInApp.SelectedValue;
            int nType = Convert.ToInt32(WDDLType.SelectedValue);

            if (nType != 1)
            {
                WTxtItemCount.Text = "0";
            }

            string sName = WTxtName.Text.Trim();
            string sNameKey = WTxtNameKey.Text.Trim();
            string sImageName = WTxtImageName.Text.Trim();

            int nUnOwnDia = Convert.ToInt32(WTxtUnOwnDia.Text.Trim());
            int nItemId = Convert.ToInt32(WTxtItemId.Text.Trim());
            int nItemCount = Convert.ToInt32(WTxtItemCount.Text.Trim());
            int nVipPoint = Convert.ToInt32(WTxtVipPoint.Text.Trim());
            int nFirstPurchaseBonusUnOwnDia = Convert.ToInt32(WTxtFirstPurchaseBonusUnOwnDia.Text.Trim());
            bool bItemOwned = WCBoxItemOwned.Checked;
            bool bSaleable = WCBoxSaleable.Checked;
            int nSortNo = Convert.ToInt32(WTxtSortNo.Text.Trim());


            if (sName == "" || sNameKey == "")
            {
                ComUtil.MsgBox("입력한 값을 다시 확인해주세요." + " Name or NameKey", "history.back();");
                return;
            }

            if (nType != 1 && WTxtItemCount.Text != "0")
            {
                ComUtil.MsgBox("타입이 다이아가 아닐 경우엔 이벤트제한수량을 0으로 고정해주세요.", "history.back();");
                return;
            }

            // 연결정보 가져오기 (DB커넥션 포함됨)
            //string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetUserDBConn();

            // 
            int nRet = DacUser.AddCashProduct(conn, null, sName, sNameKey, nInAppProductKey, sImageName, nType, nUnOwnDia, nItemId, bItemOwned, nItemCount, nVipPoint, nFirstPurchaseBonusUnOwnDia, bSaleable, nSortNo);

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet == 0)
                ComUtil.MsgBox("등록되었습니다.", "location.href='" + Request.Url.ToString() + "';");
            else
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "history.back();", "등록에 실패하였습니다.", "오류코드"));
        }
        catch (Exception ex)
        {
            if (conn != null && conn.State == ConnectionState.Connecting)
            {
                DBUtil.CloseDBConn(conn);
            }
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TextBox WTxtNameRpt = (TextBox)e.Item.FindControl("WTxtName");
            TextBox WTxtNameKeyRpt = (TextBox)e.Item.FindControl("WTxtNameKey");
            DropDownList WDDLInAppRpt = (DropDownList)e.Item.FindControl("WDDLInApp");
            TextBox WTxtImageNameRpt = (TextBox)e.Item.FindControl("WTxtImageName");
            DropDownList WDDLTypeRpt = (DropDownList)e.Item.FindControl("WDDLType");
            TextBox WTxtUnOwnDiaRpt = (TextBox)e.Item.FindControl("WTxtUnOwnDia");
            TextBox WTxtItemIdRpt = (TextBox)e.Item.FindControl("WTxtItemId");
            CheckBox WCBoxItemOwnedRpt = (CheckBox)e.Item.FindControl("WCBoxItemOwned");
            TextBox WTxtItemCountRpt = (TextBox)e.Item.FindControl("WTxtItemCount");
            TextBox WTxtVipPointRpt = (TextBox)e.Item.FindControl("WTxtVipPoint");
            TextBox WTxtFirstPurchaseBonusUnOwnDiaRpt = (TextBox)e.Item.FindControl("WTxtFirstPurchaseBonusUnOwnDia");
            CheckBox WCBoxSaleableRpt = (CheckBox)e.Item.FindControl("WCBoxSaleable");
            TextBox WTxtSortNoRpt = (TextBox)e.Item.FindControl("WTxtSortNo");

            /*
            TextBox WTxtStartTimeRpt = (TextBox)e.Item.FindControl("WTxtStartTime");
            TextBox WTxtEndTimeRpt = (TextBox)e.Item.FindControl("WTxtEndTime");
            TextBox WTxtAddUnOwnDiaRpt = (TextBox)e.Item.FindControl("WTxtAddUnOwnDia");
            TextBox WTxtDiscountRateRpt = (TextBox)e.Item.FindControl("WTxtDiscountRate");
            TextBox WTxtLimitCountRpt = (TextBox)e.Item.FindControl("WTxtLimitCount");
            DropDownList WDDLTagTypeRpt = (DropDownList)e.Item.FindControl("WDDLTagType");
            CheckBox WCBoxDisplayRpt = (CheckBox)e.Item.FindControl("WCBoxDisplay");
            */
            Button btnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
            btnUpdate.Text = "수정";
            btnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}')", "변경된 정보로 수정하시겠습니까?"));

            for (int i = 0; i < WDDLInApp.Items.Count; i++)
                WDDLInAppRpt.Items.Add(new ListItem(WDDLInApp.Items[i].Text, WDDLInApp.Items[i].Value));

            WTxtNameRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "_name");
            WTxtNameKeyRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "nameKey");
            WDDLInAppRpt.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "inAppProductKey");
            WTxtImageNameRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "imageName");
            WDDLTypeRpt.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "type");
            WTxtUnOwnDiaRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "unOwnDia");
            WTxtItemIdRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "itemId");
            WCBoxItemOwnedRpt.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "itemOwned"))) ? true : false;
            WTxtItemCountRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "itemCount");
            WTxtVipPointRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "vipPoint");
            WTxtFirstPurchaseBonusUnOwnDiaRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "firstPurchaseBonusUnOwnDia");
            WCBoxSaleableRpt.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "saleable"))) ? true : false;
            WTxtSortNoRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "sortNo");

            //WTxtStartTimeRpt.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(e.Item.DataItem, "startTime")));
            //WTxtEndTimeRpt.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(e.Item.DataItem, "endTime")));
            /*
            WTxtAddUnOwnDiaRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "addUnOwnDia");
            WTxtDiscountRateRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "discountRate");
            WTxtLimitCountRpt.Text = ComUtil.GetDataItem(e.Item.DataItem, "eventLimitCount");
            WDDLTagTypeRpt.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "tagType");
            WCBoxDisplayRpt.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "display"))) ? true : false;
           
            if (WDDLTypeRpt.SelectedValue != "1" && WDDLTypeRpt.SelectedValue != "6" && WDDLTypeRpt.SelectedValue != "7")
            {
                WTxtLimitCountRpt.Text = "--";
                WTxtLimitCountRpt.Enabled = false;
                WTxtSortNoRpt.Enabled = false;

                if (WCBoxDisplayRpt.Checked)
                {
                    WCBoxDisplayRpt.Enabled = false;
                }
            }
             */
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;

        try
        {
            int nProductId = Convert.ToInt32(e.CommandArgument);
            int nRet = 0;

            // 연결정보 가져오기 (DB커넥션 포함됨)
           // string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "update":
                    TextBox WTxtNameRpt = (TextBox)e.Item.FindControl("WTxtName");
                    TextBox WTxtNameKeyRpt = (TextBox)e.Item.FindControl("WTxtNameKey");
                    DropDownList WDDLInAppRpt = (DropDownList)e.Item.FindControl("WDDLInApp");
                    TextBox WTxtImageNameRpt = (TextBox)e.Item.FindControl("WTxtImageName");
                    DropDownList WDDLTypeRpt = (DropDownList)e.Item.FindControl("WDDLType");
                    TextBox WTxtUnOwnDiaRpt = (TextBox)e.Item.FindControl("WTxtUnOwnDia");
                    TextBox WTxtItemIdRpt = (TextBox)e.Item.FindControl("WTxtItemId");
                    CheckBox WCBoxItemOwnedRpt = (CheckBox)e.Item.FindControl("WCBoxItemOwned");
                    TextBox WTxtItemCountRpt = (TextBox)e.Item.FindControl("WTxtItemCount");
                    TextBox WTxtVipPointRpt = (TextBox)e.Item.FindControl("WTxtVipPoint");
                    TextBox WTxtFirstPurchaseBonusUnOwnDiaRpt = (TextBox)e.Item.FindControl("WTxtFirstPurchaseBonusUnOwnDia");
                    CheckBox WCBoxWCBoxSaleableRpt = (CheckBox)e.Item.FindControl("WCBoxSaleable");
                    TextBox WTxtSortNoRpt = (TextBox)e.Item.FindControl("WTxtSortNo");

                    string sName = WTxtNameRpt.Text.Trim();
                    string sNameKey = WTxtNameKeyRpt.Text.Trim();
                    string nInAppProductKey = WDDLInAppRpt.SelectedValue;
                    string sImageName = WTxtImageNameRpt.Text.Trim();
                    int nType = Convert.ToInt32(WDDLTypeRpt.SelectedValue);
                    int nUnOwnDia = Convert.ToInt32(WTxtUnOwnDiaRpt.Text.Trim());
                    int nItemId = Convert.ToInt32(WTxtItemIdRpt.Text.Trim());
                    bool bItemOwned = WCBoxItemOwnedRpt.Checked;
                    int nItemCount = Convert.ToInt32(WTxtItemCountRpt.Text.Trim());
                    int nVipPoint = Convert.ToInt32(WTxtVipPointRpt.Text.Trim());
                    int nFirstPurchaseBonusUnOwnDia = Convert.ToInt32(WTxtFirstPurchaseBonusUnOwnDiaRpt.Text.Trim());
                    bool bSaleable = WCBoxWCBoxSaleableRpt.Checked;
                    int nSortNo = Convert.ToInt32(WTxtSortNoRpt.Text.Trim());


                    if (sName == "" || sNameKey == "")
                    {
                        ComUtil.MsgBox("입력한 값을 다시 확인해주세요." + " Name or NameKey", "history.back();");
                        return;
                    }

                    nRet = DacUser.UpdateCashProduct(conn, null, nProductId, sName, sNameKey, nInAppProductKey, sImageName, nType, nUnOwnDia, nItemId, bItemOwned, nItemCount, nVipPoint, nFirstPurchaseBonusUnOwnDia, bSaleable, nSortNo);

                    break;
                default:
                    nRet = 2;
                    break;
            }

            // DB 연결 해제
            DBUtil.CloseDBConn(conn);
            if (nRet == 0)
            {
                ComUtil.MsgBox("수정되었습니다.");
                return;
            }
            if (nRet != 0)
            {
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "삭제에 실패하였습니다.", "오류코드", "history.back();"));
                return;
            }
            ComUtil.MsgBox("적용되었습니다.", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            if (conn != null && conn.State == ConnectionState.Connecting)
            {
                DBUtil.CloseDBConn(conn);
            }

            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected void WDDLServer_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Game/ChargePurchaseProduct.aspx?SVR=");
    }

    //나중에 작업필요 
    protected void WBtnApplyServer_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;

        try { 
        //{
        //    int nOldPurchaseProductDataVersion = Convert.ToInt32(WHFPurchaseProductMetaVersion.Value);
        //    int nPurchaseProductDataVersion = Convert.ToInt32(WTxtPurchaseProductMetaVersion.Text.Trim());

        //    if (nOldPurchaseProductDataVersion >= nPurchaseProductDataVersion)
        //    {
        //        ComUtil.MsgBox("메타버전을 확인하세요.\n이전버전과 같거나 작은 값이 입력되었을 수 있습니다.", "history.back();");
        //        return;
        //    }

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetGameDBConn(sConnectionString);

            // 
            int nRet = 1; // Dac.UpdateGameEnvSetting_PurchaseProductDataVersion(conn, null, nPurchaseProductDataVersion);

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet == 0)
                ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
            else
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "history.back();", "작업실패", "Error"));
        }
        catch (Exception ex)
        {
            if (conn != null && conn.State == ConnectionState.Connecting)
            {
                DBUtil.CloseDBConn(conn);
            }
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            //case "displayTr":
            //    if (!Convert.ToBoolean(ComUtil.GetDataItem(objData, "display")))
            //        sRtn = "";
            //    break;
            case "display":
                if (!Convert.ToBoolean(ComUtil.GetDataItem(objData, "display")))
                    sRtn = "숨김";
                else
                    sRtn = "정상";
                break;
            case "startTime":
            case "endTime":
                sRtn = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
                break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}