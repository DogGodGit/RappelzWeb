﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Common_Master_IFrame : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
	{
		//언어설정하기
		CultureInfo ciLang = new CultureInfo(Config.Languages); //코드언어 넣기 
		Resources.ResLang.Culture = ciLang;

		if (ComUtil.GetUserId() == "")
		{
			Response.Redirect("/Login.aspx");
			return;
		}
    }
}
