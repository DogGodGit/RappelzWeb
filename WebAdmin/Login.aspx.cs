using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //======================================================================
        //브라우저 캐쉬 제거
        //清除浏览器缓存
        //======================================================================
        ComUtil.SetNoBrowserCache();
        CultureInfo ciLang = new CultureInfo(Config.Languages);
        Resources.ResLang.Culture = ciLang;

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
        if (ComUtil.GetUserId() != "")
        {
            Response.Redirect("/");
            return;
        }
        WBtnLogin.Attributes.Add("onclick", "return checkForm();");
    }

    protected void WBtnLogin_OnClick(object sender, EventArgs e)
    {
        try
        {
            string sId = WTxtId.Text.Trim();
            string sPwd = WTxtPwd.Text.Trim();

            if (sId == "")
            {
                ComUtil.MsgBox(ResLang.Login_05, "history.back();");
                return;
            }

            if (sPwd == "")
            {
                ComUtil.MsgBox(ResLang.Login_06, "history.back();");
                return;
            }

			int nAuthority = LoginCheck(sId, sPwd);

			if (nAuthority < 0)
            {
                ComUtil.MsgBox(ResLang.Login_07, "history.back();");
                return;
            }

            //======================================================================
            // Make Login Cookies
            //======================================================================
            HttpCookie hcZeno = new HttpCookie("MNGR");
            hcZeno.Path = "/";
            hcZeno.Domain = Define.S_HOST;

            string sFId = ComUtil.GetHashValue(sId, "E", "1125");
            string sSId = ComUtil.GetHashValue(sId, "E", "5511");
			string sAuthority = ComUtil.GetHashValue(nAuthority.ToString(), "E", "1525");

            hcZeno.Values["FST"] = HttpUtility.UrlEncode(sFId);
            hcZeno.Values["SND"] = HttpUtility.UrlEncode(sSId);
            hcZeno.Values["AUT"] = HttpUtility.UrlEncode(sAuthority);
            Response.Cookies.Add(hcZeno);

            Response.Redirect("/");
        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception ex)
        {
            ComUtil.ErrorLogMsg(ex);
        }
    }

	private int LoginCheck(string sUserId, string sPassword)
    {
		ArrayList arrLogin = new ArrayList();

		string[] sUsers = Config.Users.Split('`');

		for (int i = 0; i < sUsers.Length; i++)
		{
			string[] sUser = sUsers[i].Split('|');

			arrLogin.Add(new LoginInfo(sUser[0], sUser[1], Convert.ToInt32(sUser[2])));
		}

		LoginInfo loginInfo = null;

		for (int i = 0; i < arrLogin.Count; i++)
		{
			loginInfo = (LoginInfo)arrLogin[i];

			if (loginInfo.m_sUserId == sUserId && loginInfo.m_sPassword == sPassword)
				return loginInfo.m_nAuthority;
		}
		return -1;
    }
}

public class LoginInfo
{
	public string m_sUserId;
	public string m_sPassword;
	public int m_nAuthority;

	public LoginInfo(string sUserId, string sPassword, int nAuthority)
	{
		m_sUserId = sUserId;
		m_sPassword = sPassword;
		m_nAuthority = nAuthority;
	}
}