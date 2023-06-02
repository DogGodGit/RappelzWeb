using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LitJson;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using WebCommon;
using System.Configuration;

/// <summary>
/// GameMetaDatasCommandHandler의 요약 설명입니다.
/// </summary>
public class GameMetaDatasCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	public const int kResult_NoMetaDataFile = 102;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();
	}


	protected override JsonData HandleCommand()
	{
		try
		{
			//===============================================================================================
			// 데이터베이스 연결
			//===============================================================================================
			SqlConnection conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 시스템게임설정
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

			//===============================================================================================
			// 데이터베이스 연결 닫기
			//===============================================================================================
			DBUtil.Close(ref conn);

			string sMetaDataVersion = drSystemSetting["metaDataVersion"].ToString();

			JsonData joRes = CreateResponse();

			string gameDatas = File.ReadAllText(HttpContext.Current.Server.MapPath(kFileName_MetaDataPath) + "/" + string.Format(kFileName_GameData, sMetaDataVersion));
            string tojson;
			if (LitJsonUtil.TryGetStringProperty(m_joReq, "tojson", out tojson))
			{
				var sBase64String = Util.UnZipFromBase64(gameDatas);
				var m_gameData = new WPDGameDatas();
				m_gameData.DeserializeFromBase64String(sBase64String);

				if (tojson == "all") 
				{
					var p = m_gameData.GetType().GetFields();
					var json = new JsonData();

                    foreach (var item in p)
					{
						json.Add(item.Name);
					}
					joRes["name"] = json;
                }
				else
				{
					var p = m_gameData.GetType().GetField(tojson);
					if (p != null)
					{
						var s = p.GetValue(m_gameData);
						string json = JsonMapper.ToJson(s);

						joRes[tojson] = JsonMapper.ToObject(json);
					}
				}
			}
			else
			{
				joRes["gameDatas"] = gameDatas;
			}

            return joRes;
		}
		catch (FileNotFoundException ex)
		{
			throw new CommandHandlerException(this, kResult_NoMetaDataFile, "No Metadata file.");
		}
		finally
		{

		}
	}
}