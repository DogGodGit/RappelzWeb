<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="Common_UserControl_TopMenu" %>
    <asp:PlaceHolder ID="WPHTop" Visible="true" runat="server">
    <table>
    <tr>
        <td><h1 class="title"><a href="/"><%=Define.S_NAME %></a></h1></td>
        <td>
            <ul class="top_menu">
				<li><%=DateTime.Now.ToString() %></li>
				<li><strong>Rev. <%=Define.kRev %></strong></li>
                <li><a href="#"><asp:Literal ID="WLtlUsrIdName" runat="server" /></a></li>
                <li><a href="/Logout.aspx"><%=Resources.ResLang.UserControl_TopMenu_001 %></a></li>
            </ul> 
        </td>
    </tr>
    </table>
    </asp:PlaceHolder>