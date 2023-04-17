<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" CodeFile="AccountHero_MainQuest.aspx.cs" Inherits="Game_AccountHero_MainQuest" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<p class="top_line"></p>
    <h4>메인퀘스트</h4>
    <p class="bottom_line"></p>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>최종 메인퀘스트번호</th>
		<th>진행횟수</th>
		<th>완료여부</th>
		<th>완료시각</th>
		<th>등록시각</th>
	</tr>
	<tr>
		<td class="center"><asp:Literal ID="WLtlMainQuestNo" runat="server" /></td>
		<td class="center"><asp:Literal ID="WLtlProgressCount" runat="server" /></td>
		<td class="center"><asp:Literal ID="WLtlCompleted" runat="server" /></td>
		<td class="center"><asp:Literal ID="WLtlCompletionTime" runat="server" /></td>
		<td class="center"><asp:Literal ID="WLtlRegTime" runat="server" /></td>
	</tr>
	</table>
    <p class="bottom_line"></p>

	<p class="bottom_line"></p>
	<h4>메인퀘스트 변경 <span class="red">* 데이터가 게임플레이와 달리 올바르지 않을 수 있습니다.</span></h4>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
        <th>완료 메인퀘스트 설정</th>
		<td><asp:DropDownList ID="WDDLMainQuest" runat="server" />
			<asp:Button ID="WBtnUpdate" Text="설정" CssClass="button" OnClick="WBtnUpdate_OnClick" runat="server" />
			* 선택한 메인퀘스트까지 완료
			</td>
    </tr>
    </table>

    <p class="bottom_line"></p>
</div>
</asp:Content>