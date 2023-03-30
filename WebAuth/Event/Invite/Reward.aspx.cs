using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data.SqlClient;
using System.Data;

public partial class Event_Invite_Reward : System.Web.UI.Page
{
	public const int kResult_OK = 0;
	public const int kResult_Error = 1;

	private const int N_MAILTYPE_ITEM = 2;

    protected void Page_Load(object sender, EventArgs e)
    {
		SqlConnection conn = null;
		SqlConnection connGame1 = null;
		SqlConnection connGame2 = null;

		SqlTransaction trans = null;
		SqlTransaction transGame1 = null;
		SqlTransaction transGame2 = null;

		try
		{
			//===============================================================================================
			// 파라메터 체크
			//===============================================================================================
			if (Request.QueryString["eventId"] == null)
			{
				Result(kResult_Error, "'eventId' value is required.");
				return;
			}
			if (Request.QueryString["virtualGameServerId"] == null)
			{
				Result(kResult_Error, "'virtualGameServerId' value is required.");
				return;
			}
			if (Request.QueryString["heroId"] == null)
			{
				Result(kResult_Error, "'heroId' value is required.");
				return;
			}

			int nEventId = Convert.ToInt32(Request.QueryString["eventId"]);
			int nVirtualGameServerId = Convert.ToInt32(Request.QueryString["virtualGameServerId"]);

			Guid heroId = Guid.Empty;
			string sHeroId = Request.QueryString["heroId"].ToString();

			if (!Guid.TryParse(sHeroId, out heroId))
			{
				Result(kResult_Error, "'heroId' value is required.");
				return;
			}

			//===============================================================================================
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//
			// 이벤트 정보 조회
			//

			DataRow drEventInfo = Dac.SharingEvent(conn, trans, nEventId);

			if (drEventInfo == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Event information does not exist.");
				return;
			}

			int nRewardRange = Convert.ToInt32(drEventInfo["rewardRange"]);
			int nRewardLimitCount = Convert.ToInt32(drEventInfo["senderRewardLimitCount"]);
			int nTargetLevel = Convert.ToInt32(drEventInfo["targetLevel"]);
			int nRewardMailTitleType = Convert.ToInt32(drEventInfo["rewardMailTitleType"]);
			string sRewardMailTitle = Convert.ToString(drEventInfo["rewardMailTitle"]);
			int nRewardMailContentType = Convert.ToInt32(drEventInfo["rewardMailContentType"]);
			string sRewardMailContent = Convert.ToString(drEventInfo["rewardMailContent"]);

			//
			// 수신자 서버정보 조회
			//

			DataRow drGameServerInfoReceiver = Dac.GameServer_VirtualGameServerId(conn, trans, nVirtualGameServerId);

			if (drGameServerInfoReceiver == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Game server(Receiver) information does not exist.");
				return;
			}

			//
			// 수신자 정보 조회(이미 등록되었는지 체크)
			//

			//===============================================================================================
			// 게임 데이터베이스 연결
			//===============================================================================================
			string sConnectionStringReceiver = drGameServerInfoReceiver["gameDBConnection"].ToString();

			connGame1 = DBUtil.GetGameDBConn(sConnectionStringReceiver);
			connGame1.Open();

			DataRow drAccount = DacGame.Account_HeroId(connGame1, null, heroId);

			//===============================================================================================
			// 게임 데이터베이스 연결 해제
			//===============================================================================================
			DBUtil.Close(ref connGame1);

			if (drAccount == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Hero(Receiver) information does not exist.");
				return;
			}

			Guid userId = Guid.Parse(drAccount["userId"].ToString());
			int nHeroLevel = Convert.ToInt32(drAccount["level"]);

			if (nTargetLevel > nHeroLevel)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Hero(Receiver) did not achieve the goal.");
				return;
			}

			//
			// 수신자 정보 조회
			//

			DataRow drReceiver = Dac.SharingEventReceiver(conn, trans, nEventId, userId);

			if (drReceiver == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_OK, "Information(Receiver) does not exists.");
				return;
			}

			if (Convert.ToBoolean(drReceiver["rewarded"]))
			{
				DBUtil.Close(ref conn);
				Result(kResult_OK, "Already received reward.");
				return;
			}

			Guid inviteCode = Guid.Parse(drReceiver["inviteCode"].ToString());

			//
			// 발신자 정보 조회
			//

			DataRow drSender = Dac.SharingEventSender(conn, trans, inviteCode);

			if (drSender == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_OK, "Information(Sender) does not exists.");
				return;
			}

			//
			// 수신자 보상완료 수 조회
			//

			int nSenderVirtualGameServerId = Convert.ToInt32(drSender["virtualGameServerId"]);
			Guid senderHeroId = Guid.Parse(drSender["heroId"].ToString());

			int nSenderRewardedCount = Dac.SharingEventReceiveCompletionCount(conn, trans, nEventId, nSenderVirtualGameServerId, senderHeroId);

			//
			// 발신자 서버정보 조회
			//

			string sConnectionStringSender = "";

			if (nVirtualGameServerId == nSenderVirtualGameServerId)
				sConnectionStringSender = sConnectionStringReceiver;
			else
			{
				DataRow drGameServerInfoSender = Dac.GameServer_VirtualGameServerId(conn, trans, nSenderVirtualGameServerId);

				if (drGameServerInfoSender == null)
				{
					DBUtil.Close(ref conn);
					Result(kResult_Error, "Game server(Sender) information does not exist.");
					return;
				}

				sConnectionStringSender = drGameServerInfoSender["gameDBConnection"].ToString();
			}

			//
			// 발신자보상 조회
			//

			DataRowCollection drcSenderRewards = Dac.SharingEventSenderRewards(conn, trans, nEventId);

			//
			// 수신자보상 조회
			//

			DataRowCollection drcReceiverRewards = Dac.SharingEventReceiverRewards(conn, trans, nEventId);

			DataRow drGameConfig = Dac.GameConfig(conn, null);

			int nDurationDay = 5;

			if (drGameConfig != null)
				nDurationDay = Convert.ToInt32(drGameConfig["mailRetentionDay"]);

			//
			// 발신자 보상 지급
			//

			//=======================================================================================
			// 게임 데이터베이스 연결
			//=======================================================================================
			connGame1 = DBUtil.GetGameDBConn(sConnectionStringSender);
			connGame1.Open();

			transGame1 = connGame1.BeginTransaction();

			if (nRewardRange == 1 || nRewardRange == 2)
			{
				if (nRewardLimitCount > nSenderRewardedCount)
				{
					// 메일발송
					if (!SendMail(connGame1, transGame1, senderHeroId, nRewardMailTitleType, sRewardMailTitle, nRewardMailContentType, sRewardMailContent, nDurationDay, drcSenderRewards))
					{
						DBUtil.Close(ref connGame1);
						DBUtil.Close(ref conn);
						Result(kResult_Error, "Failed to send mail to invitation sender.");
						return;
					}
				}
			}

			//
			// 수신자 보상 지급
			//

			if (nRewardRange == 1 || nRewardRange == 3)
			{
				// 메일발송

				if (nVirtualGameServerId == nSenderVirtualGameServerId)
				{
					if (!SendMail(connGame1, transGame1, heroId, nRewardMailTitleType, sRewardMailTitle, nRewardMailContentType, sRewardMailContent, nDurationDay, drcReceiverRewards))
					{
						DBUtil.Rollback(ref transGame1);
						DBUtil.Close(ref connGame1);
						DBUtil.Close(ref conn);
						Result(kResult_Error, "Failed to send mail to invitation receiver.");
						return;
					}
				}
				else
				{
					//=======================================================================================
					// 게임 데이터베이스 연결
					//=======================================================================================
					connGame2 = DBUtil.GetGameDBConn(sConnectionStringReceiver);
					connGame2.Open();

					transGame2 = connGame2.BeginTransaction();

					if (!SendMail(connGame2, transGame2, heroId, nRewardMailTitleType, sRewardMailTitle, nRewardMailContentType, sRewardMailContent, nDurationDay, drcReceiverRewards))
					{
						DBUtil.Rollback(ref transGame1);
						DBUtil.Rollback(ref transGame2);
						DBUtil.Close(ref connGame1);
						DBUtil.Close(ref connGame2);
						DBUtil.Close(ref conn);
						Result(kResult_Error, "Failed to send mail to invitation receiver.");
						return;
					}
				}
			}

			//===============================================================================================
			// 트랜잭션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			//
			// 보상완료
			//

			if (Dac.UpdateSharingEventReceiver(conn, trans, nEventId, userId, nVirtualGameServerId, heroId) != 0)
			{
				DBUtil.Rollback(ref transGame1);
				DBUtil.Rollback(ref transGame2);
				DBUtil.Rollback(ref trans);
				DBUtil.Close(ref connGame1);
				DBUtil.Close(ref connGame2);
				DBUtil.Close(ref conn);
				Result(kResult_OK, "Reward failed");
				return;
			}

			//===============================================================================================
			// 트랜잭션 종료
			//===============================================================================================
			DBUtil.Commit(ref transGame1);
			DBUtil.Commit(ref transGame2);
			DBUtil.Commit(ref trans);

			//===============================================================================================
			// 데이터베이스 연결 해제
			//===============================================================================================
			DBUtil.Close(ref connGame1);
			DBUtil.Close(ref connGame2);
			DBUtil.Close(ref conn);

			//
			// 성공리턴
			//

			Result(kResult_OK, "");
		}
		catch (Exception ex)
		{
			DBUtil.Rollback(ref trans);
			DBUtil.Rollback(ref transGame1);
			DBUtil.Rollback(ref transGame2);
			DBUtil.Close(ref connGame1);
			DBUtil.Close(ref connGame2);
			DBUtil.Close(ref conn);

			Result(kResult_Error, ex.Message);
		}
	}

	private bool SendMail(SqlConnection connGame, SqlTransaction tranGame, Guid heroId, int nMailTitleType, string sMailTitle, int nMailContentType, string sMailContent, int nDurationDay, DataRowCollection drcRewards)
	{
		Guid mailId = Guid.NewGuid();

		//===============================================================================================
		// 메일 등록
		//===============================================================================================
		if (DacGame.AddMail(connGame, tranGame, mailId, heroId, nMailTitleType, sMailTitle, nMailContentType, sMailContent, nDurationDay) != 0)
			return false;

		//===============================================================================================
		// 메일첨부 등록
		//===============================================================================================
		for (int i = 0; i < drcRewards.Count; i++)
		{
			if (DacGame.AddMailAttachment(connGame, tranGame, mailId, i + 1, Convert.ToInt32(drcRewards[i]["itemId"]), Convert.ToInt32(drcRewards[i]["itemCount"]), Convert.ToBoolean(drcRewards[i]["itemOwned"])) != 0)
				return false;
		}

		return true;
	}

	private void Result(int nResult, string sMessage)
	{
		try
		{
			JsonData joRes = LitJsonUtil.CreateObject();

			joRes["result"] = nResult;
			joRes["errMsg"] = sMessage;

			Util.WriteResponse(joRes);
		}
		catch (Exception ex)
		{
			JsonData joRes = LitJsonUtil.CreateObject();

			joRes["result"] = kResult_Error;
			joRes["errMsg"] = ex.Message;

			Util.WriteResponse(joRes);
		}
	}
}