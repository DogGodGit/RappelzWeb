<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/Master/Main.master" Codebehind="SharingEventAdd.aspx.cs" Inherits="Setting_SharingEvents_SharingEventAdd" %>
<%@ MasterType VirtualPath="~/Common/Master/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MstContent" runat="server">
<div id="CONTENT_INNER">

    <h2>공유하기 - 이벤트 등록</h2>

	<div class="spacer"></div>

	<span class="red"> 
    *이미 등록된 캠페인과 이벤트 기간이 겹치지 않도록 유의해주세요. <br />
    (이벤트 기간이 겹치는 캠페인이 존재할 경우, 보상 시 오류발생할 수 있음) 
    </span>

	<div class="spacer"></div>

    <p class="top_line"></p>

    <table cellspacing="1" cellpadding="0" class="bbs_read">
        <h4>공유하기 이벤트 등록</h4>
        <p class="top_line"></p>
        <th>이벤트ID</th>
        <td><asp:TextBox ID="WTxtEventId" runat="server" /></td>
    <tr>
        <th>홍보내용타입</th>
        <td><asp:DropDownList ID="WDDLContetType" runat="server" /></td>
    </tr>
    <tr>
        <th>홍보내용</th>
        <td><asp:TextBox ID="WTxtContent" TextMode="MultiLine" Rows="2" Columns="50" runat="server" /></td>
    </tr>
    <tr>
        <th>보상범위</th>
        <td><asp:DropDownList ID="WDDLRewardRange" runat="server" /></td>
    </tr>
    <tr>
        <th>보상최대횟수</th>
        <td><asp:TextBox ID="WTxtRewardLimitCount" runat="server" /></td>
    </tr>
    <tr>
        <th>목표레벨</th>
        <td><asp:TextBox ID="WTxtTargetLevel" runat="server" /></td>
    </tr>
    <tr>
        <th>시작시각</th>
        <td><asp:TextBox ID="WTxtStartTime" runat="server" /></td>
    </tr>
    <tr>
        <th>종료시각</th>
        <td><asp:TextBox ID="WTxtEndTime" runat="server" /></td>
    </tr>
    <tr>
        <th>보상메일제목타입</th>
        <td><asp:DropDownList ID="WDDLMailTitleType" runat="server" /></td>
    </tr>
    <tr>
        <th>보상메일제목</th>
        <td><asp:TextBox ID="WTxtMailTitle" runat="server" /></td>
    </tr>
    <tr>
        <th>보상메일내용타입</th>
        <td><asp:DropDownList ID="WDDLMailContentType" runat="server" /></td>
    </tr>
    <tr>
        <th>보상메일내용</th>
        <td><asp:TextBox ID="WTxtMailContent" TextMode="MultiLine" Rows="2" Columns="50" runat="server" /></td>
    </tr>
    <tr>
        <th>이미지이름</th>
        <td><asp:TextBox ID="WTxtImageName" runat="server" /></td>
    </tr>

    </table>
    <p class="top_line"></p>
    <asp:Button ID="WBtnAddSharingEvent" Text="공유하기 이벤트 등록" CssClass="button" OnClick="WBtnAddSharingEvent_OnClick" runat="server" />
    <input type="button" value="목록" class="button" onclick="location.href='/Setting/SharingEvents/SharingEvent.aspx';" />
    </div>
</asp:Content>