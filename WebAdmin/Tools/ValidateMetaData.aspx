<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="ValidateMetaData.aspx.cs" Inherits="Tools_ValidateMetaData" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>메타데이터 유효성 체크</h2>

    <p class="top_line"></p>
	<table id="tblLangs" cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th><asp:Button ID="WBtnValidate" Text="Validate Check" Width="300" Height="30" OnClick="WBtnValidate_OnClick" CssClass="button" runat="server" /></th>
	</tr>
	<tr>
		<td class="left"><asp:Literal ID="WLtlResult" runat="server" /></td>
	</tr>
	</table>
</div>
</asp:Content>