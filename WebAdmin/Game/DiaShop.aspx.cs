using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_DiaShop : System.Web.UI.Page
{
    protected int  m_nDiaShopCategory = 0;
    protected int m_nServerId = 0;
    protected int nPage = 0;        // 페이지
    private int nTotCnt = 0;        // 전체페이지
    private int nTotPage = 1;       // 전체페이지

    private const int N_PG_MX = 10;     //페이지 목록 수
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
        m_nDiaShopCategory = ComUtil.GetRequestInt("CATE", RequestMethod.Get, 0);

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
       // WBtnApplyServer.Attributes.Add("onclick", string.Format("return confirm('{0}');", "데이터가 서버에 실시간 반영됩니다.\n메타정보를 업데이트 하시겠습니까?"));
       // WBtnAddProduct.Attributes.Add("onclick", string.Format("return confirm('{0}');", "상품을 추가하시겠습니까?"));
       // WBtnApplyServer.Text = "메타버전 업데이트";
        WBtnAddProduct.Text = "상품추가";

        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        //카테고리
        DataTable cdt = DacUser.DiaShopCategory(conn, null);
        WDDLCategory.Items.Add(new ListItem("== " + "카테고리선택" + " ==", "0"));

        DataRowCollection drc = cdt.Rows;
        for (int i = 0; i < drc.Count; i++)
            WDDLCategory.Items.Add(new ListItem(drc[i]["_name"].ToString(), drc[i]["categoryId"].ToString()));

        if (m_nDiaShopCategory == 0)
            return;

        WDDLCategory.SelectedValue = m_nDiaShopCategory.ToString();
        //다이아샵상품 목록 
        DataTable dtDiaShopProducts = DacUser.DiaShopProducts(conn, null, m_nDiaShopCategory,  N_PG_MX, nPage, out nTotCnt);
        //아이템목록
        DataTable dtItems = DacUser.Items(conn, null);

        for (int i = 0; i < dtItems.Rows.Count; i++)
            WDDLItem.Items.Add(new ListItem(dtItems.Rows[i]["itemId"].ToString() + " - " + dtItems.Rows[i]["_name"].ToString(), dtItems.Rows[i]["itemId"].ToString()));
        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        // 목록
        WRptList.DataSource = dtDiaShopProducts;
        WRptList.DataBind();

        //SetStore(WDDLStore);
        // SetMoneyType(WDDLMoneyType);
        //SetItem(WDDLItem);

        // WHFLimitedProductMetaVersion.Value = dr["limitedProductDataVersion"].ToString();
        // WTxtLimitedProductMetaVersion.Text = dr["limitedProductDataVersion"].ToString();
        //아이템 목록 

        nTotPage = (nTotCnt - 1) / N_PG_MX + 1;

        if (nTotCnt > 0 && nTotPage < nPage)
            nPage = nTotPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = nTotPage;
        WPageNavigator.CurrentPage = nPage;
        WPageNavigator.UrlParam = String.Format("CATE={0}", m_nDiaShopCategory);
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

    private void SetItem(DropDownList ddl)
    {
        for (int i = 0; i < WDDLItems.Items.Count; i++)
            ddl.Items.Add(new ListItem(WDDLItems.Items[i].Text, WDDLItems.Items[i].Value));
    }

    private void SetStore(DropDownList ddl)
    {
        for (int i = 0; i < WDDLStores.Items.Count; i++)
            ddl.Items.Add(new ListItem(WDDLStores.Items[i].Text, WDDLStores.Items[i].Value));
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList WDDLcategoryId = (DropDownList)e.Item.FindControl("WDDLcategoryId");
        DropDownList WDDLcostumeProductType = (DropDownList)e.Item.FindControl("WDDLcostumeProductType");
        CheckBox WCBoxItemOwned = (CheckBox)e.Item.FindControl("WCBoxItemOwned");
        DropDownList WDDLtagType = (DropDownList)e.Item.FindControl("WDDLtagType");
        DropDownList WDDLmoneyType = (DropDownList)e.Item.FindControl("WDDLmoneyType");
        DropDownList WDDLbuyLimitType = (DropDownList)e.Item.FindControl("WDDLbuyLimitType");
        DropDownList WDDLbuyLimitCount = (DropDownList)e.Item.FindControl("WDDLbuyLimitCount");
        DropDownList WDDLperiodType = (DropDownList)e.Item.FindControl("WDDLperiodType");
        DropDownList WDDLperiodDayOfWeek = (DropDownList)e.Item.FindControl("WDDLperiodDayOfWeek");
        CheckBox WCBoxRecommended = (CheckBox)e.Item.FindControl("WCBoxRecommended");
        CheckBox WCBoxIsLimitEdition = (CheckBox)e.Item.FindControl("WCBoxIsLimitEdition");
        CheckBox WCBoxSellable = (CheckBox)e.Item.FindControl("WCBoxSellable");

        ((Button)e.Item.FindControl("WBtnUpdate")).Text = "수정";
        ((Button)e.Item.FindControl("WBtnDelete")).Text = "삭제";
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button WBtnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
            WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "변경된 정보로 수정하시겠습니까?"));
            Button WBtnDelete = (Button)e.Item.FindControl("WBtnDelete");
            WBtnDelete.Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));

            WDDLcategoryId.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "categoryId");
            WDDLcostumeProductType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "costumeProductType");
            WCBoxItemOwned.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "itemOwned"))) ? true : false;
            WDDLtagType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "tagType");
            WDDLmoneyType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "moneyType");
            WDDLbuyLimitType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "buyLimitType");
            WDDLbuyLimitCount.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "buyLimitCount");
            WDDLperiodType.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "periodType");
            WDDLperiodDayOfWeek.SelectedValue = ComUtil.GetDataItem(e.Item.DataItem, "periodDayOfWeek");
            WCBoxRecommended.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "recommended"))) ? true : false;
            WCBoxIsLimitEdition.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "isLimitEdition"))) ? true : false;
            WCBoxSellable.Checked = (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "sellable"))) ? true : false;

        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;

        try
        {
            int nDiaShopCategoryId = Convert.ToInt32(e.CommandArgument);
            int nRet = 0;

            // DB연결
            //conn = DBUtil.GetGameDBConn(sConnectionString);
            conn = DBUtil.GetUserDBConn();
            switch (e.CommandName)
            {
                case "update":
                    DropDownList WDDLcategoryId = (DropDownList)e.Item.FindControl("WDDLcategoryId");
                    TextBox WTxtproductId = (TextBox)e.Item.FindControl("WTxtproductId");
                    DropDownList WDDLcostumeProductType = (DropDownList)e.Item.FindControl("WDDLcostumeProductType");
                    TextBox WTxtitemId = (TextBox)e.Item.FindControl("WTxtitemId");
                    CheckBox WCBoxItemOwned = (CheckBox)e.Item.FindControl("WCBoxItemOwned");
                    DropDownList WDDLtagType = (DropDownList)e.Item.FindControl("WDDLtagType");
                    DropDownList WDDLmoneyType = (DropDownList)e.Item.FindControl("WDDLmoneyType");

                    TextBox WTxtmoneyItemId = (TextBox)e.Item.FindControl("WTxtmoneyItemId");
                    TextBox WTxtoriginalPrice = (TextBox)e.Item.FindControl("WTxtoriginalPrice");
                    TextBox WTxtprice = (TextBox)e.Item.FindControl("WTxtprice");

                    DropDownList WDDLbuyLimitType = (DropDownList)e.Item.FindControl("WDDLbuyLimitType");
                    DropDownList WDDLbuyLimitCount = (DropDownList)e.Item.FindControl("WDDLbuyLimitCount");
                    DropDownList WDDLperiodType = (DropDownList)e.Item.FindControl("WDDLperiodType");
                    TextBox WTxtperiodStartTime = (TextBox)e.Item.FindControl("WTxtperiodStartTime");
                    TextBox WTxtperiodEndTime = (TextBox)e.Item.FindControl("WTxtperiodEndTime");
                    DropDownList WDDLperiodDayOfWeek = (DropDownList)e.Item.FindControl("WDDLperiodDayOfWeek");
                    CheckBox WCBoxRecommended = (CheckBox)e.Item.FindControl("WCBoxRecommended");
                    CheckBox WCBoxIsLimitEdition = (CheckBox)e.Item.FindControl("WCBoxIsLimitEdition");
                    CheckBox WCBoxSellable = (CheckBox)e.Item.FindControl("WCBoxSellable");
                    TextBox WTxtcategorySortNo = (TextBox)e.Item.FindControl("WTxtcategorySortNo");
                    TextBox WTxtlimitEditionSortNo = (TextBox)e.Item.FindControl("WTxtlimitEditionSortNo");

                    int nProductId = Convert.ToInt32(WTxtproductId.Text.Trim());
                    int nCategoryId = Convert.ToInt32(WDDLcategoryId.SelectedValue);
                    int nCostumeProductType = Convert.ToInt32(WDDLcostumeProductType.SelectedValue);
                    int nItemId = Convert.ToInt32(WTxtitemId.Text.Trim());
                    bool bItemOwned = WCBoxItemOwned.Checked;
                    int nTagType = Convert.ToInt32(WDDLtagType.SelectedValue);
                    int nMoneyType = Convert.ToInt32(WDDLmoneyType.SelectedValue);
                    int nMoneyItemId = Convert.ToInt32(WTxtmoneyItemId.Text.Trim());
                    int nOriginalPrice = Convert.ToInt32(WTxtoriginalPrice.Text.Trim());
                    int nPrice = Convert.ToInt32(WTxtprice.Text.Trim());
                    int nPeriodType = Convert.ToInt32(WDDLperiodType.SelectedValue);

                    DateTime startTime = DateTime.MinValue;
                    DateTime endTime = DateTime.MinValue;
                    string dPeriodStartTime = WTxtperiodStartTime.Text.Trim(); 
                    string dPeriodEndTime = WTxtperiodEndTime.Text.Trim();

                    DateTime.TryParse(dPeriodStartTime, out startTime);
                    DateTime.TryParse(dPeriodEndTime, out endTime);

                    int nPeriodDayOfWeek = Convert.ToInt32(WDDLperiodDayOfWeek.SelectedValue);
                    bool bRecommended = WCBoxRecommended.Checked;
                    bool bIsLimitEdition = WCBoxIsLimitEdition.Checked;
                    bool bSellable = WCBoxSellable.Checked;
                    int nCategorySortNo = Convert.ToInt32(WTxtcategorySortNo.Text.Trim());
                    int nLimitEditionSortNo = Convert.ToInt32(WTxtlimitEditionSortNo.Text.Trim());
                    int nBuyLimitType = Convert.ToInt32(WDDLbuyLimitType.SelectedValue);
                    int nBuyLimitCount = Convert.ToInt32(WDDLbuyLimitCount.SelectedValue);
                    /*
                    if (DateTime.Compare(startTime, endTime) >= 0)
                    {
                        DBUtil.CloseDBConn(conn);
                        ComUtil.MsgBox("입력한 날짜를 다시 확인해주세요.", "history.back();");
                        return;
                    }
                    */
                    nRet = DacUser.UpdateDiaShopProduct(conn, null,  nProductId,  nCategoryId,  nCostumeProductType,  nItemId,  bItemOwned
                                ,  nTagType,  nMoneyType,  nMoneyItemId,  nOriginalPrice,  nPrice,  nPeriodType, startTime, endTime
                                ,  nPeriodDayOfWeek,  bRecommended,  bIsLimitEdition,  bSellable,  nCategorySortNo,  nLimitEditionSortNo,  nBuyLimitType,  nBuyLimitCount);

                    break;
                case "delete":

                    nRet = DacUser.DeleteDiaShopProduct(conn, null, nDiaShopCategoryId);

                    break;
                default:
                    nRet = 2;
                    break;
            }
            // DB 연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet == 0)
            {
                switch (e.CommandName)
                {
                    case "update":
                        ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
                        break;
                    case "delete":
                        ComUtil.MsgBox("작업성공", "location.href='/Game/DiaShop.aspx?CATE=" + m_nDiaShopCategory.ToString() + "&PG=" + nPage.ToString() + "';");
                        break;
                }
            }
            else
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "history.back();", "작업실패", "Error Code"));
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
    
    protected void WDDLCategory_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Game/DiaShop.aspx?CATE=" + WDDLCategory.SelectedValue);
    }  

    protected void WBtnAddProduct_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;

        try
        {
            int nCategoryId = Convert.ToInt32(WDDLcategoryId.SelectedValue);
            int nCostumeProductType = Convert.ToInt32(WDDLcostumeProductType.SelectedValue);
            int nItemId = Convert.ToInt32(WDDLItem.Text.Trim());
            bool bItemOwned = WCBoxItemOwned.Checked;
            int nTagType = Convert.ToInt32(WDDLtagType.SelectedValue);
            int nMoneyType = Convert.ToInt32(WDDLmoneyType.SelectedValue);
            int nMoneyItemId = Convert.ToInt32(WTxtmoneyItemId.Text.Trim());
            int nOriginalPrice = Convert.ToInt32(WTxtoriginalPrice.Text.Trim());
            int nPrice = Convert.ToInt32(WTxtprice.Text.Trim());
            int nPeriodType = Convert.ToInt32(WDDLperiodType.SelectedValue);

            DateTime startTime = DateTime.MinValue;
            DateTime endTime = DateTime.MinValue;
            string dPeriodStartTime = WTxtperiodStartTime.Text.Trim();
            string dPeriodEndTime = WTxtperiodEndTime.Text.Trim();

            DateTime.TryParse(dPeriodStartTime, out startTime);
            DateTime.TryParse(dPeriodEndTime, out endTime);

            int nPeriodDayOfWeek = Convert.ToInt32(WDDLperiodDayOfWeek.SelectedValue);
            bool bRecommended = WCBoxRecommended.Checked;
            bool bIsLimitEdition = WCBoxIsLimitEdition.Checked;
            bool bSellable = WCBoxSellable.Checked;
            int nCategorySortNo = Convert.ToInt32(WTxtcategorySortNo.Text.Trim());
            int nLimitEditionSortNo = Convert.ToInt32(WTxtlimitEditionSortNo.Text.Trim());
            int nBuyLimitType = Convert.ToInt32(WDDLbuyLimitType.SelectedValue);
            int nBuyLimitCount = Convert.ToInt32(WDDLbuyLimitCount.SelectedValue);

            conn = DBUtil.GetUserDBConn();

            int nRet =  DacUser.AddDiaShopProduct(conn, null, nCategoryId, nCostumeProductType, nItemId, bItemOwned
                                , nTagType, nMoneyType, nMoneyItemId, nOriginalPrice, nPrice, nPeriodType, startTime, endTime
                                , nPeriodDayOfWeek, bRecommended, bIsLimitEdition, bSellable, nCategorySortNo, nLimitEditionSortNo, nBuyLimitType, nBuyLimitCount);
            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet == 0)
                ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
            else
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "history.back();", "작업실패", "ErrorCode"));
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

    protected void WBtnApplyServer_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;

        try { 
        //    int nOldLimitedProductDataVersion = Convert.ToInt32(WHFLimitedProductMetaVersion.Value);
        //    int nLimitedProductDataVersion = Convert.ToInt32(WTxtLimitedProductMetaVersion.Text.Trim());

        //    if (nOldLimitedProductDataVersion >= nLimitedProductDataVersion)
        //    {
        //        ComUtil.MsgBox("메타버전을 확인하세요.\n이전버전과 같거나 작은 값이 입력되었을 수 있습니다.", "history.back();");
        //        return;
        //    }

            // 연결정보 가져오기 (DB커넥션 포함됨)
           // string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetUserDBConn();

            // 
            int nRet = 0;// = DacUser.UpdateGameEnvSetting_DiaShopProductDataVersion(conn, null, nLimitedProductDataVersion);

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
            case "serverTime":
                DateTime dtServerTime = DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm));
                DateTime dtStartTime = DateTime.Parse(ComUtil.GetDataItem(objData, "startTime"));
                DateTime dtEndTime = DateTime.Parse(ComUtil.GetDataItem(objData, "endTime"));

                if (DateTime.Compare(dtStartTime, dtServerTime) > -1)
                    sRtn = string.Format("<span style=\"color:green\">{0}</span>", "예정");
                else if (DateTime.Compare(dtServerTime, dtEndTime) > -1)
                    sRtn = string.Format("<span style=\"color:silver\">{0}</span>", "완료");
                else
                    sRtn = string.Format("<span style=\"color:red\">{0}</span>", "진행중");
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