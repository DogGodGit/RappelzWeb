using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// GameAssetBundlesCommandHandler'的摘要描述.
/// </summary>
public class GameAssetBundlesCommandHandler : CommandHandler
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Member functions

	protected override JsonData HandleCommand()
	{
		SqlConnection conn = null;

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
			// 조회
			//===============================================================================================
			DataRowCollection drcGameAssetBundles = Dac.GameAssetBundles(conn, null);

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

			JsonData joGameAssetBundles = LitJsonUtil.CreateArray();
			joRes["gameAssetBundles"] = joGameAssetBundles;

			foreach (DataRow dr in drcGameAssetBundles)
			{
				JsonData jo = LitJsonUtil.CreateObject();
				jo["bundleNo"] = Convert.ToInt32(dr["bundleNo"]);
				jo["fileName"] = dr["fileName"].ToString();
				jo["androidVer"] = Convert.ToInt32(dr["androidVer"]);
				jo["iosVer"] = Convert.ToInt32(dr["iosVer"]);

				joGameAssetBundles.Add(jo);
			}

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}