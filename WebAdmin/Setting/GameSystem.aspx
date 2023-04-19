<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="GameSystem.aspx.cs" Inherits="Setting_GameSystem" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<h2>게임시스템</h2>

	<p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">서버<asp:DropDownList ID="WDDLServer" AutoPostBack="true" OnSelectedIndexChanged="WDDLServer_OnSelectedIndexChanged" runat="server" /></th>
    </tr>
    </table>
    <p class="bottom_line"></p>

	<asp:PlaceHolder ID="WPHForm" Visible="false" runat="server">
	
	<div class="spacer"></div>

	<h1><span class="red"><asp:Literal ID="WLtlWarning" runat="server" /></span></h1>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>서버시간</th>
		<td><asp:Literal ID="WLtlServerTime" runat="server" /></td>
	</tr>
    <tr>
		<th>서버오픈일자</th>
        <td>
			<asp:TextBox ID="WTxtServerOpenDate"  Width="80" runat="server" /> * YYYY-MM-DD 
			<asp:Button ID="WBtnUpdate" Text="수정" Width="60" OnClick="WBtnUpdate_OnClick" CssClass="button" runat="server" />
        </td>
    </tr>
    </table>
    <p class="bottom_line"></p>
	
	</asp:PlaceHolder>
</div>
</asp:Content>