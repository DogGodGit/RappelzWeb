<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/Main.master" AutoEventWireup="true" CodeFile="DiaShop.aspx.cs" Inherits="Game_DiaShop" %>

<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<h2>한정상품</h2>

	<p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">
            카테고리 <asp:DropDownList ID="WDDLCategory" OnSelectedIndexChanged="WDDLCategory_OnSelectedIndexChanged" AutoPostBack="true" runat="server" />
			&nbsp;

<%--			한정상품메타버전
			<asp:TextBox ID="WTxtLimitedProductMetaVersion" runat="server" />
			<asp:HiddenField ID="WHFLimitedProductMetaVersion" runat="server" />
			<asp:Button ID="WBtnApplyServer" Text="메타버전 업데이트" CssClass="button" OnClick="WBtnApplyServer_OnClick" runat="server" disabled/>
			<span class="red">메타버전을 업데이트하면 한정상품 정보가 서버에 실시간 반영됩니다.</span>--%>
        </th>
    </tr>
    </table>
    <p class="bottom_line"></p>

	<div class="spacer"></div>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
		<th>카테고리ID</th>
		<th>상품ID</th>
		<th>분장상품타입</th>
		<th>아이템ID</th>
		<th>아이템귀속여부</th>
		<th>태그타입</th>
		<th>재화타입</th>
		<th>재화아이템ID</th>
		<th>원가격</th>
		<th>가격</th>
		<th>구매제한타입</th>
		<th>구매제한횟수</th>
		<th>기간타입</th>
		<th>기간시작시각</th>
		<th>기간종료시각</th>
		<th>기간요일</th>
		<th>추천여부</th>
		<th>리밋에디션여부</th>
		<th>판매여부</th>
		<th>카테고리정렬번호</th>
		<th>리밋에디션정렬번호</th>
		<th></th>
	</tr>
	<asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
	<ItemTemplate>
	<tr>
		<td>
            <asp:DropDownList ID="WDDLcategoryId" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="일상" Value="1" />
			    <asp:ListItem Text="장착" Value="2" />
			    <asp:ListItem Text="강화" Value="3" />
			    <asp:ListItem Text="특수" Value="4" />
			    <asp:ListItem Text="분장" Value="5" />
			    <asp:ListItem Text="VIP" Value="6" />
            </asp:DropDownList>
		</td>
        <td><asp:TextBox ID="WTxtproductId" runat="server" value=<%# GetDataItem(Container.DataItem, "productId")%> /></td>
        <td>
            <asp:DropDownList ID="WDDLcostumeProductType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="코스튬" Value="1" />
			    <asp:ListItem Text="효과" Value="2" />
			    <asp:ListItem Text="탈것" Value="3" />
            </asp:DropDownList>
        </td>
        <td><asp:TextBox ID="WTxtitemId" runat="server" value=<%# GetDataItem(Container.DataItem, "itemId")%> /></td>
        <td><asp:CheckBox ID="WCBoxItemOwned" runat="server" /></td>
        <td>
            <asp:DropDownList ID="WDDLtagType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="일반" Value="0" />
			    <asp:ListItem Text="신품" Value="1" />
			    <asp:ListItem Text="한정" Value="2" />
			    <asp:ListItem Text="인기" Value="3" />
			    <asp:ListItem Text="특가" Value="4" />
			    <asp:ListItem Text="구매횟수한정" Value="5" />
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="WDDLmoneyType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="다이아(귀속/비귀속)" Value="1" />
			    <asp:ListItem Text="비귀속다이아" Value="2" />
			    <asp:ListItem Text="아이템" Value="3" />
            </asp:DropDownList>
        </td>
        <td><asp:TextBox ID="WTxtmoneyItemId" runat="server" value=<%# GetDataItem(Container.DataItem, "moneyItemId")%> /></td>
        <td><asp:TextBox ID="WTxtoriginalPrice" runat="server" value=<%# GetDataItem(Container.DataItem, "originalPrice")%> /></td>
        <td><asp:TextBox ID="WTxtprice" runat="server" value=<%# GetDataItem(Container.DataItem, "price")%> /></td>
        <td>
             <asp:DropDownList ID="WDDLbuyLimitType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="일일" Value="1" />
			    <asp:ListItem Text="누적" Value="2" />
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="WDDLbuyLimitCount" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="무제한" Value="0" />
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="WDDLperiodType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="무제한" Value="0" />
			    <asp:ListItem Text="기간" Value="1" />
			    <asp:ListItem Text="요일" Value="2" />
            </asp:DropDownList>
        </td>
        <td><asp:TextBox ID="WTxtperiodStartTime" runat="server" value=<%# GetDataItem(Container.DataItem, "periodStartTime")%> /></td>
        <td><asp:TextBox ID="WTxtperiodEndTime" runat="server" value=<%# GetDataItem(Container.DataItem, "periodEndTime")%> /></td>
        <td>
           <asp:DropDownList ID="WDDLperiodDayOfWeek" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="Sunday" Value="0" />
			    <asp:ListItem Text="Monday" Value="1" />
			    <asp:ListItem Text="Tuesday" Value="2" />
			    <asp:ListItem Text="Wendseday" Value="3" />
			    <asp:ListItem Text="Tursday" Value="4" />
			    <asp:ListItem Text="Friday" Value="5" />
			    <asp:ListItem Text="Saturday" Value="6" />
            </asp:DropDownList>
        </td>
        <td><asp:CheckBox ID="WCBoxRecommended" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxIsLimitEdition" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxSellable" runat="server" /></td>
        <td><asp:TextBox ID="WTxtcategorySortNo" runat="server" value=<%# GetDataItem(Container.DataItem, "categorySortNo")%> /></td>
        <td><asp:TextBox ID="WTxtlimitEditionSortNo" runat="server" value=<%# GetDataItem(Container.DataItem, "limitEditionSortNo")%> /></td>
		<td>
			<asp:Button ID="WBtnUpdate" Text="수정" CssClass="button" CommandName="update" CommandArgument=<%# GetDataItem(Container.DataItem, "productId")%> runat="server" />
			<asp:Button ID="WBtnDelete" Text="삭제" CssClass="button" CommandName="delete" CommandArgument=<%# GetDataItem(Container.DataItem, "productId")%> runat="server" />
		</td>
	</tr>
	</ItemTemplate>
	</asp:Repeater>
	</table>
    <p class="bottom_line"></p>

	<div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

	<div class="spacer"></div>
    상품추가
    <asp:PlaceHolder ID="AddForm"  runat="server">
	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_write">
    <tr>
		<th>카테고리ID</th>
		<th>분장상품타입</th>
		<th>아이템ID</th>
		<th>아이템귀속여부</th>
		<th>태그타입</th>
		<th>재화타입</th>
		<th>재화아이템ID</th>
		<th>원가격</th>
		<th>가격</th>
		<th>구매제한타입</th>

	</tr>
	<tr>
		<td>
            <asp:DropDownList ID="WDDLcategoryId" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="일상" Value="1" />
			    <asp:ListItem Text="장착" Value="2" />
			    <asp:ListItem Text="강화" Value="3" />
			    <asp:ListItem Text="특수" Value="4" />
			    <asp:ListItem Text="분장" Value="5" />
			    <asp:ListItem Text="VIP" Value="6" />
            </asp:DropDownList>
        </td>
		<td><asp:DropDownList ID="WDDLcostumeProductType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="코스튬" Value="1" />
			    <asp:ListItem Text="효과" Value="2" />
			    <asp:ListItem Text="탈것" Value="3" />
            </asp:DropDownList></td>
		<td><asp:DropDownList ID="WDDLItem" runat="server" /></td>
		<td><asp:CheckBox ID="WCBoxItemOwned" runat="server" /></td>
        <td>
            <asp:DropDownList ID="WDDLtagType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="일반" Value="0" />
			    <asp:ListItem Text="신품" Value="1" />
			    <asp:ListItem Text="한정" Value="2" />
			    <asp:ListItem Text="인기" Value="3" />
			    <asp:ListItem Text="특가" Value="4" />
			    <asp:ListItem Text="구매횟수한정" Value="5" />
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="WDDLmoneyType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="다이아(귀속/비귀속)" Value="1" />
			    <asp:ListItem Text="비귀속다이아" Value="2" />
			    <asp:ListItem Text="아이템" Value="3" />
            </asp:DropDownList>
        </td>
        <td><asp:TextBox ID="WTxtmoneyItemId" runat="server" ></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtoriginalPrice" runat="server" ></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtprice" runat="server" ></asp:TextBox></td>
        <td>
             <asp:DropDownList ID="WDDLbuyLimitType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="일일" Value="1" />
			    <asp:ListItem Text="누적" Value="2" />
            </asp:DropDownList>
        </td>  
	</tr>
    <tr>
		<th>구매제한횟수</th>
		<th>기간타입</th>
		<th>기간시작시각</th>
		<th>기간종료시각</th>
		<th>기간요일</th>
		<th>추천여부</th>
		<th>리밋에디션여부</th>
		<th>판매여부</th>
		<th>카테고리정렬번호</th>
		<th>리밋에디션정렬번호</th>
     </tr>
    <tr>
        <td>
            <asp:DropDownList ID="WDDLbuyLimitCount" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="무제한" Value="0" />
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="WDDLperiodType" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="무제한" Value="0" />
			    <asp:ListItem Text="기간" Value="1" />
			    <asp:ListItem Text="요일" Value="2" />
            </asp:DropDownList>
        </td>
        <td><asp:TextBox ID="WTxtperiodStartTime" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtperiodEndTime" runat="server"></asp:TextBox></td>
        <td>
           <asp:DropDownList ID="WDDLperiodDayOfWeek" AutoPostBack="true" runat="server">
			    <asp:ListItem Text="Sunday" Value="0" />
			    <asp:ListItem Text="Monday" Value="1" />
			    <asp:ListItem Text="Tuesday" Value="2" />
			    <asp:ListItem Text="Wendseday" Value="3" />
			    <asp:ListItem Text="Tursday" Value="4" />
			    <asp:ListItem Text="Friday" Value="5" />
			    <asp:ListItem Text="Saturday" Value="6" />
            </asp:DropDownList>
        </td>
        <td><asp:CheckBox ID="WCBoxRecommended" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxIsLimitEdition" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxSellable" runat="server" /></td>
        <td><asp:TextBox ID="WTxtcategorySortNo" runat="server" ></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtlimitEditionSortNo" runat="server"></asp:TextBox></td>
		
    </tr>
	</table>
    <p class="bottom_line"></p>

	<asp:Button ID="WBtnAddProduct" Text="상품 추가" OnClick="WBtnAddProduct_OnClick" CssClass="button" runat="server" />
	</asp:PlaceHolder>

	<div style="display:none;">
	<asp:DropDownList ID="WDDLItems" runat="server" />
	<asp:DropDownList ID="WDDLStores" runat="server" />
	</div>
</div>
</asp:Content>

