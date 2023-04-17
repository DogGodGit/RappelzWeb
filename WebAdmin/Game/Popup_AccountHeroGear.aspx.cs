using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Game_Popup_AccountHeroGear : System.Web.UI.Page
{
	protected int m_nGameServerId = 0;
	private string m_sAccountHeroGearId = "";

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
		m_sAccountHeroGearId = ComUtil.GetRequestString("AHGID", RequestMethod.Get, "");

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
		
	}

}