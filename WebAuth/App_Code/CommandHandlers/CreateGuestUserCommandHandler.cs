using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LitJson;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// CreateGuestUserCommandHandler의 요약 설명입니다.
/// </summary>
public class CreateGuestUserCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

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
			// 게스트사용자 등록
			//===============================================================================================
			Guid userId = Guid.NewGuid();
			string sUserSecret = Util.CreateUserSecret();

			if (Dac.AddUser(conn, trans, userId, UserType.kType_Guest, sUserSecret) != 0)
				throw new Exception("사용자 등록 실패.");

			if (Dac.AddGuestUser(conn, trans, userId) != 0)
				throw new CommandHandlerException(this, kResult_Error, "게스트사용자 등록 실패.");

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