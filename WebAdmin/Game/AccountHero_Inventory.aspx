<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" CodeFile="AccountHero_Inventory.aspx.cs" Inherits="Game_Inventory" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    <p class="top_line"></p>
	<h4>
		&nbsp;
		인벤토리 |
	</h4>
	<p class="bottom_line"></p>
	<h4>인벤토리 추가</h4>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
        <th rowspan="2">빈슬롯 <asp:DropDownList ID="WDDLEmptySlot" runat="server" /></th>
        <td>아이템 추가</td>
        <td>		<asp:DropDownList ID="WDDLItem" runat="server" /></td>
        <td></td>
        <td><asp:CheckBox ID="WCBoxOwnItem" Text="귀속" runat="server" /></td>
        <td>수량 <asp:TextBox ID="WTxtItemCount" Text="1" MaxLength="2" runat="server" /></td>
        <td><asp:Button ID="WBtnAddItem" Text="아이템 추가" OnClick="WBtnAddItem_OnClick"  CssClass="button" runat="server" /></td>
    </tr>
    <tr>
        <td>장비 추가</td>
        <td><asp:DropDownList ID="WDDLGear" runat="server" /></td>
        <td><asp:DropDownList ID="WDDLGearGrade" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxOwnGear" Text="귀속" runat="server" /></td>
        <td></td>
        <td><asp:Button ID="WBtnAddGear" Text="장비 추가" OnClick="WBtnAddGear_OnClick" CssClass="button" runat="server" /></td>
    </tr>
    </table>

    <p class="bottom_line"></p>
    <p class="top_line"></p>

	<table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
        <th>슬롯번호</th>
        <th>타입</th>
        <th>이름</th>
        <th>ID</th>
        <th>수량</th>
        <th>　</th>
    </tr>

    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "slotIndex")%></td>
        <td><%# GetDataItem(Container.DataItem, "type")%></td>
        <td class="left"><asp:Image ImageUrl="/Common/Images/ico_lock.png" ID="WImagelock" visible="false" width="10" height="10" align="absmiddle" runat="server"/> <asp:Literal ID="WLitName" runat="server" /></td>
        <td><%# GetDataItem(Container.DataItem, "heroGearId") %></td>
        <td><asp:TextBox ID="WTxtCount" Text="0" MaxLength="2" CssClass="txtAttr" runat="server" /></td>
        <td class="left">
        <asp:Button ID="WBtnUpdate" Text="수정" CssClass="button" Visible="false"  CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "slotIndex")%>' runat="server" />
        <asp:Button ID="WBtnDel" Text="삭제" CssClass="button" CommandName="delete"  CommandArgument='<%# GetDataItem(Container.DataItem, "slotIndex")%>' runat="server" />
        <asp:HiddenField ID="WHFInventoryType" runat="server" />
        <asp:HiddenField ID="WHFAccountHeroGearId" runat="server" />
        <asp:HiddenField ID="WHFItemId" Value="0" runat="server" />
        <asp:HiddenField ID="WHFCount" Value="0" runat="server" />
        <asp:HiddenField ID="WHFOwned" Value="False" runat="server" />
        </td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>

    <p class="bottom_line"></p>

</div>
</asp:Content>
