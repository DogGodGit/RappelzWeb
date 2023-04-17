<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="MailAll.aspx.cs" Inherits="Game_MailAll" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<h2>우편발송(전체)</h2>

	<script type="text/javascript">
		var table;
		var tbody;
		var tbody1;
		var tr;
		var th;
		var td;
		var input;
		var selectBox;
		var targetSelectBox;
		var i;

		function delMailAttachment(obj) {
			if (confirm('삭제하시겠습니까?'))
				tbody.removeChild(obj.parentElement.parentElement);
		}

		function sendMail() {
			var objs = tbody.getElementsByTagName("tr");
			var data = "";

			if (document.getElementById("<%=WTxtMailTitle.ClientID %>").value == '') {
				alert('제목을 입력해주세요.');
				document.getElementById("<%=WTxtMailTitle.ClientID %>").focus();
				return false;
			}

			if (document.getElementById("<%=WTxtMailContent.ClientID %>").value == '') {
				alert('내용을 입력해주세요.');
				document.getElementById("<%=WTxtMailContent.ClientID %>").focus();
				return false;
			}

			for (i = 0; i < objs.length; i++) {
				if (data != "")
					data += "`";

				if (objs[i].firstChild.className == "MAIL_ITEM") {
					data += "2|";
					data += objs[i].getElementsByTagName("select")[0].value + "|";
					data += ((objs[i].getElementsByTagName("input")[0].checked) ? 1 : 0) + "|";
					data += objs[i].getElementsByTagName("input")[1].value;

				}
			}

			document.getElementById("<%=WHFMailAttachment.ClientID %>").value = data;

			if (!confirm('선택한서버의 대상유저에게 발송됩니다.\n발송하시겠습니까?'))
				return false;

			return true;
		}

		window.onload = function () {
			table = document.getElementById("TblMailAttachment");
			tbody = document.getElementById("TblBody");
		}

		function addMailItem() {
			if (tbody.getElementsByTagName("tr").length == 10) {
				alert('<우편 첨부 아이템은 최대 10개까지 입니다.');
				return;
			}

			tr = document.createElement("tr");
			tbody.appendChild(tr);

			// 제목
			th = document.createElement("th");
			th.className = "MAIL_ITEM";
			th.innerHTML = '아이템';
			tr.appendChild(th);

			// 아이템 목록
			td = document.createElement("td");
			selectBox = document.createElement("select");
			targetSelectBox = document.getElementById("<%=WDDLItem.ClientID%>");
			for (i = 0; i < targetSelectBox.options.length; i++) {
				selectBox.options[i] = new Option(targetSelectBox.options[i].innerHTML, targetSelectBox.options[i].value);
			}
			td.appendChild(selectBox);
			tr.appendChild(td);

			// 귀속여부
			td = document.createElement("td");
			input = document.createElement("input");
			input.setAttribute("type", "checkbox");
			input.setAttribute("checked", "checked");
			td.appendChild(input);
			td.innerHTML = td.innerHTML + '귀속';
			tr.appendChild(td);

			// 수량
			td = document.createElement("td");
			td.setAttribute("colspan", "2");
			input = document.createElement("input");
			input.setAttribute("value", "1");
			td.appendChild(input);
			td.innerHTML = '수량' + td.innerHTML;
			tr.appendChild(td);

			// 옵션버튼
			td = document.createElement("td");
			input = document.createElement("input");
			input.setAttribute("type", "button");
			input.setAttribute("class", "button");
			input.value = '삭제';
			input.onclick = function () { delMailAttachment(this); };
			td.appendChild(input);
			tr.appendChild(td);
		}
    </script>
    <asp:HiddenField ID="WHFMailAttachment" runat="server" />

	<p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">서버<asp:DropDownList ID="WDDLServer" AutoPostBack="true" OnSelectedIndexChanged="WDDLServer_OnSelectedIndexChanged" runat="server" /></th>
    </tr>
    </table>
    <p class="bottom_line"></p>

	<asp:PlaceHolder ID="WPHMailForm" Visible="false" runat="server">

	<div class="spacer"></div>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>
			제목 <asp:DropDownList ID="WDDLTitleType" runat="server" />
		</th>
        <td>
			
			<asp:TextBox ID="WTxtMailTitle" Width="400" runat="server" />
		</td>
	</tr>
	<tr>
	    <th>
			내용 <asp:DropDownList ID="WDDLContentType" runat="server" />
		</th>
        <td>
			
			<asp:TextBox ID="WTxtMailContent" TextMode="MultiLine" Columns="50" Rows="5" runat="server" />
		</td>
    </tr>
    <tr>
        <th class="center">첨부</th>
        <td><input type="button" value="아이템추가" class="button" onclick="addMailItem();" /></td>
    </tr>
    <tr>
        <td colspan="2">
			<table id="TblMailAttachment" class="bbs_list">
			<tbody id="TblBody">
			</tbody>
			</table>
        </td>
    </tr>
    </table>
    <p class="bottom_line"></p>

    <asp:Button ID="WBtnMailSend" Text="우편 발송 (BulkCopy)" Width="200" OnClick="WBtnMailSend_OnClick" CssClass="button" runat="server" />

    <div style="visibility:hidden;">
    <asp:DropDownList ID="WDDLItem" runat="server" />
	</div>

	</asp:PlaceHolder>
</div>
</asp:Content>