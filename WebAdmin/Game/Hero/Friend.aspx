<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" CodeFile="Friend.aspx.cs" Inherits="Game_Hero_Friend" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigatorFriend" Src="~/Common/UserControl/PageNavigator.ascx" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigatorFriendBlock" Src="~/Common/UserControl/PageNavigator.ascx" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigatorFriendEnemy" Src="~/Common/UserControl/PageNavigator.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<body>
<div>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>

        <th>친구 리스트</th>
        <th>차단 리스트</th>
        <th>적대 리스트</th>

    </tr>
    <tr>
        <td class="paddingZero">

            <table cellspacing="1" cellpadding="0" class="bbs_list">
            <tr>
                <th>등록일</th>
                <th>닉네임</th>
                <th>레벨</th>
                <!--th>삭제하기</th-->
            </tr>
            <asp:Repeater ID="WRptFriend" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
            <ItemTemplate>
            <tr>
                <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
                <td><%# GetDataItem(Container.DataItem, "name")%></td>
                <td><%# GetDataItem(Container.DataItem, "level")%></td>
                <!--td><asp:Button ID="WBtnDel" Text="삭제하기" CssClass="button" Visible="false" CommandName="delete" CommandArgument=<%# GetDataItem(Container.DataItem, "friendId")%> runat="server" /></td-->
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            </table>

            <div class="pageNavi">
                <ucl:PageNavigatorFriend ID="WPageNavigatorFriend" Runat="server" />
            </div>

        </td>
        <td class="paddingZero">

            <table cellspacing="1" cellpadding="0" class="bbs_list">
            <tr>
                <th>등록일</th>
                <th>닉네임</th>
                <th>레벨</th>
                <!--th>삭제하기</th-->
            </tr>
            <asp:Repeater ID="WRptFriendBlock" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
            <ItemTemplate>
            <tr>
                <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
                <td><%# GetDataItem(Container.DataItem, "name")%></td>
                <td><%# GetDataItem(Container.DataItem, "level")%></td>
                <!--td><asp:Button ID="WBtnDel" Text="삭제하기" CssClass="button" Visible="false" CommandName="delete" CommandArgument=<%# GetDataItem(Container.DataItem, "friendId")%> runat="server" /></td-->
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            </table>

            <div class="pageNavi">
                <ucl:PageNavigatorFriendBlock ID="WPageNavigatorFriendBlock" Runat="server" />
            </div>

        </td>
        <td class="paddingZero">

            <table cellspacing="1" cellpadding="0" class="bbs_list">
            <tr>
			    <th>등록일</th>
                <th>닉네임</th>
                <th>레벨</th>
                <!--th>삭제하기</th-->
            </tr>
            <asp:Repeater ID="WRptFriendEnemy" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
            <ItemTemplate>
            <tr>
                <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
                <td><%# GetDataItem(Container.DataItem, "name")%></td>
                <td><%# GetDataItem(Container.DataItem, "level")%></td>
                <!--td><asp:Button ID="WBtnDel" Text="삭제하기" CssClass="button" Visible="false" CommandName="delete" CommandArgument=<%# GetDataItem(Container.DataItem, "friendId")%> runat="server" /></td-->
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            </table>

            <div class="pageNavi">
                <ucl:PageNavigatorFriendEnemy ID="WPageNavigatorFriendEnemy" Runat="server" />
            </div>

        </td>
    </tr>
    </table>
    <p class="bottom_line"></p>
</div>
</body>
</asp:Content>

