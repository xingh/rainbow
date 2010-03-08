using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rainbow.Framework;
using Rainbow.Framework.BusinessObjects;
using Rainbow.Framework.Context;
using Rainbow.Framework.Items;
using Rainbow.Framework.Providers;
using Rainbow.Framework.Security;
using Rainbow.Framework.Web.UI;
using Rainbow.Framework.Web.UI.WebControls;
using History=Rainbow.Framework.History;
using Localize=Rainbow.Framework.Web.UI.WebControls.Localize;
using System.Collections.Generic;

namespace Rainbow.Content.Web.Modules
{
    /// <summary>
    /// User manager
    /// </summary>
    [History("jminond", "march 2005", "Changes for moving Tab to Page")]
    [History("gman3001", "2004/10/06",
            "Add GetCurrentProfileControl method to properly obtain a custom register control as specified by the 'Register Module ID' setting.")]
    public partial class UsersManage : EditItemPage
    {
        Guid userID = Guid.Empty;
        string userName = string.Empty;
        //        int tabIndex = 0;
        protected Localize name;
        protected IEditUserProfile EditControl;

        /// <summary>
        /// The Page_Load server event handler on this page is used
        /// to populate the role information for the page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Page_Load(object sender, EventArgs e)
        {
            // Verify that the current user has access to access this page
            // Removed by Mario Endara <mario@softworks.com.uy> (2004/11/04)
            //			if (PortalSecurity.IsInRoles("Admins") == false)
            //				PortalSecurity.AccessDeniedEdit();

            //Code no longer needed here, gman3001 10/06/2004
            /*string RegisterPage;

			//Select the actual register page
			if (portalSettings.CustomSettings["SITESETTINGS_REGISTER_TYPE"] != null &&
					portalSettings.CustomSettings["SITESETTINGS_REGISTER_TYPE"].ToString() != "register.aspx" )
				RegisterPage = portalSettings.CustomSettings["SITESETTINGS_REGISTER_TYPE"].ToString();
			else
				RegisterPage = "register.aspx";
			*/

            // Calculate userid
            if (Request.Params["userid"] != null)
            {
                userID = new Guid(Request.Params["userid"]);
            }
            if (Request.Params["username"] != null)
            {
                userName = Request.Params["username"];
            }


            //Control myControl = this.LoadControl("../DesktopModules/Register/" + RegisterPage);
            //Control myControl = this.LoadControl(Rainbow.Framework.Settings.Path.WebPathCombine(Rainbow.Framework.Settings.Path.ApplicationRoot, "DesktopModules/Register", RegisterPage));
            // Line Added by gman3001 10/06/2004, to support proper loading of a register module specified by 'Register Module ID' setting in the Portal Settings admin page
            Control myControl = GetCurrentProfileControl();

            EditControl = ((IEditUserProfile) myControl);
            //EditControl.RedirectPage = HttpUrlBuilder.BuildUrl("~/Admin/UsersManage.aspx", TabID, "username=" + userName + AllowEditUserID);
            register.Controls.Add(myControl);

            // If this is the first visit to the page, bind the role data to the datalist
            if (Page.IsPostBack == false)
            {
                // new user?
                if (userName == string.Empty)
                {
                    try
                    {
                        // make a unique new user record
                        Guid uid = Guid.Empty;
                        int i = 0;

                        Exception lastException = null;
                        while (uid == Guid.Empty && i < 99) //Avoid infinite loop
                        {
                            string friendlyName = "New User created " + DateTime.Now;
                            userName = "NewUserEmail" + i + "@yoursite.com";
                            try
                            {
                                uid = AccountSystem.Instance.AddUser(
                                        PortalProvider.Instance.CurrentPortal.PortalAlias,
                                        userName,
                                        string.Empty,
                                        friendlyName);
                            }
                            catch (Exception ex)
                            {
                                uid = Guid.Empty;
                                lastException = ex;
                            }
                            i++;
                        }
                        if (uid == Guid.Empty)
                        {
                            throw new Exception("New user creation failed after " + i + " retries.",
                                                lastException);
                        }

                        // redirect to this page with the corrected querystring args
                        Response.Redirect(
                            HttpUrlBuilder.BuildUrl("~/DesktopModules/CoreModules/Users/UsersManage.aspx", PageID,
                                                    "mID=" + ModuleID + "&username=" + userName ) );
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.Publish(LogLevel.Error, "Error creating new user", ex);
                        ErrorLabel.Text = ex.Message;
                        ErrorLabel.Visible = true;
                    }
                }

                BindData();
            }
        }

        // Method Added by gman3001 10/06/2004, to support proper loading of a register module specified by 'Register Module ID' setting in the Portal Settings admin page
        /// <summary>
        /// Gets the current profile control.
        /// </summary>
        /// <returns></returns>
        Control GetCurrentProfileControl()
        {
            //default
            string registerPage = "register.aspx";
            if (HttpContext.Current != null)
            {
                Portal localPortal = PortalProvider.Instance.CurrentPortal;

                //Select the actual register page
                if (localPortal.CustomSettings["SITESETTINGS_REGISTER_TYPE"] != null &&
                    localPortal.CustomSettings["SITESETTINGS_REGISTER_TYPE"].ToString() != "register.aspx")
                {
                    registerPage = localPortal.CustomSettings["SITESETTINGS_REGISTER_TYPE"].ToString();
                }

                int moduleID = int.Parse(localPortal.CustomSettings["SITESETTINGS_REGISTER_MODULEID"].ToString());
                string moduleDesktopSrc = string.Empty;
                if (moduleID > 0)
                {
                    moduleDesktopSrc = RainbowModuleProvider.Instance.GetModuleDesktopSrc(moduleID);
                }
                if (moduleDesktopSrc.Length == 0)
                {
                    moduleDesktopSrc = //registerPage;
                    //Changed by moudrick to fix the issue 27
                    //commented out path combinig and left just assignment since it is already combined in the default configuration
                    //http://code.google.com/p/rainbow/issues/detail?id=27
                    //Path.WebPathCombine(Path.ApplicationRoot, "DesktopModules/CoreModules/Register", RegisterPage);

                        // issue #78 - inserted to keep code bases as close as possible with stage.
                        // by admin@itinfoplus.com Path.WebPathCombine(Path.ApplicationRoot, "DesktopModules/CoreModules/Register", RegisterPage);
                        Path.WebPathCombine(Path.ApplicationRoot, "DesktopModules/CoreModules/Register", "RegisterFull.ascx");
                }
                Control control = LoadControl(moduleDesktopSrc);

                PortalModuleControl portalModuleControl = ((PortalModuleControl) control);

                // changed by Mario Endara <mario@softworks.com.uy> (2004/11/05)
                // if there's no custom register module, take actual ModuleID, else take the custom ModuleID
                if (moduleID == 0)
                {
                    portalModuleControl.ModuleID = ModuleID;
                    ((SettingItem)portalModuleControl.Settings["MODULESETTINGS_SHOW_TITLE"]).Value = "false";
                }
                else
                {
                    portalModuleControl.ModuleID = moduleID;
                }
                return portalModuleControl;
            }
            return null;
        }

        /// <summary>
        /// Set the module guids with free access to this page
        /// </summary>
        /// <value>The allowed modules.</value>
        protected override ArrayList AllowedModules
        {
            get
            {
                ArrayList al = new ArrayList();
                al.Add("B6A48596-9047-4564-8555-61E3B31D7272");
                return al;
            }
        }

        //		string AllowEditUserID
        //		{
        //			get
        //			{
        //				return (Request.Params["AllowEditUserID"] != null) ? "&AllowEditUserID=true" : string.Empty;
        //			}	
        //		}

        /// <summary>
        /// The Save_Click server event handler on this page is used
        /// to save the current security settings to the configuration system
        /// </summary>
        /// <param name="Sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Save_Click(object Sender, EventArgs e)
        {
            // Persists user data
            EditControl.SaveUserData();

            // remove cache before redirect
            Context.Cache.Remove(Key.ModuleSettings(ModuleID));

            // Navigate back to admin page
            Response.Redirect(HttpUrlBuilder.BuildUrl(PageID));
        }

        /// <summary>
        /// The AddRole_Click server event handler is used to add
        /// the user to this security role.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void AddRole_Click(object sender, EventArgs e)
        {
            //get user id from dropdownlist of existing users
            Guid roleID = new Guid(allRoles.SelectedItem.Value);
            AccountSystem.Instance.AddUserRole(roleID, userID);
            BindData(); // Rebind list
        }

        /// <summary>
        /// The UserRoles_ItemCommand server event handler on this page
        /// is used to handle deleting the user from roles
        /// from the userRoles asp:datalist control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.DataListCommandEventArgs"/> instance containing the event data.</param>
        void UserRoles_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            Guid roleID = (Guid) userRoles.DataKeys[e.Item.ItemIndex];
            AccountSystem.Instance.DeleteUserRole(roleID, userID);
            userRoles.EditItemIndex = -1; // Ensure that item is not editable
            BindData(); // Repopulate list
        }

        /// <summary>
        /// The BindData helper method is used to bind the list of
        /// security roles for this portal to an asp:datalist server control
        /// </summary>
        void BindData()
        {
            // Bind the Email and Password
            Guid currentUserID = RainbowPrincipal.CurrentUser.Identity.ProviderUserKey;
            IList<RainbowRole> roles =
                AccountSystem.Instance.GetRolesByUser(currentUserID, portalSettings.PortalAlias);
            userRoles.DataSource = roles;
            userRoles.DataBind();

            // bind all portal roles to dropdownlist
            IList<RainbowRole> allRolesList = AccountSystem.Instance.GetPortalRoles( portalSettings.PortalAlias );
            allRoles.DataSource = allRolesList;
            allRoles.DataBind();
        }

        #region Web Form Designer generated code

        /// <summary>
        /// Raises the Init event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            this.addExisting.Click += new EventHandler(this.AddRole_Click);
            this.userRoles.ItemCommand += new DataListCommandEventHandler(this.UserRoles_ItemCommand);
            this.saveBtn.Click += new EventHandler(this.Save_Click);
            this.Load += new EventHandler(this.Page_Load);
            base.OnInit(e);
        }

        #endregion
    }
}
