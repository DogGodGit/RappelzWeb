using System;
using System.Data.SqlClient;
using System.Data;

public partial class Game_Hero_Stat : System.Web.UI.Page
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
        WBtnUpdate.Text = "수정내용 적용";
        // 값 체크
        if (m_nServerId < 1 || m_heroId.Equals(""))
        {
            ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
            return;
        }

        // 버튼 속성 추가
        WTxtStatStrength.Attributes.Add("onkeyup", "validate();");
        WTxtStatAgility.Attributes.Add("onkeyup", "validate();");
        WTxtStatStamina.Attributes.Add("onkeyup", "validate();");
        WTxtStatIntelligence.Attributes.Add("onkeyup", "validate();");
        WBtnUpdate.Attributes.Add("onclick", "return validateForm();");
        WTxtStatPoint.Attributes.Add("ReadOnly", "ReadOnly");

        // 연결정보 가져오기 (DB커넥션 포함됨)
        string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

        // DB연결
        SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

        // 계정영웅 조회
        DataTable dt = Dac.Heros_Search(conn, null, Define.kHeroSearchType_heroId, m_heroId.ToString());

        // DB연결 해제
        DBUtil.CloseDBConn(conn);

        if (dt == null || dt.Rows.Count < 1)
        {
            ComUtil.MsgBox("잘못된 접근입니다.", "history.back();");
            return;
        }

        DataRow drHero = dt.Rows[0];
        dt.Dispose();

        // 계정정보 설정
        //WTxtMaxHp.Text = drHero["maxHp"].ToString();
        //WTxtPhysicalOffense.Text = drHero["physicalOffense"].ToString();
        //WTxtMagicalOffense.Text = drHero["magicalOffense"].ToString();
        //WTxtPhysicalDefense.Text = drHero["physicalDefense"].ToString();
        //WTxtMagicalDefense.Text = drHero["magicalDefense"].ToString();
        //WTxtAccuracy.Text = drHero["accuracy"].ToString();
        //WTxtDodge.Text = drHero["dodge"].ToString();
        //WTxtCritical.Text = drHero["critical"].ToString();
        //WTxtBlock.Text = drHero["block"].ToString();
        //WTxtAttackSpeed.Text = drHero["attackSpeed"].ToString();
        //WTxtMoveSpeed.Text = drHero["moveSpeed"].ToString();

        WTxtStatStrength.Text = drHero["statStrength"].ToString();
        WTxtStatAgility.Text = drHero["statAgility"].ToString();
        WTxtStatStamina.Text = drHero["statStamina"].ToString();
        WTxtStatIntelligence.Text = drHero["statIntelligence"].ToString();
        WTxtStatPoint.Text = drHero["statPoint"].ToString();
        WTxtStrength.Text = drHero["strength"].ToString();
        WTxtAgility.Text = drHero["agility"].ToString();
        WTxtStamina.Text = drHero["stamina"].ToString();
        WTxtIntelligence.Text = drHero["intelligence"].ToString();

        WHFStatStrength.Value = drHero["statStrength"].ToString();
        WHFStatAgility.Value = drHero["statAgility"].ToString();
        WHFStatStamina.Value = drHero["statStamina"].ToString();
        WHFStatIntelligence.Value = drHero["statIntelligence"].ToString();
        WHFStatPoint.Value = drHero["statPoint"].ToString();
    }

    protected void WBtnUpdate_OnClick(object sender, EventArgs e)
    {
        try
        {
            int nStatStrength = Convert.ToInt32(WTxtStatStrength.Text.Trim());
            int nStatAgility = Convert.ToInt32(WTxtStatAgility.Text.Trim());
            int nStatStamina = Convert.ToInt32(WTxtStatStamina.Text.Trim());
            int nStatIntelligence = Convert.ToInt32(WTxtStatIntelligence.Text.Trim());
            int nStatPoint = Convert.ToInt32(WTxtStatPoint.Text.Trim());
            int nStrength = Convert.ToInt32(WTxtStrength.Text.Trim());
            int nAgility = Convert.ToInt32(WTxtAgility.Text.Trim());
            int nStamina = Convert.ToInt32(WTxtStamina.Text.Trim());
            int nIntelligence = Convert.ToInt32(WTxtIntelligence.Text.Trim());

            // 연결정보 가져오기 (DB커넥션 포함됨)
            string sConnectionString = DataUtil.GetGameServerConnectionString(m_nServerId);

            // DB연결
            SqlConnection conn = DBUtil.GetGameDBConn(sConnectionString);

            // 접속중 체크
            if (Dac.Hero_Connection(conn, null, m_heroId) != 0)
            {
                DBUtil.CloseDBConn(conn);
                ComUtil.MsgBox("유저가 접속중인 상태에서는 정보가 수정되지 않습니다.", "history.back();");
                return;
            }

            // 계정영웅 수정 - 스탯
            int nRet = Dac.UpdateHero_Stat(conn, null, m_heroId, nStatStrength, nStatAgility, nStatStamina, nStatIntelligence, nStatPoint, nStrength, nAgility, nStamina, nIntelligence);

            // DB 연결 해제
            DBUtil.CloseDBConn(conn);

            if (nRet != 0)
            {
                ComUtil.MsgBox(string.Format("{0} \\n{1}(" + nRet.ToString() + ")", "history.back();", "적용에 실패하였습니다.", "오류코드"));
                return;
            }
            ComUtil.MsgBox("적용되었습니다.", "location.href='" + Request.Url.ToString() + "';");
        }
        catch (Exception ex)
        {
            ComUtil.MsgBox(String.Format("{0} \\n{1} : {0}", "시스템 예외가 발생하였습니다.", "오류코드", ex.Message), "history.back();");
        }
    }
}