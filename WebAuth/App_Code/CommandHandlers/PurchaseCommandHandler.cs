using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// PurchaseCommandHandler'的摘要描述.
/// </summary>
public class PurchaseCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables
	private UserAccessToken m_userAccessToken;
	private int m_nStoreType = 0;
	private Guid m_logId = Guid.Empty;
	private int m_nVirtualGameServerId = 0;
	private Guid m_heroId = Guid.Empty;

	private string m_sPurchaseData = null;
	private string m_sSignature = null;
	private string m_sReceipt = null;

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
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userAccessToken"));

        if (!UserAccessToken.TryParse(sUserAccessToken, out m_userAccessToken))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userAccessToken"));

        //
        // 스토어 타입
        //

        if (!LitJsonUtil.TryGetIntValue(m_joReq["storeType"], out m_nStoreType))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "storeType"));

        //
        // 서버ID
        //

        if (!LitJsonUtil.TryGetIntValue(m_joReq["virtualGameServerId"], out m_nVirtualGameServerId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "virtualGameServerId"));

        //
        // 영웅ID
        //

        string sHeroId = null;

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "heroId", out sHeroId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "heroId"));

        if (!Guid.TryParse(sHeroId, out m_heroId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "heroId"));

        //
        // 로그ID
        //

        string sLogId = null;

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "logId", out sLogId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "logId"));

        if (!Guid.TryParse(sLogId, out m_logId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "logId"));

        //
        // 구글 - 결제데이터
        //

        LitJsonUtil.TryGetStringProperty(m_joReq, "purchaseData", out m_sPurchaseData);

		//
		// 구글 - 사인
		//

		LitJsonUtil.TryGetStringProperty(m_joReq, "signature", out m_sSignature);

		//
		// 애플 - 영수증
		//

		LitJsonUtil.TryGetStringProperty(m_joReq, "receipt", out m_sReceipt);
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
			// 영수증 검증
			//===============================================================================================
			string sOrderId = null;
			JsonData verifyResult = null;

			JsonData purchaseData = null;
			string sDeveloperPayload = "";
			Guid receivedLogId;

			switch (m_nStoreType)
			{
				case 1:
					if (string.IsNullOrEmpty(m_sPurchaseData) || string.IsNullOrEmpty(m_sSignature))
						throw new CommandHandlerException(this, kResult_Error, "영수증 데이터가 유효하지 않습니다.");

					//
					// 구글 영수증 검증
					//

					if (!VerifyReceiptGoogle.VerifyGoogleLocal(m_sPurchaseData, m_sSignature))
						throw new CommandHandlerException(this, kResult_Error, "영수증 검증 실패.");

					//
					// 결과 값 설정
					//
					purchaseData = JsonMapper.ToObject(m_sPurchaseData);

					if (!LitJsonUtil.TryGetStringProperty(purchaseData, "orderId", out sOrderId))
						throw new CommandHandlerException(this, kResult_Error, "영수증 검증 주문번호 조회 실패.");

					if (!LitJsonUtil.TryGetStringProperty(purchaseData, "developerPayload", out sDeveloperPayload))
						throw new CommandHandlerException(this, kResult_Error, "'developerPayload' 프로퍼티가 유효하지 않습니다.");

					if (!Guid.TryParse(sDeveloperPayload, out receivedLogId))
						throw new CommandHandlerException(this, kResult_Error, "'developerPayload' 프로퍼티의 형식이 유효하지 않습니다.");

					if (!m_logId.Equals(receivedLogId))
						throw new CommandHandlerException(this, kResult_Error, "'logId'와 'developerPayload'가 유효하지 않습니다.");

					break;
				case 2:
					if (string.IsNullOrEmpty(m_sReceipt))
						throw new CommandHandlerException(this, kResult_Error, "영수증 데이터가 유효하지 않습니다.");

					//
					// 애플 영수증 검증
					//

					verifyResult = VerifyReceiptApple.VerifyApple(m_sReceipt);

					if (verifyResult == null)
						throw new CommandHandlerException(this, kResult_Error, "영수증 검증 실패.");

					//
					// 결과 값 설정
					//
					JsonData inApps;

					if (!LitJsonUtil.TryGetArrayProperty(verifyResult, "in_app", out inApps))
						throw new CommandHandlerException(this, kResult_Error, "영수증 inApp 정보 조회 실패.");

					DateTime dtMax = DateTime.MinValue;

					foreach (JsonData jo in inApps)
					{
						DateTime dt = new DateTime(TimeSpan.FromMilliseconds(Convert.ToInt64(jo["purchase_date_ms"].ToString())).Ticks);

						if (DateTime.Compare(dtMax, dt) < 0)
						{
							dtMax = dt;
							sOrderId = jo["original_transaction_id"].ToString();
						}
					}

					break;
				case 3:
					if (string.IsNullOrEmpty(m_sPurchaseData) || string.IsNullOrEmpty(m_sSignature))
						throw new CommandHandlerException(this, kResult_Error, "영수증 데이터가 유효하지 않습니다.");

					//
					// 영수증 검증
					//

					

					//
					// 결과 값 설정
					//
					purchaseData = JsonMapper.ToObject(m_sPurchaseData);

					if (!LitJsonUtil.TryGetStringProperty(purchaseData, "orderId", out sOrderId))
						throw new CommandHandlerException(this, kResult_Error, "영수증 검증 주문번호 조회 실패.");

					if (!LitJsonUtil.TryGetStringProperty(purchaseData, "developerPayload", out sDeveloperPayload))
						throw new CommandHandlerException(this, kResult_Error, "'developerPayload' 프로퍼티가 유효하지 않습니다.");

					if (!Guid.TryParse(sDeveloperPayload, out receivedLogId))
						throw new CommandHandlerException(this, kResult_Error, "'developerPayload' 프로퍼티의 형식이 유효하지 않습니다.");

					if (!m_logId.Equals(receivedLogId))
						throw new CommandHandlerException(this, kResult_Error, "'logId'와 'developerPayload'가 유효하지 않습니다.");

					break;
				default:
					throw new CommandHandlerException(this, kResult_Error, "'storeType' 프로퍼티가 유효하지 않습니다.");
			}

			//===============================================================================================
			// 连接到一个数据库
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 트랜잭션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			//===============================================================================================
			// 결제 구매완료 업데이트
			//===============================================================================================
			switch (m_nStoreType)
			{
				case 1:

					if (Dac.PurchaseOrderId(conn, trans, sOrderId) != 0)
					{
						throw new CommandHandlerException(this, kResult_Error, "AOS 주문번호 중복(" + sOrderId + ")으로 구매완료 처리에 실패하였습니다.");
					}

					if (Dac.UpdatePurchase(conn, trans, m_logId, m_userAccessToken.userId, m_nVirtualGameServerId, m_heroId, m_nStoreType, sOrderId, m_sSignature, m_sPurchaseData) != 0)
					{
						throw new CommandHandlerException(this, kResult_Error, "구매완료 처리에 실패하였습니다.");
					}
					break;
				case 2:

					if (Dac.PurchaseOrderId(conn, trans, sOrderId) != 0)
					{
						throw new CommandHandlerException(this, kResult_Error, "IOS 주문번호 중복(" + sOrderId + ")으로 구매완료 처리에 실패하였습니다.");
					}

					if (Dac.UpdatePurchase(conn, trans, m_logId, m_userAccessToken.userId, m_nVirtualGameServerId, m_heroId, m_nStoreType, sOrderId, "", m_sReceipt) != 0)
					{
						throw new CommandHandlerException(this, kResult_Error, "구매완료 처리에 실패하였습니다.");
					}
					break;
				case 3:
					if (Dac.PurchaseOrderId(conn, trans, sOrderId) != 0)
					{
						throw new CommandHandlerException(this, kResult_Error, "OneStore 주문번호 중복(" + sOrderId + ")으로 구매완료 처리에 실패하였습니다.");
					}

					if (Dac.UpdatePurchase(conn, trans, m_logId, m_userAccessToken.userId, m_nVirtualGameServerId, m_heroId, m_nStoreType, sOrderId, m_sSignature, m_sPurchaseData) != 0)
					{
						throw new CommandHandlerException(this, kResult_Error, "구매완료 처리에 실패하였습니다.");
					}
					break;
				default:
					throw new CommandHandlerException(this, kResult_Error, "'storeType' 프로퍼티가 유효하지 않습니다.");
			}

			//===============================================================================================
			// 트랜잭션 커밋
			//===============================================================================================
			DBUtil.Commit(ref trans);

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 响应 Json
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