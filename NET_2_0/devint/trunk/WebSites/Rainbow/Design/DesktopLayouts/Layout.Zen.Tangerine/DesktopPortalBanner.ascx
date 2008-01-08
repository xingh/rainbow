<%@ Control %>
<%@ Register TagPrefix="zen" Namespace="Rainbow.UI.WebControls" Assembly="MarinaTeq.Rainbow.Zen" %>
<zen:ZenLayout 
	ID="ZenHeader" 
	CssID="ZenHeader"
	HeaderContent="Header"
	runat="server">
	<HeaderTemplate>
		<div id="PortalLogo"></div>
		<zen:ZenHeaderTitle 
			ID="PortalTitle" 
			ShowImage="true" 
			runat="server">
		</zen:ZenHeaderTitle>
		<zen:ZenHeaderMenu 
			ID="PortalHeaderMenu" 
			ButtonsCssClass="headermenu" 
			LabelsCssClass="headerlabels" 
			ShowLogon="true" 
			ShowSaveDesktop="false" 
			runat="server">
		</zen:ZenHeaderMenu>
		<zen:ZenNavigation 
			ID="PortalMainNav" 
			ContainerCssClass="mainmenu" 
			runat="server">
		</zen:ZenNavigation>
	</HeaderTemplate>
</zen:ZenLayout>
