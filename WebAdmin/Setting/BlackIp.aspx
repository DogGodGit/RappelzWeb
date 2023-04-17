<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="BlackIp.aspx.cs" Inherits="Setting_BlackIp" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<div id="CONTENT_INNER">
    
    <h2>차단IP</h2>

    <h4>&nbsp; IP목록</h4>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
        <th>이름</th>
        <th>시작IP</th>
        <th>마지막IP</th>
        <th>기능</th>
    </tr>

    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><asp:Literal ID="WLtlRptName" Text='<%# GetDataItem(Container.DataItem, "name")%>' runat="server" /></td>
        <td class="center"><asp:Literal ID="WLtlRptStartIp" Text='<%# GetDataItem(Container.DataItem, "StartIp")%>' runat="server" /></td>
        <td class="center"><asp:Literal ID="WLtlRptEndIp" Text='<%# GetDataItem(Container.DataItem, "endIp")%>' runat="server" /></td>
        <td class="center"><asp:Button ID="WBtnDel" Text="삭제" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "startIpNo")+"|"+GetDataItem(Container.DataItem, "endIpNo")%>' CssClass="button" runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    <h4>IP 등록하기<asp:Label ID="WLabel" Text="" runat="server" /></h4>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
        <th>시작IP</th>
        <td class="left"><asp:TextBox ID="WtxtStartIp" runat="server" /></td>
        <th>마지막IP</th>
        <td class="left"><asp:TextBox ID="WtxtEndIp" runat="server" /></td>
        <th>이름</th>
        <td class="left"><asp:TextBox ID="WtxtName" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>

    <div class="formListRight">
        <asp:Button ID="WBtnAddIp" OnClick="WBtnAddIp_OnClick" Text="" CssClass="button" runat="server" />
    </div>
</div>
</asp:Content>