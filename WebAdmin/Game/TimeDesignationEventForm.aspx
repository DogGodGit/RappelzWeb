<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/Main.master" AutoEventWireup="true" Codebehind="TimeDesignationEventForm.aspx.cs" Inherits="Game_TimeDesignationEventForm" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<div id="CONTENT_INNER">

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

			for (i = 0; i < objs.length; i++) {
				if (data != "")
					data += "`";

				if (objs[i].firstChild.className == "MAIL_ITEM") {
					data += "2|";
                    data += objs[i].getElementsByTagName("select")[0].value;//+ "|";
					//data += ((objs[i].getElementsByTagName("input")[0].checked) ? 1 : 0) + "|";
					//data += objs[i].getElementsByTagName("input")[1].value;
				}
			}
                    console.log(data);

			document.getElementById("<%=WHFMailAttachment.ClientID %>").value = data;

			if (!confirm('캠페인을 등록하시겠습니까?'))
				return false;

			return true;
		}

		window.onload = function () {
			table = document.getElementById("TblMailAttachment");
			tbody = document.getElementById("TblBody");
		}

		function addMailItem() {
			if (tbody.getElementsByTagName("tr").length == 5) {
				alert('우편 첨부 아이템은 최대 5개까지 입니다.');
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
            /*
			td = document.createElement("td");
			input = document.createElement("input");
			input.setAttribute("type", "checkbox");
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
            */

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

<h2 id="eventTitle" runat="server"></h2>
	<table cellspacing="1" cellpadding="0" class="bbs_write ">
	<tr>
	<th>서버<asp:DropDownList ID="WDDLServer" OnSelectedIndexChanged="WDDLServer_OnSelectedIndexChanged" AutoPostBack="true" runat="server" /></th>
	</tr>
	</table>
	<p class="bottom_line"></p>

	<h4>&nbsp; 접속자 우편발송 정보</h4>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_write">
	<tr>
		<th>이벤트명</th>
		<td><asp:TextBox ID="WTxtName" runat="server" /></td>
	</tr>
	<tr>
		<th>사용기간</th>
		<td><asp:TextBox ID="WTxtStartTime" runat="server" /> ~ 
			<asp:TextBox ID="WTxtEndTime" runat="server" />  * 날짜를 꼭 확인해주세요.
		</td>
	</tr>
	<tr style="<%=m_sVisibleString %>">
			<%--제목--%>
		<th>제목</th> 
		<td><asp:DropDownList ID="WDDLTitleType" runat="server"/>
			<asp:TextBox ID="WTxtMailTitle" Width="400" runat="server" /></td>
	</tr>
	<tr>
			<%--내용--%>
		<th>내용</th>
		<td><asp:DropDownList ID="WDDLContentType" runat="server" />
			<br />
			<asp:TextBox ID="WTxtMailContent" TextMode="MultiLine" Columns="80" Rows="10" runat="server" /></td>
	</tr>
	
     <tr style="<%=m_sVisibleString %>">
			<%--첨부--%>
        <th class="left">첨부</th>
        <td colspan="2"><input type="button" value="아이템추가" class="button" onclick="addMailItem();" /> 
            (최대 5개 추가 가능) * 주의! 아이템을 꼭 1개 이상 첨부해주세요. </td>
    </tr>
    <tr>
			<%--아이템추가했을때--%>
        <td colspan="3">
			<table id="TblMailAttachment" class="bbs_list">
			<tbody id="TblBody">
			</tbody>
			</table>
			<table cellspacing="1" cellpadding="0" class="bbs_list">
			<tr id="ItemNames" visible="false" runat="server">
				<th>아이템ID</th>
				<th>아이템 갯수</th>
				<th>귀속여부/설명</th>
			</tr>
			<%--리피터 사용해서 데이터 가져오기 + 링크걸고 수정버튼추가--%>
			<asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" runat="server">
			<ItemTemplate>
			<tr>
				<td class="center"><%# GetDataItem(Container.DataItem, "itemId")%></td>
				<td class="center"><%# GetDataItem(Container.DataItem, "itemCount")%></td>
				<td class="center"><asp:Literal ID="WLtlItemName" runat="server" /><%# GetDataItem(Container.DataItem, "_description")%></td>
			</tr>
			</ItemTemplate>
			</asp:Repeater>
			</table>
        </td>
    </tr>
	</table>
	<p class="bottom_line"></p>

	<div class="formListRight">
        <asp:Button ID="WBtnAddTimeEvent" Text="" CssClass="button" OnClick="WBtnAddTimeEvent_OnClick" runat="server" />
		<asp:Literal ID="WLtlList" runat="server" />
    </div>

	<div style="visibility:hidden;">
		<asp:DropDownList ID="WDDLItem" runat="server" />
	</div>
</div>
</asp:Content>

