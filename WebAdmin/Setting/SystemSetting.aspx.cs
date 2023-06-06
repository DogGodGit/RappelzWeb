using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using LitJson;
using Resources;

public partial class Setting_SystemSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //清除浏览器缓存
        //======================================================================
        ComUtil.SetNoBrowserCache();

        //======================================================================
        // 파라미터
        // 参数
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
        // 버튼 속성 추가
        // 添加按钮属性
        WBtnUpdate.Attributes.Add("onclick", $"return confirm('{ResLang.SystemSetting_aspx_01}');");

		SqlConnection conn = DBUtil.GetUserDBConn();
		DataRow drSetting = DacUser.SystemSetting(conn, null);
		DataTable dtGameServers = DacUser.GameServerAll(conn, null);
		DataTable dtLanguages = DacUser.Languages(conn, null);
		DBUtil.CloseDBConn(conn);

        //기존 시스템세팅 적용
        //应用现有的系统设置
        WTxtAssetBundleUrl.Text = drSetting["assetBundleUrl"].ToString();
		WTxtTermsOfServiceUrl.Text = drSetting["termsOfServiceUrl"].ToString();
		WTxtPrivacyPolicyUrl.Text = drSetting["privacyPolicyUrl"].ToString();
		WTxtClientVersion.Text = drSetting["clientVersion"].ToString();
		WTxtClientTextVersion.Text = drSetting["clientTextVersion"].ToString();
		WHFClientTextVersion.Value = drSetting["clientTextVersion"].ToString();
		WTxtMetaDataVersion.Text = drSetting["metaDataVersion"].ToString();
		WHFMetaDataVersion.Value = drSetting["metaDataVersion"].ToString();
		WCBoxMaintanance.Checked = Convert.ToBoolean(drSetting["isMaintenance"]);
		WTxtMaintenanceInfoUrl.Text = drSetting["maintenanceInfoUrl"].ToString();
		WTxtAuthApiUrl.Text = drSetting["authApiUrl"].ToString();
		WTxtLoggingUrl.Text = drSetting["loggingUrl"].ToString();
        WTxtStatusLoggingUrl.Text = drSetting["statusLoggingUrl"].ToString();
		WCBoxLoggingEnabled.Checked = Convert.ToBoolean(drSetting["loggingEnabled"]);
		WTxtHeroNameRegex.Text = drSetting["heroNameRegex"].ToString();
		WTxtGuildNameRegex.Text = drSetting["guildNameRegex"].ToString();
		WTxtMaxUserConnectionCount.Text = drSetting["maxUserConnectionCount"].ToString();
        WTxtStatusLogInterval.Text = drSetting["statusLoggingInterval"].ToString();

        WTxtGooglePublicKey.Text = drSetting["googlePublicKey"].ToString();
        WCBoxHelpshiftSdkEnabled.Checked = Convert.ToBoolean(drSetting["helpshiftSdkEnabled"]);
        WCBoxHelpshiftWebViewEnabled.Checked = Convert.ToBoolean(drSetting["helpshiftWebViewEnabled"]);
        WTxtHelpshiftUrl.Text = drSetting["helpshiftUrl"].ToString();
        WTxtAppStoreId.Text = drSetting["appStoreId"].ToString();
        WTxtAuthUrl.Text = drSetting["authUrl"].ToString();
        WTxtCsUrl.Text = drSetting["csUrl"].ToString();
        WTxtHomepageUrl.Text = drSetting["homepageUrl"].ToString();
        // 추천 게임서버 
        // 推荐的游戏服务器 
        WDDLRecommendGameServer.Items.Add(new ListItem(ResLang.SystemSetting_aspx_02, "0"));

		for (int i = 0; i < dtGameServers.Rows.Count; i++)
		{
			if(Convert.ToBoolean(dtGameServers.Rows[i]["isPublic"]))
				WDDLRecommendGameServer.Items.Add(new ListItem("Server Id - " + dtGameServers.Rows[i]["serverId"].ToString(), dtGameServers.Rows[i]["serverId"].ToString()));
		}
		WDDLRecommendGameServer.SelectedValue = drSetting["recommendGameServerId"].ToString();

        // 자동추천 조건 타입
        // 自动转介条件类型
        WDDLRecommendType.Items.Add(new ListItem(ResLang.SystemSetting_aspx_03, "1"));

		for (int i = 0; i < dtLanguages.Rows.Count; i++)
		{
			WDDLDefaultLanguage.Items.Add(new ListItem(dtLanguages.Rows[i]["_name"].ToString(), dtLanguages.Rows[i]["languageId"].ToString()));
		}
		WDDLDefaultLanguage.SelectedValue = drSetting["defaultLanguageId"].ToString();

		WCBoxRecommendAuto.Checked = Convert.ToBoolean(drSetting["recommendServerAuto"]);
		WDDLRecommendType.SelectedValue = drSetting["recommendServerConditionType"].ToString();
	}

	protected void WBtnUpdate_OnClick(object sender, EventArgs e)
	{
		try
		{
			string sAssetBundleUrl = WTxtAssetBundleUrl.Text.Trim();
			string sTermsOfServiceUrl = WTxtTermsOfServiceUrl.Text.Trim();
			string sPrivacyPolicyUrl = WTxtPrivacyPolicyUrl.Text.Trim();
			string sClientVersion = WTxtClientVersion.Text.Trim();
			int nClientTextVersion = Convert.ToInt32(WTxtClientTextVersion.Text.Trim());
			int nMetaDataVersion = Convert.ToInt32(WTxtMetaDataVersion.Text.Trim());
			bool isMaintenance = WCBoxMaintanance.Checked;
			string sMaintenanceInfoUrl = WTxtMaintenanceInfoUrl.Text.Trim();
			int nRecommendGameServerId = Convert.ToInt32(WDDLRecommendGameServer.SelectedValue);
			string sAuthApiUrl = WTxtAuthApiUrl.Text.Trim();
			string sLoggingUrl = WTxtLoggingUrl.Text.Trim();
            string sStatusLoggingUrl = WTxtStatusLoggingUrl.Text.Trim();
			bool loggingEnabled = WCBoxLoggingEnabled.Checked;
			string sHeroNameRegex = WTxtHeroNameRegex.Text.Trim();
			string sGuildNameRegex = WTxtGuildNameRegex.Text.Trim();
			int nDefaultLanguageId = Convert.ToInt32(WDDLDefaultLanguage.SelectedValue);
			bool recommendServerAuto = WCBoxRecommendAuto.Checked;
			int nRecommendServerConditionType = Convert.ToInt32(WDDLRecommendType.SelectedValue);
			int nMaxUserConnectionCount = Convert.ToInt32(WTxtMaxUserConnectionCount.Text.Trim());

			int nOldClientTextVersion = Convert.ToInt32(WHFClientTextVersion.Value);
			int nOldMetaDataVersion = Convert.ToInt32(WHFMetaDataVersion.Value);

            int nStatusLoggingInterval = Convert.ToInt32(WTxtStatusLogInterval.Text.Trim());

            string sGooglePublicKey = WTxtGooglePublicKey.Text.Trim();
            bool bHelpshiftSdkEnabled = WCBoxHelpshiftSdkEnabled.Checked;
            bool bHelpshiftWebViewEnabled = WCBoxHelpshiftWebViewEnabled.Checked;
            string sHelpshiftUrl = WTxtHelpshiftUrl.Text.Trim();
            string sAppStoreId = WTxtAppStoreId.Text.Trim();
            string sAuthUrl = WTxtAuthUrl.Text.Trim();
            string sCsUrl = WTxtCsUrl.Text.Trim();
            string sHomepageUrl = WTxtHomepageUrl.Text.Trim();

            //공백체크
            //空间检查
            if (sAssetBundleUrl == "" || sTermsOfServiceUrl == "" || sPrivacyPolicyUrl == "" || sClientVersion == "" || nClientTextVersion.ToString() == "" ||
				nMetaDataVersion.ToString() == "" || nRecommendGameServerId.ToString() == "" || sAuthApiUrl == "" || sHeroNameRegex == "" || sGuildNameRegex == "" ||
				sMaintenanceInfoUrl == "")
			{
				ComUtil.MsgBox(ResLang.SystemSetting_aspx_04);
				return;
			}

			if (loggingEnabled && sLoggingUrl == "")
			{
				ComUtil.MsgBox(ResLang.SystemSetting_aspx_05);
				return;
			}

			string sReqJson = "";
			string sRtn = "";
			int nResult = 0;

            //텍스트 파일생성
            //创建一个文本文件
            if (nClientTextVersion != nOldClientTextVersion)
			{
				sReqJson = CreateRequest_ClientTextMetaDataCreate(nClientTextVersion.ToString());

				sRtn = SendRequest(sAuthApiUrl, sReqJson);

				JsonData joRes = JsonMapper.ToObject(sRtn);

				nResult = 0;

				if (!LitJsonUtil.TryGetIntProperty(joRes, "result", out nResult))
				{
					ComUtil.MsgBox("clientText file creation failed", "history.back();");
					return;
				}
				if (nResult != 0)
				{
					ComUtil.MsgBox("clientText file failed", "history.back();");
					return;
				}
			}

            //메타 파일생성
            //创建一个元文件
            if (nMetaDataVersion != nOldMetaDataVersion)
			{
				sReqJson = CreateRequest_GameMetaDataCreate(nMetaDataVersion.ToString());

				sRtn = SendRequest(sAuthApiUrl, sReqJson);

				JsonData joRes = JsonMapper.ToObject(sRtn);

				nResult = 0;

				if (!LitJsonUtil.TryGetIntProperty(joRes, "result", out nResult))
				{
					ComUtil.MsgBox("gameMetaData file creation failed", "history.back();");
					return;
				}
				if (nResult != 0)
				{
					ComUtil.MsgBox("gameMetaData file failed", "history.back();");
					return;
				}
			}

            //DB연결
            //DB连接
            SqlConnection conn = DBUtil.GetUserDBConn();

			int nRet = DacUser.UpdateSystemSetting(conn, null, sAssetBundleUrl, sTermsOfServiceUrl, sPrivacyPolicyUrl, sClientVersion, nClientTextVersion, nMetaDataVersion, isMaintenance, sMaintenanceInfoUrl,
                nRecommendGameServerId, sAuthApiUrl, sLoggingUrl, sStatusLoggingUrl, loggingEnabled, sHeroNameRegex, sGuildNameRegex, nDefaultLanguageId, recommendServerAuto, nRecommendServerConditionType, nMaxUserConnectionCount, nStatusLoggingInterval,
                sGooglePublicKey, bHelpshiftSdkEnabled, bHelpshiftWebViewEnabled, sHelpshiftUrl, sAppStoreId, sAuthUrl, sCsUrl, sHomepageUrl);

			DBUtil.CloseDBConn(conn);

			switch (nRet)
			{
				case 0: ComUtil.MsgBox(ResLang.SystemSetting_aspx_06, "location.href='" + Request.Url.ToString() + "';");
					break;
				default: ComUtil.MsgBox(ResLang.SystemSetting_aspx_07, "history.back();");
					break;
			}
		}
		catch(Exception ex)
		{
			ComUtil.MsgBox(ResLang.SystemSetting_aspx_08 + "(" + ex.Message + ")");
		}
	}

	private string SendRequest(string sGameServerApiUrl, string sReqJson)
	{
		return Util.GetHtmlResult(sGameServerApiUrl, sReqJson);
	}

	public string CreateRequest_ClientTextMetaDataCreate(string sVersion)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "ClientTextMetaDataCreate";
		joReq["version"] = sVersion;

		return joReq.ToJson();
	}

	public string CreateRequest_GameMetaDataCreate(string sVersion)
	{
		JsonData joReq = LitJsonUtil.CreateObject();
		joReq["cmd"] = "GameMetaDataCreate";
		joReq["version"] = sVersion;

		return joReq.ToJson();
	}
}