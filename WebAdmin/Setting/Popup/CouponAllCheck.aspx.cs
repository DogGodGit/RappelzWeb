using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
public partial class Setting_Popup_CouponAllCheck : System.Web.UI.Page
{
	private string m_nPromotionId = "";
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
		m_nPromotionId = ComUtil.GetRequestString("PID", RequestMethod.Get, "");

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
        WBtnexl.Text = "엑셀다운로드";// Resources.ResLang.ACCHLOG_aspx_btn_02;

		// 유저DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

        Guid nPromotionId = Guid.Parse(m_nPromotionId);

        DataTable dtCoupon = DacUser.Coupons(conn, null, nPromotionId);
		DataRow drPromotion = DacUser.Promotion(conn, null, nPromotionId);
		// DB연결해제
		DBUtil.CloseDBConn(conn);

		WTxtName.Text = drPromotion["_name"].ToString();
		WTxtName.Enabled = false;
		WtxtCoupon.Enabled = false;
		for(int i = 0; i < dtCoupon.Rows.Count; i++)
		{
			if (i != 0)
			{
				WtxtCoupon.Text += ",";
			}
				WtxtCoupon.Text += dtCoupon.Rows[i]["couponId"].ToString();
		}
		WDtGrid.Columns[0].HeaderText = Resources.ResLang.CouponPopup_cs_txt_09;
		WDtGrid.Columns[1].HeaderText = Resources.ResLang.CouponPopup_cs_txt_10;

		WDtGrid.DataSource = dtCoupon;
		WDtGrid.DataBind();
	}

	public void WBtnexl_Click(object sender, System.EventArgs e)
	{
		string sFilePath = "Coupon CampainName:" + WTxtName.Text + " " + DateTimeUtil.ToDateTimeString(DateTime.Now) + ".xls";
		Response.Clear();
		Response.ContentType = "application/vnd.ms-excel";
		Response.AddHeader("Content-Disposition", "attachment;fileName=" + sFilePath);
		Response.Charset = "utf-8";

		StringWriter sw = new StringWriter();
		HtmlTextWriter hw = new HtmlTextWriter(sw);
		WDtGrid.RenderControl(hw);

		Response.Write("<meta charset=\"utf-8\">");
		Response.Write(sw.GetStringBuilder().ToString());
		Response.End();
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