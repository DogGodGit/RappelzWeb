using System;
using System.Data;
using System.Data.SqlClient;

public partial class Game_Hero_MonsterBook : System.Web.UI.Page
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
        // 값 체크
        /*
        if (m_nServerId < 1 || !m_heroId.Equals(""))
        {
            ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
            return;
        }
        */
        Util.BadAccessCheck(m_nServerId, m_heroId);

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 메인퀘스트 조회
        DataTable dtMonsterBooks = Dac.MonsterBooks(conn, null, m_heroId);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dtMonsterBooks;
        WRptList.DataBind();
        WRptList.Dispose();
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "count":
                if (Convert.ToInt32(ComUtil.GetDataItem(objData, "collectedCount")) == Convert.ToInt32(ComUtil.GetDataItem(objData, "essenceCount")))
                    sRtn = "<b>" + ComUtil.GetDataItem(objData, "collectedCount") + " / " + ComUtil.GetDataItem(objData, "essenceCount") + "</b>";
                else
                    sRtn = ComUtil.GetDataItem(objData, "collectedCount") + " / " + ComUtil.GetDataItem(objData, "essenceCount");

                break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}