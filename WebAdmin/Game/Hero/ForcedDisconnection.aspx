<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" Codebehind="ForcedDisconnection.aspx.cs" Inherits="Game_Hero_ForcedDisconnection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<body>
<div>
    <p class="top_line"></p>
    <h4> * 목록은 최대 30개까지 표시됩니다.</h4>
    <p class="bottom_line"></p>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <thead>
    <tr>
        <th>작업번호</th>
        <th>처리여부</th>
        <th>등록시각</th>
        <th>처리시각</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "taskNo")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "handled")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "regTime")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "handleTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    <div class="spacer"></div>

    <p class="top_line"></p>
    <h4> * 제재중인 경우 제재 등록이 되지 않습니다. (에러코드 -2 관련)</h4>
    <p class="bottom_line"></p>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th><asp:CheckBox ID="WCBox" Text="" runat="server" /></th>
        <th>사유</th>
        <td><asp:TextBox ID="WTxtReason" Text="" runat="server" /></td>
        <th>제재시간</th>
        <td><asp:TextBox ID="WTxtTime" Text="30" CssClass="txtAttr" runat="server" />분></td>
    </tr>
    </table>
    <p class="bottom_line"></p>

    <asp:Button ID="WBtnAdd" Text="" CssClass="button" OnClick="WBtnAdd_OnClick" runat="server" />

</div>
</body>
</asp:Content>

