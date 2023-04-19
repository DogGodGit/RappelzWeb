<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="GameServerAccess.aspx.cs" Inherits="Setting_GameServerAccess" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>게임서버 접속관리</h2>

	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>게임서버지역</th>
		<td><asp:DropDownList ID="WDDLSRegion" OnSelectedIndexChanged="WDDLServerRegion_OnSelectedIndexChanged" AutoPostBack="true" Visible ="true" runat="server"></asp:DropDownList></td>
	</tr>
	<tr>
		<th>게임서버그룹</th>
		<td><asp:DropDownList ID="WDDLSGroup" OnSelectedIndexChanged="WDDLSGroup_OnSelectedIndexChanged" AutoPostBack="true" Visible ="true" runat="server"></asp:DropDownList></td>
	</tr>
	</table>
	
	<p class="bottom_line"></p>

	<div class="spacer"></div>

	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>허용국가</th>
		<th></th>
		<th>국가</th>
	</tr>
	<tr>
		<td class="center"><asp:ListBox ID="WLBoxAllowed" Width="200" Rows="20" runat="server" /></td>
		<td class="center">
			<asp:Button ID="WBtnSelect" Text="<< 허용" Width="60" CssClass="button" OnClick="WBtnSelect_OnClick" runat="server" />
			<br />
			<asp:Button ID="WBtnUnselect" Text="제외 >>" Width="60" CssClass="buttonRed" OnClick="WBtnUnselect_OnClick" runat="server" />
		</td>
		<td class="center"><asp:ListBox ID="WLBox" Width="200" Rows="20" runat="server" /></td>
	</tr>
	</table>
	<p class="bottom_line"></p>

	<div class="center">
		<asp:Button ID="WBtnUpdate" Text="적용" OnClick="WBtnUpdate_OnClick" Width="200" Height="30" CssClass="button" runat="server" />
	</div>
</div>
</asp:Content>