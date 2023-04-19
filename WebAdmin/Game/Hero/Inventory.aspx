<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" Codebehind="Inventory.aspx.cs" Inherits="Game_Hero_Inventory" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<body>
<div>
	<p class="top_line"></p>
	<h4>인벤토리</h4>
    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th rowspan="3">빈 슬롯 <asp:DropDownList ID="WDDLSlot" runat="server" /></th>
		<td>아이템</td>
		<td><asp:DropDownList ID="WDDLItem" runat="server" /></td>
		<td><asp:CheckBox ID="WCBoxItemOwned" Text="귀속됨" Checked="true" runat="server" /></td>
		<td>수량 <asp:TextBox ID="WTxtItemCount" Text="1" runat="server" /></td>
		<td><asp:Button ID="WBtnItemAdd" Text="추가" OnClick="WBtnItemAdd_OnClick" runat="server" /></td>
	</tr>
	<tr>
		<td>메인장비</td>
		<td><asp:DropDownList ID="WDDLMainGear" runat="server" /></td>
		<td colspan="2"><asp:CheckBox ID="WCBoxMainGearOwned" Text="귀속됨" Checked="true" runat="server" /></td>
		<td><asp:Button ID="WBtnMainGearAdd" Text="추가" OnClick="WBtnMainGearAdd_OnClick" runat="server" /></td>
	</tr>
	<tr>
		<td>보조장비</td>
		<td colspan="3"><asp:DropDownList ID="WDDLSubGear" runat="server" /></td>
		<td><asp:Button ID="WBtnSubGearAdd" Text="추가" OnClick="WBtnSubGearAdd_OnClick" runat="server" /></td>
	</tr>
	</table>
    <p class="bottom_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>슬롯번호</th>
		<th>타입</th>
		<th>ID</th>
		<th>이름</th>
		<th>수량</th>
		<th></th>
	</tr>
	<asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" runat="server">
	<ItemTemplate>
	<tr>
		<td><%# GetDataItem(Container.DataItem, "slotIndex")%></td>
		<td><%# GetDataItem(Container.DataItem, "slotType")%></td>
		<td><asp:Literal ID="WLtlId" runat="server" /></td>
		<td><asp:Literal ID="WLtlName" runat="server" /></td>
		<td><%# GetDataItem(Container.DataItem, "itemCount")%></td>
		<td></td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>
	</table>

	<div class="display:;">
	</div>
</div>
</body>
</asp:Content>