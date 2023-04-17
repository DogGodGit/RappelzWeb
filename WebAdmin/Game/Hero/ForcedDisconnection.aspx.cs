using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_Hero_ForcedDisconnection : System.Web.UI.Page
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
        WCBox.Text = "제재적용";
        WTxtReason.Text = "강제종료";
        WBtnAdd.Text = "강제접속종료";

        // 값 체크
        Util.BadAccessCheck(m_nServerId, m_heroId);

        // 버튼 속성 추가
        WBtnAdd.Attributes.Add("onclick", string.Format("return confirm('{0}');", "계정영웅을 강제접속종료 시키겠습니까?"));

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 메인퀘스트 조회
        DataTable dtMainQuests = Dac.ForcedDisconnectionTasks(conn, null, m_heroId);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dtMainQuests;
        WRptList.DataBind();
        WRptList.Dispose();
    }

    protected void WBtnAdd_OnClick(object sender, EventArgs e)
    {
        SqlConnection scConn = null;

        try
        {
            string sReason = WTxtReason.Text.Trim();
            DateTimeOffset dtoBlockTime = DateTimeOffset.Now.AddMinutes(Convert.ToInt32(WTxtTime.Text.Trim()));

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            scConn = DBUtil.GetGameDBConn(sConnectionString);

            // 
            int nRet = Biz.AddForcedDisconnectionTask(scConn, m_heroId, WCBox.Checked, sReason, dtoBlockTime, ComUtil.GetUserId());

            if (nRet != 0)
            {
                DBUtil.CloseDBConn(scConn);
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "강제접속종료 등록에 실패하였습니다.", "오류코드", "history.back();"));
                return;
            }

            // DB연결 해제
            DBUtil.CloseDBConn(scConn);

            ComUtil.MsgBox("강제접속종료가 등록되었습니다.", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            if (scConn != null)
                DBUtil.CloseDBConn(scConn);
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {2}", "강제접속종료 등록 중 시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "handled":
                if (Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
                    sRtn = Resources.resLang.ACCHfD_cs_txt_05;
                else
                    sRtn = Resources.resLang.ACCHfD_cs_txt_06;
                break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}