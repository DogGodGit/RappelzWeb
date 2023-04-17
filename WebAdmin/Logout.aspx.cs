using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //=====================================================================
        // Remove Cookies
        //=====================================================================
        HttpCookieCollection hcc = Response.Cookies;

        HttpCookie hcZeno = Response.Cookies["MNGR"];
        hcZeno.Path = "/";
        hcZeno.Domain = Define.S_HOST;
        hcZeno.Expires = DateTime.Now.AddHours(-1);

        Response.Redirect("/");
    }
}