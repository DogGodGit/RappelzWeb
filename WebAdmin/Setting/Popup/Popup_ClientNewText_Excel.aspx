<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup_ClientNewText_Excel.aspx.cs" Inherits="Setting_Popup_Popup_ClientNewText_Excel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<asp:DataGrid ID="WDtGrid" AutoGenerateColumns="false" runat="server">
<Columns>
	<asp:BoundColumn HeaderText="" DataField="name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	<asp:BoundColumn HeaderText="" DataField="standardValue" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	<asp:BoundColumn HeaderText="" DataField="value" HeaderStyle-HorizontalAlign="Center" />
</Columns>
</asp:DataGrid>
</form>
</body>
</html>
