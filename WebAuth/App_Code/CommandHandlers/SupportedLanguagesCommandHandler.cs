using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// SupportedLanguagesCommandHandler의 요약 설명입니다.
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
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 조회
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

			DataRowCollection drcSupportedLanguages = Dac.SupportedLanguages(conn, null);

			//===============================================================================================
			// 데이터베이스 연결 닫기
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 응답 Json
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