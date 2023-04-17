using System;
using System.Data.SqlClient;
using System.Data;
using LitJson;

public partial class Setting_ClientTextChanges : System.Web.UI.Page
{
    protected int m_nStandardLanguageId = 0;
	protected int m_nLanguageId = 0;

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
        m_nStandardLanguageId = ComUtil.GetRequestInt("SID", RequestMethod.Get, 0);
        m_nLanguageId = ComUtil.GetRequestInt("LID", RequestMethod.Get, 0);

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
        WBtnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "적용하시겠습니까?"));
        WBtnUpdate.Text = "적용";
		// 유저DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dtLanguage = DacUser.ClientTextLanguageLists(conn, null);
		DataTable dtChanges = DacUser.ClientTextDiff(conn, null, m_nLanguageId);

		// DB연결해제
		DBUtil.CloseDBConn(conn);

		string sLanguageName = "";

		for (int i = 0; i < dtLanguage.Rows.Count; i++)
		{
			if (m_nLanguageId == Convert.ToInt32(dtLanguage.Rows[i]["languageId"]))
				sLanguageName = dtLanguage.Rows[i]["languageName"].ToString();
		}

		WLtlStandardLanguage.Text = sLanguageName;

		WRptList.DataSource = dtChanges;
		WRptList.DataBind();
	}

	protected void WBtnUpdate_OnClick(object sender, EventArgs e)
	{
		SqlConnection conn = null;
		SqlTransaction tran = null;

		try
		{
			// 유저DB연결
			conn = DBUtil.GetUserDBConn();

			DataTable dt = DacUser.SystemSettings(conn, null);

			int nSettingId = 0;
			long lnSettingValue = 0;
			string sAuthApiUrl = "";

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				if (dt.Rows[i]["name"].ToString() == "clientTextVersion")
				{
					nSettingId = Convert.ToInt32(dt.Rows[i]["settingId"]);
					lnSettingValue = Convert.ToInt64(dt.Rows[i]["value"]);
				}
				if (dt.Rows[i]["name"].ToString() == "authApiUrl")
					sAuthApiUrl = dt.Rows[i]["value"].ToString();
			}

			lnSettingValue++;

			tran = conn.BeginTransaction();

			string sMsg = DacUser.ClientTextUpdateLocal(conn, tran, m_nLanguageId);

			if (sMsg != "")
			{
				tran.Rollback();
				tran.Dispose();

				DBUtil.CloseDBConn(conn);
				ComUtil.MsgBox("Error. (" + sMsg + ")", "history.back();");
				return;
			}

			string sNewValue = lnSettingValue.ToString();

			string sReqJson = CreateRequest_ClientTextCreate(sNewValue);

			string sRtn = SendRequest(sAuthApiUrl, sReqJson);

			JsonData joRes = JsonMapper.ToObject(sRtn);

			int nResult = 1;

			if (!LitJsonUtil.TryGetIntProperty(joRes, "result", out nResult))
			{
				tran.Rollback();
				tran.Dispose();

				DBUtil.CloseDBConn(conn);
				ComUtil.MsgBox("Metadata file creation failed", "history.back();");
				return;
			}

			if (DacUser.UpdateSystemSetting(conn, tran, nSettingId, sNewValue) != 0)
			{
				tran.Rollback();
				tran.Dispose();

				DBUtil.CloseDBConn(conn);

				ComUtil.MsgBox("Metadata version update failed", "history.back();");
				return;
			}

			tran.Commit();
			tran.Dispose();

			// DB연결해제
			DBUtil.CloseDBConn(conn);
            
			ComUtil.MsgBox("작업성공", "location.href='/Setting/ClientText.aspx?SID=" + m_nStandardLanguageId + "&LID=" + m_nLanguageId + "';");
		}
		catch (Exception ex)
		{
			if (tran != null)
			{
				tran.Rollback();
				tran.Dispose();
			}
			if (conn != null && conn.State == ConnectionState.Connecting)
				DBUtil.CloseDBConn(conn);

			ComUtil.MsgBox("Error. (" + ex.Message + ")", "history.back();");
		}
	}

	private string SendRequest(string sGameServerApiUrl, string sReqJson)
	{
		return Util.GetHtmlResult(sGameServerApiUrl, sReqJson);
	}

	public string CreateRequest_ClientTextCreate(string sVersion)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "ClientTextCreate";
		joReq["version"] = sVersion;
		return joReq.ToJson();
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