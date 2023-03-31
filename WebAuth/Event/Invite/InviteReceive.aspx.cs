using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data.SqlClient;
using System.Data;

public partial class Event_Invite_InviteReceive : System.Web.UI.Page
{
	public const int kResult_OK = 0;
	public const int kResult_Error = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
		SqlConnection conn = null;
		SqlConnection connGame = null;

		SqlTransaction trans = null;

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
			if (Request.QueryString["inviteCode"] == null)
			{
				Result(kResult_Error, "'inviteCode' value is required.");
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

			Guid inviteCode = Guid.Empty;
			string sInviteCode = Request.QueryString["inviteCode"].ToString();
			
			if (!Guid.TryParse(sInviteCode, out inviteCode))
			{
				Result(kResult_Error, "'inviteCode' value is required.");
				return;
			}

			//===============================================================================================
			// 连接到一个数据库
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

			//
			// 발신자 정보 조회
			//

			DataRow drEventSender = Dac.SharingEventSender(conn, trans, inviteCode);

			if (drEventSender == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Invitation code does not exist.");
				return;
			}

			int nSenderVirtualGameServerId = Convert.ToInt32(drEventSender["virtualGameServerId"]);
			Guid nSenderHeroId = Guid.Parse(drEventSender["heroId"].ToString());

			// 동일 서버의 동일한 영웅인 경우
			if (nSenderVirtualGameServerId == nVirtualGameServerId && nSenderHeroId == heroId)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Same user.");
				return;
			}

			//
			// 서버정보 조회
			//

			DataRow drGameServerInfo = Dac.GameServer_VirtualGameServerId(conn, trans, nVirtualGameServerId);

			if (drGameServerInfo == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Game server(Receiver) information does not exist.");
				return;
			}

			// 발신자 유저ID
			Guid senderUserId = Guid.Empty;

			//
			// 수신자 정보 조회(이미 등록되었는지 체크)
			//

			//===============================================================================================
			// 게임 连接到一个数据库
			//===============================================================================================
			string sConnectionString = drGameServerInfo["gameDBConnection"].ToString();

			connGame = DBUtil.GetGameDBConn(sConnectionString);
			connGame.Open();

			//===============================================================================================
			// 영웅 정보 조회(유저ID포함)
			//===============================================================================================
			DataRow drAccount = DacGame.Account_HeroId(connGame, null, heroId);

			if (drAccount == null)
			{
				DBUtil.Close(ref connGame);
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Hero(Receiver) information does not exist.");
				return;
			}

			// 발신자가 동일한 게임서버인 경우 함께 조회
			if (nVirtualGameServerId == nSenderVirtualGameServerId)
			{
				//===========================================================================================
				// 발신자 영웅 정보 조회(유저ID포함)
				//===========================================================================================
				DataRow drSenderAccount = DacGame.Account_HeroId(connGame, null, nSenderHeroId);

				if (drSenderAccount == null)
				{
					DBUtil.Close(ref connGame);
					DBUtil.Close(ref conn);
					Result(kResult_Error, "Hero(Sender) information does not exist.");
					return;
				}

				senderUserId = Guid.Parse(drSenderAccount["userId"].ToString());
			}

			//===============================================================================================
			// 게임 连接到一个数据库 해제
			//===============================================================================================
			DBUtil.Close(ref connGame);

			// 수신자 유저ID
			Guid userId = Guid.Parse(drAccount["userId"].ToString());

			// 발신자가 다른 게임서버인 경우 추가로 조회
			if (nVirtualGameServerId != nSenderVirtualGameServerId)
			{
				// 발신자 서버정보 조회
				drGameServerInfo = Dac.GameServer_VirtualGameServerId(conn, trans, nSenderVirtualGameServerId);

				if (drGameServerInfo == null)
				{
					DBUtil.Close(ref conn);
					Result(kResult_Error, "Game server(Sender) information does not exist.");
					return;
				}

				//===========================================================================================
				// 게임 连接到一个数据库
				//===========================================================================================
				sConnectionString = drGameServerInfo["gameDBConnection"].ToString();

				connGame = DBUtil.GetGameDBConn(sConnectionString);
				connGame.Open();

				DataRow drSenderAccount = DacGame.Account_HeroId(connGame, null, heroId);

				//===========================================================================================
				// 게임 连接到一个数据库 해제
				//===========================================================================================
				DBUtil.Close(ref connGame);

				if (drSenderAccount == null)
				{
					DBUtil.Close(ref conn);
					Result(kResult_Error, "Hero(Sender) information does not exist.");
					return;
				}

				senderUserId = Guid.Parse(drSenderAccount["userId"].ToString());
			}

			//
			// 동일 유저 체크
			//

			if (userId == senderUserId)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Same user.");
				return;
			}

			//
			// 수신자 정보가 존재하는지 체크
			//

			DataRow drReceiver = Dac.SharingEventReceiver(conn, trans, nEventId, userId);

			if (drReceiver != null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_OK, "Information already exists.");
				return;
			}

			//
			// 수신자 정보 등록
			//

			//===============================================================================================
			// 트랜젝션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			if (Dac.AddSharingEventReceiver(conn, trans, nEventId, userId, inviteCode, nVirtualGameServerId, heroId) != 0)
			{
				DBUtil.Rollback(ref trans);
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Registration failed.");
				return;
			}

			//===============================================================================================
			// 트랜젝션 종료
			//===============================================================================================
			DBUtil.Commit(ref trans);

			//===============================================================================================
			// 连接到一个数据库 해제
			//===============================================================================================
			DBUtil.Close(ref conn);

			//
			// 성공리턴
			//

			Result(kResult_OK, "");
		}
		catch (Exception ex)
		{
			DBUtil.Rollback(ref trans);
			DBUtil.Close(ref connGame);
			DBUtil.Close(ref conn);

			Result(kResult_Error, ex.Message);
		}
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