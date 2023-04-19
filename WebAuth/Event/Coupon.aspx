<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Coupon.aspx.cs" EnableEventValidation="false" Inherits="Event_Coupon" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="description" content="" />
	<meta name="author" content="GalaLab" />
	<meta name="format-detection" content="telephone=no, address=no" />
	<meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
	<meta name="apple-mobile-web-app-capable" content="yes" />
	<meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <title>Flyff Legacy Coupon Register</title>
	<style type="text/css">
		body{margin:0;}
		input.txt{width:360px;height:32px;background:#741E29;border:0;font-size:16pt;color:#FEFBAE;padding-left:4px;}
		select{height:36px;width:372px;font-size:16pt;}
		div{}
	</style>
</head>
<body>
<form id="form1" runat="server">
<div id="Wrapper" style="width:100%;background-repeat:no-repeat;background-image:url('Images/180321_couponEvent.jpg');width:896px;height:580px;">
	<div style="padding-left:474px;padding-top:<%=sPaddingTop%>;">
		<div style="padding-bottom:<%=sPadding%>;"><asp:TextBox ID="WTxtCoupon" CssClass="txt" runat="server" /></div>
		<div style="padding-bottom:<%=sPadding%>;"><asp:DropDownList ID="WDDLRegion" CssClass="Region" runat="server" /><asp:HiddenField ID="WHFSelectedRegion" runat="server" /></div>
		<div style="padding-bottom:<%=sPadding%>;"><asp:DropDownList ID="WDDLGroup" CssClass="Group" runat="server" /><asp:HiddenField ID="WHFSelectedGroup" runat="server" /></div>
		<div style="padding-bottom:<%=sPadding%>;"><asp:DropDownList ID="WDDLServer" CssClass="Server" runat="server" /><asp:HiddenField ID="WHFSelectedVirtualServer" runat="server" /><asp:HiddenField ID="WHFSelectedServer" runat="server" /></div>
		<div style="padding-bottom:<%=sPadding%>;"><asp:TextBox ID="WTxtName" CssClass="txt" runat="server" /></div>
		<div><asp:ImageButton ID="WBtnRegist" ImageUrl="Images/btn_regist.png" OnClick="WBtnRegist_OnClick" runat="server" /></div>
		<div style="height:122px;"></div>
	</div>
	<asp:Literal ID="WLtl" runat="server" ></asp:Literal>
	<script type="text/javascript">
		
		// select init
		var selRegion = document.getElementById("<%=WDDLRegion.ClientID %>");
		var selGroup = document.getElementById("<%=WDDLGroup.ClientID %>");
		var selServer = document.getElementById("<%=WDDLServer.ClientID %>");

		function checkForm() {

			if (document.getElementById("<%=WTxtCoupon.ClientID %>").value == ""
				|| document.getElementById("<%=WHFSelectedServer.ClientID %>").value == ""
				|| document.getElementById("<%=WTxtName.ClientID %>").value == "") {
				alert("<%=S_ENTERINFOMATION %>");
				return false;
			}

			return true;
		}

		<%=sScript %>

		function init() {
			
			var width = 896;
			var rate = (document.body.offsetWidth / 896.0);

			//if(document.body.offsetWidth > 896)
			document.body.style.zoom = rate;

			optionClear(selRegion);

			selRegion.options[0] = new Option("-- SELECT --", "0");
			for(var i = 0; i < arrRegion.length; i++)
			{
				selRegion.options[i+1] = new Option(arrRegion[i].name, arrRegion[i].regionId);
			}

			selGroup.style.visibility = "hidden";
			selServer.style.visibility = "hidden";
		}

		function selChange(obj)
		{
			var nIdx = 0;

			switch(obj.className)
			{
				case "Region": 
					if(obj.value == 0)
					{
						selGroup.style.visibility = "hidden";
						selServer.style.visibility = "hidden";

						document.getElementById("<%=WHFSelectedRegion.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedVirtualServer.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "";
					}
					else
					{
						document.getElementById("<%=WHFSelectedRegion.ClientID %>").value = obj.value;
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedVirtualServer.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "";

						selGroup.style.visibility = "visible";
						selServer.style.visibility = "hidden";

						optionClear(selGroup);

						selGroup.options[nIdx++] = new Option("-- SELECT --", "0");
						for(var i = 0; i < arrGroup.length; i++)
						{
							if(arrGroup[i].regionId == obj.value)
								selGroup.options[nIdx++] = new Option(arrGroup[i].name, arrGroup[i].groupId);
						}
					}
				break;
				case "Group":
					if(obj.value == 0)
					{
						selServer.style.visibility = "hidden";
						
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedVirtualServer.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "";
					}
					else
					{
						document.getElementById("<%=WHFSelectedGroup.ClientID %>").value = obj.value;
						document.getElementById("<%=WHFSelectedVirtualServer.ClientID %>").value = "";
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "";

						selServer.style.visibility = "visible";

						optionClear(selServer);

						selServer.options[nIdx++] = new Option("-- SELECT --", "0");
						for(var i = 0; i < arrServer.length; i++)
						{
							if(arrServer[i].groupId == obj.value)
								selServer.options[nIdx++] = new Option(arrServer[i].name, arrServer[i].virtualServerId);
						}
					}
				break;
				case "Server":
					if(obj.value == 0)
						document.getElementById("<%=WHFSelectedServer.ClientID %>").value = "";
					else
					{
						document.getElementById("<%=WHFSelectedVirtualServer.ClientID %>").value = obj.value;
						
						for(var i = 0; i < arrServer.length; i++)
						{
							if(arrServer[i].virtualServerId == obj.value)
								document.getElementById("<%=WHFSelectedServer.ClientID %>").value = arrServer[i].gameServerId;
						}
					}
				break;
			}
		}

		function optionClear(obj)
		{
			while(obj.options.length > 0)
				obj.options.remove(0);
		}

		init();

		window.onload = function(){
			var selectedRegionId = document.getElementById("<%=WHFSelectedRegion.ClientID %>").value;
			var selectedGroupId = document.getElementById("<%=WHFSelectedGroup.ClientID %>").value;
			var selectedVirtualServerId = document.getElementById("<%=WHFSelectedVirtualServer.ClientID %>").value;
			var selectedServerId = document.getElementById("<%=WHFSelectedServer.ClientID %>").value;

			var nIdx = 0;

			if(selectedRegionId != "")
			{
				selRegion.value = selectedRegionId;

				selGroup.style.visibility = "visible";

				optionClear(selGroup);

				selGroup.options[nIdx++] = new Option("-- SELECT --", "0");
				for(var i = 0; i < arrGroup.length; i++)
				{
					if(arrGroup[i].regionId == selectedRegionId)
						selGroup.options[nIdx++] = new Option(arrGroup[i].name, arrGroup[i].groupId);
				}

				if(selectedGroupId != "")
				{
					nIdx = 0;

					selGroup.value = selectedGroupId;
					
					selServer.style.visibility = "visible";

					optionClear(selServer);

					selServer.options[nIdx++] = new Option("-- SELECT --", "0");
					for(var i = 0; i < arrServer.length; i++)
					{
						if(arrServer[i].groupId == selectedGroupId)
							selServer.options[nIdx++] = new Option(arrServer[i].name, arrServer[i].virtualServerId);
					}

					if(selectedServerId != "")
					{
						selServer.value = selectedVirtualServerId;

						
					}
				}
			}
		}
	</script>
</div>
</form>
</body>
</html>