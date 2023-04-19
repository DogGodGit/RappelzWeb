<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="HeroList.aspx.cs" Inherits="Game_HeroList" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<h2>영웅관리</h2>

    <p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">
            가상서버<asp:DropDownList ID="WDDLServer" runat="server" />
            &nbsp;&nbsp;&nbsp;
            검색대상 <asp:DropDownList ID="WDDLType" runat="server" />
            <asp:TextBox ID="WTxtSearch" runat="server" /> 
            <asp:Button ID="WBtnSearch" Text="검색" OnClick="WBtnSearch_OnClick" CssClass="button" runat="server" />
            </th>
    </tr>
    </table>

    <p class="bottom_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>영웅ID</th>
        <th>이름</th>
        <th>계정ID</th>
        <th>국가ID</th>
        <th>직업ID</th>
        <th>레벨</th>
        <th>삭제여부</th>
        <th>등록시각</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "heroId")%></td>
        <td><strong><%# GetDataItem(Container.DataItem, "name")%></strong></td>
        <td><%# GetDataItem(Container.DataItem, "accountId")%></td>
        <td><%# GetDataItem(Container.DataItem, "nationId")%></td>
        <td><%# GetDataItem(Container.DataItem, "jobId")%></td>
        <td><%# GetDataItem(Container.DataItem, "level")%></td>
        <td><%# GetDataItem(Container.DataItem, "deleted")%></td>
        <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
</div>
</asp:Content>