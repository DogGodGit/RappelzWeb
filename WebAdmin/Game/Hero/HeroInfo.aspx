<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" Codebehind="HeroInfo.aspx.cs" Inherits="Game_Hero_HeroInfo" %>
<%@ MasterType VirtualPath="~/Common/Master/IFrame.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<body>
<div>
	<p class="top_line"></p>
	<h4><%=Resources.ResLang.HeroInfo_aspx_01%></h4>
    <p class="bottom_line"></p>

    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_02%></th>
		<td><asp:DropDownList ID="WDDLJob" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_03%></th>
		<td><asp:Literal ID="WLtlNationId" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_04%></th>
		<td><asp:Literal ID="WLtlName" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_05%></th>
		<td><asp:TextBox ID="WTxtLevel" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_06%></th>
		<td><asp:TextBox ID="WTxtExp" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_07%></th>
		<td><asp:Literal ID="WLtlBattlePower" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_08%></th>
		<td><asp:TextBox ID="WTxtGold" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_09%></th>
		<td><asp:TextBox ID="WTxtLak" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_10%></th>
		<td><asp:TextBox ID="WTxtOwnDia" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_11%></th>
		<td><asp:TextBox ID="WTxtVipPoint" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_12%></th>
		<td><asp:TextBox ID="WTxtStamina" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_13%></th>
		<td><asp:TextBox ID="WTxtExploitPoint" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_14%></th>
		<td><asp:Literal ID="WLtlWing" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_15%></th>
		<td><asp:Literal ID="WLtlWingStep" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_16%></th>
		<td><asp:Literal ID="WLtlWingLevel" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_17%></th>
		<td><asp:Literal ID="WLtlWingExp" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_18%></th>
		<td><asp:Literal ID="WLtlMainGearEnchant" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_19%></th>
		<td><asp:Literal ID="WLtlMainGearRefinement" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_20%></th>
		<td><asp:Literal ID="WLtlFreeImmediateRevival" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_21%></th>
		<td><asp:Literal ID="WLtlPaidImmediateRevival" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_22%></th>
		<td><asp:Literal ID="WLtlRestTime" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_23%></th>
		<td><asp:Literal ID="WLtlDailyAttendReward" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_24%></th>
		<td><asp:Literal ID="WLtlDailyAccessTime" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_25%></th>
		<td><asp:Literal ID="WLtlMountGearRefinement" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_26%></th>
		<td><asp:Literal ID="WLtlExpPotionUse" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_27%></th>
		<td><asp:Literal ID="WLtlEquippedMountId" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_28%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_29%></th>
		<td><asp:TextBox ID="WTxtGmTargetMainQuestNo" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_30%></th>
		<td><asp:TextBox ID="WTxtPaidInventorySlotCount" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_31%></th>
		<td><asp:Literal ID="WLtlWeaponHeroMainGearId" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_32%></th>
		<td><asp:Literal ID="WLtlArmorHeroMainGearId" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_33%></th>
		<td><asp:Literal ID="WLtlNamingTutorialCompleted" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_34%></th>
		<td><asp:Literal ID="WLtlLastLoginTime" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_35%></th>
		<td><asp:Literal ID="WLtlLastLogoutTime" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_36%></th>
		<td><asp:Literal ID="WLtlStatus" runat="server" /></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_37%></th>
		<td><asp:Literal ID="WLtlRegTime" runat="server" /></td>
	</tr>	
    <tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_38%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_39%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_40%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_41%></th>
		<td></td>
	</tr>
    <tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_42%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_43%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_44%></th>
		<td></td>
		<th></th>
		<td></td>
	</tr>
    <tr>
		<th><%=Resources.ResLang.HeroInfo_aspx_45%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_46%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_47%></th>
		<td></td>
		<th><%=Resources.ResLang.HeroInfo_aspx_48%></th>
		<td></td>
	</tr>
	</table>
    <p class="bottom_line"></p>
     <%=Resources.ResLang.HeroInfo_aspx_49%><asp:TextBox ID="WTxtReason" Width="300" runat="server" />
	<asp:Button ID="WBtnUpdate" Text="<%$Resources:ResLang,HeroInfo_aspx_50%>" Width="100" CssClass="button" OnClick="WBtnUpdate_OnClick" runat="server" />
    
    <h4><%=Resources.ResLang.HeroInfo_aspx_51%></h4>
    <p class="top_line"></p>
    <div style="display:none;">
        <asp:TextBox ID="WTxtGmTargetMainQuestNo_hidden" Width="300" runat="server" />
    </div>
</div>
</body>
</asp:Content>