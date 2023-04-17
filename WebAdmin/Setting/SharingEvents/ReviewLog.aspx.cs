using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Setting_SharingEvents_ReviewLog : System.Web.UI.Page
{
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
		// 유저DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

        DataTable dt = DacUser.ReviewLogs(conn, null, m_nRowsPerPage, m_nPage, out nTotCnt);

		// DB연결해제
		DBUtil.CloseDBConn(conn);

		WRptList.DataSource = dt;
		WRptList.DataBind();

		nTotPage = (nTotCnt - 1) / m_nRowsPerPage + 1;

		if (nTotCnt > 0 && nTotPage < m_nPage)
			m_nPage = nTotPage;

		//======================================================================
		// 페이징
		//======================================================================
		WPageNavigator.PageCount = nTotPage;
		WPageNavigator.CurrentPage = m_nPage;
		WPageNavigator.UrlParam = "";
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
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}

		return sRtn;
	}
}