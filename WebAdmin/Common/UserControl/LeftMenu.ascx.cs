using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Common_UserControl_LeftMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 계정 정보가 선택되어있으면 캐릭터 메뉴 표시
        
        int nDiv = ComUtil.GetRequestInt("DIV", RequestMethod.Get, 1);
		
		DisplayMenu();
    }

	private void DisplayMenu()
	{
		int nAuthority = ComUtil.GetAuthority();

		// 권한이 없으면 메뉴는 보이지 않는다.
		if (nAuthority < 0)
			return;

		List<Menu> menus = MenuUtil.GetMenu();

		StringBuilder sb = new StringBuilder();
		StringBuilder sbSubmenu = new StringBuilder();

		sb.AppendLine("<ul>");

		foreach (Menu menu in menus)
		{
			sbSubmenu.Clear();

			foreach (SubMenu submenu in menu.m_subMenus)
			{
				if (submenu.m_display && nAuthority >= submenu.m_nRequiredAuthority)
					sbSubmenu.AppendLine(string.Format("<li class=\"submenu\"><a href=\"{0}\">{1}</a></li>", submenu.m_sUrl, submenu.m_sName));
			}

			if (sbSubmenu.Length > 0)
			{
				sb.AppendLine(string.Format("<li class=\"menu\">{0}</li>", menu.m_sName));
				sb.AppendLine(sbSubmenu.ToString());
			}
		}

		sb.AppendLine("</ul>");

		WLtlLeftMenu.Text = sb.ToString();
		sb.Clear();
		sbSubmenu.Clear();
	}
}