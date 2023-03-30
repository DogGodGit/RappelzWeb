using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using LitJson;

/// <summary>
/// AnnouncementsCommandHandler의 요약 설명입니다.
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
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 조회
			//===============================================================================================
			DataRowCollection drcAnnouncements = Dac.Announcements(conn, null);

			//===============================================================================================
			// 데이터베이스 연결 닫기
			//===============================================================================================
			DBUtil.Close(ref conn);

			//===============================================================================================
			// 응답 Json
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