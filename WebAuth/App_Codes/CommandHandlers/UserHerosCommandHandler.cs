using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// UserHerosCommandHandler'的摘要描述.
/// </summary>
public class UserHerosCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private UserAccessToken m_userAccessToken;

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
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

		try
		{
			//===============================================================================================
			// 사용자액세스토큰 검증
			//===============================================================================================
			if (!m_userAccessToken.isValid)
				throw new CommandHandlerException(this, kResult_InvalidAccessToken, "사용자 액세스 토큰이 유효하지 않습니다.");

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
			// 조회
			//===============================================================================================
			DataRowCollection drcUserHeros = Dac.UserHeros(conn, null, m_userAccessToken.userId);

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 响应 Json
			//===============================================================================================
			JsonData joRes = CreateResponse();

			JsonData joUserHeros = LitJsonUtil.CreateArray();
			joRes["userHeros"] = joUserHeros;

			foreach (DataRow dr in drcUserHeros)
			{
				JsonData joData = LitJsonUtil.CreateObject();
				joData["virtualGameServerId"] = Convert.ToInt32(dr["virtualGameServerId"]);
				joData["heroId"] = Convert.ToString(dr["heroId"]);
				joData["name"] = Convert.ToString(dr["name"]);
				joData["serverId"] = Convert.ToInt32(dr["serverId"]);

				joUserHeros.Add(joData);
			}

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}