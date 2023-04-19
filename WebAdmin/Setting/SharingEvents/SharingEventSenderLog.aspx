<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="SharingEventSenderLog.aspx.cs" Inherits="Setting_SharingEvents_SharingEventSenderLog" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>

	<script language="javascript" type="text/javascript">
	    function excelDownload() {
	        window.open("<%=m_sPopupUrl %>", "excel", "width=400,height=400");
	    }
	</script>

<div id="CONTENT_INNER">
    <h2>공유하기 - 발신자 로그</h2>
    
	<div class="spacer"></div>
    
    <p class="bottom_line"></p>
    <h4>
        &nbsp;
        <a href="/Setting/SharingEvents/SharingEvent.aspx">공유하기 이벤트</a>
        |
        <a href="/Setting/SharingEvents/SharingEventSenderReward.aspx">발신자보상</a>
        |
        <a href="/Setting/SharingEvents/SharingEventReceiveReward.aspx">수신자보상</a>
        |
        <a href="/Setting/SharingEvents/SharingEventSenderLog.aspx" class="selected">발신자 로그</a>
        |
        <a href="/Setting/SharingEvents/SharingEventReceiverLog.aspx">수신자 로그</a>

    </h4>
    <p class="bottom_line"></p>
	<div class="spacer"></div>

    <p class="top_line"></p>
        <table cellspacing="2" class="bbs_read">
            <tr>
                <th class="left">
                    서버<asp:DropDownList ID="WDDLServer" runat="server" />
                    &nbsp;&nbsp;&nbsp;
                    검색대상 <asp:DropDownList ID="WDDLType" runat="server" />
                    <asp:TextBox ID="WTxtSearch" runat="server" /> 
                    <asp:Button ID="WBtnSearch" OnClick="WBtnSearch_OnClick" CssClass="button" Visible="false" runat="server" />
                    <input type="button" value="엑셀다운로드" class="pointer" onclick="excelDownload();" />
                    </th>
            </tr>
       </table>
    <p class="bottom_line"></p>


    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>추천코드</th>
        <th>이벤트ID</th>
        <th>게임서버ID</th>
        <th>계정영웅ID</th>
        <th>등록시각</th>
    </tr>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="center"><%# GetDataItem(Container.DataItem, "inviteCode")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "eventId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "serverName")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "heroId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>

	<p class="bottom_line"></p>
    <div class="pageNavi">
        <ucl:PageNavigator ID="WPageNavigator" Runat="server" />
    </div>

</div>
</asp:Content>
