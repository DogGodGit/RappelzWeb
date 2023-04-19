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

			joRes["gameDatas"] = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(kFileName_MetaDataPath) + "/" + string.Format(kFileName_GameData, sMetaDataVersion));
			var sBase64String = Util.UnZipFromBase64(joRes["gameDatas"].ToString());
            var m_gameData = new WPDGameDatas();
            m_gameData.DeserializeFromBase64String(sBase64String);
			if (m_gameData.blessings != null)
			{
				foreach (var blessing in m_gameData.blessings)
				{
					LogUtil.Log("m_nBlessingId =" + blessing.blessingId);
					LogUtil.Log("m_strName = " + blessing.nameKey);
					LogUtil.Log("m_strDescription " + blessing.descriptionKey);
					LogUtil.Log("m_nMoneyType = " + blessing.moneyType);
					LogUtil.Log("m_nMoneyAmount = " + blessing.moneyAmount);
					LogUtil.Log("m_csItemRewardSender" + blessing.senderItemRewardId);
					LogUtil.Log("m_csGoldRewardReceiver" + blessing.receiverGoldRewardId);
                }
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