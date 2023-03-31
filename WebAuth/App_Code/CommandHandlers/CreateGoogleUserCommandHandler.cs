using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// CreateGoogleUserCommandHandler'的摘要描述.
/// </summary>
public class CreateGoogleUserCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private string m_sGoogleUserId = null;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		//
		// 구글 사용자ID
		//

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "googleUserId", out m_sGoogleUserId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "googleUserId"));

		if (string.IsNullOrEmpty(m_sGoogleUserId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "googleUserId"));
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;
		SqlTransaction trans = null;

		try
		{
			//===============================================================================================
			// 连接到一个数据库
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
			// 구글사용자 정보 조회
			//===============================================================================================
			DataRow drGoogleUser = Dac.GoogleUser(conn, trans, m_sGoogleUserId);

			Guid userId = Guid.NewGuid();
			string sUserSecret = null;

			if (drGoogleUser == null)
			{
				//===============================================================================================
				// 구글사용자 등록
				//===============================================================================================
				sUserSecret = Util.CreateUserSecret();

				if (Dac.AddUser(conn, trans, userId, UserType.kType_Google, sUserSecret) != 0)
					throw new Exception(Resources.Message.Exception008);

				if (Dac.AddGoogleUser(conn, trans, userId, m_sGoogleUserId) != 0)
					throw new CommandHandlerException(this, kResult_Error, Resources.Message.Exception012);
			}
			else
			{
				if (!Guid.TryParse(drGoogleUser["userId"].ToString(), out userId))
					throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userId"));

				//===============================================================================================
				// 사용자 정보 조회
				//===============================================================================================
				DataRow drUser = Dac.User(conn, trans, userId);

				if (drUser == null)
					throw new CommandHandlerException(this, kResult_Error, Resources.Message.Exception010);

				sUserSecret = Convert.ToString(drUser["secret"]);
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