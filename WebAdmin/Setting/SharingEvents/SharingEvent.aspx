<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="SharingEvent.aspx.cs" Inherits="Setting_SharingEvents_SharingEvent" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    <h2>공유하기</h2>
    
	<div class="spacer"></div>
    
    <p class="bottom_line"></p>
    <h4>
        &nbsp;
        <a href="/Setting/SharingEvents/SharingEvent.aspx" class="selected">공유하기 이벤트</a>
        |
        <a href="/Setting/SharingEvents/SharingEventSenderReward.aspx">발신자보상</a>
        |
        <a href="/Setting/SharingEvents/SharingEventReceiveReward.aspx">수신자보상</a>
        |
        <a href="/Setting/SharingEvents/SharingEventSenderLog.aspx">발신자 로그</a>
        |
        <a href="/Setting/SharingEvents/SharingEventReceiverLog.aspx">수신자 로그</a>

    </h4>

    <p class="bottom_line"></p>
	<div class="spacer"></div>

	<span class="red"> 
    *이미 등록된 캠페인과 이벤트 기간이 겹치지 않도록 유의해주세요. <br />
    (이벤트 기간이 겹치는 캠페인이 존재할 경우, 보상 시 오류발생할 수 있음) 
    </span>

	<div class="spacer"></div>

    <p class="bottom_line"></p>
    <h4>공유하기 이벤트 목록</h4>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>이벤트ID</th>
        <th>홍보내용타입</th>
        <th>홍보내용</th>
        <th>보상범위</th>
        <th>보상최대횟수</th>
        <th>목표레벨</th>
        <th>시작시각</th>
        <th>종료시각</th>
        <th>보상메일제목타입</th>
        <th>보상메일제목</th>
        <th>보상메일내용타입</th>
        <th>보상메일내용</th>
        <th>이미지이름</th>
        <th>기능</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "eventId")%></td>
        <td><asp:DropDownList ID="WDDLContentType" runat="server" /></td>
        <td class="left"><asp:TextBox ID="WTxtContent" Text='<%# GetDataItem(Container.DataItem, "content")%>' runat="server" /></td>
        <td><asp:DropDownList ID="WDDLRewardRange" runat="server" /></td>
        <td class="left"><asp:TextBox ID="WTxtRewardLimitCount" Text='<%# GetDataItem(Container.DataItem, "senderRewardLimitCount")%>' runat="server" /></td>
        <td class="left"><asp:TextBox ID="WTxtTargetLevel" Text='<%# GetDataItem(Container.DataItem, "targetLevel")%>' runat="server" /></td>
        <td><asp:TextBox ID="WTxtStartTime" Text='<%# GetDataItem(Container.DataItem, "startTime")%>' runat="server" /></td>
        <td><asp:TextBox ID="WTxtEndTime" Text='<%# GetDataItem(Container.DataItem, "endTime")%>' runat="server" /></td>
        <td><asp:DropDownList ID="WDDLMailTitleType" runat="server" /></td>
        <td class="left"><asp:TextBox ID="WTxtMailTitle" Text='<%# GetDataItem(Container.DataItem, "rewardMailTitle")%>' runat="server" /></td>
        <td><asp:DropDownList ID="WDDLMailContentType" runat="server" /></td>
        <td class="left"><asp:TextBox ID="WTxtMailContent" Text='<%# GetDataItem(Container.DataItem, "rewardMailContent")%>' runat="server" /></td>
        <td class="left"><asp:TextBox ID="WTxtImageName" Text='<%# GetDataItem(Container.DataItem, "imageName")%>' runat="server" /></td>

<%--        <td class="left"><asp:TextBox ID="WTxtValue" Text='<%# GetDataItem(Container.DataItem, "value")%>' Width="400" runat="server" />
			<asp:Literal ID="WLtlInfo" runat="server" />
			<asp:HiddenField ID="WHFOldValue" Value='<%# GetDataItem(Container.DataItem, "value")%>' runat="server" />
			<asp:HiddenField ID="WHFName" Value='<%# GetDataItem(Container.DataItem, "name")%>' runat="server" /></td>--%>
        <td><asp:Button ID="WBtnUpdate" CssClass="button" Width="60" Text="수정" CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "eventId")%>' runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
	<asp:HiddenField ID="WHFApiUrl" runat="server" />

	<div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

    <div class="formListRight">
        <input type="button" value="공유하기 이벤트 등록" class="button" onclick="location.href='/Setting/SharingEvents/SharingEventAdd.aspx';" />
    </div>
</div>
</asp:Content>