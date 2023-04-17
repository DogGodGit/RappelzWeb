<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" CodeFile="FirstCharge.aspx.cs" Inherits="Game_Hero_Event_FirstCharge" %>

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

    <h4>첫결제 이벤트 내역</h4>
    <asp:PlaceHolder ID="WPHContent" Visible="false" runat="server">
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>수령여부</th>
        <th>수령시각</th>
        <th>등록시각</th>
    </tr>
    </thead>
    <tr>
        <td class="center"><asp:Literal ID="WLtlReceived" runat="server" /><asp:HiddenField ID="WHFReceived" runat="server" /></td>
        <td class="center"><asp:Literal ID="WLtlReceiveTime" runat="server" /></td>
        <td class="center"><asp:Literal ID="WLtlRegTime" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>
   사유 <asp:TextBox ID="WTxtReason" Width="300" runat="server" />
    <asp:Button ID="WBtnDelete" Text="" CssClass="button" OnClick="WBtnDelete_OnClick" runat="server" />
    
    <div class="spacer"></div>
    </asp:PlaceHolder>

    <h4>처리내역</h4>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>로그번호</th>
        <th>보상수령여부</th>
        <th>사유</th>
        <th>관리자 ID</th>
        <th>등록시각</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "logNo")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "rewardReceived")%></td>
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

