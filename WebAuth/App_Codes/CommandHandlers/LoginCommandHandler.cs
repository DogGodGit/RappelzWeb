using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// LoginCommandHandler'的摘要描述.
/// </summary>
public class LoginCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	private Guid m_userId;
	private string m_sUserSecret = null;
	private int m_nLanguageId;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

        //
        // 사용자ID
        //

		string	sUserId = null;

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "userId", out sUserId))
            throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userId"));

		if (string.IsNullOrEmpty(sUserId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userId"));

        if (!Guid.TryParse(sUserId, out m_userId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userId"));

        //
        // 사용자Secret
        //

        if (!LitJsonUtil.TryGetStringProperty(m_joReq, "userSecret", out m_sUserSecret))
            throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userSecret"));

        if (string.IsNullOrEmpty(m_sUserSecret))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userSecret"));

        //
        // 언어ID
        //

        if (!LitJsonUtil.TryGetIntProperty(m_joReq, "languageId", out m_nLanguageId))
			throw new CommandHandlerException(this, kResult_Error, string.Format(Resources.Message.Exception006, "userSecret"));
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
			// 언어 체크
			//===============================================================================================
			int nSelectedLanguageId = -1;

			//===============================================================================================
			// 기본언어코드 조회
			//===============================================================================================
			DataRow drSystemSetting = Dac.SystemSetting(conn, null);

			// 시스템 기본언어 코드
			nSelectedLanguageId = Convert.ToInt32(drSystemSetting["defaultLanguageId"]);

			DataRowCollection drcLanguages = Dac.SupportedLanguages(conn, null);
			for (int i = 0; i < drcLanguages.Count; i++)
			{
				// 클라이언트의 언어가 사용가능한 언어인 경우
				if (m_nLanguageId == Convert.ToInt32(drcLanguages[i]["languageId"]))
				{
					nSelectedLanguageId = m_nLanguageId;
					break;
				}
			}

			//===============================================================================================
			// 사용자 정보 조회
			//===============================================================================================
			DataRow drUser = Dac.User(conn, trans, m_userId);

			if (drUser == null)
				throw new CommandHandlerException(this, kResult_Error, Resources.Message.Exception010 + "(" + m_userId + ")");

			//===========================================================================================
			// 사용자 제한 정보 조회
			//===========================================================================================
			DataRow drUserBlock = Dac.UserBlock(conn, trans, m_userId);

			if (drUserBlock != null)
				throw new CommandHandlerException(this, kResult_Error, "Access denied.");

			int nUserType = Convert.ToInt32(drUser["type"]);
			string sUserSecret = Convert.ToString(drUser["secret"]);
			int nLastVirtualGameServerId1 = Convert.ToInt32(drUser["lastVirtualGameServerId1"]);
			int nLastVirtualGameServerId2 = Convert.ToInt32(drUser["lastVirtualGameServerId2"]);

			if (sUserSecret != m_sUserSecret)
				throw new CommandHandlerException(this, kResult_Error, Resources.Message.Exception004);

			//===========================================================================================
			// 공유이벤트정보
			//===========================================================================================
			DataRow drSharingEventReceiver = Dac.SharingEventReceiver_UserId(conn, trans, m_userId);

			//
			// 액세스 비밀번호 생성
			//

			string sAccessSecret = Util.CreateAccessSecret();

			string sIp = ComUtil.GetIpAddress();
			DateTimeOffset lastloginTime;

			//
			// 마지막 접속서버가 없는 경우 추천서버 자동선정.
			// 

			if (nLastVirtualGameServerId1 == 0)
			{
				int nSelectedVirtualGameServerId = 0;

				long lnIpNo = Util.GetIpNum(sIp);

				DataRow drGeoIp = Dac.GeoIp(conn, null, lnIpNo);
				if (drGeoIp != null)
				{
					string sCountryCode = drGeoIp["countryCode"].ToString();

					DataRowCollection drcGameServerGroupAllowedCountries = Dac.GameServerGroupAllowedCountry_CountryCode(conn, null, sCountryCode);
					DataRowCollection drcGameServers = Dac.GameServers(conn, null);

					int nCurrentUserCount = 99999;

					foreach (DataRow drAllowed in drcGameServerGroupAllowedCountries)
					{
						foreach (DataRow drServer in drcGameServers)
						{
							if (Convert.ToInt32(drAllowed["groupId"]) != Convert.ToInt32(drServer["groupId"]))
								continue;

							if (Convert.ToBoolean(drServer["deleted"]))
								continue;

							if (!Convert.ToBoolean(drServer["recommendable"]))
								continue;

							if (!Convert.ToBoolean(drServer["isPublic"]))
								continue;

							if (nCurrentUserCount > Convert.ToInt32(drServer["currentUserCount"]))
							{
								nSelectedVirtualGameServerId = Convert.ToInt32(drServer["virtualGameServerId"]);
								nCurrentUserCount = Convert.ToInt32(drServer["currentUserCount"]);
							}
						}
					}

					nLastVirtualGameServerId1 = nSelectedVirtualGameServerId;
				}
			}

			//===============================================================================================
			// 트랜잭션 시작
			//===============================================================================================
			trans = conn.BeginTransaction();

			//===============================================================================================
			// 로그인로그 등록
			//===============================================================================================
			if (Dac.AddLoginLog(conn, trans, m_userId, sIp, out lastloginTime) != 0)
				throw new CommandHandlerException(this, kResult_Error, Resources.Message.Exception015);

			//===============================================================================================
			// 사용자 수정(로그인, 언어ID)
			//===============================================================================================
			if (Dac.UpdateUser_Login(conn, trans, m_userId, sAccessSecret, lastloginTime, sIp, nSelectedLanguageId) != 0)
				throw new CommandHandlerException(this, kResult_Error, Resources.Message.Exception016);

			//===============================================================================================
			// 트랜잭션 커밋
			//===============================================================================================
			DBUtil.Commit(ref trans);

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			UserAccessToken token = new UserAccessToken(m_userId, sAccessSecret, UserAccessToken.GetCheckCode(m_userId, sAccessSecret));

			//===============================================================================================
			// 响应 Json
			//===============================================================================================
			JsonData joRes = CreateResponse();
			joRes["userType"]		    = nUserType;
			joRes["accessToken"]		= token.ToString();
			joRes["lastVirtualGameServerId1"] = nLastVirtualGameServerId1;
			joRes["lastVirtualGameServerId2"] = nLastVirtualGameServerId2;
			joRes["sharingEventReceive"] = null;
			
			if (drSharingEventReceiver != null)
			{
				JsonData joSharingEventReceive = LitJsonUtil.CreateObject();
				joSharingEventReceive["eventId"] = Convert.ToInt32(drSharingEventReceiver["eventId"]);
				joSharingEventReceive["rewarded"] = Convert.ToBoolean(drSharingEventReceiver["rewarded"]);
				joRes["sharingEventReceive"] = joSharingEventReceive;
			}

			return joRes;
		}
		finally
		{
			DBUtil.Rollback(ref trans);
			DBUtil.Close(ref conn);
		}
	}
}