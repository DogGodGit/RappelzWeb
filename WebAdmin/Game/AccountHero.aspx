<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="AccountHero.aspx.cs" Inherits="Game_AccountHero" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

	<h2>계정정보 - <asp:Literal ID="WLtlAccountAccountId" runat="server" /></h2>

    <p class="top_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>사용자ID</th>
        <td><asp:Literal ID="WLtlUserId" runat="server" /></td>
        <th>최근로그인시각</th>
        <td><asp:Literal ID="WLtlLastLoginTime" runat="server" /></td>
        <th>최근로그인IP</th>
        <td><asp:Literal ID="WLtlLastLoginIp" runat="server" /></td>
		<tr>
        <th>마지막접속 영웅</th>
        <td><asp:Literal ID="WLtlLastAccountHeroId" runat="server" /></td>
        <th>등록시각</th>
        <td><asp:Literal ID="WLtlAccountRegTime" runat="server" /></td>
        <th>상태</th>
        <td><asp:Literal ID="WLtlAccountDeleted" runat="server" /> <asp:Literal ID="WLtlAccountDelTime" runat="server" /></td>
    </tr>
	</table>

	<p class="bottom_line"></p>
    <div class="spacer"></div>

    <h2>보유 계정영웅</h2>

    <p class="top_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
    <td>
		<asp:Repeater ID="WRptAccountHeros" runat="server">
		<ItemTemplate>
		<%# GetDataItem(Container.DataItem, "name")%>
		</ItemTemplate>
		</asp:Repeater>
    </td>
    </tr>
    </table>

    <p class="bottom_line"></p>
    <div class="spacer"></div>

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
	
    <h2>계정영웅정보 - ID : <asp:Literal ID="WLtlAccountHeroId" runat="server" /></h2>

    <p class="top_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_read">

    <tr>
    <td id="TdDetail">
		 <input type="button"  class="btnMenu100 btnMenuSelected" value="계정영웅정보" onclick="displayMenu(this, '/Game/AccountHero_Info.aspx?SVR=<%=m_nGameServerId.ToString()%>&AHID=<%=m_nAccountHeroId.ToString()%>');" />
		 <input type="button"  class="btnMenu100" value="인벤토리" onclick="displayMenu(this, '/Game/AccountHero_Inventory.aspx?SVR=<%=m_nGameServerId.ToString()%>&AHID=<%=m_nAccountHeroId.ToString()%>');" />
		 <input type="button"  class="btnMenu100" value="메인퀘스트" onclick="displayMenu(this, '/Game/AccountHero_MainQuest.aspx?SVR=<%=m_nGameServerId.ToString()%>&AHID=<%=m_nAccountHeroId.ToString()%>');" />
    </td>
    </tr>

    <tr>
        <td class="paddingZero"><iframe id="IFRM" src="/Game/AccountHero_Info.aspx?SVR=<%=m_nGameServerId.ToString()%>&AHID=<%=m_nAccountHeroId.ToString()%>" width="100%" onload="resizeIFrame();" /></td>
    </tr>

    </table>

       <p class="top_line"></p>
    <p class="bottom_line"></p>

</div>
</asp:Content>