using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// CreateFacebookUserCommandHandler의 요약 설명입니다.
/// </summary>
public class CreateFacebookUserCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private string m_sFacebookAppId = null;
	private string m_sFacebookUserId = null;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		//
		// 페이스북 앱ID
		//

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "facebookAppId", out m_sFacebookAppId))
			throw new CommandHandlerException(this, kResult_Error, "'facebookAppId' 프로퍼티가 유효하지 않습니다.");

		if (string.IsNullOrEmpty(m_sFacebookAppId))
			throw new CommandHandlerException(this, kResult_Error, "'facebookAppId' 프로퍼티가 유효하지 않습니다.");

		//
		// 페이스북 사용자ID
		//

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "facebookUserId", out m_sFacebookUserId))
			throw new CommandHandlerException(this, kResult_Error, "'facebookUserId' 프로퍼티가 유효하지 않습니다.");

		if (string.IsNullOrEmpty(m_sFacebookUserId))
			throw new CommandHandlerException(this, kResult_Error, "'facebookUserId' 프로퍼티가 유효하지 않습니다.");
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;
		SqlTransaction trans = null;

		try
		{
			//===============================================================================================
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// Black IP 조회
			//===============================================================================================
			DataRowCollection drcBlackIps = Dac.BlackIps(conn, null, Util.GetIpNum(ComUtil.GetIpAddress()));

			if (drcBlackIps != null && drcBlackIps.Count > 0)
				throw new CommandHandlerException(this, kResult_Error, "Blocked IP address.");

			//===============================================================================================
			// 트랜잭션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			//===============================================================================================
			// 페이스북사용자 정보 조회
			//===============================================================================================
			DataRow drFacebookUser = Dac.FacebookUser(conn, trans, m_sFacebookAppId, m_sFacebookUserId);

			Guid userId = Guid.NewGuid();
			string sUserSecret = null;

			if (drFacebookUser == null)
			{
				//===============================================================================================
				// 페이스북사용자 등록
				//===============================================================================================
				sUserSecret = Util.CreateUserSecret();

				if (Dac.AddUser(conn, trans, userId, UserType.kType_Facebook, sUserSecret) != 0)
					throw new Exception("사용자 등록 실패.");

				if (Dac.AddFacebookUser(conn, trans, userId, m_sFacebookAppId, m_sFacebookUserId) != 0)
					throw new CommandHandlerException(this, kResult_Error, "페이스북사용자 등록 실패.");
			}
			else
			{
				if (!Guid.TryParse(drFacebookUser["userId"].ToString(), out userId))
					throw new CommandHandlerException(this, kResult_Error, "'userId' 가 유효하지 않습니다.");

				//===============================================================================================
				// 사용자 정보 조회
				//===============================================================================================
				DataRow drUser = Dac.User(conn, trans, userId);

				if (drUser == null)
					throw new CommandHandlerException(this, kResult_Error, "사용자 정보 조회 실패.");

				sUserSecret = Convert.ToString(drUser["secret"]);
			}

			//===============================================================================================
			// 트랜잭션 커밋
			//===============================================================================================
			DBUtil.Commit(ref trans);

			//===============================================================================================
			// 데이터베이스 연결 닫기
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 응답 Json
			//===============================================================================================
			JsonData joRes = CreateResponse();
			joRes["userId"] = userId.ToString();
			joRes["userSecret"] = sUserSecret;

			return joRes;
		}
		finally
		{
			DBUtil.Rollback(ref trans);
			DBUtil.Close(ref conn);
		}
	}
}