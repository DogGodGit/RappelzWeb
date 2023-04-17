using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Setting_WhiteIp : System.Web.UI.Page
{
	private long val1 = 16777216;
	private long val2 = 65536;
	private long val3 = 256;

    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================

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
		WBtnAddIp.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");
		WLtlIp.Text = Request.UserHostAddress;

		//DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dtIp = DacUser.WhiteIps(conn, null);

		//DB연결끊기
		DBUtil.CloseDBConn(conn);

		WRptList.DataSource = dtIp;
		WRptList.DataBind();
	}

	protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		Button WBtnDel = (Button)e.Item.FindControl("WBtnDel");
		WBtnDel.Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");
	}

	protected void WRptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
	{
		long lnStartIpNo = 0;
		long lnEndIpNo = 0;

		string[] sStartip = ((Literal)e.Item.FindControl("WLtlRptStartIp")).Text.Split('.');
		string[] sEndip = ((Literal)e.Item.FindControl("WLtlRptEndIp")).Text.Split('.');
		string[] sArrArgs = e.CommandArgument.ToString().Split('|');

		lnStartIpNo = Convert.ToInt64(sArrArgs[0]);
		lnEndIpNo = Convert.ToInt64(sArrArgs[1]);

		int nRet = 0;

		//DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

		switch (e.CommandName)
		{
			case "delete":
				nRet = DacUser.DeleteWhiteIp(conn, null, lnStartIpNo, lnEndIpNo);
				break;
		}

		//DB연결끊기
		DBUtil.CloseDBConn(conn);

		if (nRet != 0)
		{
			ComUtil.MsgBox("실패", "history.back();");
			return;
		}
		else ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");

	}

	protected void WBtnAddIp_OnClick(object sender, EventArgs e)
	{
		long InStartIpNo = 0;
		long InEndIpNo = 0;

		string[] sArrStartip = WtxtStartIp.Text.Split('.');
		string[] sArrEndip = WtxtEndIp.Text.Split('.');
		string sName = WtxtName.Text.Trim();
		string sStartIp = WtxtStartIp.Text.Trim();
		string sEndIp = WtxtEndIp.Text.Trim();

		//값 체크
		if (WtxtStartIp.Text.Trim() == "" || WtxtEndIp.Text.Trim() == "" || WtxtName.Text.Trim() == "")
		{
			ComUtil.MsgBox("입력값을 확인하세요.", "historyback();");
			return;
		}

		//IP 자릿수 체크
		if (sArrStartip.Length != 4 || sArrEndip.Length != 4)
		{
			ComUtil.MsgBox("입력값을 확인하세요.", "historyback();");
			return;
		}

		InStartIpNo = (Convert.ToInt64(sArrStartip[0]) * val1) + (Convert.ToInt64(sArrStartip[1]) * val2) + (Convert.ToInt64(sArrStartip[2]) * val3) + Convert.ToInt64(sArrStartip[3]);
		InEndIpNo = (Convert.ToInt64(sArrEndip[0]) * val1) + (Convert.ToInt64(sArrEndip[1]) * val2) + (Convert.ToInt64(sArrEndip[2]) * val3) + Convert.ToInt64(sArrEndip[3]);

		if (InStartIpNo > InEndIpNo)
		{
			ComUtil.MsgBox("입력값을 확인하세요.", "historyback();");
			return;
		}

		//DB 연결
		SqlConnection conn = DBUtil.GetUserDBConn();

		//IP 등록
		int nRetVal = DacUser.AddWhiteIp(conn, null, InStartIpNo, InEndIpNo, sStartIp, sEndIp, sName);

		//DB 연결끊기
		DBUtil.CloseDBConn(conn);

		if (nRetVal != 0)
		{
			ComUtil.MsgBox("실패", "history.back();");
			return;
		}
		else ComUtil.MsgBox("성공", "location.href='" + Request.Url.ToString() + "';");
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