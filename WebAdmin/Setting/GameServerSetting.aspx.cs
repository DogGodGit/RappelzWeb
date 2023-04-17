using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Setting_GameServerSetting : System.Web.UI.Page
{
	protected int m_nGameServerId = 0;

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
		// DB연결
		SqlConnection conn = DBUtil.GetUserDBConn();

		DataTable dtGroup = DacUser.GameServerGroups(conn, null);

		DataTable dtServer = DacUser.GameServers(conn, null, m_nGameServerId);

	
		DataRow drGameServerInfo = dtServer.Rows[0];
		
		WTxtServerId.Text = drGameServerInfo["serverId"].ToString();
		DBUtil.CloseDBConn(conn);

	}

}