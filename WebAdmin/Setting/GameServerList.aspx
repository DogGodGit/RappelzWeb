<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="GameServerList.aspx.cs" Inherits="Setting_GameServerList" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>게임서버</h2>

    <p class="bottom_line"></p>

	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>서버그룹</th>
		<td><asp:DropDownList ID="WDDLSGroup" OnSelectedIndexChanged="WDDLServerGroup_OnSelectedIndexChanged" AutoPostBack="true" Visible ="true" runat="server"></asp:DropDownList></td>
	</tr>
	</table>
	
	<%-- 게임서버 관리 --%>
	<asp:PlaceHolder ID="WPHServerInfo" Visible="false" runat="server">
	<p class="bottom_line"></p>
	
    <div class="spacer"></div>
	
    <h2>가상서버관리</h2>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th>가상서버ID</th>
        <th>서버ID</th>
        <th>이름</th>
        <th>표시번호</th>
		<th>수정</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptVList" OnItemDataBound="WRptVList_OnItemDataBound" OnItemCommand="WRptVList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "virtualGameServerId")%></td>
        <td><asp:TextBox ID="WTxtGameServerId" Text=<%# GetDataItem(Container.DataItem, "serverId")%> Width="40" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtName" Text=<%# GetDataItem(Container.DataItem, "displayName")%> Width="100" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtDisplayNo" Text=<%# GetDataItem(Container.DataItem, "displayNo")%> Width="40" runat="server"></asp:TextBox></td>
		<td><asp:Button ID="WBtnUpdate" Text="수정" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "virtualGameServerId")%>' CommandName="update" runat="server" />
			<asp:Button ID="WBtnDelete" Text="삭제" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "virtualGameServerId")%>' CommandName="delete" runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
	
	<div class="spacer"></div>

    <p class="top_line"><br /></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
        <th>가상서버ID</th>
        <td class="left"><asp:TextBox ID="WTxtVirtualGameServerId" Width="60" runat="server" /></td>
        <th>서버ID</th>
        <td class="left"><asp:TextBox ID="WTxtVGameServerId" Width="60" runat="server" /></td>
        <th>이름</th>
        <td class="left"><asp:TextBox ID="WTxtVName" runat="server" /></td>
        <th>표시번호</th>
        <td class="left"><asp:TextBox ID="WTxtVDisplayNo" Width="60" runat="server" /></td>
		<td><asp:Button ID="WBtnVAdd" Text="등록" OnClick="WBtnVAdd_OnClick" Width="100" CssClass="button" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>

    <div class="spacer"></div>

    <h2>게임서버관리</h2>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_01%></th>
		<th>그룹ID</th>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_04%></th>
        <th>프록시서버주소</th>
        <th>프록시서버포트</th>
        <th>접속유저수</th>
        <th>GameDBConn</th>
		<th>GameLogDBConn</th>
        <th>상태</th>
        <th>신서버여부</th>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_08%></th>
        <th>추천서버여부</th>
        <th><%=Resources.ResLang.GameServerList_aspx_txt_04%></th>
        <th><%=Resources.ResLang.GameServerList_aspx_txt_05%></th>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_11%></th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "serverId")%></td>
        <td><asp:Literal ID="WLtlGameServerGroupId" runat="server" /></td>
        <td><asp:TextBox ID="WTxtApiUrl" Text=<%# GetDataItem(Container.DataItem, "apiUrl")%> Width="270" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtGameServerIp" Text=<%# GetDataItem(Container.DataItem, "proxyServer")%> Width="120" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="WTxtGameServerPort" Text=<%# GetDataItem(Container.DataItem, "proxyServerPort")%> Width="60" runat="server"></asp:TextBox></td>
        <td><%# GetDataItem(Container.DataItem, "currentUserCount")%></td>
		<td><asp:TextBox ID="WTxtGameServerDBConn" Text=<%# GetDataItem(Container.DataItem, "gameDBConnection") %> Width="100"  style="text-align:center" runat="server" /></td>
		<td><asp:TextBox ID="WTxtGameLogServerDBConn" Text=<%# GetDataItem(Container.DataItem, "gameLogDBConnection") %> Width="100"  style="text-align:center" runat="server" /></td>
        <td><asp:DropDownList ID="WDDLStatus" runat="server"><asp:ListItem Text="원활" Value="1" /><asp:ListItem Text="혼잡" Value="2" /><asp:ListItem Text="포화" Value="3" /></asp:DropDownList></td>
        <td><asp:DropDownList ID="WDDLIsNew" runat="server"><asp:ListItem Text="비활성화" Value="0" /><asp:ListItem Text="활성화" Value="1" /></asp:DropDownList></td>
        <td><asp:DropDownList ID="WDDLMaintenance" runat="server"><asp:ListItem Text="정상" Value="0" /><asp:ListItem Text="점검중" Value="1" /></asp:DropDownList></td>
        <td><asp:DropDownList ID="WDDLIsRecommendable" runat="server"><asp:ListItem Text="비활성화" Value="0" /><asp:ListItem Text="활성화" Value="1" /></asp:DropDownList></td>
        <td><asp:CheckBox ID="WCBoxRecommendable" runat="server" /></td>
        <td><asp:DropDownList ID="WDDLPublic" runat="server"><asp:ListItem Text="비공개" Value="0" /><asp:ListItem Text="공개" Value="1" /></asp:DropDownList></td>
        <td><asp:Button ID="WBtnGameServerUpdate" Text="수정" CssClass="button" CommandArgument='<%# GetDataItem(Container.DataItem, "serverId")%>' CommandName="update" runat="server" />
			<asp:Button ID="WBtnGameServerDel" Text="삭제" CssClass="button" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "serverId")%>' runat="server" />
            <asp:Literal ID="WLtlDeleted" runat="server" />
        </td>
            
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    <div class="spacer"></div>

    <p class="top_line"><br /></p>
	<%-- 게임서버 생성 --%>
	<h2>게임서버 생성</h2>
    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <tr>
		<th>그룹ID</th>
		<td class="left"><asp:Literal ID="WLtlGameServerGroupIdAdd" runat="server" /></td>
	</tr>
    <tr>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_01%></th>
        <td class="left"><asp:TextBox ID="WTxtGameServerIdAdd" runat="server" /> <%=Resources.ResLang.GAMESLIST_aspx_txt_02%></td>
    </tr>
    <tr>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_04%></th>
        <td class="left"><asp:TextBox ID="WTxtApiAdd" Width="300" runat="server" /></td>
    </tr>
    <tr>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_05%></th>
        <td class="left"><asp:TextBox ID="WTxtProxyAdd" Width="300" runat="server" /></td>
    </tr>
    <tr>
        <th><%=Resources.ResLang.GAMESLIST_aspx_th_06%></th>
        <td class="left"><asp:TextBox ID="WTxtProxyPortAdd" runat="server" /> <%=Resources.ResLang.GAMESLIST_aspx_txt_02%></td>
    </tr>
	<tr>
		<th>GameDBConn</th>
		<td class="left"><asp:TextBox ID="WTxtGameDBConnection" Width="400" runat="server" /></td>
	</tr>
	<tr>
		<th>GameLogDBConn</th>
		<td class="left"><asp:TextBox ID="WTxtGameLogDBConnection" Width="400" runat="server" /></td>
	</tr>
    </table>
    <p class="bottom_line"></p>
    <asp:Button ID="WBtnAdd" Text="" OnClick="WBtnGameServerAdd_OnClick" Width="100" CssClass="button" runat="server" />

	</asp:PlaceHolder>


</div>
</asp:Content>
