<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="AccountHeroList.aspx.cs" Inherits="Game_AccountHeroList" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

<h2>계정영웅관리</h2>

 <p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
	<tr>
	<th class="left">
		서버그룹목록<asp:DropDownList ID="WDDLServerGropList" OnSelectedIndexChanged="WDDLServerGroup_OnSelectedIndexChanged" AutoPostBack="true" runat="server" />
		&nbsp;&nbsp;
		서버목록<asp:DropDownList ID="WDDLServerList" runat="server" />
		&nbsp;&nbsp;
		검색대상<asp:DropDownList ID="WDDLSearch" runat="server" />
		&nbsp;
				<asp:TextBox ID="WTxtsearch" runat="server" />
				<asp:Button ID="WBtnsearch" text="검색" OnClick="WBtnSearch_OnClick" CssClass="button" runat="server" />
    </th>
    </tr>
    </table>

	<p class="bottom_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<thead>
	<tr>
		<th>영웅ID</th>
		<th>이름</th>
	</tr>
	</thead>

	<asp:Repeater ID="WrptList" runat="server">
	<ItemTemplate>
	<tr>
		<td><%# GetDataItem(Container.DataItem, "heroId")%></td>
		<td><%# GetDataItem(Container.DataItem, "name")%></td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>

	</table>
</div>

</asp:Content>