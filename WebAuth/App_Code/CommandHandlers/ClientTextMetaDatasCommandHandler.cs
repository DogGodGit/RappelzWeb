using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Data.SqlClient;
using System.Data;
using System.IO;

/// <summary>
/// ClientTextMetaDatasCommandHandler의 요약 설명입니다.
/// </summary>
public class ClientTextMetaDatasCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private int m_nLanguageId;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		if (!LitJsonUtil.TryGetIntProperty(m_joReq, "languageId", out m_nLanguageId))
			throw new CommandHandlerException(this, kResult_Error, "'languageId' 프로퍼티가 유효하지 않습니다.");
	}

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
			// 시스템게임설정
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

			//===============================================================================================
			// 언어 체크
			//===============================================================================================
			int nSelectedLanguageId = -1;

			// 시스템 기본언어 코드
			nSelectedLanguageId = Convert.ToInt32(drSystemSetting["defaultLanguageId"]);

			DataRowCollection drcLanguages = Dac.SupportedLanguages(conn, null);
			for (int i = 0; i < drcLanguages.Count; i++)
			{
				// 클라이언트의 언어가 사용가능한 언어인 경우
				if (m_nLanguageId == Convert.ToInt32(drcLanguages[i]["languageId"]))
				{
					nSelectedLanguageId = m_nLanguageId;
					break;
				}
			}

			//===============================================================================================
			// 데이터베이스 연결 닫기
			//===============================================================================================
			DBUtil.Close(ref conn);

			string sClientTextVersion = drSystemSetting["clientTextVersion"].ToString();

			JsonData joRes = CreateResponse();

			joRes["clientTexts"] = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(kFileName_MetaDataPath) + "/" + string.Format(kFileName_ClientText, sClientTextVersion, nSelectedLanguageId));

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}