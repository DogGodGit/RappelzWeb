<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="SubMenuSetting.aspx.cs" Inherits="Game_SubMenuSetting" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
   <div id="CONTENT_INNER">
 
	<h2>선택된 메인메뉴 <asp:Button  ID="WBtnBack" OnClick="WBtnBack_OnClick" CssClass="btnMenu" Text="뒤로가기" runat="server" /></h2>
	
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
	 <th Width="150">메인메뉴ID</th>
	 <td  Width="150"><asp:Literal ID="WTxtMainMenuId" runat="server" /></td>
	 <th Width="150">이름키</th>
	 <td Width="150"><asp:Literal ID="WTxtNameKey" runat="server" /></td>
	 <th Width="150">팝업이름</th>
	 <td Width="150"><asp:Literal ID="WTxtPopupName" runat="server" /></td>
	</tr>
	</table>
	<p class="bottom_line"></p>

	<div class="spacer"></div>

	<h2>서브메뉴</h2>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>서브메뉴ID</th>
		<th>이름키</th>
		<th>프리팹1</th>
		<th>프리팹2</th>
		<th>프리팹3</th>
		<th>레이아웃</th>
		<th>정렬번호</th>
		<th>메뉴컨텐츠</th>
		<th>기본</th>
		<th>기능</th>
	</tr>
	<asp:Repeater ID="WRptsubMenu" OnItemDataBound="WRptSubMenu_OnItemDataBounds" OnItemCommand="WRptSubMenu_OnItemCommands"  runat="server">
	<ItemTemplate>
	<tr>
		<td><asp:TextBox ID="WtxtMenuId" Text=<%# GetDataItem(Container.DataItem, "subMenuId") %> style="text-align:center" CssClass="txtAttr" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtNameKey" Text=<%# GetDataItem(Container.DataItem, "nameKey") %> style="text-align:center" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtPrefab1" Text=<%# GetDataItem(Container.DataItem, "prefab1") %> style="text-align:center" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtPrefab2" Text=<%# GetDataItem(Container.DataItem, "prefab2") %> style="text-align:center" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtPrefab3" Text=<%# GetDataItem(Container.DataItem, "prefab3") %> style="text-align:center" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtLayout" Text=<%# GetDataItem(Container.DataItem, "layout") %> style="text-align:center" CssClass="txtAttr" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtSortNo" Text=<%# GetDataItem(Container.DataItem, "sortNo") %> style="text-align:center" CssClass="txtAttr" runat="server"/> </td>
		<td><asp:DropDownList ID="WDDLMenuContents" runat="server" /></td>
		<td><%# GetDataItem(Container.DataItem, "isDefault") %></td>
		<td> 
			<asp:Button ID="WBtnMainMenuUpdate"  Text="수정"  CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "subMenuId")%>' runat="server" />
			<asp:Button ID="WBtnMainMenuDel" Text="삭제" CssClass="button" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "subMenuId")%>' runat="server" />
		</td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>
	</table>
	<p class="bottom_line"></p>


	<div class="spacer"></div>

	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>기본메뉴 설정</th>
		<td class="left">
			<asp:DropDownList ID="WDDLSubMenus" runat="server" />
			<asp:Button ID="WBtnSubMenuDefault" Text="설정" OnClick="WBtnSubMenuDefault_OnClick"  CssClass="button" runat="server" />
			<span class="red"><asp:Literal ID="WLtlWarning" runat="server" /></span>
			</td>
	</tr>
	</table>

	<div class="spacer"></div>

	<h2>서브메뉴 등록</h2>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>메인메뉴ID</th>
		<td class="left"><asp:Literal ID="WLtlMainMenuIds" Text=""  runat="server"/> </td>
	</tr>
	<tr>
		<th>서브메뉴ID</th>
		<td class="left"><asp:TextBox ID="WTxtSubmenuIdAdd" Text=""  runat="server"/> </td>
	</tr>
	<tr>
		<th>이름키</th>
		<td class="left"><asp:TextBox ID="WtxtSubnameKeyAdd" Text="" runat="server"/> </td>
	</tr>
	<tr>
		<th>프리팹1</th>
		<td class="left"><asp:TextBox ID="WTxtPrefab1Add" Text="" runat="server"/> </td>
	</tr>
	<tr>
		<th>프리팹2</th>
		<td class="left"><asp:TextBox ID="WTxtPrefab2Add" Text="" runat="server"/> </td>
	</tr>
	<tr>
		<th>프리팹3</th>
		<td class="left"><asp:TextBox ID="WTxtPrefab3Add" Text="" runat="server"/> </td>
	</tr>
	<tr>
		<th>레이아웃</th>
		<td class="left"><asp:TextBox ID="WTxtLayout" Text="" runat="server"/> (숫자)</td>
	</tr>
	<tr>
		<th>정렬번호</th>
		<td class="left"><asp:TextBox ID="WTxtSortNo" Text="" runat="server"/> </td>
	</tr>
	<tr>
		<th>메뉴컨텐츠</th>
		<td class="left"><asp:DropDownList ID="WDDLMenuContents" runat="server" /></td>
	</tr>
	</table>
	<asp:Button ID="WBtnAdd" Text="등록" OnClick="WBtnAdd_OnClick"  CssClass="button" runat="server" />

</div>
</asp:Content>