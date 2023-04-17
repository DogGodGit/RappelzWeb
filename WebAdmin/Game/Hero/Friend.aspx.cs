using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_Hero_Friend : System.Web.UI.Page
{
    private const int FRIENDTYPE_FRIEND = 1;
    private const int FRIENDTYPE_BLOCK = 2;
    private const int FRIENDTYPE_ENEMY = 3;

    private int m_nRowsPerPage = 10;        // 페이지 목록 수
    private int n_nPageSize = 10;           // 페이징 수

    // 친구
    private int m_nTotalCount = 1;          // 전체수
    private int m_nTotalPage = 1;           // 전체페이지
    protected int m_nPage = 0;              // 페이지

    // 차단친구
    private int m_nBlockTotalCount = 1;          // 전체수
    private int m_nBlockTotalPage = 1;           // 전체페이지
    protected int m_nBlockPage = 0;              // 페이지

    // 적대친구
    private int m_nEnemyTotalCount = 1;          // 전체수
    private int m_nEnemyTotalPage = 1;           // 전체페이지
    protected int m_nEnemyPage = 0;              // 페이지

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
        m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
        m_nBlockPage = ComUtil.GetRequestInt("PGB", RequestMethod.Get, 1);
        m_nEnemyPage = ComUtil.GetRequestInt("PGE", RequestMethod.Get, 1);

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
        Util.BadAccessCheck(m_nServerId, m_heroId);

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 친구 조회
        DataTable dtFriends = Dac.Friends(conn, null, m_heroId, m_nRowsPerPage, m_nPage, out m_nTotalCount);

        // 차단 친구 조회
        DataTable dtFriendBlocks = Dac.Friends(conn, null, m_heroId, m_nRowsPerPage, m_nBlockPage, out m_nBlockTotalCount);

        // 적대 친구 조회
        DataTable dtFriendEnemys = Dac.Friends(conn, null, m_heroId, m_nRowsPerPage, m_nEnemyPage, out m_nEnemyTotalCount);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptFriend.DataSource = dtFriends;
        WRptFriend.DataBind();
        WRptFriend.Dispose();

        WRptFriendBlock.DataSource = dtFriendBlocks;
        WRptFriendBlock.DataBind();
        WRptFriendBlock.Dispose();

        WRptFriendEnemy.DataSource = dtFriendEnemys;
        WRptFriendEnemy.DataBind();
        WRptFriendEnemy.Dispose();

        // 친구
        m_nTotalPage = (m_nTotalCount - 1) / m_nRowsPerPage + 1;

        if (m_nTotalCount > 0 && m_nTotalPage < m_nPage)
            m_nPage = m_nTotalPage;

        // 차단
        m_nBlockTotalPage = (m_nBlockTotalCount - 1) / m_nRowsPerPage + 1;

        if (m_nBlockTotalCount > 0 && m_nBlockTotalPage < m_nBlockPage)
            m_nBlockPage = m_nBlockTotalPage;

        // 적대
        m_nEnemyTotalPage = (m_nEnemyTotalCount - 1) / m_nRowsPerPage + 1;

        if (m_nEnemyTotalCount > 0 && m_nEnemyTotalPage < m_nEnemyPage)
            m_nEnemyPage = m_nEnemyTotalPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigatorFriend.PageCount = m_nTotalPage;
        WPageNavigatorFriend.CurrentPage = m_nPage;
        WPageNavigatorFriend.SQueryName = "PG";
        WPageNavigatorFriend.UrlParam = String.Format("SVR={0}&HID={1}&PGB={2}&PGE={3}", m_nServerId, m_heroId, m_nBlockPage, m_nEnemyPage);
        WPageNavigatorFriend.PageListSize = n_nPageSize;
        WPageNavigatorFriend.FirstPageItem = "처음";
        WPageNavigatorFriend.PrevPageItem = "이전";
        WPageNavigatorFriend.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigatorFriend.NextPageItem = "다음";
        WPageNavigatorFriend.LastPageItem = "끝";
        WPageNavigatorFriend.SNumberDecoLeft = "<span>";
        WPageNavigatorFriend.SNumberDecoRight = "</span>";
        WPageNavigatorFriend.Dispose();

        WPageNavigatorFriendBlock.PageCount = m_nBlockTotalPage;
        WPageNavigatorFriendBlock.CurrentPage = m_nBlockPage;
        WPageNavigatorFriendBlock.SQueryName = "PGB";
        WPageNavigatorFriendBlock.UrlParam = String.Format("SVR={0}&HID={1}&PG={2}&PGE={3}", m_nServerId, m_heroId, m_nPage, m_nEnemyPage);
        WPageNavigatorFriendBlock.PageListSize = n_nPageSize;
        WPageNavigatorFriend.FirstPageItem = "처음";
        WPageNavigatorFriend.PrevPageItem = "이전";
        WPageNavigatorFriend.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigatorFriend.NextPageItem = "다음";
        WPageNavigatorFriend.LastPageItem = "끝";
        WPageNavigatorFriendBlock.SNumberDecoLeft = "<span>";
        WPageNavigatorFriendBlock.SNumberDecoRight = "</span>";
        WPageNavigatorFriendBlock.Dispose();

        WPageNavigatorFriendEnemy.PageCount = m_nEnemyTotalPage;
        WPageNavigatorFriendEnemy.CurrentPage = m_nEnemyPage;
        WPageNavigatorFriendEnemy.SQueryName = "PGE";
        WPageNavigatorFriendEnemy.UrlParam = String.Format("SVR={0}&HID={1}&PG={2}&PGB={3}", m_nServerId, m_heroId, m_nPage, m_nBlockPage);
        WPageNavigatorFriendEnemy.PageListSize = n_nPageSize;
        WPageNavigatorFriend.FirstPageItem = "처음";
        WPageNavigatorFriend.PrevPageItem = "이전";
        WPageNavigatorFriend.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigatorFriend.NextPageItem = "다음";
        WPageNavigatorFriend.LastPageItem = "끝";
        WPageNavigatorFriendEnemy.SNumberDecoLeft = "<span>";
        WPageNavigatorFriendEnemy.SNumberDecoRight = "</span>";
        WPageNavigatorFriendEnemy.Dispose();
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button btnDel = (Button)e.Item.FindControl("WBtnDel");
            btnDel.Attributes.Add("onclick", string.Format("return confirm('{0}')", "삭제하시겠습니까?"));
        }
    }

    protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            string nFriendId = Convert.ToString(e.CommandArgument.ToString());
            Guid friendId = Guid.Parse(nFriendId);
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

            // 친구 삭제
            int nRet = Dac.DelFriend(conn, null, m_heroId, friendId);

            // DB 연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet != 0)
            {
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "삭제에 실패하였습니다.", "오류코드", "history.back();"));
                return;
            }
            ComUtil.MsgBox("삭제되었습니다.", "location.href='" + Request.Url.ToString() + "';");
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