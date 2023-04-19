<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master"  Codebehind="GameServerSetting.aspx.cs" Inherits="Setting_GameServerSetting" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<body>
<div>
	<p class="top_line"></p>
    <h4> * 반드시 검토 후 적용 바랍니다. 문제를 발생시킬 수 있습니다.</h4>
    <p class="bottom_line"></p>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>서버ID</th>
        <td><asp:TextBox ID="WTxtServerId" runat="server" /></td>
        <th>서버이름</th>
         <td><asp:TextBox ID="TextBox1" runat="server" /></td>
        <th>그룹ID</th>
        <td><asp:TextBox ID="TextBox2" runat="server" /></td>
    </tr>
	<tr>
        <th>API주소</th>
        <td><asp:TextBox ID="WTxtTradition" runat="server" /></td>
        <th>프록시서버주소</th>
        <td><asp:TextBox ID="WTxtLevel"  runat="server" /></td>
        <th>프록시서버포트</th>
        <td><asp:Literal ID="WLtlExp" runat="server" /></td>
    </tr>
	<tr>
        <th>GameDBConnect</th>
        <td><asp:TextBox ID="TextBox3" runat="server" /></td>
        <th>State</th>
        <td><asp:TextBox ID="TextBox4" runat="server" /></td>
        <th>isNew</th>
        <td><asp:Literal ID="Literal1" runat="server" /></td>
    </tr>
	<tr>
        <th>점검여부</th>
        <td><asp:TextBox ID="TextBox5" runat="server" /></td>
        <th>정렬번호</th>
        <td><asp:TextBox ID="TextBox6" runat="server" /></td>
        <th>접속유저수</th>
        <td><asp:Literal ID="Literal2" runat="server" /></td>
    </tr>
</div>
</body>
</asp:Content>