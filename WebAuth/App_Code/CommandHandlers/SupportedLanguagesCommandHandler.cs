using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// SupportedLanguagesCommandHandler'的摘要描述.
/// </summary>
public class SupportedLanguagesCommandHandler : CommandHandler
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
			// 조회
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

			DataRowCollection drcSupportedLanguages = Dac.SupportedLanguages(conn, null);

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

			if (drSystemSetting == null)
				throw new CommandHandlerException(this, kResult_Error, "시스템 설정 정보가 없습니다.");

			joRes["defaultLanguageId"] = Convert.ToInt32(drSystemSetting["defaultLanguageId"]);

			JsonData joSupportedLanguages = LitJsonUtil.CreateArray();
			joRes["supportedLanguages"] = joSupportedLanguages;

			foreach (DataRow dr in drcSupportedLanguages)
			{
				JsonData jo = LitJsonUtil.CreateObject();
				jo["languageId"] = Convert.ToInt32(dr["languageId"].ToString());
                jo["maintenanceInfoUrl"] = dr["maintenanceInfoUrl"].ToString();
                joSupportedLanguages.Add(jo);
			}

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}