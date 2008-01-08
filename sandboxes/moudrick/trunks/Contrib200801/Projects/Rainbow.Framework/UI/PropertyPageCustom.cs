using System.Collections;
using Rainbow.Framework.Core;
using Rainbow.Framework.Core.Configuration.Settings.Providers;
using System;
using Rainbow.Framework.Security;

namespace Rainbow.Framework.Web.UI
{
    /// <summary>
    /// PropertyPage_custom inherits from Rainbow.Framework.UI.PropertyPage <br/>
    /// Used for properties pages to display custom properties of a module<br/>
    /// Can be inherited
    /// </summary>
    public class PropertyPageCustom : PropertyPage
    {
        private Hashtable customUserSettings;

        /// <summary>
        /// Stores current module settings
        /// </summary>
        /// <value>The custom user settings.</value>
        public Hashtable CustomUserSettings
        {
            get
            {
                if (customUserSettings == null)
                {
                    if (ModuleID > 0)
                        // Get settings from the database
                        customUserSettings =
                            ModuleSettingsProvider.GetModuleUserSettings(ModuleID,
                                                                       (Guid)RainbowPrincipal.CurrentUser.Identity.ProviderUserKey,
                                                                       this);
                    else
                        // Or provides an empty hashtable
                        customUserSettings = new Hashtable();
                }
                return customUserSettings;
            }
        }
    }
}