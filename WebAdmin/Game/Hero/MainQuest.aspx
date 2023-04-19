<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" Codebehind="MainQuest.aspx.cs" Inherits="Game_Hero_MainQuest" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<body>
<div>
	<p class="top_line"></p>
	<h4>영웅정보</h4>
    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <thead>
	<tr>
		<th>메인퀘스트No</th>
        <th>진행횟수</th>
        <th>완료여부</th>
		<th>클리어시각</th>
        <th>등록시각</th>

	</tr>
    </thead>
	<asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "mainQuestNo")%></td>
        <td><%# GetDataItem(Container.DataItem, "progressCount")%></td>
        <td><%# GetDataItem(Container.DataItem, "completed")%></td>
        <td><%# GetDataItem(Container.DataItem, "completionTime")%></td>
        <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
	</table>
    <p class="bottom_line"></p>
    <div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

    <div class="spacer"></div>

    <h2>메인퀘스트 수정</h2>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>클리어할 메인퀘스트No</th>
        <td><asp:TextBox ID="WTxtMainQuestId" CssClass="txtAttr" runat="server" /> 
        <asp:Button ID="WBtnUpdateAccountHeroMainQuest" OnClick="WBtnUpdateHeroMainQuest_OnClick" Text="업데이트" CssClass="button" runat="server" disabled/>
        Ex) 10 입력시 10번 메인퀘스트까지 완료. * 완료시 지급되는 아이템은 지급되지 않습니다.</td>
    </tr>
    </table>
    <p class="bottom_line"></p>
	
</div>
</body>
</asp:Content>