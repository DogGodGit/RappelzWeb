using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Data.SqlClient;
using System.Data;

public partial class Event_Invite_Invite : System.Web.UI.Page
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
				Result(kResult_Error, "'eventId' value is required.", "");
				return;
			}
			if (Request.QueryString["virtualGameServerId"] == null)
			{
				Result(kResult_Error, "'virtualGameServerId' value is required.", "");
				return;
			}
			if (Request.QueryString["heroId"] == null)
			{
				Result(kResult_Error, "'heroId' value is required.", "");
				return;
			}

			
			int nEventId = Convert.ToInt32(Request.QueryString["eventId"]);
			int nVirtualGameServerId = Convert.ToInt32(Request.QueryString["virtualGameServerId"]);

			Guid heroId = Guid.Empty;
			string sHeroId = Request.QueryString["heroId"].ToString();

			if (!Guid.TryParse(sHeroId, out heroId))
			{
				Result(kResult_Error, "'heroId' value is required.", "");
				return;
			}

			//===============================================================================================
			// 连接到一个数据库
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//
			// 이벤트정보 조회(기간)
			//

			DataRow drEventInfo = Dac.SharingEvent(conn, trans, nEventId);

			if (drEventInfo == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Event information does not exist.", "");
				return;
			}

			//
			// 서버정보 조회
			//

			DataRow drGameServerInfo = Dac.GameServer_VirtualGameServerId(conn, trans, nVirtualGameServerId);

			if (drGameServerInfo == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Game server information does not exist.", "");
				return;
			}

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

			//===============================================================================================
			// 게임 连接到一个数据库 해제
			//===============================================================================================
			DBUtil.Close(ref connGame);

			if (drAccount == null)
			{
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Hero information does not exist.", "");
				return;
			}

			// 초대코드 생성
			Guid inviteCode = Guid.NewGuid();

			//===============================================================================================
			// 트랜젝션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			//===============================================================================================
			// 로그 등록
			//===============================================================================================
			if (Dac.AddSharingEventSender(conn, trans, inviteCode, nEventId, nVirtualGameServerId, heroId) != 0)
			{
				DBUtil.Rollback(ref trans);
				DBUtil.Close(ref conn);
				Result(kResult_Error, "Registration failed.", "");
				return;
			}

			//===============================================================================================
			// 트랜젝션 종료
			//===============================================================================================
			DBUtil.Commit(ref trans);

			//===============================================================================================
			// 게임 连接到一个数据库 해제
			//===============================================================================================
			DBUtil.Close(ref conn);

			//
			// 성공리턴
			//

			Result(kResult_OK, "", inviteCode.ToString());
		}
		catch (Exception ex)
		{
			DBUtil.Rollback(ref trans);
			DBUtil.Close(ref connGame);
			DBUtil.Close(ref conn);

			Result(kResult_Error, ex.Message, "");
		}
    }

	private void Result(int nResult, string sMessage, string sInviteCode)
	{
		try
		{
			JsonData joRes = LitJsonUtil.CreateObject();

			joRes["result"] = nResult;
			joRes["errMsg"] = sMessage;
			joRes["inviteCode"] = sInviteCode;

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