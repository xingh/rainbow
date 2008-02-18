<%@ WebHandler Language="C#" Class="sitelogo" %>

using System.Drawing.Imaging;
using System.Web;
using Rainbow.Framework;
using Rainbow.Framework.BusinessObjects;
using Rainbow.Framework.Providers;

public class sitelogo : IHttpHandler 
{
    public void ProcessRequest(HttpContext context)
    {
        Portal portalSettings = PortalProvider.Instance.CurrentPortal;

        //PortalImage
        if (portalSettings.CustomSettings["SITESETTINGS_LOGO"] != null &&
            portalSettings.CustomSettings["SITESETTINGS_LOGO"].ToString().Length != 0)
        {
            string imageUrl = Path.WebPathCombine(Path.ApplicationRoot, 
                portalSettings.PortalPath,
                portalSettings.CustomSettings["SITESETTINGS_LOGO"].ToString());

            using (System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(imageUrl)))
            {
                image.Save(context.Response.OutputStream, image.RawFormat);
                context.Response.ContentType = GetImageFormat(image.RawFormat);
            }
        }
        else //no image, alt text will be displayed
        {
            context.Response.StatusCode = 404;
        }
    }

    string GetImageFormat (ImageFormat format) 
    {
        if (format.Equals(ImageFormat.Jpeg))
        {
            return "image/jpeg";
        }
        else if (format.Equals(ImageFormat.Gif))
        {
            return "image/gif";
        }
        else if (format.Equals(ImageFormat.Png))
        {
            return "image/png";
        }
        else if (format.Equals(ImageFormat.Bmp))
        {
            return "image/bmp";
        }
        else
        {
            return "image/jpeg";
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }
}