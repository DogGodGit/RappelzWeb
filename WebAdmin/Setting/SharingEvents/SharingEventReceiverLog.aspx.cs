using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Setting_SharingEvents_SharingEventReceiverLog : System.Web.UI.Page
{
    protected string m_sPopupUrl = "";

    private int m_nGameServerId = 0;
    private string m_sName = "";
    private int m_nType = 1;

    private int m_nRowsPerPage = 10;        // 페이지 목록 수
	private int n_nPageSize = 10;           // 페이징 수
	private int m_nTotalCount = 1;          // 전체수
	private int m_nTotalPage = 1;           // 전체페이지
	protected int m_nPage = 0;              // 페이지

	private int nTotCnt = 0;        // 전체페이지
	private int nTotPage = 1;       // 전체페이지

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
        m_nGameServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
        m_sName = ComUtil.GetRequestString("NM", RequestMethod.Get, ""); //검색어 
        m_nType = ComUtil.GetRequestInt("TP", RequestMethod.Get, 1);

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
		// 유저DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

        // 서버목록 조회
        DataTable drcs = DacUser.GameServerAll(conn, null);

        ////엑셀다운로드 페이지
        m_sPopupUrl = String.Format("/Setting/Popup/Popup_SharingEventReceiverLog.aspx", "");

        //검색 
        WBtnSearch.Text = "검색";
        WDDLServer.Items.Add(new ListItem("== " + "서버선택" + " ==", "0"));

        DataRowCollection drc = drcs.Rows;
        for (int i = 0; i < drc.Count; i++)
            WDDLServer.Items.Add(new ListItem(drc[i]["displayName"].ToString(), drc[i]["serverId"].ToString()));

        WDDLType.Items.Add(new ListItem("계정영웅ID", "1"));
        WDDLType.Items.Add(new ListItem("추천코드", "2"));

        WBtnSearch.Visible = true;


        WDDLServer.SelectedValue = m_nGameServerId.ToString();
        WTxtSearch.Text = m_sName;
        WDDLType.SelectedValue = m_nType.ToString();


        // 공유하기 - 수신자 로그
        DataTable senderLog = DacUser.SharingEventReceiverLogs(conn, null, m_nGameServerId, m_sName, m_nType, m_nRowsPerPage, m_nPage, out m_nTotalCount);

        // DB연결해제
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = senderLog;
        WRptList.DataBind();

        m_nTotalPage = (m_nTotalCount - 1) / m_nRowsPerPage + 1;

        if (m_nTotalCount > 0 && m_nTotalPage < m_nPage)
            m_nPage = m_nTotalPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = m_nTotalPage;
        WPageNavigator.CurrentPage = m_nPage;
        WPageNavigator.UrlParam = String.Format("SVR={0}&NM={1}&TP={2}", m_nGameServerId, m_sName, m_nType);
        WPageNavigator.PageListSize = n_nPageSize;
        WPageNavigator.FirstPageItem = Resources.ResLang.COMMON_page_txt_01;
        WPageNavigator.PrevPageItem = Resources.ResLang.COMMON_page_txt_02;
        WPageNavigator.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigator.NextPageItem = Resources.ResLang.COMMON_page_txt_03;
        WPageNavigator.LastPageItem = Resources.ResLang.COMMON_page_txt_04;
        WPageNavigator.SNumberDecoLeft = "<span>";
        WPageNavigator.SNumberDecoRight = "</span>";
        WPageNavigator.Dispose();


    }

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
            case "rewarded":
                if (Convert.ToBoolean(ComUtil.GetDataItem(objData, "rewarded")))
					sRtn = "성공";
				else
					sRtn = "<span class='red'>실패</span>";
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}

		return sRtn;
	}
    protected void WBtnSearch_OnClick(object sender, EventArgs e)
    {

        //if (WDDLServer.SelectedValue == "0")
        //{
        //    ComUtil.MsgBox(Resources.ResLang.ACCHBLOCK_cs_mbox_01, "history.back();"); //서버를 선택해 주세요
        //    return;
        //}

        Response.Redirect("/Setting/SharingEvents/SharingEventReceiverLog.aspx?SVR=" + WDDLServer.SelectedValue + "&NM=" + WTxtSearch.Text.Trim() + "&TP=" + WDDLType.SelectedValue);

    }

}