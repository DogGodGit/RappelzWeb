using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Data.SqlClient;
using System.Data;
using WebCommon;
using System.IO;
using System.IO.Compression;

/// <summary>
/// ClientTextMetaDataCreateCommandHandler의 요약 설명입니다.
/// </summary>
public class ClientTextMetaDataCreateCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private string m_sVersion;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "version", out m_sVersion))
			throw new CommandHandlerException(this, kResult_Error, "'version' 프로퍼티가 유효하지 않습니다.");
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

		try
		{
			int nLanguageId = 0;
			WPDClientTexts clientTexts;
			DataRowCollection drcClientTexts;

			//===============================================================================================
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 응답 Json
			//===============================================================================================
			JsonData joRes = null;

			DataRowCollection drcLanguages = Dac.SupportedLanguages(conn, null);
			for (int i = 0; i < drcLanguages.Count; i++)
			{
				nLanguageId = Convert.ToInt32(drcLanguages[i]["languageId"]);

				//===============================================================================================
				// 선택된 언어의 클라이언트 텍스트 목록 조회
				//===============================================================================================
				drcClientTexts = Dac.ClientTexts_LanguageId(conn, null, nLanguageId);

				//
				// 클라이언트 텍스트 목록
				//

				clientTexts = new WPDClientTexts();

				clientTexts.languageId = nLanguageId;

				List<WPDClientText> texts = new List<WPDClientText>();
				foreach (DataRow dr in drcClientTexts)
				{
					WPDClientText text = new WPDClientText();
					text.name = Convert.ToString(dr["name"]);
					text.value = Convert.ToString(dr["value"]);

					texts.Add(text);
				}
				clientTexts.clientTexts = texts.ToArray();
				texts.Clear();

				//
				// 결과
				//

				if (!ZipWithBase64(clientTexts.SerializeBase64String(), nLanguageId))
				{
					//===============================================================================================
					// 데이터베이스 연결 닫기
					//===============================================================================================
					DBUtil.Close(ref conn);

					joRes = CreateResponse(kResult_Error);
					return joRes;
				}
			}

			//===============================================================================================
			// 데이터베이스 연결 닫기
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 응답 Json
			//===============================================================================================
			joRes = CreateResponse();

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}

	private bool ZipWithBase64(string inputString, int nLanguageId)
	{
		using (var stream = new MemoryStream())
		{
			using (var writer = new StreamWriter(stream))
			{
				writer.Write(inputString);
				writer.Flush();
				stream.Position = 0;

				MemoryStream ms = new MemoryStream();

				using (GZipStream sw = new GZipStream(ms, CompressionMode.Compress))
				{
					var buffer = new byte[31457280];	// 30MB
					int numRead;
					while ((numRead = stream.Read(buffer, 0, buffer.Length)) != 0)
					{
						sw.Write(buffer, 0, numRead);
					}
				}

				string pathToFiles = System.Web.HttpContext.Current.Server.MapPath(kFileName_MetaDataPath);

				File.WriteAllText(pathToFiles + "/" + string.Format(kFileName_ClientText, m_sVersion, nLanguageId), Convert.ToBase64String(ms.ToArray()));
			}
		}

		return true;
	}
}