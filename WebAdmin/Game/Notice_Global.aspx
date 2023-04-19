<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="Notice_Global.aspx.cs" Inherits="Game_Notice_Global" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    
    <h2>인게임공지 관리</h2>

    <p class="top_line"></p>
    <h4>
        &nbsp;
        <a href="Notice_Server.aspx">서버공지</a>
        |
        <a href="Notice_Global.aspx" class="selected">글로벌공지</a>
    </h4>
    <p class="bottom_line"></p>
    <p class="top_line"><br /></p>

    <asp:PlaceHolder ID="WHide" Visible="true" runat="server">
    <h3>글로벌공지 등록</h3>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>내용</th>
        <td><asp:TextBox ID="WTxtContent" Columns="80" runat="server" /></td>
    </tr>
    <tr>
        <th>표시시각</th>
        <td><asp:TextBox ID="WTxtDisplayTime" Columns="40" runat="server" /></td>
    </tr>
    <tr>
        <th>표시간격</th>
        <td><asp:TextBox ID="WtxtDisplayInterval" Columns="40" runat="server" /></td>
    </tr>
    <tr>
        <th>반복횟수</th>
        <td><asp:TextBox ID="WtxtRepetitionCount" Columns="40" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>
    <asp:Button ID="WBtnAdd" Text="등록" OnClick="WBtnAdd_OnClick" Width="100" CssClass="button" runat="server" />
    </asp:PlaceHolder>

    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>공지ID</th>
        <th>내용</th>
        <th>표시시각</th>
        <th>표시간격</th>
        <th>반복횟수</th>
        <th>등록시각</th>
        <th>삭제</th>
    </tr>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "noticeId")%></td>
        <td><%# GetDataItem(Container.DataItem, "content")%></td>
        <td><%# GetDataItem(Container.DataItem, "displayTime")%></td>
        <td><%# GetDataItem(Container.DataItem, "displayInterval")%></td>
        <td><%# GetDataItem(Container.DataItem, "repetitionCount")%></td>
        <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
        <td class="center"><asp:Button ID="WBtnDel" Text="" Width="60" CssClass="button" CommandArgument=<%# GetDataItem(Container.DataItem, "noticeId")%> CommandName="delete" runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>

</div>
</asp:Content>
