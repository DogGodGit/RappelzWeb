<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" CodeFile="Stat.aspx.cs" Inherits="Game_Hero_Stat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<body>

    <script type="text/javascript" >

        function validateForm() {

            var statPoint = document.getElementById("<%=WTxtStatPoint.ClientID%>").value;

            if (statPoint == "" || statPoint == "NaN" || parseInt(statPoint) < 0) {
            	alert("스탯 값이 올바르지 않습니다.");
                return false;
               }

               return confirm('변경된 정보로 수정하시겠습니까?');
        }

        function validate() {
            
            var strength = parseInt(document.getElementById("<%=WHFStatStrength.ClientID%>").value);
            var agility = parseInt(document.getElementById("<%=WHFStatAgility.ClientID%>").value);
            var stamina = parseInt(document.getElementById("<%=WHFStatStamina.ClientID%>").value);
            var intelligence = parseInt(document.getElementById("<%=WHFStatIntelligence.ClientID%>").value);
            var statPoint = parseInt(document.getElementById("<%=WHFStatPoint.ClientID%>").value);

            var totalStatPoint = strength + agility + stamina + intelligence + statPoint;

            var inputStrength = parseInt(document.getElementById("<%=WTxtStatStrength.ClientID%>").value);
            var inputAgility = parseInt(document.getElementById("<%=WTxtStatAgility.ClientID%>").value);
            var inputStamina = parseInt(document.getElementById("<%=WTxtStatStamina.ClientID%>").value);
            var inputIntelligence = parseInt(document.getElementById("<%=WTxtStatIntelligence.ClientID%>").value);

            var inputTotalStatPoint = inputStrength + inputAgility + inputStamina + inputIntelligence;

            document.getElementById("<%=WTxtStatPoint.ClientID%>").value = totalStatPoint - inputTotalStatPoint;
        }
    </script>
<div>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>힘</th>
        <td><asp:TextBox ID="WTxtStatStrength" runat="server" />
            <asp:HiddenField ID="WHFStatStrength" runat="server" />
        </td>
    </tr>
    <tr>
        <th>민첩</th>
        <td><asp:TextBox ID="WTxtStatAgility" runat="server" />
            <asp:HiddenField ID="WHFStatAgility" runat="server" />
        </td>
    </tr>
    <tr>
        <th>체력</th>
        <td><asp:TextBox ID="WTxtStatStamina" runat="server" />
            <asp:HiddenField ID="WHFStatStamina" runat="server" />
        </td>
    </tr>
    <tr>
        <th>지능</th>
        <td><asp:TextBox ID="WTxtStatIntelligence" runat="server" />
            <asp:HiddenField ID="WHFStatIntelligence" runat="server" />
        </td>
    </tr>
    <tr>
        <th>남은스탯</th>
        <td><asp:TextBox ID="WTxtStatPoint" runat="server" />
            <asp:HiddenField ID="WHFStatPoint" runat="server" />
        </td>
    </tr>
    <tr>
        <th>보주 힘 </th>
        <td><asp:TextBox ID="WTxtStrength" runat="server" /></td>
    </tr>
    <tr>
        <th>보주 민첩</th>
        <td><asp:TextBox ID="WTxtAgility" runat="server" /></td>
    </tr>
    <tr>
        <th>보주 체력</th>
        <td><asp:TextBox ID="WTxtStamina" runat="server" /></td>
    </tr>
    <tr>
        <th>보주 지능</th>
        <td><asp:TextBox ID="WTxtIntelligence" runat="server" /></td>
    </tr>
    </table>
    <p class="bottom_line"></p>
    
    <asp:Button ID="WBtnUpdate" Text="" OnClick="WBtnUpdate_OnClick" Visible="true" CssClass="button" runat="server" />

</div>
</body>
</asp:Content>

