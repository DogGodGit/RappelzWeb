<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="GameServerRegion.aspx.cs" Inherits="Setting_GameServerRegion" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>게임서버지역</h2>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>지역ID</th>
        <th>이름</th>
        <th>이름키</th>
        <th>표시순서</th>
        <th>기능</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><a href="/Setting/GameServerGroup.aspx?SVRR=<%# GetDataItem(Container.DataItem, "regionId")%>"><strong><%# GetDataItem(Container.DataItem, "regionId")%></strong></a></td>
		<td><asp:TextBox ID="WTxtName" Text=<%# GetDataItem(Container.DataItem, "_name")%> Width="100" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtNameKey" Text=<%# GetDataItem(Container.DataItem, "nameKey")%> Width="100" runat="server"></asp:TextBox></td>
		<td><asp:TextBox ID="WTxtSortNo" Text=<%# GetDataItem(Container.DataItem, "sortNo")%> Width="100" runat="server"></asp:TextBox></td>
        <td><asp:Button ID="WBtnUpdate" Text="" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "regionId")%>' CommandName="update" runat="server" />
			<asp:Button ID="WBtnDelete" Text="" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "regionId")%>' CommandName="delete" runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    <div class="spacer"></div>

    <p class="top_line"><br /></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
        <th>지역ID</th>
        <td class="left"><asp:TextBox ID="WTxtRegionId" runat="server" /></td>
    </tr>
    <tr>
        <th>이름</th>
        <td class="left"><asp:TextBox ID="WTxtName" runat="server" /></td>
    </tr>
    <tr>
        <th>이름키</th>
        <td class="left"><asp:TextBox ID="WTxtNameKey" runat="server" /></td>
    </tr>
    <tr>
        <th>표시순서</th>
        <td class="left"><asp:TextBox ID="WTxtSortNo" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>
    <asp:Button ID="WBtnAdd" Text="" OnClick="WBtnAdd_OnClick" Width="100" CssClass="button" runat="server" />

</div>
</asp:Content>