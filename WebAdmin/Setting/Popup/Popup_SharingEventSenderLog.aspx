<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Popup_SharingEventSenderLog.aspx.cs" Inherits="Setting_Popup_Popup_SharingEventSenderLog" %>

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
	    <asp:BoundColumn HeaderText="" DataField="inviteCode" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="eventId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="gameServerId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
	    <asp:BoundColumn HeaderText="" DataField="accountHeroId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundColumn HeaderText="" DataField="regTime" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
    </Columns>
    </asp:DataGrid>
    </form>
</body>
</html>
