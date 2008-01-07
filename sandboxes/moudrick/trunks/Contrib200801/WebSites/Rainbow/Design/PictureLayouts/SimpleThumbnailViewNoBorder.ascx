<%@ Import namespace="Rainbow.Framework.Providers"%>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="Rainbow.Framework.Design.PictureItem" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register Assembly="Rainbow.Framework.Core" Namespace="Rainbow.Framework.Web.UI.WebControls" TagPrefix="rbfwebui" %>
<%@ Register Assembly="Rainbow.Framework.Web.UI.WebControls" Namespace="Rainbow.Framework.Web.UI.WebControls" TagPrefix="rbfwebui" %>
<table width="100%" height="100%" aligh="center">
	<tr>
		<td align="center">
			<a href='<%# HttpUrlBuilder.BuildUrl("~/DesktopModules/Pictures/PictureView.aspx","ItemID=" + GetMetadata("ItemID") + "&mid=" + GetMetadata("ModuleID") + "&wversion=" + GetMetadata("WVersion"))%>' runat="server">
				<img border='0' width='<%#GetMetadata("ThumbnailWidth")%>' height='<%#GetMetadata("ThumbnailHeight")%>' alt='<%#GetMetadata("Caption")%>' src='<%# GetMetadata("AlbumPath") + "/" + GetMetadata("ThumbnailFilename")%>' />
			</a>
		</td>
	</tr>
	<tr>
		<td align="center" valign="middle" class="Normal">
			<%#GetMetadata("ShortDescription")%>
			<rbfwebui:HyperLink id="editLink" ImageUrl='<%# PortalProvider.Instance.GetCurrentImageFromTheme("Buttons_Edit", "Edit.gif") %>' NavigateUrl='<%# HttpUrlBuilder.BuildUrl("~/DesktopModules/Pictures/PicturesEdit.aspx","ItemID=" + GetMetadata("ItemID") + "&mid=" + GetMetadata("ModuleID"))%>' Visible='<%# GetMetadata("IsEditable") == "True"%>' runat="server" />
		</td>
	</tr>
</table>
