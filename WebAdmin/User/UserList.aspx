<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="UserList.aspx.cs" Inherits="User_UserList" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

    <h2>사용자관리</h2>
    
    <p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="right">
            <asp:Literal ID="WLtlSearchResult" runat="server" />
            <asp:TextBox ID="WTxtSearch" MaxLength="50" Columns="20" CssClass="text" runat="server" /> 
            <asp:Button ID="WBtnSearch" Text="검색" OnClick="WBtnSearch_OnClick" CssClass="button" runat="server" /> 
        </th>
    </tr>
    </table>
    <p class="bottom_line"></p>
    
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>사용자ID</th>
        <th>비밀키</th>
        <th>엑세스키</th>
        <th>인증타입</th>
        <th>삭제여부</th>
        <th>등록시각</th>
        <th>엑세스토큰</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
	<%--<a href="/Game/Account.aspx?uid=<%# GetDataItem(Container.DataItem, "userId")%>&as= ">--%>
        <td><%# GetDataItem(Container.DataItem, "userId")%></a></td>
        <td><%# GetDataItem(Container.DataItem, "secret")%></td>
        <td><%# GetDataItem(Container.DataItem, "accessSecret")%></td>
        <td><%# GetDataItem(Container.DataItem, "type")%></td>
        <td><%# GetDataItem(Container.DataItem, "deleted")%></td>
        <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
		<td><%# GetDataItem(Container.DataItem, "accessToken")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
    <div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>
    <div class="formListRight">
        <asp:Button ID="WBtnAdd" Text="게스트 사용자 생성" OnClick="WBtnAdd_OnClick" CssClass="button" runat="server" />
    </div>

</div>
</asp:Content>
