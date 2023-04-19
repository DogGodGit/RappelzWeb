<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" Codebehind="DailyCharge.aspx.cs" Inherits="Game_Hero_Event_DailyCharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<body>
<div>
    <p class="top_line"></p>
    <h4>
        &nbsp;
       
        <a href="/Game/Hero/Event/FirstCharge.aspx?SVR=<%=m_nServerId.ToString() %>&HID=<%=m_heroId.ToString() %>" class="selected">첫결제</a>
        |
        <a href="/Game/Hero/Event/DailyCharge.aspx?SVR=<%=m_nServerId.ToString() %>&HID=<%=m_heroId.ToString() %>">매일충전</a>
        |
    </h4>
    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>일일충전다이아수</th>
        <td><asp:TextBox ID="WTxtDailyAccumulateChargeDia" runat="server" /> 
            <asp:HiddenField ID="WHFDailyAccumulateChargeDia" runat="server" />
            <asp:Literal ID="WLtlLastChargeTime" runat="server" /></td>
        <th>사유</th>
        <td><asp:TextBox ID="WTxtReason" Width="300" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>
    <asp:Button ID="WBtnUpdate" Text="" CssClass="button" OnClick="WBtnUpdate_OnClick" Visible="false" runat="server" />
    
    <div class="spacer"></div>

    <h4>보상내역</h4>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>날짜</th>
        <th>항목 ID</th>
        <th>일일충전다이아수</th>
        <th>등록시각</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptReward" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "date")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "entryId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "dailyChargeDia")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    <div class="spacer"></div>

    <h4>처리내역</h4>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>로그번호</th>
        <th>이전일일충전다이아수</th>
        <th>일일충전다이아수</th>
        <th>사유</th>
        <th>관리자 ID</th>
        <th>등록시각</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "logNo")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "oldDailyAccumulateChargeDia")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "dailyAccumulateChargeDia")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "reason")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "adminId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
 
</div>
</body>
</asp:Content>

