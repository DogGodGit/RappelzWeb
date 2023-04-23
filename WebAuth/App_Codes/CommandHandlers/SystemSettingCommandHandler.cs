using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// SystemSettingCommandHandler'的摘要描述.
/// </summary>
public class SystemSettingCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

		try
		{
			//===============================================================================================
			// 连接到一个数据库
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// Black IP 조회
			//===============================================================================================
			DataRowCollection drcBlackIps = Dac.BlackIps(conn, null, Util.GetIpNum(ComUtil.GetIpAddress()));

			if (drcBlackIps != null && drcBlackIps.Count > 0)
				throw new CommandHandlerException(this, kResult_Error, "Blocked IP address.");

			//===============================================================================================
			// 조회
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 响应 Json
			//===============================================================================================
			JsonData joRes = CreateResponse();

			//
			// 결과
			//

			if(drSystemSetting == null)
				throw new CommandHandlerException(this, kResult_Error, "시스템 설정 정보가 없습니다.");

			JsonData joSystemSetting = LitJsonUtil.CreateObject();
			joSystemSetting["assetBundleUrl"] = drSystemSetting["assetBundleUrl"].ToString();
			joSystemSetting["termsOfServiceUrl"] = drSystemSetting["termsOfServiceUrl"].ToString();
			joSystemSetting["privacyPolicyUrl"] = drSystemSetting["privacyPolicyUrl"].ToString();
			joSystemSetting["clientVersion"] = drSystemSetting["clientVersion"].ToString();
			joSystemSetting["clientTextVersion"] = Convert.ToInt32(drSystemSetting["clientTextVersion"]);
			joSystemSetting["metaDataVersion"] = Convert.ToInt32(drSystemSetting["metaDataVersion"]);
			joSystemSetting["isMaintenance"] = Convert.ToBoolean(drSystemSetting["isMaintenance"]);
			joSystemSetting["maintenanceInfoUrl"] = drSystemSetting["maintenanceInfoUrl"].ToString();
			joSystemSetting["recommendGameServerId"] = Convert.ToInt32(drSystemSetting["recommendGameServerId"]);
			joSystemSetting["loggingUrl"] = drSystemSetting["loggingUrl"].ToString();
			joSystemSetting["loggingEnabled"] = Convert.ToBoolean(drSystemSetting["loggingEnabled"]);
			joSystemSetting["statusLoggingUrl"] = drSystemSetting["statusLoggingUrl"].ToString();
			joSystemSetting["statusLoggingInterval"] = Convert.ToInt32(drSystemSetting["statusLoggingInterval"]);
			joSystemSetting["googlePublicKey"] = Convert.ToString(drSystemSetting["googlePublicKey"]);
			joSystemSetting["helpshiftSdkEnabled"] = Convert.ToBoolean(drSystemSetting["helpshiftSdkEnabled"]);
			joSystemSetting["helpshiftWebViewEnabled"] = Convert.ToBoolean(drSystemSetting["helpshiftWebViewEnabled"]);
			joSystemSetting["helpshiftUrl"] = Convert.ToString(drSystemSetting["helpshiftUrl"]);
			joSystemSetting["appStoreId"] = Convert.ToString(drSystemSetting["appStoreId"]);
			joSystemSetting["authUrl"] = drSystemSetting["authUrl"].ToString();
			joSystemSetting["csUrl"] = drSystemSetting["csUrl"].ToString();
			joSystemSetting["homepageUrl"] = drSystemSetting["homepageUrl"].ToString();
			
			joRes["systemSetting"] = joSystemSetting;
			
			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}