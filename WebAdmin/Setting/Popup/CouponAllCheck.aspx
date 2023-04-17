<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/IFrame.master" CodeFile="CouponAllCheck.aspx.cs" Inherits="Setting_Popup_CouponAllCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<body>
<div>
	<h3><%=Resources.ResLang.PopupCoupon_aspx_txt_01%></h3>
	 <p class="top_line"></p>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
	<tr>
		<th width="300" id="WTxtCampain" runat="server"><%=Resources.ResLang.CouponSystem_aspx_txt_03%></th>
		<td><asp:TextBox ID="WTxtName" runat="server" Height="25" width="500"/>
			<asp:Button ID="WBtnexl" Text="" OnClick="WBtnexl_Click" CssClass="button"  runat="server" />
	  </td>
	</tr>
	<tr>
		<th width="300" id="WTxtCouponCode" runat="server"><%=Resources.ResLang.PopupCoupon_aspx_txt_02%></th>
		<td><asp:TextBox ID="WtxtCoupon" TextMode="MultiLine" runat="server" Height="300" width="600"/></td>
	</tr>
	</table>
	<table cellspacing="1" cellpadding="0" class="bbs_read">
		<td align="center">
			<input type="button" value="<%=Resources.ResLang.PopupCoupon_aspx_txt_03%>" class="button" onclick="self.close();" /> 
		</td>
	</table>

	 <div style="visibility:hidden;">
		<asp:DataGrid ID="WDtGrid" AutoGenerateColumns="false" runat="server">
			<Columns>
				<asp:BoundColumn HeaderText="" DataField="promotionId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
				<asp:BoundColumn HeaderText="" DataField="couponId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
			</Columns>
		</asp:DataGrid>
	</div>

</div>
</body>
</asp:Content>