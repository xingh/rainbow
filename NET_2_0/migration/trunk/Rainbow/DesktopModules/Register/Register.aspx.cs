using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rainbow.Configuration;
using Rainbow.Security;
using Rainbow.Settings;
using Rainbow.UI.WebControls;

namespace Rainbow.Admin
{
	/// <summary>
	/// Summary description for Register.
	/// </summary>
	[History("jminond", "march 2005", "Changes for moving Tab to Page")]
	[History("gman3001","2004/10/06","Modified GetCurrentProfileControl method to properly obtain a custom register control as specified by the 'Register Module ID' setting.")]
	[History("John.Mandia@whitelightsolutions.com","2003/10/31","Fixed Bug 799945 in sourceforge. After allow no new registrations is ticked users cannot edit their profile")]
	[History("Manu","2003/04/04","Only one register page can load multiple modules")]
	[History("Jes1111","2003/03/10","Modified from original page to use Register module")]
	public class Register : UI.Page
	{
		protected PlaceHolder register;
		protected IEditUserProfile EditControl;

		public bool EditMode
		{
			get
			{ return (userName.Length != 0); }
		}

		private string userName
		{
			get
			{
				string _userName = string.Empty;
				if (Request.Params["userName"] != null)
					_userName = Request.Params["userName"];
				return _userName;
			}
		
		}

		private void Page_Load(object sender, EventArgs e)
		{
			if(!EditMode && !bool.Parse(portalSettings.CustomSettings["SITESETTINGS_ALLOW_NEW_REGISTRATION"].ToString()))
				PortalSecurity.AccessDeniedEdit();

			Control myControl = GetCurrentProfileControl();
			
			EditControl = ((IEditUserProfile) myControl);
			EditControl.RedirectPage = HttpUrlBuilder.BuildUrl(PageID);

			register.Controls.Add(myControl);
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Raises the Init event.
		/// </summary>
		/// <param name="e"></param>
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{    
			this.Load += new EventHandler(this.Page_Load);
		}
		#endregion


		public static Control GetCurrentProfileControl()
		{
			//default
			string RegisterPage = "Register.ascx";

			// 19/08/2004 Jonathan Fong 
			// www.gt.com.au
			RainbowPrincipal user = HttpContext.Current.User as RainbowPrincipal;
			if (user != null && user.Identity.AuthenticationType == "LDAP")
			{
				RegisterPage = "LDAPUserProfile.ascx";
				PortalSettings portalSettings = (PortalSettings) HttpContext.Current.Items["PortalSettings"];
				Page x = new Page();
				Control myControl = x.LoadControl(Path.WebPathCombine(Path.ApplicationRoot, "DesktopModules/LDAPUserProfile", RegisterPage));
				
				PortalModuleControl p = ((PortalModuleControl) myControl);
				p.ModuleID = int.Parse(portalSettings.CustomSettings["SITESETTINGS_REGISTER_MODULEID"].ToString());

				return ((Control) p);
			}
			// Obtain PortalSettings from Current Context
			else if (HttpContext.Current != null)
			{
				PortalSettings portalSettings = (PortalSettings) HttpContext.Current.Items["PortalSettings"];

				//Select the actual register page
				if (portalSettings.CustomSettings["SITESETTINGS_REGISTER_TYPE"] != null &&
					portalSettings.CustomSettings["SITESETTINGS_REGISTER_TYPE"].ToString() != "Register.ascx" )
				{
					RegisterPage = portalSettings.CustomSettings["SITESETTINGS_REGISTER_TYPE"].ToString();
				}
				Page x = new Page();

				// Modified by gman3001 10/06/2004, to support proper loading of a register module specified by 'Register Module ID' setting in the Portal Settings admin page
				int moduleID = int.Parse(portalSettings.CustomSettings["SITESETTINGS_REGISTER_MODULEID"].ToString());
				string moduleDesktopSrc = string.Empty;
				if (moduleID > 0)
					moduleDesktopSrc = ModuleSettings.GetModuleDesktopSrc(moduleID);
				if (moduleDesktopSrc.Length == 0)
					moduleDesktopSrc = Path.WebPathCombine(Path.ApplicationRoot, "DesktopModules/Register", RegisterPage);
				Control myControl = x.LoadControl(moduleDesktopSrc);
				// End Modification by gman3001

				PortalModuleControl p = ((PortalModuleControl) myControl);
				//p.ModuleID = int.Parse(portalSettings.CustomSettings["SITESETTINGS_REGISTER_MODULEID"].ToString());
				p.ModuleID = moduleID;
				if (p.ModuleID == 0)
					((SettingItem) p.Settings["MODULESETTINGS_SHOW_TITLE"]).Value = "false";
				return ((Control) p);
			}

			return (null);
		}
	}
}