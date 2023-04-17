<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="SharingEventReceiveReward.aspx.cs" Inherits="Setting_SharingEvents_SharingEventReceiveReward" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    <h2>공유하기 - 수신자보상 목록</h2>
    
	<div class="spacer"></div>
    
    <p class="bottom_line"></p>
    <h4>
        &nbsp;
        <a href="/Setting/SharingEvents/SharingEvent.aspx">공유하기 이벤트</a>
        |
        <a href="/Setting/SharingEvents/SharingEventSenderReward.aspx">발신자보상</a>
        |
        <a href="/Setting/SharingEvents/SharingEventReceiveReward.aspx" class="selected">수신자보상</a>
        |
        <a href="/Setting/SharingEvents/SharingEventSenderLog.aspx">발신자 로그</a>
        |
        <a href="/Setting/SharingEvents/SharingEventReceiverLog.aspx">수신자 로그</a>
      
    </h4>
    <p class="bottom_line"></p>
	<div class="spacer"></div>

    <p class="top_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_read">
        <h4>공유하기 수신자보상 등록</h4>
        <p class="top_line"></p>
        <th>이벤트ID</th>
        <td><asp:TextBox ID="WTxtEventId" runat="server" /></td>
    <tr>
        <th>보상번호</th>
        <td><asp:TextBox ID="WTxtRewardNo" runat="server" /></td>
    </tr>
    <tr>
    <th>아이템</th>
    <td><asp:DropDownList ID="WDDLItem" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxOwnItem" Text="" runat="server" /> 귀속</td>
        <td>수량 <asp:TextBox ID="WTxtItemCount" Text="1" MaxLength="3" runat="server" /></td>
    </tr>
    </table>
    <p class="top_line"></p>
    <asp:Button ID="WBtnAddSharingEventReceiverReward" Text="공유하기 수신자보상 등록" CssClass="button" OnClick="WBtnAddSharingEventReceiverReward_OnClick"  runat="server" />

	<div class="spacer"></div>
    <p class="bottom_line"></p>
    
    
    <%--수신자보상 목록--%>

    <h4>공유하기 수신자보상 목록</h4>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>이벤트ID</th>
        <th>보상번호</th>
        <th>아이템</th>
        <th>귀속여부</th>
        <th>수량</th>
        <th>기능</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "eventId")%></td>
        <td><asp:TextBox ID="WTxtRewardNos" Text='<%# GetDataItem(Container.DataItem, "rewardNo")%>' runat="server" /></td>
        <td><asp:DropDownList ID="WDDLItems" runat="server" /></td>
        <td><asp:CheckBox ID="WCBoxOwnItems" runat="server" /></td>
        <td><asp:TextBox ID="WTxtItemCounts" Text='<%# GetDataItem(Container.DataItem, "itemCount")%>' runat="server" /></td>

        <td>
            <asp:Button ID="WBtnUpdate" CssClass="button" Width="60" Text="수정" CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "eventId")%>' runat="server" />
            <asp:Button ID="WBtnDelete" CssClass="button" Width="60" Text="삭제" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "eventId")%>' runat="server" />
        </td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
	<asp:HiddenField ID="WHFApiUrl" runat="server" />

	<div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

</div>
</asp:Content>