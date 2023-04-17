using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Setting_GameServerAccess : System.Web.UI.Page
{
    protected int m_nGameServerRegionId = 0;
    protected int m_nGameServerGroupId = 0;

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
        m_nGameServerRegionId = ComUtil.GetRequestInt("SVRR", RequestMethod.Get, 0);
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
        WBtnUpdate.Attributes.Add("onclick", "return confirm('서버에 즉시 적용됩니다. 적용하시겠습니까?');");
        WBtnUpdate.Visible = false;

        SqlConnection conn = DBUtil.GetUserDBConn();
        DataTable dtRegion = DacUser.GameServerRegions(conn, null);
        DataTable dtGroup = null;

        if (m_nGameServerRegionId > 0)
            dtGroup = DacUser.GameServerGroups_RegionId(conn, null, m_nGameServerRegionId);

        DataTable dtAllowedCountryCode = null;
        DataTable dtCountryCodes = null;

        if (m_nGameServerGroupId > 0)
        {
            dtAllowedCountryCode = DacUser.GameServerGroupAllowedCountries(conn, null, m_nGameServerGroupId);
            dtCountryCodes = DacUser.GeoIpCountryCodes(conn, null);
        }

        DBUtil.CloseDBConn(conn);

        // 서버지역
        WDDLSRegion.Items.Add(new ListItem("== 서버지역 선택 == ", "0"));
        for (int i = 0; i < dtRegion.Rows.Count; i++)
        {
            WDDLSRegion.Items.Add(new ListItem(dtRegion.Rows[i]["_name"].ToString(), dtRegion.Rows[i]["regionId"].ToString()));
        }
        WDDLSRegion.SelectedValue = m_nGameServerRegionId.ToString();

        if (m_nGameServerRegionId == 0)
            return;

        // 서버그룹
        WDDLSGroup.Items.Add(new ListItem("== 서버그룹 선택 == ", "0"));
        for (int i = 0; i < dtGroup.Rows.Count; i++)
        {
            WDDLSGroup.Items.Add(new ListItem(dtGroup.Rows[i]["_name"].ToString(), dtGroup.Rows[i]["groupId"].ToString()));
        }
        WDDLSGroup.SelectedValue = m_nGameServerGroupId.ToString();

        if (m_nGameServerGroupId > 0)
        {
            WBtnUpdate.Visible = true;

            //전체 국가코드
            for (int i = 0; i < dtCountryCodes.Rows.Count; i++)
                WLBox.Items.Add(new ListItem(dtCountryCodes.Rows[i]["countryName"].ToString() + " - " + dtCountryCodes.Rows[i]["countryCode"].ToString(), dtCountryCodes.Rows[i]["countryCode"].ToString()));

            //허용된 국가코드
            for (int i = 0; i < dtAllowedCountryCode.Rows.Count; i++)
            {
                ListItem item = WLBox.Items.FindByValue(dtAllowedCountryCode.Rows[i]["countryCode"].ToString());
                if (item != null)
                {
                    WLBoxAllowed.Items.Add(new ListItem(item.Text, item.Value));
                    WLBox.Items.Remove(item);
                }
            }
        }
    }

    protected void WBtnSelect_OnClick(object sender, EventArgs e)
    {
        if (WLBox.SelectedItem != null)
        {
            WLBoxAllowed.Items.Add(new ListItem(WLBox.SelectedItem.Text, WLBox.SelectedItem.Value));
            WLBox.Items.Remove(WLBox.SelectedItem);
        }
    }

    protected void WBtnUnselect_OnClick(object sender, EventArgs e)
    {
        if (WLBoxAllowed.SelectedItem != null)
        {
            WLBox.Items.Add(new ListItem(WLBoxAllowed.SelectedItem.Text, WLBoxAllowed.SelectedItem.Value));
            WLBoxAllowed.Items.Remove(WLBoxAllowed.SelectedItem);
        }
    }

    //서버지역 선택시 게임그룹출력
    protected void WDDLServerRegion_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Setting/GameServerAccess.aspx?SVRR=" + WDDLSRegion.SelectedValue);
    }

    protected void WDDLSGroup_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Setting/GameServerAccess.aspx?SVRR=" + WDDLSRegion.SelectedValue + "&SVRG=" + WDDLSGroup.SelectedValue);
    }

    protected void WBtnUpdate_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        SqlTransaction tran = null;

        try
        {
            // DB연결
            conn = DBUtil.GetUserDBConn();

            // Transaction 시작
            tran = conn.BeginTransaction();

            // 기존 데이터 삭제
            if (DacUser.DeleteGameServerGroupAllowedCountry(conn, tran, m_nGameServerGroupId) != 0)
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("기존 데이터 삭제 실패", "history.back();");
                return;
            }

            // 허용국가를 재설정
            for (int i = 0; i < WLBoxAllowed.Items.Count; i++)
            {
                if (DacUser.AddGameServerGroupAllowedCountry(conn, tran, m_nGameServerGroupId, WLBoxAllowed.Items[i].Value) != 0)
                {
                    tran.Rollback();
                    tran.Dispose();
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox("허용국가 추가 실패(" + WLBoxAllowed.Items[i].Value + ")", "history.back();");
                    return;
                }
            }

            // Transaction 종료
            tran.Commit();
            tran.Dispose();

            // DB연결 종료
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            if (tran != null)
            {
                tran.Rollback();
                tran.Dispose();
            }
            if (conn.State == ConnectionState.Connecting)
                DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(String.Format("예외발생 : {0}", ex.StackTrace), "history.back();");
        }
    }
}