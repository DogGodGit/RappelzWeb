<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/Main.master" AutoEventWireup="true" CodeFile="ClientText.aspx.cs" Inherits="Setting_ClientText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<div id="CONTENT_INNER">
	<script language="javascript" type="text/javascript">
	    function excelDownload() {
	        window.open("<%=m_sPopupUrl %>", "excel", "width=400,height=400");
	    }
	</script>

	<h2>Client Text</h2>

    <div style="text-align:right; font-size:large">
    Standard Language
    <asp:DropDownList ID="WDDLStandardLanguage" OnSelectedIndexChanged="WDDLStandardLanguage_OnSelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>
    </div>
    
    <h4>[Languages] <asp:Button ID="WBtnInit" Text="한국어 기준 데이터 초기화" CssClass="buttonRed" OnClick="WBtnInit_OnClick" Visible="false" runat="server" /></h4>

    <p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>LanguageId</th>
		<th>Language</th>
        <th>Download</th>
        <th>New Text</th>
        <th>New Text_Count</th>
        <th>Total</th>
        <th>Update</th>
	</tr>

    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "languageId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "languageName")%></td>
        <td class="center"><asp:Button ID="WBtnDownLoad" Text="Excel_DownLoad" CssClass="button" CommandName="download" CommandArgument='<%# GetDataItem(Container.DataItem, "languageId")%>' runat="server" /></td>
        <td class="center"><asp:Button ID="WBtnNewTextDown" Text="NewText_DownLoad" CssClass="button" CommandName="NewTextDown" CommandArgument='<%# GetDataItem(Container.DataItem, "languageId")%>' runat="server" /></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "NewTextCount")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "totalCount")%></td>
        <td class="center"><asp:FileUpload ID="WFUUpload" runat="server" />
						   <asp:Button ID="WBtnUpload" Text="Upload" CssClass="button" CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "languageId")%>' runat="server" />
						   <!--a href="/Setting/ClientTextChanges.aspx?SID=<%=m_nStandardLanguageId %>&LID=<%# GetDataItem(Container.DataItem, "languageId")%>">View Changes</a-->
		</td><%--<td class="center"><a href="javascript:;" onclick="window.open('/Setting/CouponPopup/CouponAllCheck.aspx?PID=<%# GetDataItem(Container.DataItem, "promotionId")%>', 'couponList', 'width=1000,height=700');">[<%=Resources.resLang.CouponSystem_aspx_txt_13%>]</a></td>--%>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
	</table>
<%--	<p class="bottom_line"></p>

	<div class="spacer"></div>

    <h4>[New Text]</h4>
    <h4><asp:Literal ID="WLtlTitleName" runat="server" /></h4>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th><asp:Literal ID="WLtlLanguageId" Text="LanguageId" runat="server" /></th>
		<th><asp:Literal ID="WLtlName" Text="Name" runat="server" /></th>
        <th><asp:Literal ID="WLtlSValue" Text="StandardValue" runat="server" /></th>
        <th><asp:Literal ID="WLtlValue" Text="Current Value" runat="server" /></th>
	</tr>

    <asp:Repeater ID="WRptList_NewText" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "languageId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "Name")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "StandardValue")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "value")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
	</table>--%>

    <p class="bottom_line"></p>

</div>
</asp:Content>

