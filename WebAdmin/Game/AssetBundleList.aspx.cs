using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_AssetBundleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //======================================================================
        ComUtil.SetNoBrowserCache();

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
		WBtnAddFile.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");
        WBtnUpdateVersion.Attributes.Add("onclick", "return getCheckedItems();");

        // DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 게임 어셋번들 조회
        DataTable dt = DacUser.GameAssetBundles(conn, null);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dt;
        WRptList.DataBind();
        dt.Dispose();
    }

    protected void WBtnUpdateVersion_OnClick(object sender, EventArgs e)
    {
        try
        {
            bool bAndroid = WCBoxAndroid.Checked;
            bool biOS = WCBoxiOS.Checked;
            string sBundleNos = WHFSelectedBundleNo.Value.Trim();

            if (!bAndroid && !biOS)
            {
                ComUtil.MsgBox("Android 또는 iOS를 선택해주세요.", "history.back();");
                return;
            }

            if (sBundleNos == "")
            {
                ComUtil.MsgBox("선택한 번들파일이 없습니다.", "history.back();");
                return;
            }

            // DB연결
            SqlConnection conn = DBUtil.GetUserDBConn();

            // 선택된 어셋번들을 업데이트
            int nRet = BizUser.UpdateGameAssetBundleSelected(conn, bAndroid, biOS, sBundleNos);

            // DB연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet != 0)
            {
                //ComUtil.MsgBox(Resources.ResLang.ACCHBL_cs_mbox_03, "history.back();");
				
                return;
            }
            ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
			ComUtil.MsgBox("예외" +  ex.Message, "history.back();");
        }
    }

    protected void WBtnAddFile_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;

        try
        {
            int nBundleNo = Convert.ToInt32(WTxtBundleNo.Text.Trim());
            string sFileName = WTxtFileName.Text.Trim();
            int nAndroidVer = Convert.ToInt32(WTxtAndroidVer.Text.Trim());
            int niOSVer = Convert.ToInt32(WTxtiOSVer.Text.Trim());

            conn = DBUtil.GetUserDBConn();
            int nRet = DacUser.AddGameAssetBundle(conn, null, nBundleNo, sFileName, nAndroidVer, niOSVer);
            DBUtil.CloseDBConn(conn);

            if (nRet != 0)
            {
				ComUtil.MsgBox("실패", "history.back();");
               return;
            }
            ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            if (conn != null)
                DBUtil.CloseDBConn(conn);

			ComUtil.MsgBox("예외" + ex.Message, "history.back();");
        }
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
		((CheckBox)e.Item.FindControl("WCBoxIsCommon")).Checked = Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "isCommon"));
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
			((Button)e.Item.FindControl("WBtnUpdate")).Attributes.Add("onclick", string.Format("return confirm('{0}');", "수정하시겠습니까?"));
			((Button)e.Item.FindControl("WBtnDel")).Attributes.Add("onclick", string.Format("return confirm('{0}');", "삭제하시겠습니까?"));
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            int nBundleNo = Convert.ToInt32(e.CommandArgument.ToString());
            int nRet = 0;

            SqlConnection conn = DBUtil.GetUserDBConn();

            switch (e.CommandName)
            {
                case "update":
                    string sFileName = ((TextBox)e.Item.FindControl("WTxtFileName")).Text.Trim();
                    string sAndroidVer = ((TextBox)e.Item.FindControl("WTxtAndroidVer")).Text.Trim();
                    string siOSVer = ((TextBox)e.Item.FindControl("WTxtiOSVer")).Text.Trim();
					bool bWCBoxIsCommon = ((CheckBox)e.Item.FindControl("WCBoxIsCommon")).Checked;

					nRet = DacUser.UpdateGameAssetBundle(conn, null, nBundleNo, sFileName, Convert.ToInt32(sAndroidVer), Convert.ToInt32(siOSVer), bWCBoxIsCommon);
                    break;
                case "delete":
                    nRet = DacUser.DelGameAssetBundle(conn, null, nBundleNo);
                    break;
                default:
                    nRet = 2;
                    break;
            }

            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    if(e.CommandName == "update")
                        ComUtil.MsgBox("수정 성공", "location.href='" + Request.Url.ToString() + "';");
                    if (e.CommandName == "delete")
						ComUtil.MsgBox("삭제 성공", "location.href='" + Request.Url.ToString() + "';");
                    break;
                case 1:
                    if (e.CommandName == "update")
						ComUtil.MsgBox("수정 실패", "history.back();");
                    if (e.CommandName == "delete")
						ComUtil.MsgBox("삭제 실패", "history.back();");
                    break;
                default:
					ComUtil.MsgBox("실패", "history.back();");
                    break;
            }
        }
        catch (Exception ex)
        {
			ComUtil.MsgBox("예외" + ex.Message, "history.back();");
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