using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class Event_Coupon : System.Web.UI.Page
{
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// Constants

	protected const string S_ENTERINFOMATION = "Information is not complete. Enter full information to use coupon.";
	private const string S_SUCCESS = "Registered coupon successfully. Please check your reward at mailbox.";
	private const string S_FAIL_COUPON = "Coupon number invalid. Please check and try again.";
	private const string S_FAIL_COUPON_USED = "This coupon was already used";
	private const string S_FAIL_NAME = "Please check server and character name and try again.";
	private const string S_FAIL_SERVER = "Server is incorrect. Please check and try again.";
	private const string S_ERROR = "Failed to register coupon. Please contact help center.";

	private const int N_TYPE_GLOBAL = 1;
	private const int N_TYPE_PERSONAL = 2;

	private const int N_STATUS_SUCCESS = 1;
	private const int N_STATUS_ALREADYUSED = 2;
	private const int N_STATUS_INVALID = 3;

	private const int N_MAILTYPE_ITEM = 2;

	protected string sPaddingTop = "214px";
	protected string sPadding = "";
	protected string sScript = "";

	private int CheckMobile()
	{
		int isMobile = 0;
		string[] MOBILE_AGENTS1 = { "Android" };
		string[] MOBILE_AGENTS2 = { "iPhone", "Mobile", "BlackBerry", "Windows CE", "SonyEricsson" };

		HttpRequest hq = HttpContext.Current.Request;

		if (hq.Params["HTTP_USER_AGENT"] == null)
			return isMobile;

		string us = hq.Params["HTTP_USER_AGENT"].ToString();

		for (int i = 0; i < MOBILE_AGENTS1.Length; i++)
		{
			if (us.LastIndexOf(MOBILE_AGENTS1[i]) >= 0)
			{
				isMobile = 1;
				break;
			}
		}
		if (isMobile == 0)
		{
			for (int i = 0; i < MOBILE_AGENTS2.Length; i++)
			{
				if (us.LastIndexOf(MOBILE_AGENTS2[i]) >= 0)
				{
					isMobile = 2;
					break;
				}
			}
		}

		return isMobile;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		HttpResponse hr = HttpContext.Current.Response;

		hr.Cache.SetCacheability(HttpCacheability.Private);
		hr.Cache.SetExpires(DateTime.MinValue);

		if (IsPostBack)
			return;

		switch (CheckMobile())
		{
			case 1:
				sPaddingTop = "220px";
				sPadding = "10px";
				break;
			case 2:
				sPaddingTop = "214px";
				sPadding = "6px";
				break;
			default:
				sPaddingTop = "220px";
				sPadding = "10px";
				break;

		}

		SqlConnection conn = null;

		try
		{
			WBtnRegist.Attributes.Add("onclick", "return checkForm();");

			WDDLRegion.Attributes.Add("onchange", "selChange(this);");
			WDDLGroup.Attributes.Add("onchange", "selChange(this);");
			WDDLServer.Attributes.Add("onchange", "selChange(this);");

			//===============================================================================================
			// 데이터베이스 연결
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 이벤트 정보 조회
			//===============================================================================================
			DataRowCollection drcRegions = Dac.GameServerRegions(conn, null);
			DataRowCollection drcGroups = Dac.GameServerGroups(conn, null);
			DataRowCollection drcServers = Dac.GameServers(conn, null);

			DBUtil.Close(ref conn);

			int nIndex = 0;

			StringBuilder sb = new StringBuilder();

			sb.Append("var arrRegion = [");
			foreach (DataRow dr in drcRegions)
			{
				if (nIndex > 0)
					sb.Append(",");
				sb.Append("{regionId:" + dr["regionId"].ToString() + ", name:'" + dr["_name"].ToString() + "'}");
				nIndex++;
			}
			sb.Append("];");

			sb.AppendLine();

			nIndex = 0;

			sb.Append("var arrGroup = [");
			foreach (DataRow dr in drcGroups)
			{
				if (nIndex > 0)
					sb.Append(",");
				sb.Append("{groupId:" + dr["groupId"].ToString() + ", name:'" + dr["_name"].ToString() + "', regionId:" + dr["regionId"].ToString() + "}");
				nIndex++;
			}
			sb.Append("];");

			sb.AppendLine();

			nIndex = 0;

			sb.Append("var arrServer = [");
			foreach (DataRow dr in drcServers)
			{
				if (nIndex > 0)
					sb.Append(",");
				sb.Append("{virtualServerId:" + dr["virtualGameServerId"].ToString() + ", name:'" + dr["displayName"].ToString() + "', gameServerId:" + dr["serverId"].ToString() + ", groupId:" + dr["groupId"].ToString() + "}");
				nIndex++;
			}
			sb.Append("];");

			sScript = sb.ToString();
			sb.Clear();
		}
		catch (Exception ex)
		{
			DBUtil.Close(ref conn);
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}

	protected void WBtnRegist_OnClick(object sender, EventArgs e)
	{
		SqlConnection conn = null;
		SqlConnection connGame = null;

		SqlTransaction tran = null;
		SqlTransaction tranGame = null;

		try
		{
			string sCouponId = WTxtCoupon.Text.Trim();
			int nGameServerId = Convert.ToInt32(WHFSelectedServer.Value.Trim());
			string sName = WTxtName.Text.Trim();

			if (sCouponId == "" || nGameServerId == 0 || sName == "")
			{
				ComUtil.MsgBox(S_ENTERINFOMATION, "history.back();");
				return;
			}

			conn = DBUtil.GetUserConnection();
			conn.Open();

			DataRow drServer = Dac.GameServer(conn, null, nGameServerId);

			if (drServer == null)
			{
				DBUtil.Close(ref conn);

				ComUtil.MsgBox(S_FAIL_SERVER, "history.back();");
				return;
			}

			string sConnectionString = drServer["gameDBConnection"].ToString();
			int nRegionId = Convert.ToInt32(drServer["regionId"]);
			int nGroupId = Convert.ToInt32(drServer["groupId"]);

			// 닉네임 조회
			// 연결정보 가져오기 (DB커넥션 포함됨)

			// DB연결
			connGame = DBUtil.GetGameDBConn(sConnectionString);
			connGame.Open();

			DataRow drHero = DacGame.Hero_NickName(connGame, null, sName);

			if (drHero == null)
			{
				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_FAIL_NAME, "history.back();");
				return;
			}

			Guid heroId = Guid.Parse(drHero["heroId"].ToString());

			// 프로모션 정보 조회
			DataRow drPromotion = Dac.Promotion_Code(conn, null, sCouponId);

			if (drPromotion == null)
			{
				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_FAIL_COUPON, "history.back();");
				return;
			}

			// 사용가능여부
			if (Convert.ToInt32(drPromotion["usable"]) != 1)
			{
				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_FAIL_COUPON, "history.back();");
				return;
			}

			Guid promotionId = Guid.Parse(drPromotion["promotionId"].ToString());
			int nType = Convert.ToInt32(drPromotion["type"]);
			int nMailTitleType = Convert.ToInt32(drPromotion["mailTitleType"]);
			string sMailTitle = drPromotion["mailTitle"].ToString();
			int nMailContentType = Convert.ToInt32(drPromotion["mailContentType"]);
			string sMailContent = drPromotion["mailContent"].ToString();

			// 대상체크
			if (Dac.IsPromotionTarget(conn, null, promotionId, nRegionId, nGroupId, nGameServerId) != 1)
			{
				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_FAIL_COUPON, "history.back();");
				return;
			}

			int nCouponRet = -1;

			switch (nType)
			{
				case N_TYPE_GLOBAL: nCouponRet = Dac.CouponUseLog_Global(conn, null, sCouponId);
					break;
				case N_TYPE_PERSONAL: nCouponRet = Dac.CouponUseLog_Personal(conn, null, nGameServerId, heroId, sCouponId);
					break;
				default:
					break;
			}

			// 쿠폰타입이 없는 타입. 에러.
			if (nCouponRet == -1)
			{
				Dac.AddCouponUse(conn, null, nGameServerId, heroId, promotionId, sCouponId, N_STATUS_INVALID);

				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_ERROR + " ERROR(-1)", "history.back();");
				return;
			}

			// 사용하지 않은 쿠폰인 경우 동일 프로모션에 사용했는지 확인
			if (nCouponRet == 0)
				nCouponRet = Dac.CouponUse_Promotion(conn, null, nGameServerId, heroId, promotionId);

			// 이미 사용된 쿠폰
			if (nCouponRet == 1)
			{
				Dac.AddCouponUse(conn, null, nGameServerId, heroId, promotionId, sCouponId, N_STATUS_ALREADYUSED);

				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_FAIL_COUPON_USED, "history.back();");
				return;
			}

			// 사용가능한 쿠폰이 아닌 그외의 경우
			if (nCouponRet != 0)
			{
				Dac.AddCouponUse(conn, null, nGameServerId, heroId, promotionId, sCouponId, N_STATUS_INVALID);

				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_ERROR + " ERROR(-2)", "history.back();");
				return;
			}

			// 프로모션 아이템 조회
			DataRowCollection drcItems = Dac.PromotionItems(conn, null, promotionId);

			DataRow drGameConfig = Dac.GameConfig(conn, null);

			tran = conn.BeginTransaction();

			// 쿠폰 사용 로그 등록
			if (Dac.AddCouponUse(conn, tran, nGameServerId, heroId, promotionId, sCouponId, 1) != 0)
			{
				DBUtil.Rollback(ref tran);

				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_ERROR + " ERROR(-3)", "history.back();");
				return;
			}

			int nDurationDay = 5;

			if (drGameConfig != null)
				nDurationDay = Convert.ToInt32(drGameConfig["mailRetentionDay"]);

			Guid mailId = Guid.NewGuid();

			tranGame = connGame.BeginTransaction();

			//===============================================================================================
			// 메일 등록
			//===============================================================================================
			if (DacGame.AddMail(connGame, tranGame, mailId, heroId, nMailTitleType, sMailTitle, nMailContentType, sMailContent, nDurationDay) != 0)
			{
				DBUtil.Rollback(ref tran);
				DBUtil.Rollback(ref tranGame);

				DBUtil.Close(ref conn);
				DBUtil.Close(ref connGame);

				ComUtil.MsgBox(S_ERROR + " ERROR(-4)", "history.back();");
				return;
			}

			//===============================================================================================
			// 메일첨부 등록
			//===============================================================================================
			for (int i = 0; i < drcItems.Count; i++)
			{
				int nAttachmentNo = i + 1;


				if (DacGame.AddMailAttachment(connGame, tranGame, mailId, nAttachmentNo, Convert.ToInt32(drcItems[i]["itemId"]), Convert.ToInt32(drcItems[i]["itemCount"]), Convert.ToBoolean(drcItems[i]["itemOwned"])) != 0)
				{
					DBUtil.Rollback(ref tran);
					DBUtil.Rollback(ref tranGame);

					DBUtil.Close(ref conn);
					DBUtil.Close(ref connGame);

					ComUtil.MsgBox(S_ERROR + " ERROR(-5)", "history.back();");
					return;
				}
			}

			DBUtil.Commit(ref tranGame);
			DBUtil.Commit(ref tran);

			// User 연결 종료
			DBUtil.Close(ref conn);

			// Game 연결 종료
			DBUtil.Close(ref connGame);

			ComUtil.MsgBox(S_SUCCESS, "location.href='/Event/Coupon.aspx';");
		}
		catch (Exception ex)
		{
			DBUtil.Rollback(ref tran);
			DBUtil.Rollback(ref tranGame);

			DBUtil.Close(ref conn);
			DBUtil.Close(ref connGame);

			ComUtil.MsgBox(S_ERROR + " ERROR(-99)" + ex.Message, "history.back();");

			LogUtil.Log(ex);
		}
	}
}