using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;

/// <summary>
/// GameMetaDataCreateCommandHandler의 요약 설명입니다.
/// </summary>
public class GameMetaDataCreateCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

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
		try
		{
			//===============================================================================================
			// 메타데이터 생성
			//===============================================================================================
			string sGameDataBase64String = MakeGameMetaData.GameMetaData();

			if (sGameDataBase64String == null)
				throw new CommandHandlerException(this, kResult_Error, "메타데이터 생성 실패.");

			//
			// 파일 저장
			//

			//===============================================================================================
			// 응답 Json
			//===============================================================================================
			JsonData joRes = null;

			if (!ZipWithBase64(sGameDataBase64String, m_sVersion))
				joRes = CreateResponse(kResult_Error);
			else
				joRes = CreateResponse();

			return joRes;
		}
		finally
		{
		}
	}

	private bool ZipWithBase64(string inputString, string sVersion)
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

				File.WriteAllText(pathToFiles + "/" + string.Format(kFileName_GameData, sVersion), Convert.ToBase64String(ms.ToArray()));
			}
		}

		return true;
	}
}