using System;
using System.Web;

namespace Rainbow.Framework
{
    /// <summary>
    /// Static helper methods for one line calls
    /// </summary>
    /// <remarks>
    /// <list type="string">
    /// <item>GetString</item>
    /// </list>
    /// </remarks>
    public static class General
    {
        /// <summary>
        /// Get a resource string value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            return GetString(key, "");
        }

        /// <summary>
        /// Get a resource string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// /// <param name="o">//TODO: get rid of this parameter on the first opportunity</param>
        /// <returns></returns>
        public static string GetString(string key, string defaultValue, object o)
        {
            // TODO: What are objects passed arond for?
            return GetString(key, defaultValue);
        }

        /// <summary>
        /// Get a resource string value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(string key, string defaultValue)
        {
            if (HttpContext.Current == null)
            {
                Exception ne = new Exception("HttpContext.Current not an object");
                ErrorHandler.Publish(LogLevel.Warn, "Problem with Global Resources - could not get key: " + key, ne);
                return "<span class='error'>Could not get key: " + key + "</span>";
            }

            try
            {
                // TODO: Should we be using cached reourceset per language?
#if DEBUG
                HttpContext.Current.Trace.Warn("GetString(" + key + ")");
#endif
                // userCulture = Thread.CurrentThread.CurrentCulture.Name;

                object str = HttpContext.GetGlobalResourceObject("Rainbow", key);
                // string str = ((Rainbow.Framework.Web.UI.Page)System.Web.UI.Page).UserCultureSet.GetString(key);
                string ret = "";

                if (str != null)
                {
                    ret = str.ToString();
#if DEBUG
                    if (ret.Length > 0)
                    {
                        HttpContext.Current.Trace.Warn("We got localized  version");
                    }
                    else
                    {
                        HttpContext.Current.Trace.Warn("Localized return empty, use default");
                    }
#endif
                }

                if (ret.Length == 0)
                {
                    return defaultValue;
                }

                HttpContext.Current.Trace.Warn("GetString  = " + ret);
                return ret;
            }
            catch (Exception ex)
            {
                ErrorHandler.Publish(LogLevel.Warn, "Problem with Global Resources - could not get key: " + key, ex);
                return defaultValue;
            }
        }

        /// <summary>
        /// Get resource
        /// </summary>
        /// <param name="resourceID">The resource ID.</param>
        /// <param name="localize">The _localize.</param>
        /// <returns></returns>
        public static string GetStringResource(string resourceID, string[] localize)
        {
            string res = GetString(resourceID);

            for (int i = 0; i <= localize.GetUpperBound(0); i++)
            {
                string thisparam = "%" + i + "%";
                res = res.Replace(thisparam, GetString(localize[i]));
            }
            return res;
        }
    }
}