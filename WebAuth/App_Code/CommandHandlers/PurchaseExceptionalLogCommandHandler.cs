using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// PurchaseExceptionalLogCommandHandler의 요약 설명입니다.
/// </summary>
public class PurchaseExceptionalLogCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables
	private UserAccessToken m_userAccessToken;
	private int m_nStoreType = 0;
	private int m_nVirtualGameServerId = 0;
	private Guid m_heroId = Guid.Empty;

	private string m_sPurchaseData = null;
	private string m_sSignature = null;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		//
		// 사용자액세스토큰
		//

		string sUserAccessToken = null;

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "userAccessToken", out sUserAccessToken))
			throw new CommandHandlerException(this, kResult_Error, "'userAccessToken' 프로퍼티가 유효하지 않습니다.");

		if (!UserAccessToken.TryParse(sUserAccessToken, out m_userAccessToken))
			throw new CommandHandlerException(this, kResult_Error, "'userAccessToken' 프로퍼티가 유효하지 않습니다.");

		//
		// 스토어 타입
		//

		if (!LitJsonUtil.TryGetIntValue(m_joReq["storeType"], out m_nStoreType))
			throw new CommandHandlerException(this, kResult_Error, "'storeType' 프로퍼티가 유효하지 않습니다.");

		//
		// 서버ID
		//

		if (!LitJsonUtil.TryGetIntValue(m_joReq["virtualGameServerId"], out m_nVirtualGameServerId))
			throw new CommandHandlerException(this, kResult_Error, "'virtualGameServerId' 프로퍼티가 유효하지 않습니다.");

		//
		// 영웅ID
		//

		string sHeroId = null;

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "heroId", out sHeroId))
			throw new CommandHandlerException(this, kResult_Error, "'heroId' 프로퍼티가 유효하지 않습니다.");

		if (!Guid.TryParse(sHeroId, out m_heroId))
			throw new CommandHandlerException(this, kResult_Error, "'heroId' 프로퍼티가 유효하지 않습니다.");

		//
		// 구글 - 결제데이터
		//

		LitJsonUtil.TryGetStringProperty(m_joReq, "purchaseData", out m_sPurchaseData);

		//
		// 구글 - 사인
		//

		LitJsonUtil.TryGetStringProperty(m_joReq, "signature", out m_sSignature);
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;
		SqlTransaction trans = null;

		try
		{
			//===============================================================================================
			// 사용자액세스토큰 검증
			//===============================================================================================

			//
			// 인증서버에 검증을 요청해야하나 현재는 무결성 검사만 한다.
			//

			if (!m_userAccessToken.isValid)
				throw new CommandHandlerException(this, kResult_InvalidAccessToken, "사용자 액세스 토큰이 유효하지 않습니다.");

			//===============================================================================================
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 트랜잭션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			//===============================================================================================
			// 결제 구매 예외 등록
			//===============================================================================================
			JsonData purchaseData = JsonMapper.ToObject(m_sPurchaseData);

			string sOrderId = LitJsonUtil.GetStringProperty(purchaseData, "orderId");

			if (Dac.AddPurchaseExceptional(conn, trans, m_userAccessToken.userId, m_nVirtualGameServerId, m_heroId, m_nStoreType, sOrderId, m_sSignature, m_sPurchaseData) != 0)
				throw new CommandHandlerException(this, kResult_Error, "결제 예외 등록에 실패했습니다.");

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
			return joRes;
		}
		finally
		{
			DBUtil.Rollback(ref trans);
			DBUtil.Close(ref conn);
		}
	}
}