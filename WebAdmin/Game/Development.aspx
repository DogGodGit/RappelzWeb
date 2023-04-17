<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="Development.aspx.cs" Inherits="Game_Development" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">가상서버<asp:DropDownList ID="WDDLServer" runat="server" /></th>
    </tr>
    </table>
    <p class="bottom_line"></p>

	<div class="spacer"></div>

	<p class="top_line"></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
		<td><asp:Button ID="WBtnNationWarInit" Text="금일 국가전초기화" CssClass="button" OnClick="WBtnNationWarInit_OnClick" runat="server" /></td>
	</tr>
    </table>
    <p class="bottom_line"></p>
</div>
</asp:Content>