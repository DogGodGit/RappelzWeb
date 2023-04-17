using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_Mail : System.Web.UI.Page
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

		WDDLType.Items.Add(new ListItem("닉네임", "1"));
		WDDLType.Items.Add(new ListItem("영웅ID", "2"));

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
		Response.Redirect("/Game/Mail.aspx?SVR=" + WDDLServer.SelectedValue);
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
			int nType = Convert.ToInt32(WDDLType.SelectedValue);
			string sTargetIds = WTxtTarget.Text.Trim();
			int nTitleType = Convert.ToInt32(WDDLTitleType.SelectedValue);
			string sTitle = WTxtMailTitle.Text.Trim();
			int nContentType = Convert.ToInt32(WDDLContentType.SelectedValue);
			string sContent = WTxtMailContent.Text.Trim();

			string sAttachment = WHFMailAttachment.Value;

			if (sTargetIds == "" || sTitle == "" || sContent == "")
			{
				ComUtil.MsgBox("입력내용을 확인해주세요.", "history.back();");
				return;
			}

			// 대상 정리
			string[] sSplit = sTargetIds.Replace("\r", "").Split('\n');

			for (int i = 0; i < sSplit.Length; i++)
				if(sSplit[i].Trim() != "")
					sSplit[i] = string.Format("'{0}'", sSplit[i].Trim());
			
			sTargetIds = string.Join(",", sSplit);

			SqlConnection conn = DBUtil.GetUserDBConn();
			DataRow dr = DacUser.GameConfig(conn, null);
			DBUtil.CloseDBConn(conn);

			if(dr == null)
			{
				ComUtil.MsgBox("게임설정정보가 없습니다.", "history.back();");
				return;
			}

			int nDurationDay = Convert.ToInt32(dr["mailRetentionDay"]);

			// 연결정보 가져오기 (DB커넥션 포함됨)
			connGame = DBUtil.GetGameDBConn(m_nServerId);

			DataTable dt = Dac.HeroSearchTargets(connGame, null, nType, sTargetIds);

			if (dt == null || dt.Rows.Count == 0)
			{
				ComUtil.MsgBox("우편발송대상이 존재하지 않습니다.", "history.back();");
				return;
			}

			int nSendHeroCount = 0;
			int nSendMailCount = 0;

			tran = connGame.BeginTransaction();

			for (int idx = 0; idx < dt.Rows.Count; idx++)
			{
				if (Convert.ToBoolean(dt.Rows[idx]["deleted"]))
					continue;

				nSendHeroCount++;

				Guid heroId = Guid.Parse(dt.Rows[idx]["heroId"].ToString());

                // 메일발송
                Guid mailId = Guid.NewGuid();

                int nRet = Dac.AddMail(connGame, tran, mailId, heroId, nTitleType, sTitle, nContentType, sContent, nDurationDay);
                
                if (nRet != 0)
                {
                    tran.Rollback();
                    tran.Dispose();
                    DBUtil.CloseDBConn(connGame);

                    ComUtil.MsgBox("메일 발송에 실패하였습니다.", "history.back();");
                    return;
                }
			
				if (sAttachment != "")
				{
					string[] sArr = sAttachment.Split('`');
					for (int i = 0; i < sArr.Length; i++)
					{
						string[] sItem = sArr[i].Split('|');
                        int nAttachmentNo = i + 1;
						if (sItem[0] == "2")
						{

							// 아이템
							bool itemOwned = (sItem[2] == "0") ? false : true;
                            if (Dac.AddMailAttachment(connGame, tran, mailId, nAttachmentNo, Convert.ToInt32(sItem[1]), Convert.ToInt32(sItem[3]), itemOwned) != 0)
							{
								tran.Rollback();
								tran.Dispose();
								DBUtil.CloseDBConn(connGame);

								ComUtil.MsgBox("메일 발송에 실패하였습니다.", "history.back();");
								return;
							}

							nSendMailCount++;
						}
					}
				}
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