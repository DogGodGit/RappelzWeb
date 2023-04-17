using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_Hero_Event_FirstCharge : System.Web.UI.Page
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
        WBtnDelete.Text = "첫결제이벤트 삭제";

        Util.BadAccessCheck(m_nServerId, m_heroId);

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 
        DataRow drReward = Dac.FirstChargeEventRewardLog(conn, null, m_heroId);
        DataTable dtLogs = Dac.AdminFirstChargeEventLogs(conn, null, m_heroId);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        if (drReward != null)
        {
            WPHContent.Visible = true;

            if (Convert.ToBoolean(drReward["received"]))
                WLtlReceived.Text = "수령";
            else
                WLtlReceived.Text = "미수령";

            WHFReceived.Value = drReward["received"].ToString();

            WLtlReceiveTime.Text = drReward["receiveTime"].ToString();
            WLtlRegTime.Text = drReward["regTime"].ToString();

            WBtnDelete.Attributes.Add("onclick", string.Format("return confirm('{0}');", "첫결제 이벤트 내역을 삭제하시겠습니까?"));
            WBtnDelete.Visible = true;
        }

        WRptList.DataSource = dtLogs;
        WRptList.DataBind();
    }

    protected void WBtnDelete_OnClick(object sender, EventArgs e)
    {
        try
        {
            bool bRewardReceived = Convert.ToBoolean(WHFReceived.Value);

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
            int nRet = Biz.DelFirstChargeEventRewardLog(conn, m_heroId, bRewardReceived, sReason, ComUtil.GetUserId());

            // DB 연결 해제
            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("적용되었습니다.", "location.href='" + Request.Url.ToString() + "';");
                    break;
                case -1:
                    ComUtil.MsgBox(String.Format("{0} \\n{1}(" + nRet.ToString() + ")", "적용에 실패하였습니다.", "오류코드", "history.back();"));
                    break;
                case -2:
                    ComUtil.MsgBox(String.Format("{0} \\n{1}(" + nRet.ToString() + ")", "내용 로그 등록에 실패하였습니다.", "오류코드", "history.back();"));
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
            case "rewardReceived":
                if (Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
                    sRtn = "수령";
                else
                    sRtn = "미수령";
                break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}