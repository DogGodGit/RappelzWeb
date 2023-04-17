using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Setting_Languages : System.Web.UI.Page
{
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
		WBtnUpdate.Text = "업데이트";
		WBtnUpdate.Attributes.Add("onclick", "return getCheckedItems();");

		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.Languages(conn, null);

		DBUtil.CloseDBConn(conn);

		WRptList.DataSource = dt;
		WRptList.DataBind();
		dt.Dispose();

	}

	protected void WBtnUpdateLangId_OnClick(object sender, EventArgs e)
	{
		try
		{
			string sLangNos = WHFSelectedLangNo.Value.Trim();

			SqlConnection conn = DBUtil.GetUserDBConn();

			//업데이트하기

			string[] sLanguageNos = sLangNos.Split(',');
			int[] nLanguageNos = Array.ConvertAll<string, int>(sLanguageNos, int.Parse);

			int nRet = BizUser.ResetSupportedLanguage(conn, nLanguageNos);

			DBUtil.CloseDBConn(conn);

			if (nRet != 0)
			{
				ComUtil.MsgBox("수정에 실패하였습니다.", "history.back();");
				return;
			}

			ComUtil.MsgBox("수정되었습니다.", "location.href='" + Request.Url.ToString() + "';");
		}
	
		catch (Exception ex)
		{
			ComUtil.MsgBox(String.Format("오류내용 : {0}", ex.Message), "history.back();");
		}
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "checked":
				if (Convert.ToInt32(ComUtil.GetDataItem(objData, "supportedLanguageId")) > -1)
					sRtn = " checked=\"checked\"";
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
		return sRtn;
	}
}