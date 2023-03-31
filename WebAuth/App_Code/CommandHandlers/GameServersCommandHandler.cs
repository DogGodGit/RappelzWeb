using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// GameServersCommandHandler'的摘要描述.
/// </summary>
public class GameServersCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

		try
		{
			// IP주소->IP번호로 변환.
			long lnIpNo = Util.GetIpNum(ComUtil.GetIpAddress());

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
			DataRowCollection drcGameServerRegions = Dac.GameServerRegions(conn, null);
			DataRowCollection drcGameServerGroups = Dac.GameServerGroups(conn, null);
			DataRowCollection drcGameServers = Dac.GameServers(conn, null);
			DataRowCollection drcGameServerGroupAllowedCountries = null;

			//===============================================================================================
			// IP 조회
			//===============================================================================================
			DataRow drGeoIp = Dac.GeoIp(conn, null, lnIpNo);

			string sCountryCode = "";

			if (drGeoIp != null)
			{
				sCountryCode = drGeoIp["countryCode"].ToString();

				drcGameServerGroupAllowedCountries = Dac.GameServerGroupAllowedCountry_CountryCode(conn, null, sCountryCode);
			}

			DataRow drSystemSetting = Dac.SystemSetting(conn, null);
			DataRowCollection drcWhiteIps = Dac.WhiteIps(conn, null, lnIpNo);

			//===============================================================================================
			// 关闭一个数据库连接
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 响应 Json
			//===============================================================================================
			JsonData joRes = CreateResponse();

			//
			// 결과
			//

			// 화이트IP
			bool isAllowedIP = false;

			// 화이트IP에 포함된 사용자IP이면 허용.
			if (drcWhiteIps != null && drcWhiteIps.Count > 0)
				isAllowedIP = true;

			int nRecommendGameServerId = Convert.ToInt32(drSystemSetting["recommendGameServerId"]);
			bool isRecommendAuto = Convert.ToBoolean(drSystemSetting["recommendServerAuto"]);
			int nRecommendType = Convert.ToInt32(drSystemSetting["recommendServerConditionType"]);

			int nRecommendVirtualGameServerId = 0;
			int nMinCcu = 99999;

			// 추천서버 자동인 경우
			if (isRecommendAuto)
			{
				for (int i = 0; i < drcGameServers.Count; i++)
				{
					// 최소 CCU인 서버를 추천서버로
					if (nRecommendType == 1)
					{
						if (Convert.ToBoolean(drcGameServers[i]["isPublic"])
							&& Convert.ToBoolean(drcGameServers[i]["recommendable"])
							&& Convert.ToInt32(drcGameServers[i]["currentUserCount"]) < nMinCcu)
						{
							nRecommendVirtualGameServerId = Convert.ToInt32(drcGameServers[i]["virtualGameServerId"]);
							nMinCcu = Convert.ToInt32(drcGameServers[i]["currentUserCount"]);
						}
					}
				}
			}

			//
			// 게임서버 목록
			//

			JsonData joGameServerRegions = LitJsonUtil.CreateArray();
			joRes["gameServerRegions"] = joGameServerRegions;

			foreach (DataRow drRegion in drcGameServerRegions)
			{
				JsonData joRegion = LitJsonUtil.CreateObject();
				joRegion["regionId"] = Convert.ToInt32(drRegion["regionId"]);
				joRegion["nameKey"] = drRegion["nameKey"].ToString();

				joGameServerRegions.Add(joRegion);
			}

			bool isRecommended = false;

			JsonData joGameServerGroups = LitJsonUtil.CreateArray();
			joRes["gameServerGroups"] = joGameServerGroups;

			foreach (DataRow dr in drcGameServerGroups)
			{
				int nGroupId = Convert.ToInt32(dr["groupId"]);

				JsonData jo = LitJsonUtil.CreateObject();
				jo["groupId"] = nGroupId;
				jo["nameKey"] = dr["nameKey"].ToString();
				jo["regionId"] = Convert.ToInt32(dr["regionId"]);
				jo["recommendServerAuto"] = Convert.ToBoolean(dr["recommendServerAuto"]);
				jo["recommendServerConditionType"] = Convert.ToInt32(dr["recommendServerConditionType"]);
				jo["isAccessRestriction"] = Convert.ToBoolean(dr["isAccessRestriction"]);
				jo["accessAllowed"] = false;

				// 허용여부
				if (sCountryCode == "")
				{
					// GeoIp 데이터에 정보가 없는 경우는 허용
					jo["accessAllowed"] = true;
				}
				else if (isAllowedIP)
				{
					// 화이트IP는 허용
					jo["accessAllowed"] = true;
				}
				else
				{
					if (drcGameServerGroupAllowedCountries != null && drcGameServerGroupAllowedCountries.Count > 0)
					{
						foreach (DataRow drGroupAllowed in drcGameServerGroupAllowedCountries)
						{
							if (nGroupId == Convert.ToInt32(drGroupAllowed["groupId"]))
							{
								jo["accessAllowed"] = true;
								break;
							}
						}
					}
				}

				joGameServerGroups.Add(jo);
			}

			JsonData joGameServers = LitJsonUtil.CreateArray();
			joRes["gameServers"] = joGameServers;

			foreach (DataRow dr in drcGameServers)
			{
				// 비공개인데 허용되지 않은 IP인 경우
				if (!Convert.ToBoolean(dr["isPublic"]) && !isAllowedIP)
					continue;

				JsonData jo = LitJsonUtil.CreateObject();
				jo["virtualGameServerId"] = Convert.ToInt32(dr["virtualGameServerId"]);
				jo["serverId"] = Convert.ToInt32(dr["serverId"]);
				jo["name"] = dr["displayName"].ToString();
				jo["groupId"] = Convert.ToInt32(dr["groupId"]);
				jo["apiUrl"] = dr["apiUrl"].ToString();
				jo["proxyServer"] = dr["proxyServer"].ToString();
				jo["proxyServerPort"] = Convert.ToInt32(dr["proxyServerPort"]);
				jo["currentUserCount"] = Convert.ToInt32(dr["currentUserCount"]);
				jo["status"] = Convert.ToInt32(dr["status"]);
				jo["isNew"] = Convert.ToBoolean(dr["isNew"]);
				jo["isMaintenance"] = Convert.ToBoolean(dr["isMaintenance"]);
				jo["recommendable"] = Convert.ToBoolean(dr["recommendable"]);
				jo["openTime"] = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(dr["openTime"].ToString()));

				if (isRecommendAuto)
					jo["isRecommend"] = (Convert.ToInt32(dr["virtualGameServerId"]) == nRecommendVirtualGameServerId);
				else
				{
					// 추천이고 아직 추천서버가 나오지 않은 경우 추천서버로 선정(표시순)하고 이후 중복되는 추천은 적용하지 않는다.
					if (nRecommendGameServerId == Convert.ToInt32(dr["serverId"]) && !isRecommended)
					{
						jo["isRecommend"] = true;
						isRecommended = true;
					}
					else
						jo["isRecommend"] = false;
				}

				joGameServers.Add(jo);
			}

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}