<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="SendMail.aspx.cs" Inherits="Game_SendMail" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
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
    	var trCheck;
    	var number = 0;
		var p;
    	function delMailAttachment(obj) {
    		if (confirm('삭제하시겠습니까?')) {
    			var objs = tbody.getElementsByTagName("tr");

    			for (i = 0; i < objs.length; i++) {
    				if (obj.parentElement.parentElement == objs[i]) {
    					tbody.removeChild(objs[i]);
    					tbody.removeChild(objs[i]);
    				}
    			}
    		}
    	}

    	function sendMail() {
    		var objs = tbody.getElementsByTagName("tr");
    		var dataItem = "";

    		for (i = 0; i < objs.length; i++) {
				if(objs[i].getElementsByTagName("input")[0].checked)
				{
					if (objs[i].firstChild.className == "MAIL_ITEM") {
						if (dataItem != "")
							dataItem += "`";
						dataItem += "1|";
						dataItem += objs[i].getElementsByTagName("select")[0].value + "|";
						dataItem += ((objs[i].getElementsByTagName("input")[1].checked) ? 1 : 0) + "|";
						dataItem += objs[i].getElementsByTagName("input")[2].value;
					}
					if (objs[i].firstChild.className == "MAIL_GEAR") {
						if (dataItem != "")
							dataItem += "`";
						dataItem += "2|";
						dataItem += objs[i].getElementsByTagName("select")[0].value + "|";
						dataItem += objs[i].getElementsByTagName("select")[1].value + "|";
						dataItem += ((objs[i].getElementsByTagName("input")[1].checked) ? 1 : 0) + "|";
						dataItem += objs[i].getElementsByTagName("input")[2].value + "|";
						dataItem += objs[i].getElementsByTagName("input")[3].value + "|";
						dataItem += objs[i].getElementsByTagName("select")[2].value;
					}
				}
    		}
    		document.getElementById("<%=WHFMailAttachmentITEM.ClientID %>").value = dataItem;

    		// 제목인자
    		var titleArgObj = document.getElementById("tblTitleArgBody").getElementsByTagName("tr");
    		var Args = "";

    		for (i = 0; i < titleArgObj.length; i++) {
    			if (Args != "")
    				Args += "|";
    			Args += "1`" + titleArgObj[i].getElementsByTagName("select")[0].value + "`" + titleArgObj[i].getElementsByTagName("input")[0].value;
    		}

    		// 내용인자
    		var contentArgObj = document.getElementById("tblContentArgBody").getElementsByTagName("tr");

    		for (i = 0; i < contentArgObj.length; i++) {
    			if (Args != "")
    				Args += "|";
    			Args += "2`" + contentArgObj[i].getElementsByTagName("select")[0].value + "`" + contentArgObj[i].getElementsByTagName("input")[0].value;
    		}

    		document.getElementById("<%=WHFMailArgs.ClientID %>").value = Args;

    		if (!confirm('선택한서버의 대상유저에게 발송됩니다. \n 발송하시겠습니까?'))
    			return false;

    		return true;
    	}

    	function addArgs(tblBodyId) {

    		if (document.getElementById(tblBodyId).getElementsByTagName("tr").length == 10) {
    			alert('인자는 최대 10개까지 입니다.');
    			return;
    		}

    		tr = document.createElement("tr");
    		document.getElementById(tblBodyId).appendChild(tr);

    		// 인자타입
    		td = document.createElement("td");
    		td.innerHTML = td.innerHTML + '인자';
    		selectBox = document.createElement("select");
    		targetSelectBox = document.getElementById("<%=WDDLTitleType.ClientID%>");
    		for (i = 0; i < targetSelectBox.options.length; i++) {
    			selectBox.options[i] = new Option(targetSelectBox.options[i].innerHTML, targetSelectBox.options[i].value);
    		}
    		td.appendChild(selectBox);
    		tr.appendChild(td);

    		// 인자값
    		input = document.createElement("input");

    		td.appendChild(input);


    		// 옵션버튼
    		input = document.createElement("input");
    		input.setAttribute("type", "button");
    		input.setAttribute("class", "button");
    		input.value = '삭제';
    		input.onclick = function () { delArgs(tblBodyId, this); };
    		td.appendChild(input);


    		tr.appendChild(td);
    	}

    	function delArgs(tblBodyId, obj) {
    		if (confirm('삭제하시겠습니까?'))
    			document.getElementById(tblBodyId).removeChild(obj.parentElement.parentElement);
    	}

    	window.onload = function () {
    		table = document.getElementById("TblMailAttachment");
    		tbody = document.getElementById("TblBody");
    	}

    	//글자 수 제한
    	function ByteCheck(str) {
    		var strCheck = str.value;
    		var totalByte = 0;
    		var txtboxLen;
    		var maxByte = 7900;
    		var byte1 = "";

    		for (var i = 0; i < strCheck.length; i++) {
    			byte1 = strCheck.charAt(i);
    			if (escape(byte1).length > 4)
    				totalByte += 2;
    			else
    				totalByte++;
    		}

    		txtboxLen = document.getElementById("<%=WTxtByteCheck.ClientID%>").value = totalByte.toString();

    		if (totalByte >= maxByte) {
    			if (alert(maxByte + 'byte 초과 글자 수 확인'))
    				return false;
    		}
    	}
    	function addMailItem() {

    		if (tr  > 5) {
    			alert('우편 첨부 아이템은 최대 7개까지 입니다.');
    			return;
    		}

    		tr = document.createElement("tr");
    		tbody.appendChild(tr);

    		// 제목
    		th = document.createElement("th");
    		th.className = "MAIL_ITEM";
    		th.innerHTML = '아이템';
    		tr.appendChild(th);

    		// 라디오버튼(선택)
    		td = document.createElement("td");
    		input = document.createElement("input");
    		input.setAttribute("type", "radio");
    		input.setAttribute("name", "Check" + number);
    		input.setAttribute("checked", "checked");
    		td.appendChild(input);
    		tr.appendChild(td);

    		// 아이템 목록
    		td = document.createElement("td");
    		td.className = "left";
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
    		td.appendChild(input);
    		td.innerHTML = td.innerHTML + '귀속';
    		tr.appendChild(td);

    		// 수량
    		td = document.createElement("td");
    		td.setAttribute("colspan", "4");
    		td.setAttribute("class", "left");
    		input = document.createElement("input");
    		input.setAttribute("value", "1");
    		td.appendChild(input);
    		td.innerHTML = '수량' + td.innerHTML;
    		tr.appendChild(td);

			//위는 아이템

    		// 옵션버튼
    		td = document.createElement("td");
    		td.setAttribute("rowspan", "2");
    		input = document.createElement("input");
    		input.setAttribute("type", "button");
    		input.setAttribute("class", "button");
    		input.value = '삭제';
    		input.onclick = function () { delMailAttachment(this); };
    		td.appendChild(input);
    		tr.appendChild(td);

    		tr = document.createElement("tr");
    		tbody.appendChild(tr);

			///////////////
    		//아래는 장비//
    		///////////////

    		// 제목
    		th = document.createElement("th");
    		th.className = "MAIL_GEAR";
    		th.innerHTML = '장비';
    		tr.appendChild(th);

    		// 라디오버튼(선택)
    		td = document.createElement("td");
    		input = document.createElement("input");
    		input.setAttribute("type", "radio");
    		input.setAttribute("name", "Check" + number);
    		td.appendChild(input);
    		tr.appendChild(td);

    		// 장비 목록
    		td = document.createElement("td");
    		td.className = "left";
    		selectBox = document.createElement("select");
    		targetSelectBox = document.getElementById("<%=WDDLGear.ClientID%>");
    		for (i = 0; i < targetSelectBox.options.length; i++) {
    			selectBox.options[i] = new Option(targetSelectBox.options[i].innerHTML, targetSelectBox.options[i].value);
    		}
    		td.appendChild(selectBox);
    		tr.appendChild(td);

    		// 귀속여부
    		td = document.createElement("td");
    		input = document.createElement("input");
    		input.setAttribute("type", "checkbox");
    		td.appendChild(input);
    		td.innerHTML = td.innerHTML + '귀속';
    		tr.appendChild(td);

    		// 장비 등급
    		td = document.createElement("td");
    		selectBox = document.createElement("select");
    		targetSelectBox = document.getElementById("<%=WDDLGearGrade.ClientID%>");
    		for (i = 0; i < targetSelectBox.options.length; i++) {
    			selectBox.options[i] = new Option(targetSelectBox.options[i].innerHTML, targetSelectBox.options[i].value);
    		}
    		td.appendChild(selectBox);
    		tr.appendChild(td);

    		// 장비강화수치
    		td = document.createElement("td");
    		input = document.createElement("input");
    		input.setAttribute("value", "0");
    		td.appendChild(input);
    		td.innerHTML = '강화수치' + td.innerHTML;
    		tr.appendChild(td);

    		// 장비레벨
    		td = document.createElement("td");
    		input = document.createElement("input");
    		input.setAttribute("value", "1");
    		td.appendChild(input);
    		td.innerHTML = '레벨' + td.innerHTML;
    		tr.appendChild(td);

    		// 장비로열타입
    		td = document.createElement("td");
    		selectBox = document.createElement("select");
    		targetSelectBox = document.getElementById("<%=WDDLGearRoyalType.ClientID%>");
    		for (i = 0; i < targetSelectBox.options.length; i++) {
    			selectBox.options[i] = new Option(targetSelectBox.options[i].innerHTML, targetSelectBox.options[i].value);
    		}
    		td.appendChild(selectBox);
    		tr.appendChild(td);

    		number++;
		}
    </script>
    <asp:HiddenField ID="WHFMailAttachmentITEM" runat="server" />
	<asp:HiddenField ID="WHFMailArgs" runat="server" />
	<asp:HiddenField ID="WHFMailTBody" runat="server" />
	
	<h2>우편 발송</h2>

    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">
			서버그룹목록<asp:DropDownList ID="WDDLServerGropList" OnSelectedIndexChanged="WDDLServerGroup_OnSelectedIndexChanged" AutoPostBack="true" runat="server" />
			&nbsp;&nbsp;
			서버목록<asp:DropDownList ID="WDDLServerList" OnSelectedIndexChanged="WDDLServerList_OnSelectedIndexChanged" AutoPostBack="true" runat="server" />
        </th>
    </tr>
    </table>

	<p class="bottom_line"></p>

    <div class="spacer"></div>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
    <th>
      <asp:DropDownList ID="WDDLType" runat="server" />
          &nbsp;&nbsp;
        <td><asp:TextBox ID="WTxtTarget" TextMode="MultiLine" onkeyup="ByteCheck(this)"  Width="600" Rows="4" runat="server" /> <br /> 
       ex) 영웅 ID: 1,2,3,4    &nbsp; &nbsp;
        <asp:TextBox ID="WTxtByteCheck" Text="0" style="text-align:right;"  Width="27" runat="server"/>byte /7900 byte
    </th>
    </tr>
   
    </table>
	<p class="bottom_line"></p>

    <div class="spacer"></div>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
	    <th>
			우편 유지기간 (Day)
		</th>
		<td colspan="2">
			<asp:TextBox ID="WTxtDuration" CssClass="txtAttr" runat="server" /> 일
		</td>
	</tr>
	<tr>
        <th>
			제목 <asp:DropDownList ID="WDDLTitleType" runat="server" />
		</th>
        <td>
			<asp:TextBox ID="WTxtMailTitle" Width="400" runat="server" />
		</td>
		<td>
			<input type="button" value="인자 추가" class="button" onclick="addArgs('tblTitleArgBody');" />  최대 10개
			<table id="tblTitleArg" class="bbs_list">
			<tbody id="tblTitleArgBody">
			</tbody>
			</table>
		</td>
	</tr>
	<tr>
	    <th>
			내용 <asp:DropDownList ID="WDDLContentType" runat="server" />
		</th>
        <td>
			<asp:TextBox ID="WTxtMailContent" TextMode="MultiLine" Columns="50" Rows="5" runat="server" />
		</td>
		<td>
			<input type="button" value="인자 추가" class="button" onclick="addArgs('tblContentArgBody');" /> 최대 10개
			<table id="tblContentArg" class="bbs_list">
			<tbody id="tblContentArgBody">
			</tbody>
			</table>
		</td>
    </tr>

    <tr>
        <th>첨부</th>
        <td colspan="2"><input type="button" value="아이템,장비추가" class="button" onclick="addMailItem();" /> 
            (최대 5개 추가 가능)</td>
    </tr>
    <tr>
        <td colspan="3">
			<table id="TblMailAttachment" class="bbs_list">
			<tbody id="TblBody">
			</tbody>
			</table>
        </td>
    </tr>
    </table>
	<p class="bottom_line"></p>

    <asp:Button ID="WBtnMailSend" Text="우편발송" OnClick="WBtnMailSend_OnClick" CssClass="button" runat="server" />

    <div style="visibility:hidden;">
    <asp:DropDownList ID="WDDLItem" runat="server" />
    <asp:DropDownList ID="WDDLGear" runat="server" />
    <asp:DropDownList ID="WDDLGearGrade" runat="server" />
    <asp:DropDownList ID="WDDLGearRoyalType" runat="server" />
	</div>

</div>
</asp:Content>