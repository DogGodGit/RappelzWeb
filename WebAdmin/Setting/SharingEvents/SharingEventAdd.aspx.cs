using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Setting_SharingEvents_SharingEventAdd : System.Web.UI.Page
{
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

        WTxtStartTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now);
        WTxtEndTime.Text = DateTimeUtil.ToDateTimeString(DateTime.Now);

        SetType(WDDLContetType, WDDLMailContentType, WDDLMailTitleType);
        SetRewardRange(WDDLRewardRange);

    }

    private void SetType(DropDownList ddl, DropDownList ddl2, DropDownList ddl3)
    {
        ddl.Items.Add(new ListItem("일반텍스트", "1"));
        ddl.Items.Add(new ListItem("스트링키", "2"));

        ddl2.Items.Add(new ListItem("일반텍스트", "1"));
        ddl2.Items.Add(new ListItem("스트링키", "2"));

        ddl3.Items.Add(new ListItem("일반텍스트", "1"));
        ddl3.Items.Add(new ListItem("스트링키", "2"));
    }

    private void SetRewardRange(DropDownList ddl)
    {
        ddl.Items.Add(new ListItem("모두", "1"));
        ddl.Items.Add(new ListItem("초대한 사람", "2"));
        ddl.Items.Add(new ListItem("초대 받은사람", "3"));
        ddl.Items.Add(new ListItem("없음", "4"));
    }

    protected void WBtnAddSharingEvent_OnClick(object sender, EventArgs e)
    {
        int nEventId = Convert.ToInt32(WTxtEventId.Text.Trim());
        int nContentType = Convert.ToInt32(WDDLContetType.SelectedValue);
        string sContent = WTxtContent.Text.Trim();
        int nRewardRange = Convert.ToInt32(WDDLRewardRange.SelectedValue);
        int nRewardLimitCount = Convert.ToInt32(WTxtRewardLimitCount.Text.Trim());

        string sStartTime = WTxtStartTime.Text.Trim();
		string sEndTime = WTxtEndTime.Text.Trim();

        int nTargetLevel = Convert.ToInt32(WTxtTargetLevel.Text.Trim());
        int nRewardMailTitleType = Convert.ToInt32(WDDLMailTitleType.SelectedValue);
        string sRewardMailTitle = WTxtMailTitle.Text.Trim();
        int nRewardMailContentType = Convert.ToInt32(WDDLMailContentType.SelectedValue);
        string sRewardMailContent = WTxtMailContent.Text.Trim();
        string sImageName = WTxtImageName.Text.Trim();

        //값 체크
        if (nEventId <= 0)
        {
            ComUtil.MsgBox("0이하의 값은 설정할 수 없습니다.");
            return;
        }

        DateTime dtStartTime;
        DateTime dtEndTime;

        // 값 체크
        if (sStartTime == "" || sEndTime == "" || !DateTime.TryParse(sStartTime, out dtStartTime) || !DateTime.TryParse(sEndTime, out dtEndTime) || sRewardMailTitle == "" || sRewardMailContent == "" || DateTime.Compare(dtStartTime, dtEndTime) > -1)
        {
            ComUtil.MsgBox(Resources.ResLang.CouponPopup_cs_txt_04);
            return;
        }

        // 유저DB연결
        SqlConnection conn = DBUtil.GetUserDBConn();

        SqlTransaction tran = conn.BeginTransaction();

        // 공유하기 이벤트 등록
        int nRetVal = DacUser.AddSharingEvents(conn, tran, nEventId, nContentType, sContent, nRewardRange, nRewardLimitCount, nTargetLevel, dtStartTime, dtEndTime, nRewardMailTitleType, sRewardMailTitle, nRewardMailContentType, sRewardMailContent, sImageName);

        if (nRetVal != 0)
        {
            tran.Rollback();
            tran.Dispose();
            DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox("등록에 실패하였습니다.", "history.back();");
            return;
        }
        // 트랜잭션 정리
        tran.Commit();
        tran.Dispose();

        // DB연결해제
        DBUtil.CloseDBConn(conn);

        ComUtil.MsgBox("작업성공", "location.href='/Setting/SharingEvents/SharingEvent.aspx';");

    }
}