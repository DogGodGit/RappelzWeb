using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Game_AccountHero_MainQuest : System.Web.UI.Page
{
	protected int m_nGameServerId = 0;
	protected Guid m_nHeroId;

    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================
		m_nGameServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
		m_nHeroId = ComUtil.GetRequestGuid("AHID", RequestMethod.Get);

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
		//DB연결
		SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(m_nGameServerId));
		DataRow dr = Dac.Hero(conn, null, m_nHeroId);
		DataRow drMainQuest = Dac.HeroMainQuest_Last(conn, null, m_nHeroId);
		//DB연결끊기
		DBUtil.CloseDBConn(conn);

		if (dr == null)
			return;

		if (!Convert.ToBoolean(dr["created"]))
			WBtnUpdate.Attributes.Add("onclick", "alert('캐릭터가 생성이 완료되지 않았습니다.');return false;");
		else
			WBtnUpdate.Attributes.Add("onclick", "return confirm('설정하시겠습니까?');");
		
		int nNation = Convert.ToInt32(dr["nationId"]);

		//DB연결
		SqlConnection connUser = DBUtil.GetUserDBConn();
		DataTable dt = DacUser.MainQuests(connUser, null, nNation);
		//DB연결끊기
		DBUtil.CloseDBConn(connUser);

		WDDLMainQuest.Items.Add(new ListItem("0 - 초기화됨", "0"));

		for(int i = 0; i < dt.Rows.Count; i++)
			WDDLMainQuest.Items.Add(new ListItem(dt.Rows[i]["mainQuestNo"].ToString() + " - " + dt.Rows[i]["_title"].ToString(), dt.Rows[i]["mainQuestNo"].ToString()));

		if (drMainQuest != null)
		{
			WLtlMainQuestNo.Text = Convert.ToString(drMainQuest["mainQuestNo"]);
			WLtlProgressCount.Text = Convert.ToString(drMainQuest["progressCount"]);
			WLtlCompleted.Text = Convert.ToString(drMainQuest["completed"]);
			WLtlCompletionTime.Text = Convert.ToString(drMainQuest["completionTime"]);
			WLtlRegTime.Text = Convert.ToString(drMainQuest["regTime"]);

			WDDLMainQuest.SelectedValue = Convert.ToString(drMainQuest["mainQuestNo"]);
		}
	}

	protected void WBtnUpdate_OnClick(object sender, EventArgs e)
	{
		try
		{
			int nMainQuestNo = Convert.ToInt32(WDDLMainQuest.SelectedValue);

			//DB연결
			SqlConnection conn = DBUtil.GetGameDBConn(m_nGameServerId);

			// 접속중 체크
			if (Dac.Hero_Connection(conn, null, m_nHeroId) != 0)
			{
				DBUtil.CloseDBConn(conn);
				ComUtil.MsgBox("영웅이 접속중입니다.", "history.back();");
				return;
			}

			// 메인퀘스트 변경.
			int nRet = Biz.ManageHeroMainQuest(conn, m_nHeroId, nMainQuestNo);

			//DB연결 끊기
			DBUtil.CloseDBConn(conn);

			//등록결과
			switch (nRet)
			{
				case 0: ComUtil.MsgBox("메인퀘스트가 설정되었습니다.", "location.href='" + Request.Url.ToString() + "';");
					break;
				default: ComUtil.MsgBox("메인퀘스트 설정 중 오류가 발생하였습니다." + nRet.ToString(), "history.back();");
					break;
			}
		}
		catch (Exception ex)
		{
			ComUtil.MsgBox(String.Format("예외오류 오류내용 : {0}", ex.Message), "history.back();");
		}
	}
}