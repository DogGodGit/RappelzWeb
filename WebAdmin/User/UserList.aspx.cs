using Resources;
using System;
using System.Data;
using System.Data.SqlClient;

public partial class User_UserList : System.Web.UI.Page
{
    protected int nPage = 0;        // 페이지
    private int nTotCnt = 0;        // 전체페이지
    private int nTotPage = 1;       // 전체페이지
    private string sUserId = "";       // 사용자아이디

    private const int N_PG_MX = 10;     //페이지 목록 수
    private const int N_PG_SZ = 10;     //페이징 수
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //======================================================================
        ComUtil.SetNoBrowserCache();

        //======================================================================
        // 파라미터
        //======================================================================
        nPage = ComUtil.GetRequestInt("PG", RequestMethod.Get, 1);
        sUserId = ComUtil.GetRequestString("UID", RequestMethod.Get, "");

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
        // 언어
        WTxtSearch.Text = sUserId;

        WBtnAdd.Attributes.Add("onclick", $"return confirm('{ResLang.UserList_04}');");

        SqlConnection conn = DBUtil.GetUserDBConn();
        DataTable dt = DacUser.GetUserList(conn, null, sUserId, N_PG_MX, nPage, out nTotCnt);
        DBUtil.CloseDBConn(conn);

        WRptList.DataSource = dt;
        WRptList.DataBind();
        WRptList.Dispose();

        if (sUserId != "")
            WLtlSearchResult.Text = string.Format(ResLang.UserList_05, sUserId, nTotCnt);

        nTotPage = (nTotCnt - 1) / N_PG_MX + 1;

        if (nTotCnt > 0 && nTotPage < nPage)
            nPage = nTotPage;

        //======================================================================
        // 페이징
        //======================================================================
        WPageNavigator.PageCount = nTotPage;
        WPageNavigator.CurrentPage = nPage;
        WPageNavigator.UrlParam = String.Format("UID={0}", sUserId);
        WPageNavigator.PageListSize = N_PG_SZ;
        WPageNavigator.FirstPageItem = ResLang.UserList_06;
        WPageNavigator.PrevPageItem = ResLang.UserList_07;
        WPageNavigator.SeparateItem = " &nbsp;|&nbsp; ";
        WPageNavigator.NextPageItem = ResLang.UserList_08;
        WPageNavigator.LastPageItem = ResLang.UserList_09;
        WPageNavigator.SNumberDecoLeft = "<span>";
        WPageNavigator.SNumberDecoRight = "</span>";
        WPageNavigator.Dispose();
    }

    protected void WBtnSearch_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/User/UserList.aspx?UID=" + WTxtSearch.Text.Trim());
    }

    protected void WBtnAdd_OnClick(object sender, EventArgs e)
    {
        //게스트사용자 등록
        string sSecret = Util.CreateUserSecret();
        string sAccessSecret = Util.CreateCode(Util.kAccessSecret_MaxLength);

        int nRet = 0;
        int nType = Define.kUserType_Guest;  // 게스트사용자
		Guid uidNewUserId;
	
        SqlConnection conn = null;
        try
        {
            conn = DBUtil.GetUserDBConn();
			uidNewUserId = Guid.NewGuid();

			nRet = Biz.AddUserId(conn, uidNewUserId, nType, sSecret, sAccessSecret);
                if (nRet != 0)
                {
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox("USER_USERLIST_ADD_FAIL");
                    return;
                }
                else
                {
                    DBUtil.CloseDBConn(conn);
                    ComUtil.MsgBox(String.Format(ResLang.UserList_10, uidNewUserId), "location.href='/User/UserList.aspx';");
                    return;
                }
            DBUtil.CloseDBConn(conn);
           // ComUtil.MsgBox("계정생성 3회 실패", "history.back();");
        }
        catch (Exception ex)
        {
            if (conn != null && conn.State == ConnectionState.Connecting)
            {
                DBUtil.CloseDBConn(conn);
            }
        }
    }

    protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
            case "type":
                switch (Convert.ToInt32(ComUtil.GetDataItem(objData, sFieldNm)))
                {
                    case Define.kUserType_Guest: sRtn = ResLang.UserList_11;
                        break;
                    case Define.kUserType_Facebook: sRtn = ResLang.UserList_12;
                        break;
                    case Define.kUserType_Google: sRtn = ResLang.UserList_13;
                        break;
                    case Define.kUserType_Entermate: sRtn = ResLang.UserList_14;
                        break;
                    default: sRtn = ResLang.UserList_15;
                        break;
                }
                break;
            case "regTime":
                sRtn = DateTime.Parse(ComUtil.GetDataItem(objData, sFieldNm)).ToString("yyyy-MM-dd HH:mm:ss.fff");
                break;
            case "deleted":
                if (Boolean.Parse(ComUtil.GetDataItem(objData, sFieldNm)))
                    sRtn = ResLang.UserList_16;
                else
                    sRtn = ResLang.UserList_17;
                break;
			case "accessToken":
				UserAccessToken token = new UserAccessToken(Guid.Parse(ComUtil.GetDataItem(objData, "userId")), ComUtil.GetDataItem(objData, "accessSecret"), UserAccessToken.GetCheckCode(Guid.Parse(ComUtil.GetDataItem(objData, "userId")), ComUtil.GetDataItem(objData, "accessSecret")));
				
				sRtn = "<input type=\"text\" value='" + token.ToString().Replace("\"", "\\\"") + "' />";
				break;
            default:
                sRtn = ComUtil.GetDataItem(objData, sFieldNm);
                break;
        }
        return sRtn;
    }
}