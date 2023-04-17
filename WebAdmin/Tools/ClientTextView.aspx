<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="ClientTextView.aspx.cs" Inherits="Tools_ClientTextView" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>클라이언트 텍스트 확인</h2>

    <p class="top_line"></p>
	<table id="tblLangs" cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th><asp:DropDownList ID="WDDLLanguage" runat="server" /> 
			<asp:TextBox ID="WTxtKey" Width="200" MaxLength="20" runat="server" />
			<asp:Button ID="WBtnView" Text="View" OnClick="WBtnView_OnClick" CssClass="button" runat="server" /></th>
	</tr>
	<tr>
		<td class="center" style="padding:100px;">
			<asp:Literal ID="WLtlResult" runat="server" />
		</td>
	</tr>
	</table>
</div>
</asp:Content>