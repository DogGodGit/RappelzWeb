using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// AnnouncementsCommandHandler'的摘要描述.
/// </summary>
public class AnnouncementsCommandHandler : CommandHandler
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
			// 조회
			//===============================================================================================
			DataRowCollection drcAnnouncements = Dac.Announcements(conn, null);

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

			JsonData joAnnouncements = LitJsonUtil.CreateArray();
			joRes["announcements"] = joAnnouncements;

			foreach (DataRow dr in drcAnnouncements)
			{
				JsonData jo = LitJsonUtil.CreateObject();
				jo["announcementId"] = dr["announcementId"].ToString();
				jo["title"] = dr["title"].ToString();
				jo["contentUrl"] = dr["contentUrl"].ToString();
				jo["startTime"] = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(dr["startTime"].ToString()));
				jo["endTime"] = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(dr["endTime"].ToString())); 
				jo["sortNo"] = Convert.ToInt32(dr["sortNo"]);

				joAnnouncements.Add(jo);
			}

			return joRes;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}