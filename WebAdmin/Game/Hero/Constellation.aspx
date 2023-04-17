<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/IFrame.master" AutoEventWireup="true" CodeFile="Constellation.aspx.cs" Inherits="Game_Hero_Constellation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" Runat="Server">
<body>
<div>
    <p class="top_line"></p>
  <%--  <h4><%=Resources.resLang.ACCHINFO_aspx_h4_01%></h4>
	    <h4>*사이클 수정시 현재항목이 초기화 됩니다.</h4>--%>
    <p class="bottom_line"></p>
    <p class="top_line"></p>
    <table cellspacing="1" cellpadding="0" class="bbs_read">
    <tr>
        <th>별자리</th>
        <th>단계</th>
		<th>사이클</th>
        <th>현재항목</th>
        <th></th>
    </tr>
    <asp:Repeater ID="WRptStar" OnItemDataBound="WRptStar_OnItemDataBound" OnItemCommand="WRptStar_OnItemCommand" runat="server">
    <ItemTemplate>
    <tr>
        <td>[<%# GetDataItem(Container.DataItem, "constellationId")%>] <%# GetDataItem(Container.DataItem, "name")%> </td>
        <td class="right"><asp:Literal ID="WLtlSteb" Text=<%# GetDataItem(Container.DataItem, "step")%> runat="server" />  &nbsp; <%=Resources.resLang.ACCHC_aspx_td_01%></td>
        <td><asp:TextBox ID="WTxtCycle" Text=<%# GetDataItem(Container.DataItem, "maxCycle")%> runat="server" /><%=Resources.resLang.Constellation_aspx_03%>
        <td><asp:TextBox ID="WTxtEntryId" Text=<%# GetDataItem(Container.DataItem, "maxEntryId")%> runat="server" /><%=Resources.resLang.ACCHC_aspx_td_02%></td>
        <td class="center"><asp:Button ID="WBtnUpdate" Text="" Visible="true" CssClass="button" CommandName="update" CommandArgument=<%# GetDataItem(Container.DataItem, "constellationId")%> runat="server" /></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
</div>
</body>
</asp:Content>

