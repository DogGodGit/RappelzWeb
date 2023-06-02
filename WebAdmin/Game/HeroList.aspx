<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="HeroList.aspx.cs" Inherits="Game_HeroList" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
	<h2><%=Resources.ResLang.HeroList_01%></h2>

    <p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">
            <%=Resources.ResLang.HeroList_02%><asp:DropDownList ID="WDDLServer" runat="server" />
            &nbsp;&nbsp;&nbsp;
            <%=Resources.ResLang.HeroList_03%><asp:DropDownList ID="WDDLType" runat="server" />
            <asp:TextBox ID="WTxtSearch" runat="server" /> 
            <asp:Button ID="WBtnSearch" Text="<%$ Resources:ResLang,HeroList_04 %>" OnClick="WBtnSearch_OnClick" CssClass="button" runat="server" />
            </th>
    </tr>
    </table>

    <p class="bottom_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_list">
    <thead>
    <tr>
        <th><%=Resources.ResLang.HeroList_tr_01%></th>
        <th><%=Resources.ResLang.HeroList_tr_02%></th>
        <th><%=Resources.ResLang.HeroList_tr_03%></th>
        <th><%=Resources.ResLang.HeroList_tr_04%></th>
        <th><%=Resources.ResLang.HeroList_tr_05%></th>
        <th><%=Resources.ResLang.HeroList_tr_06%></th>
        <th><%=Resources.ResLang.HeroList_tr_07%></th>
        <th><%=Resources.ResLang.HeroList_tr_08%></th>
    </tr>
    </thead>
    <asp:Repeater ID="WRptList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# GetDataItem(Container.DataItem, "heroId")%></td>
        <td><strong><%# GetDataItem(Container.DataItem, "name")%></strong></td>
        <td><%# GetDataItem(Container.DataItem, "accountId")%></td>
        <td><%# GetDataItem(Container.DataItem, "nationId")%></td>
        <td><%# GetDataItem(Container.DataItem, "jobId")%></td>
        <td><%# GetDataItem(Container.DataItem, "level")%></td>
        <td><%# GetDataItem(Container.DataItem, "deleted")%></td>
        <td><%# GetDataItem(Container.DataItem, "regTime")%></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    <p class="bottom_line"></p>
</div>
</asp:Content>