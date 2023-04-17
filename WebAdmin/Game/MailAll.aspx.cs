using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_MailAll : System.Web.UI.Page
{
	protected int m_nServerId;

	protected void Page_Load(object sender, EventArgs e)
	{
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
		m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);

		if (IsPostBack)
			return;
		try
		{
			PageLoad();
		}
		catch (System.Threading.ThreadAbortException) { }
		catch (Exception ex)
		{
			ComUtil.ErrorLogMsg(ex);
		}
	}

	private void PageLoad()
	{
		WBtnMailSend.Attributes.Add("onclick", "return sendMail();");

		SqlConnection conn = DBUtil.GetUserDBConn();
		DataTable dt = DacUser.GameServerAll(conn, null);
		DataTable dtItems = DacUser.Items(conn, null);
		DBUtil.CloseDBConn(conn);

		WDDLServer.Items.Add(new ListItem("===서버선택===", "0"));
		for (int i = 0; i < dt.Rows.Count; i++)
			WDDLServer.Items.Add(new ListItem("서버 ID - " + dt.Rows[i]["serverId"].ToString(), dt.Rows[i]["serverId"].ToString()));

		WDDLServer.SelectedValue = m_nServerId.ToString();

		for (int i = 0; i < dtItems.Rows.Count; i++)
			WDDLItem.Items.Add(new ListItem(dtItems.Rows[i]["itemId"].ToString() + ". " + dtItems.Rows[i]["_name"].ToString(), dtItems.Rows[i]["itemId"].ToString()));

		WDDLTitleType.Items.Add(new ListItem("일반텍스트", "1"));
		WDDLTitleType.Items.Add(new ListItem("스트링키", "2"));
		WDDLContentType.Items.Add(new ListItem("일반텍스트", "1"));
		WDDLContentType.Items.Add(new ListItem("스트링키", "2"));

		WPHMailForm.Visible = false;

		if (m_nServerId == 0)
			return;

		WPHMailForm.Visible = true;
	}

	protected void WDDLServer_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Response.Redirect("/Game/MailAll.aspx?SVR=" + WDDLServer.SelectedValue);
	}

	protected void WBtnMailSend_OnClick(object sender, EventArgs e)
	{
		if (m_nServerId == 0)
		{
			ComUtil.MsgBox("서버를 선택해주세요.", "history.back();");
			return;
		}

		SqlConnection connGame = null;
		SqlTransaction tran = null;

		try
		{
			int nTitleType = Convert.ToInt32(WDDLTitleType.SelectedValue);
			string sTitle = WTxtMailTitle.Text.Trim();
			int nContentType = Convert.ToInt32(WDDLContentType.SelectedValue);
			string sContent = WTxtMailContent.Text.Trim();

			string sAttachment = WHFMailAttachment.Value;

			if (sTitle == "" || sContent == "")
			{
				ComUtil.MsgBox("입력내용을 확인해주세요.", "history.back();");
				return;
			}

			SqlConnection conn = DBUtil.GetUserDBConn();
			DataRow dr = DacUser.GameConfig(conn, null);
			DBUtil.CloseDBConn(conn);

			if (dr == null)
			{
				ComUtil.MsgBox("게임설정정보가 없습니다.", "history.back();");
				return;
			}

			int nDurationDay = Convert.ToInt32(dr["mailRetentionDay"]);

			// 연결정보 가져오기 (DB커넥션 포함됨)
			connGame = DBUtil.GetGameDBConn(m_nServerId);
			
			// 서버시간
			DataRow drServerTime = Dac.ServerTime(connGame, null);

			DateTimeOffset dtoServerTime = DateTimeOffset.Parse(drServerTime["serverTime"].ToString());

			// 영웅 전체목록
			DataTable dt = Dac.Heros(connGame, null);

			if (dt == null || dt.Rows.Count == 0)
			{
				ComUtil.MsgBox("우편발송대상이 존재하지 않습니다.", "history.back();");
				return;
			}

			// 발송메일
			DataTable dtMail = new DataTable("t_Mail");
			dtMail.Columns.AddRange(new DataColumn[] {
				new DataColumn{	ColumnName = "mailId", DataType=typeof(Guid), Unique=true, AllowDBNull=false },
				new DataColumn{	ColumnName = "heroId", DataType=typeof(Guid) },
				new DataColumn{	ColumnName = "titleType", DataType=typeof(Int32) },
				new DataColumn{	ColumnName = "title", DataType=typeof(String) },
				new DataColumn{	ColumnName = "contentType", DataType=typeof(Int32) },
				new DataColumn{	ColumnName = "content", DataType=typeof(String) },
				new DataColumn{	ColumnName = "delivered", DataType=typeof(Boolean) },
				new DataColumn{	ColumnName = "deliveryTime", DataType=typeof(DateTimeOffset), AllowDBNull=true },	//NULL
				new DataColumn{	ColumnName = "received", DataType=typeof(Boolean) },
				new DataColumn{	ColumnName = "receiveTime", DataType=typeof(DateTimeOffset), AllowDBNull=true },	//NULL,
				new DataColumn{	ColumnName = "regTime", DataType=typeof(DateTimeOffset) },
				new DataColumn{	ColumnName = "expireTime", DataType=typeof(DateTimeOffset) },
				new DataColumn{	ColumnName = "deleted", DataType=typeof(Boolean) },
				new DataColumn{	ColumnName = "delTime", DataType=typeof(DateTimeOffset), AllowDBNull=true }	//NULL,

			});

			// 첨부파일
			DataTable dtMailAttachment = new DataTable("t_MailAttachment");
			dtMailAttachment.Columns.AddRange(new DataColumn[]{
				new DataColumn{	ColumnName = "mailId", DataType=typeof(Guid), AllowDBNull=false },
				new DataColumn{	ColumnName = "attachmentNo", DataType=typeof(Int32), AllowDBNull=false },
				new DataColumn{	ColumnName = "itemId", DataType=typeof(Int32) },
				new DataColumn{	ColumnName = "itemCount", DataType=typeof(Int32) },
				new DataColumn{	ColumnName = "itemOwned", DataType=typeof(Boolean) }
			});

			int nSendHeroCount = 0;

			DataRow drMail;
			DataRow drMailAttachment;
			Guid mailId = Guid.Empty;

			for (int idx = 0; idx < dt.Rows.Count; idx++)
			{
				if (Convert.ToBoolean(dt.Rows[idx]["deleted"]))
					continue;

				nSendHeroCount++;

				mailId = Guid.NewGuid();
				Guid heroId = Guid.Parse(dt.Rows[idx]["heroId"].ToString());

				drMail = dtMail.NewRow();
				drMail["mailId"] = mailId;
				drMail["heroId"] = heroId;
				drMail["titleType"] = nTitleType;
				drMail["title"] = sTitle;
				drMail["contentType"] = nContentType;
				drMail["content"] = sContent;
				drMail["delivered"] = 0;
				drMail["deliveryTime"] = DBNull.Value;
				drMail["received"] = 0;
				drMail["receiveTime"] = DBNull.Value;
				drMail["regTime"] = dtoServerTime;
				drMail["expireTime"] = dtoServerTime.AddDays(nDurationDay);
				drMail["deleted"] = 0;
				drMail["delTime"] = DBNull.Value;
				dtMail.Rows.Add(drMail);

				// 메일
				if (sAttachment != "")
				{
					string[] sArr = sAttachment.Split('`');
					for (int i = 0; i < sArr.Length; i++)
					{
						string[] sItem = sArr[i].Split('|');
						if (sItem[0] == "2")
						{
							// 아이템
							int nItemId = Convert.ToInt32(sItem[1]);
							int nItemCount = Convert.ToInt32(sItem[3]);
							bool itemOwned = (sItem[2] == "0") ? false : true;

							drMailAttachment = dtMailAttachment.NewRow();
							drMailAttachment["mailId"] = mailId;
							drMailAttachment["attachmentNo"] = (i + 1);
							drMailAttachment["itemId"] = nItemId;
							drMailAttachment["itemCount"] = nItemCount;
							drMailAttachment["itemOwned"] = itemOwned;
							dtMailAttachment.Rows.Add(drMailAttachment);
						}
					}
				}
			}

			tran = connGame.BeginTransaction();

			if (Dac.SqlBulkCopy(connGame, tran, dtMail) != 0)
			{
				tran.Rollback();
				tran.Dispose();
				DBUtil.CloseDBConn(connGame);
				ComUtil.MsgBox("메일 발송에 실패하였습니다.", "history.back();");
				return;
			}

			if (Dac.SqlBulkCopy(connGame, tran, dtMailAttachment) != 0)
			{
				tran.Rollback();
				tran.Dispose();
				DBUtil.CloseDBConn(connGame);
				ComUtil.MsgBox("메일 첨부 발송에 실패하였습니다.", "history.back();");
				return;
			}

			tran.Commit();
			tran.Dispose();

			DBUtil.CloseDBConn(connGame);

			ComUtil.MsgBox(nSendHeroCount + "명의 영웅에게 메일이 발송되었습니다.", "location.href='" + Request.Url.ToString() + "';");
		}
		catch (Exception ex)
		{
			if (tran != null)
			{
				tran.Rollback();
				tran.Dispose();
			}
			if (connGame != null && connGame.State == ConnectionState.Connecting)
				DBUtil.CloseDBConn(connGame);

			Response.Write(ex.StackTrace);

			ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
		}
	}
}