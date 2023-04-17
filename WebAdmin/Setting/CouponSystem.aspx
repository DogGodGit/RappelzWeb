<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="CouponSystem.aspx.cs" Inherits="Setting_CouponSystem" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<div id="CONTENT_INNER">

	<h2><%=Resources.ResLang.CouponSystem_aspx_txt_01%></h2>

	<h4>&nbsp; <%=Resources.ResLang.CouponSystem_aspx_txt_02%></h4>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_03%></th>
		<td><asp:TextBox ID="WTxtName" runat="server" /></td>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_04%></th>
		<td><asp:TextBox ID="WTxtStartTime" runat="server" /> ~ 
			<asp:TextBox ID="WTxtEndTime" runat="server" />
		</td>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_05%></th>
		<td><asp:TextBox ID="WTxtCouponId" runat="server" /></td>
		<td><asp:Button ID="WBtnSearch" Text="" Width="100" CssClass="button" OnClick="WBtnSearch_OnClick" runat="server" /></td>
	</tr>
	</table>
	<p class="bottom_line"></p>

    <div class="spacer"></div>

	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_07%></th>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_03%></th>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_08%></th>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_09%></th>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_10%></th>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_11%></th>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_12%></th>
	</tr>
	<asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "promotionId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "_name")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "couponCount")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "startTime")%> ~ <%# GetDataItem(Container.DataItem, "endTime")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "type")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "enabled")%></td>
        <td class="center"><a href="javascript:;" onclick="window.open('/Setting/Popup/CouponAllCheck.aspx?PID=<%# GetDataItem(Container.DataItem, "promotionId")%>', 'couponList', 'width=1000,height=700');">[<%=Resources.ResLang.CouponSystem_aspx_txt_13%>]</a></td>
    </tr>
	
    </ItemTemplate>
    </asp:Repeater>
	</table>
	<p class="bottom_line"></p>
	<div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>
    <div class="formListRight">
        <input type="button" value="<%=Resources.ResLang.CouponAdd_aspx_txt_01%>" class="button" onclick="location.href='/Setting/Couponform.aspx';" />
    </div>
</div>
</asp:Content>
