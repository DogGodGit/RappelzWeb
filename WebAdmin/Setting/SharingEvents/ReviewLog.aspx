<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="ReviewLog.aspx.cs" Inherits="Setting_SharingEvents_ReviewLog" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<div id="CONTENT_INNER">
    <h2>리뷰 로그</h2>
    
	<div class="spacer"></div>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>게임서버ID</th>
        <th>계정영웅ID</th>
        <th>영웅ID</th>
        <th>캐릭터레벨</th>
        <th>만족도</th>
        <th>등록시각</th>
    </tr>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>

        <td class="center"><%# GetDataItem(Container.DataItem, "gameServerId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "accountHeroId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "heroId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "level")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "satisfaction")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>

	<p class="bottom_line"></p>
    <div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

</div>
</asp:Content>
