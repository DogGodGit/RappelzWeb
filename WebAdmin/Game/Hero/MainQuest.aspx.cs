using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_Hero_MainQuest : System.Web.UI.Page
{
    private int m_nRowsPerPage = 10;        // 페이지 목록 수
    private int n_nPageSize = 10;           // 페이징 수
    private int m_nTotalCount = 1;          // 전체수
    private int m_nTotalPage = 1;           // 전체페이지
    protected int m_nPage = 0;              // 페이지

    protected int m_nServerId;
    protected Guid m_heroId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //======================================================================
        ComUtil.SetNoBrowserCache();

        //======================================================================
        // 파라미터
        //======================================================================
        m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_heroId = Guid.Parse(ComUtil.GetRequestString("HID", RequestMethod.Get, Guid.Empty.ToString()));
        m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);

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
        if (m_nServerId == 0)
        {
            ComUtil.MsgBox("잘못된접근", "history.back();");
            return;
        }

        // 버튼 속성 추가
        WBtnUpdateAccountHeroMainQuest.Attributes.Add("onclick", "return confirm('업데이트하시겠습니까?');");

        // 연결정보 가져오기 (DB커넥션 포함됨)
        SqlConnection connGame = DBUtil.GetGameDBConn(m_nServerId);

        // 메인퀘스트 조회
        DataTable dtMainQuests = Dac.HeroMainQuests(connGame, null, m_heroId, m_nRowsPerPage, m_nPage, out m_nTotalCount);

        // DB연결 해제
        DBUtil.CloseDBConn(connGame);

        WRptList.DataSource = dtMainQuests;
        WRptList.DataBind();
        WRptList.Dispose();

        m_nTotalPage = (m_nTotalCount - 1) / m_nRowsPerPage + 1;

        if (m_nTotalCount > 0 && m_nTotalPage < m_nPage)
            m_nPage = m_nTotalPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = m_nTotalPage;
        WPageNavigator.CurrentPage = m_nPage;
        WPageNavigator.UrlParam = String.Format("SVR={0}&HID={1}", m_nServerId, m_heroId);
        WPageNavigator.PageListSize = n_nPageSize;
        WPageNavigator.FirstPageItem = "처음";
        WPageNavigator.PrevPageItem = "이전";
        WPageNavigator.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigator.NextPageItem = "다음";
        WPageNavigator.LastPageItem = "끝";
        WPageNavigator.SNumberDecoLeft = "<span>";
        WPageNavigator.SNumberDecoRight = "</span>";
        WPageNavigator.Dispose();
    }

    protected void WBtnUpdateHeroMainQuest_OnClick(object sender, EventArgs e)
    {
        SqlConnection connGame = null;

        try
        {
            int nToMainQuestNo = Convert.ToInt32(WTxtMainQuestId.Text.Trim());

            // 연결정보 가져오기 (DB커넥션 포함됨)
            connGame = DBUtil.GetGameDBConn(m_nServerId);

            // 접속여부 확인
            if (Dac.Hero_Connection(connGame, null, m_heroId) != 0)
            {
                DBUtil.CloseDBConn(connGame);
                ComUtil.MsgBox("영웅이 접속중입니다.", "history.back();");
                return;
            }

            // 메인퀘스트 
            int nRet = Biz.UpdateHeroMainQuest(connGame, m_heroId, nToMainQuestNo);

            if (nRet != 0)
            {
                DBUtil.CloseDBConn(connGame);
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "history.back();", "예외발생", "실패하였습니다."));
                return;
            }

            // DB연결 해제
            DBUtil.CloseDBConn(connGame);

            ComUtil.MsgBox("성공하였습니다.", "location.href='" + Request.Url.ToString() + "';");
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
            case "completionTime":
                    sRtn = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(ComUtil.GetDataItem(objData, "completionTime")));
                    break;
            case "completed":
                    if (Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
                        sRtn = "완료";
                    else
                        sRtn = "진행중";
                    break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }

        return sRtn;
    }
}