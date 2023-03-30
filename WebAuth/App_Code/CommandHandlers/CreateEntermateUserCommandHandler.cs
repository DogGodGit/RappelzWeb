using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// CreateEntermateUserCommandHandler의 요약 설명입니다.
/// </summary>
public class CreateEntermateUserCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private string m_sEntermateUserId = null;
	private string m_sEntermatePrivateKey = null;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		//
		// 엔터메이트 사용자ID
		//

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "entermateUserId", out m_sEntermateUserId))
			throw new CommandHandlerException(this, kResult_Error, "'entermateUserId' 프로퍼티가 유효하지 않습니다.");

		if (string.IsNullOrEmpty(m_sEntermateUserId))
			throw new CommandHandlerException(this, kResult_Error, "'entermateUserId' 프로퍼티가 유효하지 않습니다.");

		//
		// 엔터메이트 PrivateKey
		//

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "entermatePrivateKey", out m_sEntermatePrivateKey))
			throw new CommandHandlerException(this, kResult_Error, "'entermatePrivateKey' 프로퍼티가 유효하지 않습니다.");

		if (string.IsNullOrEmpty(m_sEntermatePrivateKey))
			throw new CommandHandlerException(this, kResult_Error, "'entermatePrivateKey' 프로퍼티가 유효하지 않습니다.");
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;
		SqlTransaction trans = null;

		try
		{
			//===============================================================================================
			// 엔터메이트 유저 검증
			//===============================================================================================
			string sVerificationResult = Connect.VerificationEntermate(m_sEntermateUserId, m_sEntermatePrivateKey);

			JsonData joVerificationRes = JsonMapper.ToObject(sVerificationResult);

			int nResultCode = 0;

			if (!LitJsonUtil.TryGetIntProperty(joVerificationRes, "result", out nResultCode))
				throw new CommandHandlerException(this, kResult_Error, "Entermate 유저 검증에 실패하였습니다.");

			if (nResultCode != 1000)
				throw new CommandHandlerException(this, kResult_Error, "Entermate 유저 검증에 실패하였습니다.(" + nResultCode.ToString() + ")");

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
			// 엔터메이트사용자 정보 조회
			//===============================================================================================
			DataRow drEntermateUser = Dac.EntermateUser(conn, trans, m_sEntermateUserId);

			Guid userId = Guid.NewGuid();
			string sUserSecret = null;

			if (drEntermateUser == null)
			{
				//===============================================================================================
				// 구글사용자 등록
				//===============================================================================================
				sUserSecret = Util.CreateUserSecret();

				if (Dac.AddUser(conn, trans, userId, UserType.kType_Entermate, sUserSecret) != 0)
					throw new Exception("사용자 등록 실패.");

				if (Dac.AddEntermateUser(conn, trans, userId, m_sEntermateUserId) != 0)
					throw new CommandHandlerException(this, kResult_Error, "엔터메이트사용자 등록 실패.");
			}
			else
			{
				if (!Guid.TryParse(drEntermateUser["userId"].ToString(), out userId))
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