<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="GameServerGroup.aspx.cs" Inherits="Setting_GameServerGroup" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>게임서버그룹</h2>

    <p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>게임서버지역</th>
		<td><asp:DropDownList ID="WDDLSRegion" OnSelectedIndexChanged="WDDLServerRegion_OnSelectedIndexChanged" AutoPostBack="true" Visible ="true" runat="server"></asp:DropDownList></td>
	</tr>
	</table>
	
	<p class="bottom_line"></p>

	<asp:PlaceHolder ID="WPHServerInfo" Visible="false" runat="server">

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>그룹ID</th>
		<th>정렬번호</th>
        <th>이름</th>
        <th>이름키</th>
		<th>추천서버자동여부</th>
		<th>추천서버조건타입</th>
		<th>접속제한여부</th>
        <th>기능</th>
        <th></th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><a href="/Setting/GameServerList.aspx?SVRG=<%# GetDataItem(Container.DataItem, "groupId")%>"><strong><%# GetDataItem(Container.DataItem, "groupId")%></strong></a></td>
		<td class="left"><asp:TextBox ID="WTxtSortNo" Text=<%# GetDataItem(Container.DataItem, "sortNo")%> runat="server" /></td>
		<td><asp:TextBox ID="WTxtName" Text=<%# GetDataItem(Container.DataItem, "_name")%> Width="100" runat="server"></asp:TextBox></td>
		<td><asp:TextBox ID="WTxtNameKey" Text=<%# GetDataItem(Container.DataItem, "nameKey")%> Width="100" runat="server"></asp:TextBox></td>
        <td class="left"><asp:CheckBox ID="WCBoxAuto" Text="자동" runat="Server" /></td>
		<td class="left"><asp:DropDownList ID="WDDLConditionType" runat="server">
				<asp:ListItem Text="최저접속유저수순" Value="1" />
				<asp:ListItem Text="최근오픈서버순" Value="2" />
			</asp:DropDownList></td>
        <td class="left"><asp:CheckBox ID="WCBoxAccessRestriction" Text="접속제한" runat="Server" /></td>
		<td><asp:Button ID="WBtnUpdate" Text="" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "groupId")%>' CommandName="update" runat="server" />
			<asp:Button ID="WBtnDelete" Text="" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "groupId")%>' CommandName="delete" runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    <div class="spacer"></div>

    <p class="top_line"><br /></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
        <th>그룹ID</th>
        <td class="left"><asp:TextBox ID="WTxtGroupId" runat="server" /></td>
    </tr>
    <tr>
        <th>정렬번호</th>
        <td class="left"><asp:TextBox ID="WTxtSortNo" runat="server" /></td>
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
        <th>추천서버자동여부</th>
        <td class="left"><asp:CheckBox ID="WCBoxAuto" Text="자동" runat="Server" /></td>
    </tr>
    <tr>
        <th>추천서버조건타입</th>
        <td class="left"><asp:DropDownList ID="WDDLConditionType" runat="server">
				<asp:ListItem Text="최저접속유저수순" Value="1" />
				<asp:ListItem Text="최근오픈서버순" Value="2" />
			</asp:DropDownList></td>
    </tr>
    <tr>
        <th>접속제한</th>
        <td class="left"><asp:CheckBox ID="WCBoxAccessRestriction" Text="접속제한" runat="Server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>
    <asp:Button ID="WBtnAdd" Text="" OnClick="WBtnAdd_OnClick" Width="100" CssClass="button" runat="server" />

	</asp:PlaceHolder>

</div>
</asp:Content>