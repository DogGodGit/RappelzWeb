<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="Hero.aspx.cs" Inherits="Game_Hero" %>
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

	<h2>계정정보 ID - <asp:Literal ID="WLtlAccountId" runat="server" /></h2>

	<p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>사용자ID</th>
		<td><asp:Literal ID="WLtlUserId" runat="server" /></td>
		<th>가상게임서버ID</th>
		<td><asp:Literal ID="WLtlVirtualGameServerId" runat="server" /></td>
		<th>상태</th>
		<td><asp:Literal ID="WLtlDeleted" runat="server" /></td>
	</tr>
	<tr>
		<th>기본비귀속다이아</th>
		<td><asp:TextBox ID="WTxtBaseUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th>보너스비귀속다이아</th>
		<td><asp:TextBox ID="WTxtBonusUnOwnDia" CssClass="txtAttr" runat="server" /></td>
		<th>VIP포인트</th>
		<td><asp:TextBox ID="WTxtVipPoint" CssClass="txtAttr" runat="server" ></asp:TextBox></td>
	</tr>
	<tr>
		<th>최근로그인시각</th>
		<td><asp:Literal ID="WLtlLastLoginTime" runat="server" /></td>
		<th>최근로그인IP</th>
		<td><asp:Literal ID="WLtlLastLoginIp" runat="server" /></td>
		<th>등록시각</th>
		<td><asp:Literal ID="WLtlRegTime" runat="server" /></td>
	</tr>
	<tr>
		<th>VIP보상내역</th>
		<td colspan="5">
			<script type="text/javascript">
				function ToggleVipReward() {
					if (document.getElementById("DivVipReward").style.display == "none")
						document.getElementById("DivVipReward").style.display = "block";
					else
						document.getElementById("DivVipReward").style.display = "none";

				}
			</script>
			<input type="button" value="보기/안보기" class="button" onclick="ToggleVipReward()" />
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
		<th>보유계정영웅</th>
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
	<asp:Button ID="WBtnUpdate" Text="수정" Width="100" OnClick="WBtnUpdate_OnClick" CssClass="button" runat="server" />
	<!-- -->
	<div class="spacer"></div>
    	<h2>계정영웅 GM 이전</h2>
    <p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th>GM 닉네임</th>
		<td><asp:TextBox ID="WTxtGMNickName" runat="server" />
			<asp:Button ID="WBtnGMSearch" Text="찾기" OnClick="WBtnGMSearch_OnClick" runat="server" />
			<span class="red"><asp:Literal ID="WLtlGMInfo" runat="server" /></span><asp:HiddenField ID="WHFGMAccount" runat="server" />
			<asp:Button ID="WBtnGMTrans" Text="계정영웅 이전" OnClick="WBtnGMTrans_OnClick" CssClass="button" Visible="false" runat="server" />
			<asp:Button ID="WBtnRecovery" Text="계정영웅 회수" OnClick="WBtnRecovery_OnClick" CssClass="button" Visible="false" runat="server" />
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
            <input type="button" class="btnMenu100 btnMenuSelected" value="영웅정보" onclick="displayMenu(this, '/Game/Hero/HeroInfo.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu100" value="인벤토리" onclick="displayMenu(this, '/Game/Hero/Inventory.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
            <input type="button" class="btnMenu100" value="메인퀘스트" onclick="displayMenu(this, '/Game/Hero/MainQuest.aspx?SVR=<%=m_nServerId.ToString()%>&HID=<%=m_heroId.ToString()%>');" />
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