<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="Hero.aspx.cs" Inherits="Game_Hero" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	
	<script type="text/javascript">
		function resizeIFrame() {
			var maxHeight = 500;
			if (document.getElementById("IFRM").contentDocument.body.scrollHeight > 500)
				document.getElementById("IFRM").height = maxHeight;
			else
				document.getElementById("IFRM").height = document.getElementById("IFRM").contentDocument.body.scrollHeight;
		}
		function displayMenu(obj, sLink) {

			var arrButtons = document.getElementById("TdDetail").getElementsByTagName("input");

			for (var i = 0; i < arrButtons.length; i++) {
				if (arrButtons[i] == obj) {
					arrButtons[i].style.backgroundColor = "#4c5c84";
					arrButtons[i].style.color = "#FFFFFF";
				}
				else {
					arrButtons[i].style.backgroundColor = "#FFFFFF";
					arrButtons[i].style.color = "#000000";
				}
			}

			document.getElementById('IFRM').src = sLink;
		}
    </script>

	<h2><%=Resources.ResLang.Hero_aspx_01%> ID - <asp:Literal ID="WLtlAccountId" runat="server" /></h2>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th><%=Resources.ResLang.WLtlUserId%></th>
		<td><asp:Literal ID="WLtlUserId" runat="server" /></td>
		<th><%=Resources.ResLang.WLtlVirtualGameServerId%></th>
		<td><asp:Literal ID="WLtlVirtualGameServerId" runat="server" /></td>
		<th><%=Resources.ResLang.WLtlDeleted%></th>
		<td><asp:Literal ID="WLtlDeleted" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.WTxtBaseUnOwnDia%></th>
		<td><asp:TextBox ID="WTxtBaseUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th><%=Resources.ResLang.WTxtBaseUnOwnDia%></th>
		<td><asp:TextBox ID="WTxtBonusUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th><%=Resources.ResLang.WTxtVipPoint%></th>
		<td><asp:TextBox ID="WTxtVipPoint" CssClass="txtAttr" runat="server" ></asp:TextBox></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.WLtlLastLoginTime%></th>
		<td><asp:Literal ID="WLtlLastLoginTime" runat="server" /></td>
		<th><%=Resources.ResLang.WLtlLastLoginIp%></th>
		<td><asp:Literal ID="WLtlLastLoginIp" runat="server" /></td>
		<th><%=Resources.ResLang.WLtlRegTime%></th>
		<td><asp:Literal ID="WLtlRegTime" runat="server" /></td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.WLtlVipReward%></th>
		<td colspan="5">
			<script type="text/javascript">
				function ToggleVipReward() {
					if (document.getElementById("DivVipReward").style.display == "none")
						document.getElementById("DivVipReward").style.display = "block";
					else
						document.getElementById("DivVipReward").style.display = "none";

				}
			</script>
			<input type="button" value="<%= Resources.ResLang.btnShow%>" class="button" onclick="ToggleVipReward()" />
			<div id="DivVipReward" style="display:none">
			<asp:Repeater ID="WRptVipRewardList" runat="server">
			<ItemTemplate>
			VipLevel <%# GetDataItem(Container.DataItem, "vipLevel")%> : <%# GetDataItem(Container.DataItem, "name")%><br />
			</ItemTemplate>
			</asp:Repeater>
			</div>
		</td>
	</tr>
	<tr>
		<th><%=Resources.ResLang.Hero_aspx_03%></th>
		<td colspan="5">
			<asp:Repeater ID="WRptList" runat="server">
			<ItemTemplate>
            <%# GetDataItem(Container.DataItem, "heroInfo")%>
            </ItemTemplate>
			</asp:Repeater>
		</td>
	</tr>
	</table>
	<p class="bottom_line"></p>
	<asp:Button ID="WBtnUpdate" Text="<%$ Resources:ResLang,Hero_aspx_02 %>" Width="100" OnClick="WBtnUpdate_OnClick" CssClass="button" runat="server" />
	<!-- -->
	<div class="spacer"></div>
    	<h2><%=Resources.ResLang.Hero_aspx_04%></h2>
    <p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th><%=Resources.ResLang.Hero_aspx_05%></th>
		<td><asp:TextBox ID="WTxtGMNickName" runat="server" />
			<asp:Button ID="WBtnGMSearch" Text="<%$ Resources:ResLang,WBtnGMSearch %>" OnClick="WBtnGMSearch_OnClick" runat="server" />
			<span class="red"><asp:Literal ID="WLtlGMInfo" runat="server" /></span><asp:HiddenField ID="WHFGMAccount" runat="server" />
			<asp:Button ID="WBtnGMTrans" Text="<%$ Resources:ResLang,WBtnGMTrans %>" OnClick="WBtnGMTrans_OnClick" CssClass="button" Visible="false" runat="server" />
			<asp:Button ID="WBtnRecovery" Text="<%$ Resources:ResLang,WBtnRecovery %>" OnClick="WBtnRecovery_OnClick" CssClass="button" Visible="false" runat="server" />
			</td>
	</tr>
	</table>
    <p class="bottom_line"></p>

	<div class="spacer"></div>


	<h2>영웅정보 ID - <asp:Literal ID="WLtlHeroId" runat="server" /></h2>
	<p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<td id="TdDetail">
            <input type="button" class="btnMenu100 btnMenuSelected" value="<%= Resources.ResLang.Hero_aspx_06 %>" onclick="displayMenu(this, '/Game/Hero/HeroInfo.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu100" value="<%= Resources.ResLang.Hero_aspx_07 %>" onclick="displayMenu(this, '/Game/Hero/Inventory.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu100" value="<%= Resources.ResLang.Hero_aspx_08 %>" onclick="displayMenu(this, '/Game/Hero/MainQuest.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
           <%-- <input type="button" class="btnMenu" value="스탯정보" onclick="displayMenu(this, '/Game/Hero/Stat.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu60" value="별자리" onclick="displayMenu(this, '/Game/Hero/Constellation.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu60" value="도감" onclick="displayMenu(this, '/Game/Hero/MonsterBook.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu60" value="친구" onclick="displayMenu(this, '/Game/Hero/Friend.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu60" value="강제종료" onclick="displayMenu(this, '/Game/Hero/ForcedDisconnection.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />--%>
        </td>
	</tr>
    <tr>
        <td class="paddingZero"><iframe id="IFRM" src="/Game/Hero/HeroInfo.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>" width="100%" onload="resizeIFrame();" /></td>
    </tr>
	</table>
	<p class="bottom_line"></p>
</div>
</asp:Content>