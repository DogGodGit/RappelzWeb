using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Tools_ClientTextView : System.Web.UI.Page
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
		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dt = DacUser.Languages(conn, null);

		DBUtil.CloseDBConn(conn);

		for (int i = 0; i < dt.Rows.Count; i++)
		{
			if (Convert.ToInt32(dt.Rows[i]["supportedLanguageId"]) > -1)
				WDDLLanguage.Items.Add(new ListItem(dt.Rows[i]["_name"].ToString(), dt.Rows[i]["supportedLanguageId"].ToString()));
		}

		WDDLLanguage.SelectedValue = "23"; //Korean
	}

	protected void WBtnView_OnClick(object sender, EventArgs e)
	{
		WLtlResult.Text = "";

		int nLanguageId = Convert.ToInt32(WDDLLanguage.SelectedValue);
		string sKey = WTxtKey.Text.Trim();

		if (sKey == "")
			return;

		SqlConnection conn = DBUtil.GetUserDBConn();

		DataRow dr = DacUser.ClientText(conn, null, sKey, nLanguageId);

		DBUtil.CloseDBConn(conn);

		if (dr == null)
			return;

		WLtlResult.Text = dr["value"].ToString();
	}
}