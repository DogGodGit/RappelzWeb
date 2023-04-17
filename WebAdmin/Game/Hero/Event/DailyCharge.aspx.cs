using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Game_Hero_Event_DailyCharge : System.Web.UI.Page
{
    protected int m_nServerId;
    protected Guid m_heroId;

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
        m_heroId = Guid.Parse(ComUtil.GetRequestString("HID", RequestMethod.Get, Guid.Empty.ToString()));

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
        WBtnUpdate.Text ="수정";
        // 값 체크
        Util.BadAccessCheck(m_nServerId, m_heroId);

        WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "변경된 정보로 수정하시겠습니까?"));

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 계정영웅 조회
        DataTable dt = Dac.Heros_Search(conn, null, Define.kHeroSearchType_heroId, m_heroId.ToString());

        // 
        DataTable dtRewards = Dac.DailyChargeEntryRewardLogs(conn, null, m_heroId);
        DataTable dtLogs = Dac.AdminDailyAccumulateChargeDiaLogs(conn, null, m_heroId);

        DataRow drNow = Dac.SystemDateTimeOffset(conn, null);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        if (dt == null || dt.Rows.Count < 1)
        {
            ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
            return;
        }

        DataRow drAccountHero = dt.Rows[0];
        dt.Dispose();

        WTxtDailyAccumulateChargeDia.Text = drAccountHero["dailyAccumulateChargeDia"].ToString();
        WHFDailyAccumulateChargeDia.Value = drAccountHero["dailyAccumulateChargeDia"].ToString();
        if (drAccountHero["lastChargeTime"] != DBNull.Value)
        {
            DateTimeOffset dtoLastChargeTime = DateTimeOffset.Parse(drAccountHero["lastChargeTime"].ToString());

            if (dtoLastChargeTime.Date == DateTimeOffset.Parse(drNow["currentTime"].ToString()).Date)
            {
                WLtlLastChargeTime.Text = string.Format("{0} : " + DateTimeUtil.ToDateTimeOffsetString(dtoLastChargeTime), "마지막 충전 시각");
                WBtnUpdate.Visible = true;
            }
            else
            {
                WTxtDailyAccumulateChargeDia.Enabled = false;
                WTxtDailyAccumulateChargeDia.Text = "0";
                WLtlLastChargeTime.Text = "당일 충전일 경우에만 수정이 가능합니다.";
            }
        }
        else
            WLtlLastChargeTime.Text = "마지막 충전 일자가 없음";

        WRptReward.DataSource = dtRewards;
        WRptReward.DataBind();

        WRptList.DataSource = dtLogs;
        WRptList.DataBind();
    }

    protected void WBtnUpdate_OnClick(object sender, EventArgs e)
    {
        try
        {
            int nOldDailyAccumulateChargeDia = Convert.ToInt32(WHFDailyAccumulateChargeDia.Value);
            int nDailyAccumulateChargeDia = Convert.ToInt32(WTxtDailyAccumulateChargeDia.Text.Trim());

            if (nOldDailyAccumulateChargeDia == nDailyAccumulateChargeDia)
            {
                ComUtil.MsgBox("기존값과 동일한 값을 입력하셨습니다.", "history.back();");
                return;
            }

            string sReason = WTxtReason.Text.Trim();

            if (sReason == "")
            {
                ComUtil.MsgBox("사유를 반드시 입력하셔야합니다.", "history.back();");
                return;
            }

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

            // 접속중 체크
            if (Dac.Hero_Connection(conn, null, m_heroId) != 0)
            {
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("유저가 접속중인 상태에서는 정보가 수정되지 않습니다.", "history.back();");
                return;
            }

            // 작업
            int nRet = Biz.UpdateHero_DailyAccumulateChargeDia(conn, m_heroId, nOldDailyAccumulateChargeDia, nDailyAccumulateChargeDia, sReason, ComUtil.GetUserId());

            // DB 연결 해제
            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("적용되었습니다.", "location.href='" + Request.Url.ToString() + "';");
                    break;
                case -1:
                    ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "적용에 실패하였습니다.", "오류코드", "history.back();"));
                    break;
                case -2:
                    ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "내용 로그 등록에 실패하였습니다.", "오류코드", "history.back();"));
                    break;
                default:
                    ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "시스템 예외가 발생하였습니다.", "오류코드", nRet), "history.back();");
                    break;
            }
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
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}