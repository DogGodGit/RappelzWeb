<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Common/Master/Main.master" CodeFile="CouponForm.aspx.cs" Inherits="Setting_CouponForm" %>
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
					data += objs[i].getElementsByTagName("select")[0].value + "|";
					data += ((objs[i].getElementsByTagName("input")[0].checked) ? 1 : 0) + "|";
					data += objs[i].getElementsByTagName("input")[1].value;

				}
			}

			document.getElementById("<%=WHFMailAttachment.ClientID %>").value = data;

			if (!confirm('<%=Resources.ResLang.CouponAdd_aspx_txt_12%>'))
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

	<h2 id="CouponTitle" runat="server"></h2>

	<h4>&nbsp; <%=Resources.ResLang.CouponAdd_aspx_txt_02%></h4>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_write">
	<tr>
		<th>대상서버</th>
		<td>
			<asp:Literal ID="WLtlTargetGuide" runat="server" />
			<asp:PlaceHolder ID="WPHTargetServer" Visible="false" runat="server">
			지역 <asp:DropDownList ID="WDDLRegion" CssClass="Region" runat="server" /><asp:HiddenField ID="WHFSelectedRegion" Value="0" runat="server" />
			그룹 <asp:DropDownList ID="WDDLGroup" CssClass="Group" runat="server" /><asp:HiddenField ID="WHFSelectedGroup" Value="0" runat="server" />
			서버 <asp:DropDownList ID="WDDLServer" CssClass="Server" runat="server" /><asp:HiddenField ID="WHFSelectedServer" Value="0" runat="server" />
			<asp:Button ID="WBtnAddTarget" Text="대상추가" OnClick="WBtnAddTarget_OnClick" CssClass="button" runat="server" />
			</asp:PlaceHolder>

			<table cellspacing="1" cellpadding="0" class="bbs_list">
			<tr>
				<th>지역</th>
				<th>그룹</th>
				<th>서버</th>
				<th></th>
			</tr>
			<asp:Repeater ID="WRptTarget" OnItemDataBound="WRptTarget_OnItemDataBound" OnItemCommand="WRptTarget_OnItemCommand" runat="server">
			<ItemTemplate>
			<tr>
				<td><%# GetDataItem(Container.DataItem, "targetRegionId")%><%# GetDataItem(Container.DataItem, "regionName")%></td>
				<td><%# GetDataItem(Container.DataItem, "targetGroupId")%><%# GetDataItem(Container.DataItem, "groupName")%></td>
				<td><%# GetDataItem(Container.DataItem, "targetServerId")%><%# GetDataItem(Container.DataItem, "serverName")%></td>
				<td><asp:Button ID="WBtnDelTarget" Text="대상삭제" CssClass="button" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "targetRegionId") + "," + GetDataItem(Container.DataItem, "targetGroupId") + "," + GetDataItem(Container.DataItem, "targetServerId")%>' runat="server" /></td>
			</tr>
			</ItemTemplate>
			</asp:Repeater>
			</table>
		</td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.CouponSystem_aspx_txt_03%></th>
		<td><asp:TextBox ID="WTxtName" runat="server" /></td>
	</tr>
	<tr style="<%=m_sVisibleString %>">
		<th><%=Resources.ResLang.CouponAdd_aspx_txt_13%></th>
		<td><asp:TextBox ID="WTxtCouponCount" runat="server">1</asp:TextBox></td>
	</tr>
	<tr style="<%=m_sVisibleString %>">
		<th><%=Resources.ResLang.CouponAdd_aspx_txt_04%></th>
		<td><asp:DropDownList ID="WDDLCouponLength" runat="server">
			<asp:ListItem Text="10" Value="10" />
			<asp:ListItem Text="11" Value="11" />
			<asp:ListItem Text="12" Value="12" />
			<asp:ListItem Text="13" Value="13" />
			<asp:ListItem Text="14" Value="14" />
			<asp:ListItem Text="15" Value="15" />
			</asp:DropDownList></td>
	</tr>
	<tr style="<%=m_sVisibleString %>">
		<th><%=Resources.ResLang.CouponAdd_aspx_txt_05%></th>
		<td><asp:TextBox ID="WTxtCouponHeader" runat="server"></asp:TextBox> <%=Resources.ResLang.CouponAdd_aspx_txt_06%></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.CouponAdd_aspx_txt_07%></th>
		<td><asp:CheckBox ID="WCBoxType" runat="server" /> <%=Resources.ResLang.CouponAdd_aspx_txt_08%> <%=Resources.ResLang.CouponAdd_aspx_txt_09%></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.CouponAdd_aspx_txt_10%></th>
		<td><asp:TextBox ID="WTxtStartTime" runat="server" /> ~ 
			<asp:TextBox ID="WTxtEndTime" runat="server" />
		</td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.CouponAdd_aspx_txt_11%></th>
		<td><asp:CheckBox ID="WCBoxEnabled" runat="server" /> <%=Resources.ResLang.CouponAdd_aspx_txt_08%></td>
	</tr>
	<tr>
		<th>제목</th>
		<td><asp:DropDownList ID="WDDLMailTitleType" runat="server"/>
			<asp:TextBox ID="WTxtMailTitle" Width="400" runat="server" /></td>
	</tr>
	<tr>
		<th>내용</th> 
		<td><asp:DropDownList ID="WDDLMailContentType" runat="server" />
			<br />
			<asp:TextBox ID="WTxtMailContent" TextMode="MultiLine" Columns="80" Rows="10" runat="server" /></td>
	</tr>
	<%--<tr>
		<th>귀속다이아</th>
		<td><asp:TextBox ID="WTxtOwnDia" runat="server">0</asp:TextBox></td>
	</tr>
	<tr>
		<th>귀속골드</th>
		<td><asp:TextBox ID="WTxtOwnGold" runat="server">0</asp:TextBox></td>
	</tr>--%>
    <tr style="<%=m_sVisibleString %>">
        <th class="left">첨부</th>
        <td colspan="2"><input type="button" value="아이템추가" class="button" onclick="addMailItem();" /> 
            (최대 5개 추가 가능)</td>
    </tr>
    <tr>
        <td colspan="3">
			<table id="TblMailAttachment" class="bbs_list">
			<tbody id="TblBody">
			</tbody>
			</table>
			<table cellspacing="1" cellpadding="0" class="bbs_list">
			<tr id="ItemNames" runat="server">
				<th><%=Resources.ResLang.CouponUpdate_aspx_txt_01%></th>
				<th><%=Resources.ResLang.CouponUpdate_aspx_txt_02%></th>
				<th><%=Resources.ResLang.CouponUpdate_aspx_txt_03%></th>
			</tr>
			<%--리피터 사용해서 데이터 가져오기 + 링크걸고 수정버튼추가--%>
			<asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" runat="server">
			<ItemTemplate>
			<tr>
				<td class="left"><asp:Literal ID="WLtlItemName" runat="server" /></td>
				<td class="center"><%# GetDataItem(Container.DataItem, "itemId")%></td>
				<td class="center"><%# GetDataItem(Container.DataItem, "itemCount")%></td>
			</tr>
	
			</ItemTemplate>
			</asp:Repeater>
			</table>
        </td>
    </tr>
	</table>
	<p class="bottom_line"></p>

	<div class="formListRight">
        <asp:Button ID="WBtnAddPromotion" Text="" CssClass="button" OnClick="WBtnAddPromotion_OnClick" runat="server" />
		<asp:Literal ID="WLtlList" runat="server" />
    </div>

	<div style="visibility:hidden;">
    <asp:DropDownList ID="WDDLItem" runat="server" />
	</div>

	<script type="text/javascript">
		// select init
		var selRegion = document.getElementById("<%=WDDLRegion.ClientID %>");
		var selGroup = document.getElementById("<%=WDDLGroup.ClientID %>");
		var selServer = document.getElementById("<%=WDDLServer.ClientID %>");

		<%=sScript %>

		function selChange(obj) {
			var nIdx = 1;

			switch (obj.className) {
				case "Region":
					if (obj.value == 0) {
						optionClear(selGroup);
						optionClear(selServer);

						document.getElementById("<%=WHFSelectedRegion.ClientID %>").value = "0";
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = "0";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "0";
					}
					else {
						document.getElementById("<%=WHFSelectedRegion.ClientID %>").value = obj.value;
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = "0";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "0";

						optionClear(selGroup);
						optionClear(selServer);

						for (var i = 0; i < arrGroup.length; i++) {
							if (arrGroup[i].regionId == obj.value)
								selGroup.options[nIdx++] = new Option(arrGroup[i].name, arrGroup[i].groupId);
						}
					}
					
					break;
				case "Group":
					if (obj.value == 0) {
						optionClear(selServer);

						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = "0";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "0";
					}
					else {
						
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = obj.value;
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "0";

						optionClear(selServer);
						for (var i = 0; i < arrServer.length; i++) {
							if (arrServer[i].groupId == obj.value)
								selServer.options[nIdx++] = new Option(arrServer[i].name, arrServer[i].serverId);
						}
					}
					break;
				case "Server":
					if(obj.value == 0)
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "0";
					else
                        document.getElementById("<%=WHFSelectedServer.ClientID %>").value = obj.value;
					break;
			}
		}

		function optionClear(obj) {
			while (obj.options.length > 0)
				obj.options.remove(0);

			obj.options[0] = new Option("-- SELECT --", "0");
		}

		optionClear(selRegion);

		for(var i = 0; i < arrRegion.length; i++)
		{
			selRegion.options[i+1] = new Option(arrRegion[i].name, arrRegion[i].regionId);
		}

		//selGroup.style.visibility = "hidden";
		//selServer.style.visibility = "hidden";
	</script>
</div>
</asp:Content>