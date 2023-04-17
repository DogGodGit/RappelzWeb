using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Setting_CouponSystem : System.Web.UI.Page
{
	private string m_sName = "";
	private string m_sStartTime = "";
	private string m_sEndTime = "";
	private string m_sCouponId = "";

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
		m_sName = ComUtil.GetRequestString("NM", RequestMethod.Get, "");
		m_sStartTime = ComUtil.GetRequestString("ST", RequestMethod.Get, "");
		m_sEndTime = ComUtil.GetRequestString("ET", RequestMethod.Get, "");
		m_sCouponId = ComUtil.GetRequestString("CID", RequestMethod.Get, "");
		
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
		WBtnSearch.Text = Resources.ResLang.CouponSystem_aspx_txt_06;
		WTxtName.Text = m_sName.Trim();

		WTxtCouponId.Text = m_sCouponId.Trim();

		DateTime startTime = DateTime.Now.AddYears(-10);
		DateTime endTime = DateTime.Now.AddYears(10);

		WTxtStartTime.Text = DateTimeUtil.ToDateTimeOffsetSearchString(startTime);
		WTxtEndTime.Text = DateTimeUtil.ToDateTimeOffsetSearchString(endTime);

		if(!string.IsNullOrEmpty(m_sStartTime.Trim()))
			startTime = DateTime.Parse(m_sStartTime.Trim());

		if(!string.IsNullOrEmpty(m_sEndTime.Trim()))
			endTime = DateTime.Parse(m_sEndTime.Trim());

        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.Promotions(conn, null, m_sName, m_sCouponId, startTime, endTime, m_nRowsPerPage, m_nPage, out nTotCnt);

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
		WPageNavigator.UrlParam = string.Format("NM={0}&ST={1}&ET={2}&CID={3}", m_sName, m_sStartTime, m_sEndTime, m_sCouponId);
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

	protected void WBtnSearch_OnClick(object sender, EventArgs e)
	{
		Response.Redirect(string.Format("/Setting/CouponSystem.aspx?NM={0}&ST={1}&ET={2}&CID={3}", WTxtName.Text.Trim(), WTxtStartTime.Text.Trim(), WTxtEndTime.Text.Trim(), WTxtCouponId.Text.Trim()));
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "_name":
				sRtn = "<a href=\"/Setting/CouponForm.aspx?" + string.Format("NM={0}&ST={1}&ET={2}&CID={3}&PG={4}&PID={5}", m_sName, m_sStartTime, m_sEndTime, m_sCouponId, m_nPage, ComUtil.GetDataItem(objData, "promotionId")) + "\" >" + ComUtil.GetDataItem(objData, sFieldNm) + "</a>";
				break;
			case "startTime":
			case "endTime":
				sRtn = DateTimeUtil.ToDateTimeString(DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm)));
				break;
			case "type":
                if (ComUtil.GetDataItem(objData, sFieldNm) == "1")
                    sRtn = Resources.ResLang.CouponSystem_cs_01;
                else
                    sRtn = "영웅"; // Resources.ResLang.ACCHLIST_aspx_th_04;
				break;
			case "enabled":
				if (Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
					sRtn = Resources.ResLang.CouponAdd_aspx_txt_08;
				else
					sRtn = Resources.ResLang.CouponSystem_cs_02;
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
		return sRtn;
	}
}