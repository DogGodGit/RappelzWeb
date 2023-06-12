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
using System.Text;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

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

			if (!LitJsonUtil.TryGetStringProperty(m_joReq, "version", out string sMetaDataVersion))
				sMetaDataVersion = drSystemSetting["metaDataVersion"].ToString();

			JsonData joRes = CreateResponse();
			string dir = HttpContext.Current.Server.MapPath(kFileName_MetaDataPath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            string gameDatas = File.ReadAllText(dir + "/" + string.Format(kFileName_GameData, sMetaDataVersion));
			if (LitJsonUtil.TryGetStringProperty(m_joReq, "tojson", out string tojson))
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
						var obj = item.GetValue(m_gameData);
						if (obj is Array)
						{
							json[item.Name] = (obj as Array).Length;
						}
						else if (obj != null)
						{
							json[item.Name] = 1;
						}
						else
						{
							json[item.Name] = 0;
						}
					}
					joRes["name"] = json;
				}
				else
				{
					var p = m_gameData.GetType().GetField(tojson);
					if (p != null)
					{
						var s = p.GetValue(m_gameData);
						var d = DBUtil.ObjectToTable(s);
						joRes[tojson] = JsonMapper.ToObject(DBUtil.DataTableToJson(d));
                    }

                }
			}
            else if (LitJsonUtil.TryGetStringProperty(m_joReq, "tocsv", out string tocsv))
            {
                var sBase64String = Util.UnZipFromBase64(gameDatas);
                var m_gameData = new WPDGameDatas();
                m_gameData.DeserializeFromBase64String(sBase64String);
				string path = dir + "/" + "csv";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (tocsv == "all")
                {
                    var p = m_gameData.GetType().GetFields();
                    var json = new JsonData();

                    foreach (var item in p)
                    {
                        var obj = item.GetValue(m_gameData);
                        var d = DBUtil.ObjectToTable(obj);
						if (d != null)
						{
							var csv = DBUtil.DataTableToCsv(d);
							File.WriteAllText(path + "/" + item.Name + ".csv", csv, Encoding.UTF8);
							json[item.Name] = d.Rows.Count;
                        }
						else
						{
                            json[item.Name] = 0;
                        }
                    }
                    joRes["name"] = json;
                }
                else
                {
                    var p = m_gameData.GetType().GetField(tocsv);
                    if (p != null)
                    {
                        var s = p.GetValue(m_gameData);
                        var d = DBUtil.ObjectToTable(s);
						if (d != null)
						{
							var csv = DBUtil.DataTableToCsv(d);
							File.WriteAllText(path + "/" + tocsv + ".csv", csv, Encoding.UTF8);
                            joRes[tocsv] = d.Rows.Count;
                        }
						else
						{
                            joRes[tocsv] = 0;
                        }
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