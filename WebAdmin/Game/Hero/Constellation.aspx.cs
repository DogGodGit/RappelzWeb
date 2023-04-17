using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Game_Hero_Constellation : System.Web.UI.Page
{
    protected int m_nServerId;
    protected Guid m_heroId;

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
        m_nServerId = ComUtil.GetRequestInt("SVR", RequestMethod.Get, 0);
        m_heroId = Guid.Parse(ComUtil.GetRequestString("HID", RequestMethod.Get, Guid.Empty.ToString()));

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

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 별자리 조회
        DataTable dtConstellations = Dac.AccountHeroConstellations(conn, null, m_heroId);

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        WRptStar.DataSource = dtConstellations;
        WRptStar.DataBind();

    }

    protected void WRptStar_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Button btnUpdate = (Button)e.Item.FindControl("WBtnUpdate");
            btnUpdate.Attributes.Add("onclick", string.Format("return confirm('{0}');", "변경된 정보로 수정하시겠습니까?"));
            btnUpdate.Text = "수정";
        }
    }
    protected void WRptStar_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = null;
        int nRet = 0;

        try
        {
            int nConstellationId = Convert.ToInt32(e.CommandArgument.ToString());
            int nStep = Convert.ToInt32(((Literal)e.Item.FindControl("WLtlSteb")).Text.Trim());
            int nCycle = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtCycle")).Text.Trim());
            int nEntryId = Convert.ToInt32(((TextBox)e.Item.FindControl("WTxtEntryId")).Text.Trim());

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            conn = DBUtil.GetGameDBConn(sConnectionString);

            switch (e.CommandName)
            {
                case "update":
                    nRet = Dac.AccountHeroConstellationStepEntryReset(conn, null, m_heroId, nConstellationId, nStep, nCycle, nEntryId);
                    break;
                default:
                    nRet = 3;
                    break;
            }

            DBUtil.CloseDBConn(conn);

            switch (nRet)
            {
                case 0:
                    ComUtil.MsgBox("작업성공", "location.href='" + Request.Url.ToString() + "';");
                    break;
                case 1:
                    ComUtil.MsgBox("작업실패(별자리항목삭제)", "history.back();");
                    break;
                case 2:
                    ComUtil.MsgBox("작업실패(별자리항목등록)", "history.back();");
                    break;
                default:
                    ComUtil.MsgBox(string.Format("{0}(" + nRet.ToString() + ")", "history.back();", "잘못된 접근입니다."));
                    break;
            }
        }
        catch (Exception ex)
        {
            if (conn != null)
                DBUtil.CloseDBConn(conn);

            ComUtil.MsgBox(String.Format("{0} {1}", "예외발생", ex.Message), "history.back();");
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