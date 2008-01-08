<%@ Import namespace="Rainbow.Framework.Providers"%>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="Rainbow.Framework.Design.PictureItem" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register Assembly="Rainbow.Framework.Core" Namespace="Rainbow.Framework.Web.UI.WebControls" TagPrefix="rbfwebui" %>
<%@ Register Assembly="Rainbow.Framework.Web.UI.WebControls" Namespace="Rainbow.Framework.Web.UI.WebControls" TagPrefix="rbfwebui" %>
<a href='<%# HttpUrlBuilder.BuildUrl("~/DesktopModules/Pictures/PictureView.aspx?ItemID=" + GetMetadata("ItemID") + "&amp;mid=" + GetMetadata("ModuleID") + "&amp;wversion=" + GetMetadata("WVersion"))%>' runat="server">
	<img border='0' width='<%#GetMetadata("ThumbnailWidth")%>' height='<%#GetMetadata("ThumbnailHeight")%>' alt='<%#GetMetadata("Caption")%>' src='<%# GetMetadata("AlbumPath") + "/" + GetMetadata("ThumbnailFilename")%>'>
</a>
<rbfwebui:HyperLink id="editLink" ImageUrl='<%# PortalProvider.Instance.GetCurrentImageFromTheme("Buttons_Edit", "Edit.gif") %>' NavigateUrl='<%# HttpUrlBuilder.BuildUrl("~/DesktopModules/Pictures/PicturesEdit.aspx","ItemID=" + GetMetadata("ItemID") + "&amp;mid=" + GetMetadata("ModuleID"))%>' Visible='<%# GetMetadata("IsEditable") == "True"%>' runat="server" />