<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/Main.master" AutoEventWireup="true" CodeFile="ChargePurchaseProduct.aspx.cs" Inherits="Game_ChargePurchaseProduct" %>

<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	
	<h2>구입상품 관리</h2>

<%--	<p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">
            서버 <asp:DropDownList ID="WDDLServer" OnSelectedIndexChanged="WDDLServer_OnSelectedIndexChanged" AutoPostBack="true" runat="server" />
            &nbsp;

			구입상품메타버전
			<asp:TextBox ID="WTxtPurchaseProductMetaVersion" runat="server" />
			<asp:HiddenField ID="WHFPurchaseProductMetaVersion" runat="server" />
			<asp:Button ID="WBtnApplyServer" Text="" CssClass="button" OnClick="WBtnApplyServer_OnClick" runat="server" disabled />
			<span class="red">메타버전을 업데이트하면 구입상품 정보가 서버에 실시간 반영됩니다.</span>
            </th>
    </tr>
    </table>
    <p class="bottom_line"></p>--%>

	<div class="spacer"></div>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
		<th>상품ID</th>
		<th>인앱상품키</th>
		<th>상품타입</th>
		<th>_이름</th>
		<th>이름키</th>
		<th>이미지이름</th>
		<th>비귀속다이아수량</th>
		<th>아이템ID</th>
		<th>아이템수량</th>
		<th>VIP포인트</th>
		<th>첫구매추가보너스비귀속다이아</th>
		<th>아이템귀속여부</th>
		<th>판매가능여부</th>
		<th>정렬번호</th>
		<th>기능</th>
	</tr>
	<asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
	<ItemTemplate>
	<tr>
		<td><%# GetDataItem(Container.DataItem, "productId")%></td>
		<td><asp:DropDownList ID="WDDLInApp" runat="server" /></td>
		<td><asp:DropDownList ID="WDDLType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="다이아" Value="1" />
			    <asp:ListItem Text="아이템" Value="2" />
            </asp:DropDownList>
		</td>
		<td><asp:TextBox ID="WTxtName" runat="server" /></td>
		<td><asp:TextBox ID="WTxtNameKey" runat="server" /></td>
		<td><asp:TextBox ID="WTxtImageName" runat="server" /></td>
		<td><asp:TextBox ID="WTxtUnOwnDia" runat="server" /></td>
		<td><asp:TextBox ID="WTxtItemId" CssClass="txtAttr" runat="server" /></td>
		<td><asp:TextBox ID="WTxtItemCount" CssClass="txtAttr" runat="server" /></td>
		<td><asp:TextBox ID="WTxtVipPoint" CssClass="txtAttr" runat="server" /></td>
		<td><asp:TextBox ID="WTxtFirstPurchaseBonusUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<td><asp:CheckBox ID="WCBoxItemOwned" runat="server" /></td>
		<td><asp:CheckBox ID="WCBoxSaleable" runat="server" /></td>
		<td><asp:TextBox ID="WTxtSortNo" CssClass="txtAttr" runat="server" /></td>
		<td><asp:Button ID="WBtnUpdate" Text="" CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "productId")%>' runat="server" /></td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>
	</table>
    <p class="bottom_line"></p>

	<div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

	<asp:PlaceHolder ID="WPHAddForm" Visible="false" runat="server">
	<h3>구입상품 등록</h3>
	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_write table_left_fix">
	<tr>
		<th>인앱상품ID</th>
		<td><asp:DropDownList ID="WDDLInApp" runat="server" /></td>
	</tr>
	<tr>
		<th>상품타입</th>
		<td><asp:DropDownList ID="WDDLType" runat="server" /></td>
	</tr>
	<tr>
		<th>_이름</th>
		<td><asp:TextBox ID="WTxtName" runat="server" /></td>
	</tr>
	<tr>
		<th>이름키</th>
		<td><asp:TextBox ID="WTxtNameKey" runat="server" /></td>
	</tr>
	<tr>
		<th>이미지이름</th>
		<td><asp:TextBox ID="WTxtImageName" runat="server" /> </td>
	</tr>
	<tr>
		<th>비귀속다이아수량</th>
		<td><asp:TextBox ID="WTxtUnOwnDia" runat="server" /></td>
	</tr>
	<tr>
		<th>아이템ID</th>
		<td><asp:TextBox ID="WTxtItemId" runat="server">0</asp:TextBox></td>
	</tr>
	<tr>
		<th>아이템수량</th>
		<td><asp:TextBox ID="WTxtItemCount" runat="server">0</asp:TextBox></td>
	</tr>
	<tr>
		<th>VIP포인트</th>
		<td><asp:TextBox ID="WTxtVipPoint" runat="server">0</asp:TextBox></td>
	</tr>
	<tr>
		<th>첫구매추가보너스비귀속다이아</th>
		<td><asp:TextBox ID="WTxtFirstPurchaseBonusUnOwnDia" runat="server">0</asp:TextBox></td>
	</tr>
	<tr>
		<th>아이템귀속여부</th>
		<td><asp:CheckBox ID="WCBoxItemOwned" runat="server"/></td>
	</tr>
	<tr>
		<th>판매가능여부</th>
		<td><asp:CheckBox ID="WCBoxSaleable" runat="server"/></td>
	</tr>
	<tr>
		<th>정렬번호</th>
		<td><asp:TextBox ID="WTxtSortNo" runat="server">0</asp:TextBox></td>
	</tr>	  
	</table>
    <p class="bottom_line"></p>
	
    <div class="formListRight">
        <asp:Button ID="WBtnAdd" Text="" OnClick="WBtnAdd_OnClick" CssClass="button" runat="server" />
    </div>
	이미지파일명 작성법 <br />
	다이아 :frm_img_cash1 ~ frm_img_cash8 <br /> 
	<div class="spacer"></div>

	</asp:PlaceHolder>
</div>
</asp:Content>