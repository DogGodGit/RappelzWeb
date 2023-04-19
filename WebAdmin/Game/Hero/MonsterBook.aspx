<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" Codebehind="MonsterBook.aspx.cs" Inherits="Game_Hero_MonsterBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<body>
<div>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <thead>
    <tr>
        <th>대륙</th>
        <th>몬스터</th>
        <th>몬스터정수</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "continentName")%></td>
        <td><%# GetDataItem(Container.DataItem, "name")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "count")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
</div>
</body>
</asp:Content>

