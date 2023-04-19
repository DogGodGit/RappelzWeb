<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" Codebehind="HeroInfo.aspx.cs" Inherits="Game_Hero_HeroInfo" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<body>
<div>
	<p class="top_line"></p>
	<h4>영웅정보</h4>
    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>직업ID</th>
		<td><asp:DropDownList ID="WDDLJob" runat="server" /></td>
		<th>국가ID</th>
		<td><asp:Literal ID="WLtlNationId" runat="server" /></td>
		<th>이름</th>
		<td><asp:Literal ID="WLtlName" runat="server" /></td>
		<th>레벨</th>
		<td><asp:TextBox ID="WTxtLevel" runat="server" /></td>
	</tr>
	<tr>
		<th>경험치</th>
		<td><asp:TextBox ID="WTxtExp" runat="server" /></td>
		<th>전투력</th>
		<td><asp:Literal ID="WLtlBattlePower" runat="server" /></td>
		<th>골드</th>
		<td><asp:TextBox ID="WTxtGold" runat="server" /></td>
		<th>라크</th>
		<td><asp:TextBox ID="WTxtLak" runat="server" /></td>
	</tr>
	<tr>
		<th>귀속다이아</th>
		<td><asp:TextBox ID="WTxtOwnDia" runat="server" /></td>
		<th>VIP포인트</th>
		<td><asp:TextBox ID="WTxtVipPoint" runat="server" /></td>
		<th>체력</th>
		<td><asp:TextBox ID="WTxtStamina" runat="server" /></td>
		<th>공적점수</th>
		<td><asp:TextBox ID="WTxtExploitPoint" runat="server" /></td>
	</tr>
	<tr>
		<th>착용날개</th>
		<td><asp:Literal ID="WLtlWing" runat="server" /></td>
		<th>날개단계</th>
		<td><asp:Literal ID="WLtlWingStep" runat="server" /></td>
		<th>날개레벨</th>
		<td><asp:Literal ID="WLtlWingLevel" runat="server" /></td>
		<th>날개경험치</th>
		<td><asp:Literal ID="WLtlWingExp" runat="server" /></td>
	</tr>
	<tr>
		<th>메인장비강화</th>
		<td><asp:Literal ID="WLtlMainGearEnchant" runat="server" /></td>
		<th>메인장비세련</th>
		<td><asp:Literal ID="WLtlMainGearRefinement" runat="server" /></td>
		<th>무료즉시부활</th>
		<td><asp:Literal ID="WLtlFreeImmediateRevival" runat="server" /></td>
		<th>유료부활</th>
		<td><asp:Literal ID="WLtlPaidImmediateRevival" runat="server" /></td>
	</tr>
	<tr>
		<th>휴식시간</th>
		<td><asp:Literal ID="WLtlRestTime" runat="server" /></td>
		<th>일일출석보상</th>
		<td><asp:Literal ID="WLtlDailyAttendReward" runat="server" /></td>
		<th>일일접속시간</th>
		<td><asp:Literal ID="WLtlDailyAccessTime" runat="server" /></td>
		<th>탈것장비재강화</th>
		<td><asp:Literal ID="WLtlMountGearRefinement" runat="server" /></td>
	</tr>
	<tr>
		<th>경험치물약사용</th>
		<td><asp:Literal ID="WLtlExpPotionUse" runat="server" /></td>
		<th>착용탈것</th>
		<td><asp:Literal ID="WLtlEquippedMountId" runat="server" /></td>
		<th>무료소탕사용</th>
		<td></td>
		<th>메인퀘스트 번호</th>
		<td><asp:TextBox ID="WTxtGmTargetMainQuestNo" runat="server" /></td>
	</tr>
	<tr>
		<th>구입인벤토리슬롯수</th>
		<td><asp:TextBox ID="WTxtPaidInventorySlotCount" runat="server" /></td>
		<th>메인장비(무기)</th>
		<td><asp:Literal ID="WLtlWeaponHeroMainGearId" runat="server" /></td>
		<th>메인장비(방어구)</th>
		<td><asp:Literal ID="WLtlArmorHeroMainGearId" runat="server" /></td>
		<th>이름튜토리얼</th>
		<td><asp:Literal ID="WLtlNamingTutorialCompleted" runat="server" /></td>
	</tr>
	<tr>
		<th>마지막로그인</th>
		<td><asp:Literal ID="WLtlLastLoginTime" runat="server" /></td>
		<th>마지막로그아웃</th>
		<td><asp:Literal ID="WLtlLastLogoutTime" runat="server" /></td>
		<th>상태</th>
		<td><asp:Literal ID="WLtlStatus" runat="server" /></td>
		<th>등록시각</th>
		<td><asp:Literal ID="WLtlRegTime" runat="server" /></td>
	</tr>	
    <tr>
		<th>GM여부</th>
		<td></td>
		<th>누적구매다이아</th>
		<td></td>
		<th>누적소비다이아</th>
		<td></td>
		<th>연속로그인</th>
		<td></td>
	</tr>
    <tr>
		<th>점령티어이름</th>
		<td></td>
		<th>점령티어 레벨</th>
		<td></td>
		<th>점령티어 경험치</th>
		<td></td>
		<th></th>
		<td></td>
	</tr>
    <tr>
		<th>별의정수</th>
		<td></td>
		<th>영혼가루</th>
		<td></td>
		<th>구입한 창고 슬롯수</th>
		<td></td>
		<th>날개명칭</th>
		<td></td>
	</tr>
	</table>
    <p class="bottom_line"></p>
    사유 <asp:TextBox ID="WTxtReason" Width="300" runat="server" />
	<asp:Button ID="WBtnUpdate" Text="수정" Width="100" CssClass="button" OnClick="WBtnUpdate_OnClick" runat="server" />
    
    <h4>처리내역</h4>
    <p class="top_line"></p>
    <div style="display:none;">
        <asp:TextBox ID="WTxtGmTargetMainQuestNo_hidden" Width="300" runat="server" />
    </div>
</div>
</body>
</asp:Content>