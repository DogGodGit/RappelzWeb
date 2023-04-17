using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Game_AccountHero : System.Web.UI.Page
{
	protected int m_nGameServerId = 0;
	protected Guid m_nAccountHeroId;
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
		m_nAccountHeroId = ComUtil.GetRequestInt("AHID", RequestMethod.Get, 0);

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
		//WBtnServerGroupAdd.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");
		//WBtnGameServerAdd.Attributes.Add("onclick", "return confirm('등록하시겠습니까?');");

		SqlConnection conn = DBUtil.GetGameDBConn(Convert.ToInt32(m_nGameServerId));
		
		DataRow dr = Dac.Hero(conn, null, m_nAccountHeroId);
		Guid accountId = Guid.Parse(dr["accountId"].ToString());
		DataRow drAccount = Dac.Account(conn, null, accountId);
		DataTable drHeros = Dac.AccountHeros(conn, null, accountId);

		DBUtil.CloseDBConn(conn);

		WLtlAccountAccountId.Text = drAccount["accountId"].ToString();
		WLtlUserId.Text = drAccount["userId"].ToString();
		WLtlAccountHeroId.Text = dr["heroId"].ToString();
		WLtlLastLoginTime.Text = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drAccount["lastLoginTime"].ToString()));
		WLtlLastLoginIp.Text = drAccount["lastLoginIp"].ToString();
		WLtlLastAccountHeroId.Text = dr["heroId"].ToString();
		WLtlAccountRegTime.Text = DateTimeUtil.ToDateTimeOffsetString(DateTimeOffset.Parse(drAccount["regTime"].ToString()));
		WLtlAccountDeleted.Text = drAccount["delTime"].ToString();

		if (Convert.ToBoolean(drAccount["deleted"]))
		{
			WLtlAccountDeleted.Text = "삭제됨";
			DateTime delTime;
			if (DateTime.TryParse(drAccount["delTime"].ToString(), out delTime))
				WLtlAccountDelTime.Text = delTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
			else
				WLtlAccountDelTime.Text = "잘못된 형식";
		}
		else
			WLtlAccountDeleted.Text = "정상";

		WRptAccountHeros.DataSource = drHeros;
		WRptAccountHeros.DataBind();
	}

	 protected string GetDataItem(object objData, string sFieldNm)
    {
        string sRtn = "";

        switch (sFieldNm)
        {
			case "name":

			string sStyle = "";
				if (Convert.ToBoolean(ComUtil.GetDataItem(objData, "deleted")))
					sStyle = "background:#999999;";

				if (Convert.ToInt32(ComUtil.GetDataItem(objData, "heroId")) == m_nAccountHeroId)
					sStyle += "background:#739b57;color:#FFFFFF";

				sRtn = "<input type=\"button\" value=\"" + ComUtil.GetDataItem(objData, "name") + "\" class=\"btnMenu\" onclick=\"location.href='/Game/AccountHero.aspx?SVR=" + m_nGameServerId.ToString() + "&AHID=" + ComUtil.GetDataItem(objData, "heroId") + "';\" style=\"" + sStyle + "\" />";
				break;
            
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
			   
		return sRtn;
    }
}