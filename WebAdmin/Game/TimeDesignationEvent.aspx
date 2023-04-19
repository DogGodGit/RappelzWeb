<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/Main.master" AutoEventWireup="true" Codebehind="TimeDesignationEvent.aspx.cs" Inherits="Game_TimeDesignationEvent" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<div id="CONTENT_INNER">

	<h2>접속자 우편발송</h2>

	<p class="top_line"><br /></p>
	<table cellspacing="2" class="bbs_read">
		<tr>
			<th class="left">
				서버<asp:DropDownList ID="WDDLServer" OnSelectedIndexChanged="WDDLServer_OnSelectedIndexChanged" AutoPostBack="true" runat="server" /> &nbsp;
				상태<asp:DropDownList ID="WDDLState" runat="server" /> 
				<asp:Button ID="WBtnSerch" Text="검색" CssClass="button" Width="50" OnClick="WBtnSerch_OnClick" runat="server" />
			</th>
		</tr>
	</table>
	<p class="bottom_line"></p>

	<div class="spacer"></div>

	<h4>접속자 우편발송 내역</h4>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
		<tr>
			<th>이벤트 번호</th>
			<th>이벤트명</th>
			<th>사용기간</th>
			<th>삭제</th>
		</tr>

	<asp:Repeater ID="WRptList" OnItemCommand="WRptList_OnItemCommand" OnItemDataBound="WRptList_OnItemDataBound" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "eventId")%></td>
        <td class="center"><asp:Label ID="WLabelName" Text=<%# GetDataItem(Container.DataItem, "_name")%> runat="server" /></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "startTime")%> ~ <%# GetDataItem(Container.DataItem, "endTime")%></td>
		<td class="center"><asp:Button ID="WBtnDel" CssClass="button" Text="" CommandArgument=<%# GetDataItem(Container.DataItem, "eventId")%> CommandName="delete"  runat="server" /></td>
    </tr>
	
    </ItemTemplate>
    </asp:Repeater>
	</table>
	<p class="bottom_line"></p>
	<div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

    <div class="formListRight">
        <input type="button" value='새 이벤트만들기' class="button" onclick="location.href='/Game/TimeDesignationEventForm.aspx';" />
    </div>

</div>
</asp:Content>

