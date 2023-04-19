<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/Main.master" AutoEventWireup="true" Codebehind="PurchaseAllLog.aspx.cs" Inherits="Log_PurchaseAllLog" %>
<%@ Register TagPrefix="ucl" TagName="PageNavigator" Src="~/Common/UserControl/PageNavigator.ascx" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">
    <h2>결제 로그</h2>

    <p class="top_line"><br /></p>
    <table cellspacing="2" class="bbs_read">
    <tr>
        <th class="left">
            서버<asp:DropDownList ID="WDDLServer" OnSelectedIndexChanged="WDDLServer_SelectedIndexChanged" AutoPostBack="true" runat="server" />
            &nbsp;
<%--            <%=Resources.resLang.ACCHLIST_aspx_txt_01%> <asp:DropDownList ID="WDDLType" runat="server" />
            &nbsp;
            HeroName<asp:TextBox ID="WTxtName" runat="server" />--%>
        </th>
    </tr>
    </table>

    <p class="bottom_line"></p>

    <script language="javascript" type="text/javascript">
        function excelDownload() {
            window.open("<%=m_sPopupUrl%>", "excel", "width=400, height=400");
        }
    </script>
    <div runat="server">
        <p class="top_line"></p>
        <h2>전체 결제로그</h2>        
        <p class="bottom_line"></p>

        <p class="top_line"></p>
        &nbsp;
        기간 : <asp:TextBox ID="WTxtStart" runat="server" /> ~ <asp:TextBox ID="WTxtEnd" runat="server" />
        <asp:Button ID="WBtnSearch" Text="검색" OnClick="WBtnSearch_OnClick" CssClass="button" runat="server" />
        <input type="button" value="엑셀다운로드" class="pointer" onclick="excelDownload();" />
        <p class="bottom_line"></p>

        <p class="top_line"></p>
        <table cellspacing="1" cellpadding="0" class="bbs_read">
        <thead>
        <tr>
        <th>결제ID</th>
        <th>게임서버ID</th>
        <th>heroId</th>
        <th>상품ID</th>
        <th>구매데이터</th>
        <th>스토어타입</th>
        <th>주문번호</th>
        <th>구매타입</th>
        <th>상태</th>
        <th>기타</th>
        <th>수정시각</th>
        <th>등록시각</th>
        <th>예외</th>
        </tr>
        </thead>
        <asp:Repeater ID="WRptList" runat="server">
        <ItemTemplate>
        <tr>
        <td class="center"><input type="text" value='<%# GetDataItem(Container.DataItem, "purchaseId")%>' /></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "virtualGameServerId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "heroId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "productId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "purchaseData")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "storeType")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "orderId")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "signature")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "status")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "failReason")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "statusUpdateTime")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "regTime")%></td>
        <td class="center"><%# GetDataItem(Container.DataItem, "exceptionId")%></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        </table>
        <p class="bottom_line"></p>
        <div class="pageNavi">
            <ucl:PageNavigator ID="WPageNavigator" runat="server" />
        </div>
    </div>
</div>
</asp:Content>