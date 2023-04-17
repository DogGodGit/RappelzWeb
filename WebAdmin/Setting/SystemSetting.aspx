<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" CodeFile="SystemSetting.aspx.cs" Inherits="Setting_SystemSetting" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    <h2>시스템 관리</h2>

	<p class="top_line"><br /></p>
	<table cellspacing="1" cellpadding="0" class="bbs_list">
	<tr>
		<th>이름키</th>
		<th>값</th>
	</tr>
	<tr>
		<td class="red">assetBundleUrl</td>
		<td class="left"><asp:TextBox ID="WTxtAssetBundleUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>termsOfServiceUrl</td>
		<td class="left"><asp:TextBox ID="WTxtTermsOfServiceUrl" Width="500"  runat="server" /></td>
	</tr>
	<tr>
		<td>privacyPolicyUrl</td>
		<td class="left"><asp:TextBox ID="WTxtPrivacyPolicyUrl" Width="500"  runat="server" /></td>
	</tr>
	<tr>
		<td>clientVersion</td>
		<td class="left"><asp:TextBox ID="WTxtClientVersion" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>clientTextVersion</td>
		<td class="left"><asp:TextBox ID="WTxtClientTextVersion" Width="500" runat="server" /><asp:HiddenField ID="WHFClientTextVersion" runat="server" /><br />
		<span class="red">* 업데이트시 서버에 메타데이터 파일이 생성됩니다.</span></td>
	</tr>
	<tr>
		<td>metaDataVersion</td>
		<td class="left"><asp:TextBox ID="WTxtMetaDataVersion" Width="500" runat="server" /><asp:HiddenField ID="WHFMetaDataVersion" runat="server" /><br />
		<span class="red">* 업데이트시 서버에 메타데이터 파일이 생성됩니다.</span></td>
	</tr>
	<tr>
		<td>isMaintenance</td>
		<td class="left"><asp:CheckBox ID="WCBoxMaintanance" runat="server" /> 점검중</td>
	</tr>
	<tr>
		<td>MaintenanceInfoUrl</td>
		<td class="left"><asp:TextBox ID="WTxtMaintenanceInfoUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td class="red">recommendGameServerId</td>
		<td class="left"><asp:DropDownList ID="WDDLRecommendGameServer" runat="server" />
			* 공개 상태의 서버만 추천서버에 적용 가능합니다.</td>
	</tr>
	<tr>
		<td class="red">authApiUrl</td>
		<td class="left"><asp:TextBox ID="WTxtAuthApiUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>loggingUrl</td>
		<td class="left"><asp:TextBox ID="WTxtLoggingUrl" Width="500" runat="server" /> <asp:CheckBox ID="WCBoxLoggingEnabled" Text="Logging Enable" runat="server" /></td>
	</tr>
    <tr>
		<td>statusLoggingUrl</td>
		<td class="left"><asp:TextBox ID="WTxtStatusLoggingUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td class="red">heroNameRegex</td>
		<td class="left"><asp:TextBox ID="WTxtHeroNameRegex" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td class="red">guildNameRegex</td>
		<td class="left"><asp:TextBox ID="WTxtGuildNameRegex" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td class="red">defaultLanguageId</td>
		<td class="left"><asp:DropDownList ID="WDDLDefaultLanguage" runat="server" /></td>
	</tr>
	<tr>
		<td>recommendServerAuto</td>
		<td class="left">
			<asp:CheckBox ID="WCBoxRecommendAuto" Text="자동" runat="server" />
			<asp:DropDownList ID="WDDLRecommendType" runat="server" />
		</td>
	</tr>
	<tr>
		<td>maxUserConnectionCount</td>
		<td class="left"><asp:TextBox ID="WTxtMaxUserConnectionCount" runat="server" /> * 0 이하 : 무제한</td>
	</tr>
	<tr>
		<td>StatusLoggingInterval</td>
		<td class="left"><asp:TextBox ID="WTxtStatusLogInterval" runat="server" /></td>
	</tr>

	<tr>
		<td class="red">googlePublicKey</td>
		<td class="left"><asp:TextBox ID="WTxtGooglePublicKey" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>helpshiftSdkEnabled</td>
		<td class="left"><asp:CheckBox ID="WCBoxHelpshiftSdkEnabled" runat="server" /> SDK사용</td>
	</tr>
	<tr>
		<td>helpshiftWebViewEnabled</td>
		<td class="left"><asp:CheckBox ID="WCBoxHelpshiftWebViewEnabled" runat="server" /> 웹뷰사용</td>
	</tr>
    	<tr>
		<td>helpshiftUrl</td>
		<td class="left"><asp:TextBox ID="WTxtHelpshiftUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>appStoreId</td>
		<td class="left"><asp:TextBox ID="WTxtAppStoreId" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>authUrl</td>
		<td class="left"><asp:TextBox ID="WTxtAuthUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>csUrl</td>
		<td class="left"><asp:TextBox ID="WTxtCsUrl" Width="500" runat="server" /></td>
	</tr>
	<tr>
		<td>homepageUrl</td>
		<td class="left"><asp:TextBox ID="WTxtHomepageUrl" Width="500" runat="server" /></td>
	</tr>
	</table>
	<p class="bottom_line"></p>
	
	<asp:Button ID="WBtnUpdate" Text="수정" OnClick="WBtnUpdate_OnClick"  CssClass="button" runat="server" />
</div>
</asp:Content>
