<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="Sub_Game_MenuSetting.aspx.cs" Inherits="Sub_Game_MenuSetting" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
   <div id="CONTENT_INNER">
 
	<h2>선택된 메인메뉴 <asp:Button  ID="WBtnBack" OnClick="WBtnBack_OnClick" CssClass="btnMenu" Text="뒤로가기" runat="server" /></h2>
	   <p class="top_line"></p>

	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
	 <th Width="150">메인메뉴ID</th>
	 <td  Width="150"><asp:Literal ID="WTxtMainMenuId"  Text="asdasd" runat="server" /></td>
	 <th Width="150">이름키</th>
	 <td Width="150"><asp:Literal ID="TextBox1" Text="asdasd" runat="server" /></td>
	 <th Width="150">팝업이름</th>
	 <td Width="150"><asp:Literal ID="TextBox2" Text="asdasd" runat="server" /></td>
	</tr>
	</table>

	<p class="bottom_line"></p>
	<p class="top_line"></p>

	<h2>서브메뉴</h2>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>서브메뉴ID</th>
		<th>이름키</th>
		<th>프리팹1</th>
		<th>프리팹2</th>
		<th>기능</th>
	
	</tr>

	<asp:Repeater ID="WRptsubMenu" OnItemDataBound="WRptSubMenu_OnItemDataBounds" OnItemCommand="WRptSubMenu_OnItemCommands"  runat="server">
	<ItemTemplate>

	<tr>
		<td><asp:TextBox ID="WtxtMenuId" Text=<%# GetDataItem(Container.DataItem, "subMenuId") %> style="text-align:center"  runat="server"/> </td>
		<td><asp:TextBox ID="WTxtNameKey" Text=<%# GetDataItem(Container.DataItem, "nameKey") %> style="text-align:center"  runat="server"/> </td>
		<td><asp:TextBox ID="WTxtprefab1" Text=<%# GetDataItem(Container.DataItem, "prefab1") %> style="text-align:center" runat="server"/> </td>
		<td><asp:TextBox ID="WTxtprefab2" Text=<%# GetDataItem(Container.DataItem, "prefab2") %> style="text-align:center" runat="server"/> </td>

		 <td> <asp:Button ID="WBtnMainMenuUpdate"  Text="수정"  CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "subMenuId")%>' runat="server" />
		 <asp:Button ID="WBtnMainMenuDel" Text="삭제" CssClass="button" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "subMenuId")%>' runat="server" />
           </td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>
	</table>

	<p class="bottom_line"></p>
	<p class="top_line"></p>

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
		<td class="left"><asp:TextBox ID="Wtxtprefab1Add" Text="" runat="server"/> </td>
	</tr>
	<tr>
		<th>프리팹2</th>
		<td class="left"><asp:TextBox ID="Wtxtprefab2Add" Text="" runat="server"/> </td>
	</tr>

	</table>
	<asp:Button ID="WBtnAdd" Text="등록" OnClick="WBtnAdd_OnClick"  CssClass="button" runat="server" />
    </div>
</asp:Content>
