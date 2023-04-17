<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="ClientTextChanges.aspx.cs" Inherits="Setting_ClientTextChanges" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<h2>Client Text Update</h2>

	<input type="button" class="button" value="Back" onclick="location.href='/Setting/ClientText.aspx?SID=<%=m_nStandardLanguageId %>&LID=<%=m_nLanguageId %>';" />

	<h4>Standard Language - <asp:Literal ID="WLtlStandardLanguage" runat="server" /></h4>

	<h4>[Changes]</h4>

    <asp:Button ID="WBtnUpdate" Text="" CssClass="button" OnClick="WBtnUpdate_OnClick" runat="server" />

	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>TYPE</th>
        <th>Name</th>
        <th>New Value</th>
        <th>Current Value</th>
	</tr>

    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "status")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "name")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "newValue")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "value")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
	</table>
	<p class="bottom_line"></p>

</div>
</asp:Content>