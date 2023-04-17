<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup_SharingEventReceiverLog.aspx.cs" Inherits="Setting_Popup_Popup_SharingEventReceiverLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:DataGrid ID="WDtGrid" OnItemDataBound="WDtGrid_OnItemDataBound" AutoGenerateColumns="false" runat="server">
    <Columns>
       <asp:BoundColumn HeaderText="" DataField="sortId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="eventId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="userId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="inviteCode" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="gameServerId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn HeaderText="" DataField="accountHeroId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn HeaderText="" DataField="rewarded" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn HeaderText="" DataField="regTime" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn HeaderText="" DataField="completionTime" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
    </Columns>
    </asp:DataGrid>
    </form>
</body>
</html>
