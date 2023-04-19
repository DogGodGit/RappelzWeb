<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="Languages.aspx.cs" Inherits="Setting_Languages" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<script type="text/javascript">
		function checkboxAllToggle(obj) {
			var arrInput = document.getElementById("tblLangs").getElementsByTagName("input");

			for (var i = 0; i < arrInput.length; i++) {
				if (arrInput[i].type == "checkbox")
					arrInput[i].checked = obj.checked;
			}
		}

		function getCheckedItems() {
			var arrInput = document.getElementById("tblLangs").getElementsByTagName("input");

			var selectedNo = "";

			for (var i = 0; i < arrInput.length; i++) {
				if (arrInput[i].type == "checkbox" && arrInput[i].checked && arrInput[i].id != "checkall")
					selectedNo += (selectedNo == "") ? arrInput[i].value : "," + arrInput[i].value;
			}
			if (selectedNo == "") {
				alert("최소 1개를 선택하셔야 합니다.");
				return false;
			}

			document.getElementById("<%=WHFSelectedLangNo.ClientID %>").value = selectedNo;
			//업데이트를 진행하시겠습니까?
			if (!confirm("업데이트를 진행하시겠습니까?"))
				return false;

			return true;
		}
	</script>

	<asp:HiddenField ID="WHFSelectedLangNo" runat="server" />
	
<h2>언어 관리</h2>

<div class="spacer"></div>

<p class="top_line"></p>
<table id="tblLangs" cellspacing="1" cellpadding="0" class="bbs_list">
<thead>
<tr>
	<th><input type="checkbox" id="checkall" onchange="checkboxAllToggle(this)" /></th>
		<th>언어ID</th>
		<th>이름</th>
</tr>
</thead>

<asp:Repeater ID="WRptList"  runat="server">
<ItemTemplate>
<tr>
	<td><input type="checkbox" value="<%# GetDataItem(Container.DataItem, "languageId")%>"<%# GetDataItem(Container.DataItem, "checked")%> /></td>
	<td><%# GetDataItem(Container.DataItem, "LanguageId")%></td>
	<td><%# GetDataItem(Container.DataItem, "_name")%></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>

<asp:Button ID="WBtnUpdate" Text="" CssClass="button" OnClick="WBtnUpdateLangId_OnClick" runat="server" />
</div>
</asp:Content>
