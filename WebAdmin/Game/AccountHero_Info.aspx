<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" Codebehind="AccountHero_Info.aspx.cs" Inherits="Game_AccountHero_Info" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	
	<p class="top_line"></p>
    <h4>영웅정보</h4>
    <p class="bottom_line"></p>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>직업</th>
		<td><asp:Literal ID="WLtlJobId" runat="server" /></td>
		<th>국가</th>
		<td><asp:Literal ID="WLtlNationId" runat="server" /></td>
		<th>이름</th>
		<td><asp:Literal ID="WLtlName" runat="server" /></td>
		<th>레벨</th>
		<td><asp:TextBox ID="WTxtLevel" CssClass="txtAttr" runat="server" /></td>
	</tr>
	<tr>
		<th>경험치</th>
		<td><asp:TextBox ID="WTxtExp" CssClass="txtAttr" runat="server" /></td>
		<th>전투력</th>
		<td><asp:Literal ID="WLtlBattlePower" runat="server" /></td>
		<th>HP</th>
		<td><asp:Literal ID="WLtlHp" runat="server" /></td>
		<th>실제최대HP</th>
		<td><asp:Literal ID="WLtlRealMaxHp" runat="server" /></td>
	</tr>
	<tr>
		<th>실제물리공격력</th>
		<td><asp:Literal ID="WLtlRealPhysicalOffense" runat="server" /></td>
		<th>실제마법공격력</th>
		<td><asp:Literal ID="WLtlRealMagicalOffense" runat="server" /></td>
		<th>실제물리방어력</th>
		<td><asp:Literal ID="WLtlRealPhysicalDefense" runat="server" /></td>
		<th>실제마법방어력</th>
		<td><asp:Literal ID="WLtlRealMagicalDefense" runat="server" /></td>
	</tr>
	<tr>
		<th>비귀속다이아</th>
		<td><asp:TextBox ID="WTxtBaseUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th>보너스비귀속다이아</th>
		<td><asp:TextBox ID="WTxtBonusUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th>귀속다이아</th>
		<td><asp:TextBox ID="WTxtOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th>골드</th>
		<td><asp:TextBox ID="WTxtGold" CssClass="txtAttr" runat="server" /></td>
	</tr>
	<tr>
		<th>인벤토리슬롯수</th>
		<td><asp:Literal ID="WLtlInventorySlotCount" runat="server" /></td>
		<th>직업포인트</th>
		<td><asp:TextBox ID="WTxtJobPoint" CssClass="txtAttr" runat="server" /></td>
		<th>라크</th>
		<td><asp:TextBox ID="WTxtLak" CssClass="txtAttr" runat="server" /></td>
		<th>이름튜토리얼완료여부</th>
		<td><asp:Literal ID="WLtlNamingTutorialCompleted" runat="server" /></td>
	</tr>
	<tr>
		<th>마지막로그인시각</th>
		<td><asp:Literal ID="WLtlLastLoginTime" runat="server" /></td>
		<th>마지막로그아웃시각</th>
		<td><asp:Literal ID="WLtlLastLogoutTime" runat="server" /></td>
		<th>이전대륙사망시각</th>
		<td><asp:Literal ID="WLtlPrevContinentDeadTime" runat="server" /></td>
		<th>마지막대륙사망시각</th>
		<td><asp:Literal ID="WLtlLastContinentDeadTime" runat="server" /></td>
	</tr>
	<tr>
		<th>마지막위치ID</th>
		<td><asp:Literal ID="WLtlLastLocationId" runat="server" /></td>
		<th>마지막위치변수</th>
		<td><asp:Literal ID="WLtlLastLocationParam" runat="server" /></td>
		<th>마지막위치인스턴스ID</th>
		<td><asp:Literal ID="WLtlLastInstanceId" runat="server" /></td>
		<th>마지막위치</th>
		<td><asp:Literal ID="WLtlLastPosition" runat="server" /></td>
	</tr>
	<tr>
		<th>이전대륙ID</th>
		<td><asp:Literal ID="WLtlPreviousContinentId" runat="server" /></td>
		<th>이전좌표</th>
		<td><asp:Literal ID="WLtlPreviousPosition" runat="server" /></td>
		<th>누적로그인일수</th>
		<td><asp:Literal ID="WLtlAccumulationLoginDayCount" runat="server" /></td>
		<th>사망횟수</th>
		<td><asp:TextBox ID="WTxtDeadCount" CssClass="txtAttr" runat="server" /></td>
	</tr>
	<tr>
		<th>주간퀘스트피버단계</th>
		<td><asp:Literal ID="WLtlWeeklyQuestFeverStep" runat="server" /></td>
		<th>주간퀘스트피버시작시각</th>
		<td><asp:Literal ID="WLtlWeeklyQuestFeverStartTime" runat="server" /></td>
		<th>주간퀘스트피버진행횟수</th>
		<td><asp:Literal ID="WLtlWeeklyQuestFeverProgressCount" runat="server" /></td>
		<th>채팅말풍선표시여부</th>
		<td><asp:Literal ID="WLtlChattingBubbleDisplayed" runat="server" /></td>
	</tr>
	<tr>
		<th>착용된스킨ID</th>
		<td><asp:Literal ID="WLtlEquippedSkinId" runat="server" /></td>
		<th>스킨헬멧표시여부</th>
		<td><asp:Literal ID="WLtlSkinHelmetVisible" runat="server" /></td>
		<th>레벨갱신시각</th>
		<td><asp:Literal ID="WLtlLevelUpdateTime" runat="server" /></td>
		<th>전투력갱신시각</th>
		<td><asp:Literal ID="WLtlBattlePowerUpdateTime" runat="server" /></td>
	</tr>
	<tr>
		<th>HP물약자동사용여부</th>
		<td><asp:Literal ID="WLtlHpPotionAutoEnabled" runat="server" /></td>
		<th>자동반격여부</th>
		<td><asp:Literal ID="WLtlAutoCountattackEnabled" runat="server" /></td>
		<th>몬스터전투회피여부</th>
		<td><asp:Literal ID="WLtlMonsterBattleEvasionEnabled" runat="server" /></td>
		<th>전투범위타입</th>
		<td><asp:Literal ID="WLtlBattleAreaType" runat="server" /></td>
	</tr>
	<tr>
		<th>루팅장비최소등급</th>
		<td><asp:Literal ID="WLtlLootingGearMinGrade" runat="server" /></td>
		<th>루팅아이템최소등급</th>
		<td><asp:Literal ID="WLtlLootingItemMinGrade" runat="server" /></td>
		<th></th>
		<td></td>
		<th></th>
		<td></td>
	</tr>
	<!-- 위로 추가 //-->
	<tr>
		<th>등록시각</th>
		<td><asp:Literal ID="WLtlRegTime" runat="server" /></td>
		<th>생성여부</th>
		<td><asp:Literal ID="WLtlCreated" runat="server" /></td>
		<th>삭제여부</th>
		<td><asp:Literal ID="WLtlDeleted" runat="server" /></td>
		<th>삭제시각</th>
		<td><asp:Literal ID="WLtlDelTime" runat="server" /></td>
	</tr>
	</table>
    <p class="bottom_line"></p>

	<div class="formListRight">
		<asp:Button ID="WBtnUpdate" Text="수정" CssClass="button" OnClick="WBtnUpdate_OnClick" runat="server" />
	</div>
</div>
</asp:Content>