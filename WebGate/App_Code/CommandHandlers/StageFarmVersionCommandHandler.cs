using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// StageFarmVersionCommandHandler'的摘要描述.
/// </summary>
public class StageFarmVersionCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member variables

	public const int kResult_NotExists = 101;

	private int m_nPlatformId;
	private string m_sVersionName;
	private int m_nBuildNo;

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override void Parse()
	{
		base.Parse();

		//
		// 플랫폼ID
		//

		if (!LitJsonUtil.TryGetIntProperty(m_joReq, "platformId", out m_nPlatformId))
			throw new CommandHandlerException(this, kResult_Error, "'platformId' 프로퍼티가 유효하지 않습니다.");

		//
		// 버전명
		//

		if (!LitJsonUtil.TryGetStringProperty(m_joReq, "versionName", out m_sVersionName))
			throw new CommandHandlerException(this, kResult_Error, "'versionName' 프로퍼티가 유효하지 않습니다.");

		//
		// 빌드번호
		//

		if (!LitJsonUtil.TryGetIntProperty(m_joReq, "buildNo", out m_nBuildNo))
			throw new CommandHandlerException(this, kResult_Error, "'buildNo' 프로퍼티가 유효하지 않습니다.");
	}

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

		try
		{
			long lnIpNo = Util.GetIpNum(HttpContext.Current.Request.UserHostAddress);
			int nStageFarmId = 0;
			int nInternalStageFarmId = 0;
			int nSelectedFarmId = 0;

			//===============================================================================================
			// 响应 Json
			//===============================================================================================
			JsonData joRes = null;

			//===============================================================================================
			// 连接到一个数据库
			//===============================================================================================
			conn = DBUtil.GetConnection();
			conn.Open();

			//===============================================================================================
			// 조회
			//===============================================================================================
			DataRowCollection drcWhiteIps = Dac.WhiteIps(conn, null, lnIpNo);

			bool isAllowedIP = false;

			if (drcWhiteIps != null && drcWhiteIps.Count > 0)
				isAllowedIP = true;
			
			DataRow drStageFarmVersion = Dac.StageFarmVersion(conn, null, m_nPlatformId, m_sVersionName, m_nBuildNo);
			DataRow drPlatform = Dac.Platform(conn, null, m_nPlatformId);

			if (drStageFarmVersion == null && drPlatform == null)
			{
				DBUtil.Close(ref conn);
				throw new CommandHandlerException(this, kResult_Error, "접속 가능한 버전 정보가 없습니다.");
			}

			if (drStageFarmVersion != null)
			{
				nStageFarmId = Convert.ToInt32(drStageFarmVersion["farmId"]);
				nInternalStageFarmId = Convert.ToInt32(drStageFarmVersion["internalFarmId"]);

				// 내부IP인 경우 내부 스테이지팜이 설정된 경우
				if(isAllowedIP)
				{
					if(nInternalStageFarmId > 0)
						nSelectedFarmId = nInternalStageFarmId;
				}

				if(nSelectedFarmId == 0)
					nSelectedFarmId = nStageFarmId;

				DataRow drStageFarm = Dac.StageFarm(conn, null, nSelectedFarmId);

				if (drStageFarm == null)
				{
					DBUtil.Close(ref conn);
					throw new CommandHandlerException(this, kResult_Error, "접속 가능한 팜 정보가 없습니다.");
				}

				joRes = CreateResponse();

				//
				// 스테이지 팜 버전 정보
				//

				JsonData joStageFarmVersion = LitJsonUtil.CreateObject();
				joRes["stageFarmVersion"] = joStageFarmVersion;

				joStageFarmVersion["farmId"] = Convert.ToInt32(drStageFarm["farmId"]);
				joStageFarmVersion["name"] = Convert.ToString(drStageFarm["name"]);
				joStageFarmVersion["serverUrl"] = Convert.ToString(drStageFarm["serverUrl"]);
			}
			else if (drPlatform != null)
			{
				joRes = CreateResponse(kResult_NotExists);
				joRes["downloadUrl"] = drPlatform["downloadUrl"].ToString();
			}

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}