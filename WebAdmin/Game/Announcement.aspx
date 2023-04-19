<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="Announcement.aspx.cs" Inherits="Game_Announcement" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

    <h2>공지팝업</h2>

    <p class="top_line"></p>

    <h3>공지팝업 등록</h3>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>제목</th>
        <td><asp:TextBox ID="WTxtTitle" Columns="80" runat="server" /></td>
    </tr>
    <tr>
        <th>내용URL</th>
        <td><asp:TextBox ID="WTxtContentURL" Columns="80" runat="server" /></td>
    </tr>
    <tr>
        <th>시작시각</th>
        <td><asp:TextBox ID="WTxtStartTime" Columns="40" runat="server" /></td>
    </tr>
    <tr>
        <th>종료시각</th>
        <td><asp:TextBox ID="WTxtEndTime" Columns="40" runat="server" /></td>
    </tr>
    <tr>
        <th>정렬번호</th>
        <td><asp:TextBox ID="WTxtSortNo" Columns="20" runat="server" /> *정렬번호는 중복될 수 없습니다.</td>
    </tr>
    </table>
    
    <p class="bottom_line"></p>
    <asp:Button ID="WBtnAdd" Text="등록" OnClick="WBtnAdd_OnClick" Width="100" CssClass="button" runat="server" />

    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>정렬번호</th>
        <th>공지팝업ID</th>
        <th>제목</th>
        <th>내용URL</th>
        <th>시작시각</th>
        <th>종료시각</th>
        <th>노출여부</th>
        <th>등록시각</th>
        <th>기능</th>
    </tr>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><asp:Literal ID="WLtlSortNoUpdate" Text=<%# GetDataItem(Container.DataItem, "sortNo")%> runat="server" /></td>
        <td><%# GetDataItem(Container.DataItem, "announcementId")%></td>
        <td><asp:TextBox ID="WTxtTitleUpdate" Text=<%# GetDataItem(Container.DataItem, "title")%> runat="server" /></td>
        <td><asp:TextBox ID="WTxtContentURLUpdate" Text=<%# GetDataItem(Container.DataItem, "contentUrl")%> runat="server" /></td>
        <td><asp:TextBox ID="WTxtStartTimeUpdate" Text=<%# GetDataItem(Container.DataItem, "startTime")%> runat="server" /></td>
        <td><asp:TextBox ID="WTxtEndTimeUpdate" Text=<%# GetDataItem(Container.DataItem, "endTime")%> runat="server" /></td>
        <td><asp:DropDownList ID="WDDLVisibleUpdate" runat="server"><asp:ListItem Text="불가능" Value="0" /><asp:ListItem Text="가능" Value="1" /></asp:DropDownList></td>
        <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
        <td class="center">
        <asp:Button ID="WBtnUpdate" Text="수정" Width="60" CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "announcementId")%>' runat="server" />
        <asp:Button ID="WBtnDel" Text="삭제" Width="60" CssClass="button" CommandArgument=<%# GetDataItem(Container.DataItem, "announcementId")%> CommandName="delete" runat="server" />
        </td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
</div>
</asp:Content>
