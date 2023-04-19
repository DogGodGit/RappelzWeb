<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="AssetBundleList.aspx.cs" Inherits="Game_AssetBundleList" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    <script type="text/javascript">
    function checkboxAllToggle(obj) {
        var arrInput = document.getElementById("tblBundle").getElementsByTagName("input");

        for (var i = 0; i < arrInput.length; i++) {
            if(arrInput[i].type == "checkbox" && "ch" == arrInput[i].className)
                arrInput[i].checked = obj.checked;
        }
    }

    function getCheckedItems() {
        var arrInput = document.getElementById("tblBundle").getElementsByTagName("input");

        var selectedNo = "";

        for (var i = 0; i < arrInput.length; i++) {
        	if (arrInput[i].type == "checkbox" && arrInput[i].checked && "ch" == arrInput[i].className)
                selectedNo += (selectedNo == "") ? arrInput[i].value : "," + arrInput[i].value;
        }

        if (!document.getElementById("<%=WCBoxAndroid.ClientID %>").checked && !document.getElementById("<%=WCBoxiOS.ClientID %>").checked) {
        	alert("Android 또는 iOS를 선택해주세요.");
            return false;
        }

        if (selectedNo == "") {
        	alert("선택한 번들파일이 없습니다.");
            return false;
        }

        document.getElementById("<%=WHFSelectedBundleNo.ClientID %>").value = selectedNo;

        if (!confirm("진행 하시겠습니까?"))
            return false;

        return true;
    }
    </script>

    <asp:HiddenField ID="WHFSelectedBundleNo" runat="server" />
    <h2>Asset Bundle 관리</h2>
    
    <div class="spacer"></div>
    
    <asp:CheckBox ID="WCBoxAndroid" Text="Android버전" runat="server" />
    <asp:CheckBox ID="WCBoxiOS" Text="iOS버전" runat="server" />
    <asp:Button ID="WBtnUpdateVersion" Text="선택한 항목 버전 업데이트" CssClass="button" OnClick="WBtnUpdateVersion_OnClick" runat="server" />

    <h2>어셋번들 파일 추가</h2>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <td>   
            번들번호 : <asp:TextBox ID="WTxtBundleNo" CssClass="txtAttr" Text="1" runat="server" />
            파일명 : <asp:TextBox ID="WTxtFileName" runat="server" />
            Android버전 : <asp:TextBox ID="WTxtAndroidVer" CssClass="txtAttr" Text="1" MaxLength="3" runat="server" />
            iOS 버전 : <asp:TextBox ID="WTxtiOSVer" CssClass="txtAttr" Text="1" MaxLength="3" runat="server" />
        </td>
        <td>
            <asp:Button ID="WBtnAddFile" Text="등록" OnClick="WBtnAddFile_OnClick" Width="100" CssClass="button" runat="server" />
        </td>
    </tr>
    </table>
    <p class="bottom_line"></p>

    <p class="top_line"><br /></p>

    <table id="tblBundle" cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th><input type="checkbox" id="checkall" onchange="checkboxAllToggle(this)" /></th>
        <th>번들번호</th>
        <th>파일명</th>
        <th>Android버전</th>
        <th>iOS 버전</th>
		<th>Common여부</th>
        <th>기능</th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" OnItemDataBound="WRptList_OnItemDataBound" OnItemCommand="WRptList_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td><input type="checkbox" class="ch" value="<%# GetDataItem(Container.DataItem, "bundleNo")%>" /></td>
        <td><%# GetDataItem(Container.DataItem, "bundleNo")%></td>
        <td><asp:TextBox ID="WTxtFileName" Text='<%# GetDataItem(Container.DataItem, "fileName")%>' runat="server" /></td>
        <td><asp:TextBox ID="WTxtAndroidVer" Text='<%# GetDataItem(Container.DataItem, "androidVer")%>' CssClass="txtAttr" runat="server" /></td>
        <td><asp:TextBox ID="WTxtiOSVer" Text='<%# GetDataItem(Container.DataItem, "iosVer")%>' CssClass="txtAttr" runat="server" /></td>
		<td><asp:CheckBox ID="WCBoxIsCommon" runat="server" /></td>
        <td><asp:Button ID="WBtnUpdate" Text="수정" Width="60" CssClass="button" CommandName="update" CommandArgument='<%# GetDataItem(Container.DataItem, "bundleNo")%>' runat="server" />
            <asp:Button ID="WBtnDel" Text="삭제" Width="60" CssClass="button" CommandName="delete" CommandArgument='<%# GetDataItem(Container.DataItem, "bundleNo")%>' runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>

    
    <div class="spacer"></div>

</div>
</asp:Content>