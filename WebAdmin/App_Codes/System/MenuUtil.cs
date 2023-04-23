using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// MenuUtil의 요약 설명입니다.
/// </summary>
public class MenuUtil
{
	public static List<Menu> m_menus;

	public MenuUtil()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

	public static List<Menu> GetMenu()
	{
		if (m_menus != null)
			return m_menus;

		m_menus = new List<Menu>();

		Menu menu;

		// 관리형 메뉴
		menu = new Menu("ManageMenu");
		menu.AddSubMenu(new SubMenu("Default", "/Default.aspx", 0, false));
		menu.AddSubMenu(new SubMenu("AccountHero", "/Game/AccountHero.aspx", 5, false));
		menu.AddSubMenu(new SubMenu("Sub_MenuSetting", "/Game/Sub_MenuSetting.aspx", 5, false));
		m_menus.Add(menu);

		// 디스플레이형 메뉴
		menu = new Menu(Resources.ResLang.MenuUtil_01);	//사용자
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_01_001, "/User/UserList.aspx", 5));	//사용자
        //menu.AddSubMenu(new SubMenu("사용자 제재", "/User/UserBlock.aspx", 5));	//사용자 차단
		m_menus.Add(menu);

		menu = new Menu(Resources.ResLang.MenuUtil_02);	//게임
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_001, "/Game/HeroList.aspx", 5));	//영웅
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_002, "/Game/AssetBundleList.aspx", 5));	//어셋번들
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_003, "/Game/MenuSetting.aspx", 5));	//메뉴설정
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_004, "/Game/Mail.aspx", 5));	//우편
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_005, "/Game/MailAll.aspx", 5));	//우편
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_006, "/Game/Development.aspx", 5));	//우편
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_007, "/Game/Notice_Server.aspx", 5));	//인게임 공지
        //menu.AddSubMenu(new SubMenu("공지팝업", "/Game/ShopPurchaseProduct.aspx", 5)); //공지팝업
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_008, "/Game/TimeDesignationEvent.aspx", 5)); 
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_009, "/Game/ChargePurchaseProduct.aspx", 5));
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_02_010, "/Game/DiaShop.aspx", 5)); 
		m_menus.Add(menu);

		menu = new Menu(Resources.ResLang.MenuUtil_03);	//설정
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_001, "/Setting/SystemSetting.aspx", 5));	//시스템
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_006, "/Setting/GameServerRegion.aspx", 5));	//게임서버지역
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_007, "/Setting/GameServerGroup.aspx", 5));	//게임서버그룹
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_002, "/Setting/GameServerList.aspx", 5));	//게임서버
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_008, "/Setting/GameServerAccess.aspx", 5));	//게임서버 접속관리
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_003, "/Setting/Languages.aspx", 5));	//언어 관리
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_009, "/Setting/CouponSystem.aspx", 5)); //쿠폰
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_004, "/Setting/WhiteIp.aspx", 5));	//화이트 IP
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_010, "/Setting/BlackIp.aspx", 5));	//블랙 IP
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_005, "/Setting/GameSystem.aspx", 5));	//게임시스템
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_011, "/Setting/SharingEvents/SharingEvent.aspx", 5));
        menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_03_012, "/Setting/ClientText.aspx", 5));
        m_menus.Add(menu);

		menu = new Menu(Resources.ResLang.MenuUtil_04);	//도구
		menu.AddSubMenu(new SubMenu(Resources.ResLang.MenuUtil_04_001, "/Tools/ClientTextView.aspx", 5));	//클라이언트 텍스트 확인

        menu = new Menu("Logs");
        menu.AddSubMenu(new SubMenu("결제로그", "/Log/PurchaseAllLog.aspx", 5));//로그

        m_menus.Add(menu);

		return m_menus;
	}

	public static bool IsAuthority(string sUrl)
	{
		int nAuthority = ComUtil.GetAuthority();

		// 관리자는 모든 권한
		if (nAuthority == 9)
			return true;

		GetMenu();

		foreach (Menu menu in m_menus)
		{
			foreach (SubMenu submenu in menu.m_subMenus)
			{
				if (submenu.m_sUrl.ToLower() == sUrl.ToLower() && nAuthority >= submenu.m_nRequiredAuthority)
					return true;
			}
		}

		return false;
	}
}

public class Menu
{
	public string m_sName;
	public List<SubMenu> m_subMenus = new List<SubMenu>();

	public Menu(string sName)
	{
		m_sName = sName;
	}

	public void AddSubMenu(SubMenu subMenu)
	{
		m_subMenus.Add(subMenu);
	}
}

public class SubMenu
{
	public string m_sName;
	public string m_sUrl;
	public int m_nRequiredAuthority;
	public bool m_display;

	public SubMenu(string sName, string sUrl, int nAuthority, bool display)
	{
		m_sName = sName;
		m_sUrl = string.Format("http://{0}{1}", Define.S_HOST, sUrl);
		m_nRequiredAuthority = nAuthority;
		m_display = display;
	}

	public SubMenu(string sName, string sUrl, int nAuthority)
	{
		m_sName = sName;
		m_sUrl = string.Format("http://{0}{1}", Define.S_HOST, sUrl);
		m_nRequiredAuthority = nAuthority;
		m_display = true;
	}
}