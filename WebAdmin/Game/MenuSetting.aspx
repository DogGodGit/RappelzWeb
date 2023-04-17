<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="MenuSetting.aspx.cs" Inherits="Game_MenuSetting" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
   <div id="CONTENT_INNER">
 
	<h2>메뉴 설정 - 메인</h2>
	   <p class="top_line"></p>

    <p class="bottom_line"></p>

	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>기능</th>
		<th>메뉴ID</th>
		<th>이름키</th>
		<th>팝업이름</th>
		<th>기능</th>
	</tr>

	<asp:Repeater ID="WRptMainMenu" OnItemDataBound="WRptMainMenu_OnItemDataBounds" OnItemCommand="WRptMainMenu_OnItemCommands"  runat="server">
	<ItemTemplate>
	<tr>
		<td> <asp:Button ID="Button1"  Text="서브메뉴 이동"  CssClass="btnMenu100" CommandName="SubMenuBtn" CommandArgument='<%# GetDataItem(Container.DataItem, "menuId")%>' runat="server" />  </td> 
		<td><asp:TextBox ID="WtxtMenuId" Text=<%# GetDataItem(Container.DataItem, "menuId") %> style="text-align:center"  runat="server"/> </td>
		<td><asp:TextBox ID="WTxtNameKey" Text=<%# GetDataItem(Container.DataItem, "nameKey") %> style="text-align:center" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtPopName" Text=<%# GetDataItem(Container.DataItem, "popupName") %> style="text-align:center" runat="server"/> </td>

		<td>
			<asp:Button ID="WBtnMainMenuUpdate"  Text="수정"  CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "menuId")%>' runat="server" />
			<asp:Button ID="WBtnMainMenuDel" Text="삭제" CssClass="button" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "menuId")%>' runat="server" />
        </td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>
	</table>

	<p class="bottom_line"></p>
	<p class="top_line"></p>

	<h2>메인메뉴 등록</h2>

	<p class="top_line"></p>

	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>메뉴ID</th>
		<td class="left"><asp:TextBox ID="WTxtmenuIdAdd" Text=""  runat="server"/> </td>
	</tr>
	<tr>
		<th>이름키</th>
		<td class="left"><asp:TextBox ID="WtxtnameKeyAdd" Text="" runat="server"/> </td>
	</tr>
		<th>팝업이름</th>
		<td class="left"><asp:TextBox ID="WtxtpopUpNameAdd" Text="" runat="server"/> </td>
	</tr>

	</table>
	<asp:Button ID="WBtnAdd" Text="등록" OnClick="WBtnAdd_OnClick"  CssClass="button" runat="server" />
    </div>
</asp:Content>