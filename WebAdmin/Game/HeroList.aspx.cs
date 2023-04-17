﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitJson;

public partial class Game_HeroList : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

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
		WDDLType.Items.Add(new ListItem("영웅이름", "1"));
		WDDLType.Items.Add(new ListItem("영웅ID", "2"));

		SqlConnection conn = DBUtil.GetUserDBConn();
		DataTable dt = DacUser.VirtualGameServers(conn, null);
		DBUtil.CloseDBConn(conn);

		WDDLServer.Items.Add(new ListItem("=가상서버선택=", "0"));
		for (int i = 0; i < dt.Rows.Count; i++)
			WDDLServer.Items.Add(new ListItem(dt.Rows[i]["displayName"].ToString(), dt.Rows[i]["serverId"].ToString()));

		//WRptList.DataSource = dt;
		//WRptList.DataBind();
	}

	protected void WBtnSearch_OnClick(object sender, EventArgs e)
	{
		if (WDDLServer.SelectedValue == "0" || WTxtSearch.Text.Trim() == "")
			return;

		int nServerId = Convert.ToInt32(WDDLServer.SelectedValue);
		int nType = Convert.ToInt32(WDDLType.SelectedValue);
		string sText = WTxtSearch.Text.Trim();

		SqlConnection connGame = DBUtil.GetGameDBConn(nServerId);
		DataTable dt = Dac.Heros_Search(connGame, null, nType, sText);
		DBUtil.CloseDBConn(connGame);

		WRptList.DataSource = dt;
		WRptList.DataBind();
	}

	protected string GetDataItem(object objData, string sFieldNm)
	{
		string sRtn = "";

		switch (sFieldNm)
		{
			case "name":
				sRtn = "<a href=\"/Game/Hero.aspx?SVR=" + WDDLServer.SelectedValue + "&HID=" + ComUtil.GetDataItem(objData, "heroId") + "\">" + ComUtil.GetDataItem(objData, sFieldNm) + "</a>";
				break;
			case "deleted":
				if (Convert.ToBoolean(ComUtil.GetDataItem(objData, sFieldNm)))
					sRtn = "<span class=\"red\">삭제됨</span>";
				break;
			default:
				sRtn = ComUtil.GetDataItem(objData, sFieldNm);
				break;
		}
		return sRtn;
	}
}