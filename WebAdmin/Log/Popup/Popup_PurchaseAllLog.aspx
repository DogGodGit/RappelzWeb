<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup_PurchaseAllLog.aspx.cs" Inherits="Log_Popup_Popup_PurchaseAllLog" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<asp:DataGrid ID="WDtGrid" OnItemDataBound="WDtGrid_OnItemDataBound" AutoGenerateColumns="false" runat="server">
<Columns>
	<asp:BoundColumn HeaderText="" DataField="purchaseId" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
	<asp:BoundColumn HeaderText="" DataField="virtualGameServerId" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
	<asp:BoundColumn HeaderText="" DataField="heroId"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" />
	<asp:BoundColumn HeaderText="" DataField="productId" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
	<asp:BoundColumn HeaderText="" DataField="purchaseData" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
	<asp:BoundColumn HeaderText="" DataField="storeType" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="orderId" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="signature" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="status" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="failReason" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="statusUpdateTime" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="regTime" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundColumn HeaderText="" DataField="exceptionId" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Yellow" ItemStyle-HorizontalAlign="Center" />

</Columns>
</asp:DataGrid>
</form>
</body>
</html>