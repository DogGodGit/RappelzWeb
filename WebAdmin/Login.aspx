<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
	<link rel="stylesheet" type="text/css" href="/Common/Css/Style.css?20170515" />
    <script type="text/javascript">
        function checkForm() {
            if (document.getElementById("<%=WTxtId.ClientID %>").value == "") {
                alert('<%= Resources.ResLang.Login_03 %>');
                document.getElementById("<%=WTxtId.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=WTxtPwd.ClientID %>").value == "") {
                alert('<%= Resources.ResLang.Login_04 %>');
                document.getElementById("<%=WTxtPwd.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
<div id="dvLoginForm">
    <h1 class="title"><%=Define.S_NAME%></h1>
	<h2><span class="red"><%= Resources.ResLang.Login_01 %></span></h3>
    <div class="spacer"></div>
    <table id="LoginForm">
    <tr>
        <td><asp:TextBox ID="WTxtId" TabIndex="1" CssClass="text" runat="server" /></td>
        <td rowspan="2"><asp:Button ID="WBtnLogin" Text="<%$ Resources:ResLang,Login_02 %>" TabIndex="3" Width="80" Height="50" OnClick="WBtnLogin_OnClick" ToolTip="Login" runat="server" /></td>
    </tr>
    <tr>
        <td><asp:TextBox ID="WTxtPwd" TabIndex="2" TextMode="Password" CssClass="text" runat="server" /></td>
    </tr>
    </table>
</div>
</form>
</body>
</html>