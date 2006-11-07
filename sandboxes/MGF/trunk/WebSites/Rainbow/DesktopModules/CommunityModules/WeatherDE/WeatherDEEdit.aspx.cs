using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rainbow.Framework;
using Rainbow.Framework.Site.Configuration;
using Rainbow.Framework.Web.UI;

namespace Rainbow.Content.Web.Modules
    /// <summary>


        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void Page_Load(object sender, EventArgs e)
                            int.Parse(((SettingItem) moduleSettings["WeatherSetting"]).ToString());
                                (((SettingItem) moduleSettings["WeatherDesign"]).ToString()))
                                WeatherDesign.SelectedIndex = i;

        /// <summary>
        /// Set the module guids with free access to this page
        /// </summary>
        /// <value>The allowed modules.</value>
        protected override ArrayList AllowedModules

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        protected override void OnUpdate(EventArgs e)
                                                   WeatherSetting.Items[WeatherSetting.SelectedIndex].Value);
                                                   WeatherDesign.Items[WeatherDesign.SelectedIndex].Value);

        #region Web Form Designer generated code

        /// <summary>
        /// Raises OnInitEvent
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnInit(EventArgs e)

            this.Load += new EventHandler(this.Page_Load);

        #endregion