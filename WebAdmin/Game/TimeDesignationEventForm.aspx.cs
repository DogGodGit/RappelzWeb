using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;


public partial class Game_TimeDesignationEventForm : System.Web.UI.Page
{
    private string m_sEventName = "";
    private string m_sStartTime = "";
    private string m_sEndTime = "";
    protected int m_nPage = 0;              // 페이지
    private int m_nServerId = 0;
    private int m_nEventId = 0;
    private int m_nState = 0;
    protected string m_sVisibleString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //======================================================================
        ComUtil.SetNoBrowserCache();

        //======================================================================
        //다국어 변환
        //======================================================================

        //======================================================================
        // 파라미터
        //======================================================================

        m_nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
        m_sEventName = ComUtil.GetRequestString("NM", RequestMethod.Get, "");
        m_sStartTime = ComUtil.GetRequestString("ST", RequestMethod.Get, "");
        m_sEndTime = ComUtil.GetRequestString("ET", RequestMethod.Get, "");
        m_nEventId = ComUtil.GetRequestInt("CID", RequestMethod.Get, 0);
        m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_nState = ComUtil.GetRequestInt("STT", RequestMethod.Get, 0);

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

        WBtnAddTimeEvent.Text = "이벤트등록";
        WBtnAddTimeEvent.Attributes.Add("onclick", "return sendMail();");
        eventTitle.InnerText = "접속자 우편발송";

        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        // 게임목록 조회
        DataTable sdt = DacUser.GameServerAll(conn, null);

        WDDLServer.Items.Add(new ListItem("== " + "서버선택" + " ==", "0"));

        DataRowCollection drc = sdt.Rows;
        for (int i = 0; i < drc.Count; i++)
            WDDLServer.Items.Add(new ListItem(drc[i]["displayName"].ToString(), drc[i]["serverId"].ToString()));

        if (m_nServerId == 0)
            return;
        WDDLServer.SelectedValue = m_nServerId.ToString();

        int nSelectedserverId = -1;

        foreach (DataRow dr in drc)
        {
            if (!Convert.ToBoolean(dr["deleted"]))
            {
                nSelectedserverId = Convert.ToInt32(dr["serverId"]);
                break;
            }
        }
        if (nSelectedserverId == -1)
        {
            ComUtil.MsgBox("게임 서버가 존재하지 않습니다.", "history.back();");
            return;
        }

        // 아이템 조회
        DataTable dtItems = DacUser.ItemReward(conn, null);

        DataRow drEvent = null;
        DataTable drEventItems = null;

        //이름클릭해서 왔을경우(수정페이지)
        if (m_nEventId > 0)
        {
            drEvent = DacUser.TimeDesignationEvent(conn, null, m_nEventId);

            if (drEvent == null)
            {
                ComUtil.MsgBox("프로모션 정보가 존재하지 않습니다.", "history.back();");
                DBUtil.CloseDBConn(conn);
                return;
            }
            drEventItems = DacUser.TimeDesignationEventRewards(conn, null, m_nEventId);
        }
        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        // 아이템 선택 컨트롤 채우기
        for (int i = 0; i < dtItems.Rows.Count; i++)
            WDDLItem.Items.Add(new ListItem("" + dtItems.Rows[i]["itemId"].ToString() + " " + dtItems.Rows[i]["_description"].ToString()+"("+ dtItems.Rows[i]["itemCount"].ToString() + ")", dtItems.Rows[i]["itemRewardId"].ToString()));

        //임시시간표시
        WTxtStartTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now);
        WTxtEndTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now);

        // 제목,내용 타입 선택 컨트롤 채우기
        WDDLTitleType.Items.Add(new ListItem("일반텍스트", "1"));
        WDDLTitleType.Items.Add(new ListItem("스트링키", "2"));
        WDDLContentType.Items.Add(new ListItem("일반텍스트", "1"));
        WDDLContentType.Items.Add(new ListItem("스트링키", "2"));

        ItemNames.Visible = false;

        if (m_nEventId > 0)
        {
            eventTitle.InnerText = "접속자 우편발송 - 수정";
            ItemNames.Visible = true;
            WBtnAddTimeEvent.Attributes.Add("onclick", string.Format("return confirm('{0}');", "변경된 정보로 수정하시겠습니까?"));
            WBtnAddTimeEvent.Text = "수정하기";

            WTxtName.Text = drEvent["_name"].ToString();
            WTxtStartTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(drEvent["startTime"].ToString()));
            WTxtEndTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Parse(drEvent["endTime"].ToString()));
            WDDLTitleType.SelectedValue = drEvent["mailTitleType"].ToString();
            WTxtMailTitle.Text = drEvent["mailTitle"].ToString();
            WDDLContentType.SelectedValue = drEvent["mailContentType"].ToString();
            WTxtMailContent.Text = drEvent["mailContent"].ToString();
            m_sVisibleString = "display:none;";

            WTxtName.Enabled = false;
            WRptList.DataSource = drEventItems;
            WRptList.DataBind();

            //목록버튼
            WLtlList.Text = "<input type=\"button\"" + "value=\"" + "목록" + "\" class=\"button\" onclick=\"location.href='/Game/TimeDesignationEvent.aspx?SVR=" + m_nServerId + "';\" />";
        }
    }
    protected void WDDLServer_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/Game/TimeDesignationEventForm.aspx?SVR=" + WDDLServer.SelectedValue);
    }

    protected void WBtnAddTimeEvent_OnClick(object sender, EventArgs e)
    {
        if (m_nEventId > 0)
        {
            string sStartTime = WTxtStartTime.Text.Trim();
            string sEndTime = WTxtEndTime.Text.Trim();
            string m_sEventName = WTxtName.Text.Trim();
            int nMailTitleType = Convert.ToInt32(WDDLTitleType.SelectedValue);
            string sMailTitle = WTxtMailTitle.Text.Trim();
            int nMailContentType = Convert.ToInt32(WDDLContentType.SelectedValue);
            string sMailContent = WTxtMailContent.Text.Trim();

            DateTime dtStartTime;
            DateTime dtEndTime;

            // 값 체크
            if (sStartTime == "" || sEndTime == "" || !DateTime.TryParse(sStartTime, out dtStartTime) || !DateTime.TryParse(sEndTime, out dtEndTime) || sMailTitle == "" || sMailContent == "" || DateTime.Compare(dtStartTime, dtEndTime) > -1)
            {
                ComUtil.MsgBox("입력하신 내용을 다시 확인해주세요.");
                return;
            }

            // DB연결
            SqlConnection conn = DBUtil.GetUserDBConn();
            SqlTransaction tran = conn.BeginTransaction();

            // 이벤트리스트 수정
            int nRetVal = DacUser.UpdateTimeDesignationEvent(conn, tran, m_nEventId, m_sEventName, nMailTitleType, sMailTitle, nMailContentType, sMailContent, dtStartTime, dtEndTime);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);

                ComUtil.MsgBox("수정에 실패하였습니다.", "history.back();");
                return;
            }

            // 트랜잭션 정리
            tran.Commit();
            tran.Dispose();
            // DB연결해제
            DBUtil.CloseDBConn(conn);
            ComUtil.MsgBox("수정되었습니다.", "location.href='" + Request.Url.ToString() + "';");
            return;
        }
        else
        {
            string sStartTime = WTxtStartTime.Text.Trim();
            string sEndTime = WTxtEndTime.Text.Trim();
            string m_sEventName = WTxtName.Text.Trim();
            int nMailTitleType = Convert.ToInt32(WDDLTitleType.SelectedValue);
            string sMailTitle = WTxtMailTitle.Text.Trim();
            int nMailContentType = Convert.ToInt32(WDDLContentType.SelectedValue);
            string sMailContent = WTxtMailContent.Text.Trim();
            string sAttachment = WHFMailAttachment.Value;

            DateTime dtStartTime;
            DateTime dtEndTime;

            // 값 체크
            
            if (sStartTime == "" || sEndTime == "" || !DateTime.TryParse(sStartTime, out dtStartTime) || !DateTime.TryParse(sEndTime, out dtEndTime) || sMailTitle == "" || sMailContent == "" || DateTime.Compare(dtStartTime, dtEndTime) > -1)
            {
                ComUtil.MsgBox(sStartTime+","+ sStartTime + "값이 존재하지 않습니다~.");
                return;
            }
            
            // DB연결
            SqlConnection conn = DBUtil.GetUserDBConn();
            SqlTransaction tran = conn.BeginTransaction();

            int nRetVal = DacUser.AddTimeDesignationEvent(conn, tran, m_sEventName, nMailTitleType, sMailTitle, nMailContentType, sMailContent, dtStartTime, dtEndTime, out m_nEventId);

            if (nRetVal != 0)
            {
                tran.Rollback();
                tran.Dispose();
                DBUtil.CloseDBConn(conn);

                ComUtil.MsgBox("프로모션 등록에 실패하였습니다.", "history.back();");
                return;
            }

            // 이벤트 아이템 등록
            if (sAttachment != "")
            {
                string[] sArr = sAttachment.Split('`'); //2|1`2|420103
                for (int i = 0; i < sArr.Length; i++)
                {
                    string[] sItem = sArr[i].Split('|');
                    if (sItem[0] == "2")
                    {
                        // 아이템
                        nRetVal = DacUser.AddTimeDesignationEventReward(conn, tran, m_nEventId, i + 1, Convert.ToInt64(sItem[1]) );

                        if (nRetVal != 0)
                        {
                            tran.Rollback();
                            tran.Dispose();
                            DBUtil.CloseDBConn(conn);

                            ComUtil.MsgBox("프로모션 아이템 등록에 실패하였습니다2.", "history.back();");
                            return;
                        }
                    }
                }
            }
            // 트랜잭션 정리
            tran.Commit();
            tran.Dispose();
            // DB연결해제
            DBUtil.CloseDBConn(conn);
        }
        Response.Redirect("/Game/TimeDesignationEvent.aspx?SVR=" + WDDLServer.SelectedValue);
    }

    protected void WRptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal WLtlItemName = (Literal)e.Item.FindControl("WLtlItemName");

            if (Convert.ToBoolean(ComUtil.GetDataItem(e.Item.DataItem, "itemOwned")))
                WLtlItemName.Text = "<img src=\"/Common/Images/ico_lock.png\" width=\"10\" height=\"10\" align=\"absmiddle\">"; 
            else
                WLtlItemName.Text = "<img src=\"/Common/Images/_blank.gif\" width=\"10\" height=\"10\" align=\"absmiddle\">"; 
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }
        return sRtn;
    }
}