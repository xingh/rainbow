using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esperantus;
using Rainbow.Configuration;
using Rainbow.Helpers;
using Rainbow.Settings;
using Rainbow.Settings.Cache;
using Rainbow.UI.DataTypes;
using Rainbow.UI.WebControls;

namespace Rainbow.DesktopModules 
{
        
    public class Pages : PortalModuleControl
    {
		protected Esperantus.WebControls.Label lblHead;
		protected ListBox tabList;
		protected Esperantus.WebControls.ImageButton upBtn;
		protected Esperantus.WebControls.ImageButton downBtn;
		protected Esperantus.WebControls.LinkButton addBtn;

		protected ArrayList portalPages;
		
		/// <summary>
		/// Admin Module
		/// </summary>
		public override bool AdminModule
		{
			get
			{
				return true;
			}
		}

        /// <summary>
        /// The Page_Load server event handler on this user control 
        /// is used to populate the current tab settings from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load(object sender, EventArgs e) 
        {
            portalPages = new PagesDB().GetPagesFlat (portalSettings.PortalID);// Warning --> This method is used because the new not work

            // If this is the first visit to the page, bind the tab data to the page listbox
            if (!Page.IsPostBack) 
            {
				// Set the ImageUrl for controls from current Theme
				upBtn.ImageUrl		= this.CurrentTheme.GetImage("Buttons_Up", "Up.gif").ImageUrl;
				downBtn.ImageUrl	= this.CurrentTheme.GetImage("Buttons_Down", "Down.gif").ImageUrl;
				
				tabList.DataBind();

				// 2/27/2003 Start - Ender Malkoc
				// After up or down button when the page is refreshed, 
				// select the previously selected tab from the list.
				if (Request.Params["selectedtabID"] != null) 
				{
					try
					{
						int tabIndex = Int32.Parse(Request.Params["selectedtabID"]);
						SelectPage(tabIndex);
					}
					catch
					{

					}
				}
				// 2/27/2003 End - Ender Malkoc
            }
        }

		/// <summary>
		/// This is where you add module settings. These settings  
		/// are used to control the behavior of the module
		/// </summary>
		/// <param></param>
		public Pages()
		{
			// EHN: Add new version control for tabs module. 
			//      Mike Stone - 19/12/2004
			SettingItem PageVersion = new SettingItem(new BooleanDataType());
			PageVersion.Value = "True";
			PageVersion.EnglishName = "Use Old Version?";
			PageVersion.Description = "If Checked the module acts has it always did. If not it uses the new short form which allows security to be set so the new tab will not be seen by all users.";
			PageVersion.Order = 10;
			this._baseSettings.Add("TAB_VERSION", PageVersion); 
		}



		/// <summary>
		/// The UpDown_Click server event handler on this page is
		/// used to move a portal module up or down on a tab's layout pane
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpDown_Click(Object sender, ImageClickEventArgs e) 
		{
			string cmd = ((ImageButton)sender).CommandName;
        
			if (tabList.SelectedIndex > -1) 
			{
				int delta;
            
				// Determine the delta to apply in the order number for the module
				// within the list.  +3 moves down one item; -3 moves up one item
				if (cmd == "down") 
				{
					delta = 3;
				}
				else 
				{
					delta = -3;
				}

				PageItem t;
				t = (PageItem) portalPages[tabList.SelectedIndex];
				t.Order += delta;
				OrderPages();
				Response.Redirect(HttpUrlBuilder.BuildUrl("~/DesktopDefault.aspx", PageID, "selectedtabID=" + t.ID));
			}		
		}

        /// <summary>
        /// The DeleteBtn_Click server event handler is used to delete
        /// the selected tab from the portal
        /// </summary>
        override protected void OnDelete()
        {
            base.OnDelete();

            if (tabList.SelectedIndex > -1)
            {
                try
                {
                    // must delete from database too
                    PageItem t = (PageItem) portalPages[tabList.SelectedIndex];
                    PagesDB tabs = new PagesDB();
                    tabs.DeletePage(t.ID);
                        
                    portalPages.RemoveAt(tabList.SelectedIndex);

					if (tabList.SelectedIndex > 0) 
						t = (PageItem) portalPages[tabList.SelectedIndex-1]; 

                    OrderPages();
            
					Response.Redirect(HttpUrlBuilder.BuildUrl("~/DesktopDefault.aspx", PageID, "SelectedPageID=" + t.ID));
                }
                catch (SqlException)
                {
                    Controls.Add(new LiteralControl("<br><span class='Error'>" + Localize.GetString("TAB_DELETE_FAILED", "Failed to delete Page", this) + "<br>"));
                }
            }
        }

        /// <summary>
        /// The AddPage_Click server event handler is used
        /// to add a new tab for this portal
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void AddPage_Click(Object Sender, EventArgs e) 
        {
			if (Settings["TAB_VERSION"] != null)
			{
				if(Settings["TAB_VERSION"].ToString() == "True") // Use Old Version
				{
					// New tabs go to the end of the list
					PageItem t = new PageItem();
					t.Name = Localize.GetString("TAB_NAME", "New Page Name");  //Just in case it comes to be empty
					t.ID = -1;
					t.Order = 990000;
					portalPages.Add(t);

					// write tab to database
					PagesDB tabs = new PagesDB();
					t.ID = tabs.AddPage(portalSettings.PortalID, t.Name, t.Order);
        
					// Reset the order numbers for the tabs within the list  
					OrderPages();


					// Redirect to edit page
					// 3_aug_2004 Cory Isakson added returntabid so that PageLayout could return to the tab it was called from.
					// added mID by Mario Endara <mario@softworks.com.uy> to support security check (2004/11/09)
					Response.Redirect(HttpUrlBuilder.BuildUrl("~/DesktopModules/Pages/PageLayout.aspx", t.ID, "mID=" + ModuleID.ToString() + "&returntabid=" + Page.PageID));
				}
				else
				{
					// Redirect to New Form - Mike Stone 19/12/2004
					Response.Redirect(HttpUrlBuilder.BuildUrl("~/DesktopModules/Pages/AddPage.aspx", "mID=" + ModuleID.ToString() + "&returntabid=" + Page.PageID));
				}
			}

        }

        /// <summary>
        /// The EditBtn_Click server event handler is used to edit
        /// the selected tab within the portal
        /// </summary>
        override protected void OnEdit()
        {
            // Redirect to edit page of currently selected tab
            if (tabList.SelectedIndex > -1) 
            {
                // Redirect to module settings page
                PageItem t = (PageItem) portalPages[tabList.SelectedIndex];
            
				// added mID by Mario Endara <mario@softworks.com.uy> to support security check (2004/11/09)
				Response.Redirect(HttpUrlBuilder.BuildUrl("~/DesktopModules/Pages/PageLayout.aspx", t.ID, "mID=" + ModuleID.ToString() + "&returntabid=" + Page.PageID));
			}
        }

        /// <summary>
        /// The OrderPages helper method is used to reset 
        /// the display order for tabs within the portal
        /// </summary>
        private void OrderPages () 
        {
            int i = 1;
        
            portalPages.Sort();
        
            foreach (PageItem t in portalPages) 
            {
                // number the items 1, 3, 5, etc. to provide an empty order
                // number when moving items up and down in the list.
				t.Order = i; 
                i += 2;
            
                // rewrite tab to database
                PagesDB tabs = new PagesDB();
				// 12/16/2002 Start - Cory Isakson 
                tabs.UpdatePageOrder(t.ID, t.Order); 
				// 12/16/2002 End - Cory Isakson 
            }
			//gbs: Invalidate cache, fix for bug RBM-220
        	CurrentCache.RemoveAll("_PageNavigationSettings_");
		}
    
		/// <summary>
		/// Given the tabID of a tab, this function selects the right tab in the provided list control
		/// </summary>
		/// <param name="tabID">tabID of the tab that needs to be selected</param>
		private void SelectPage (int tabID)
		{
			for(int i = 0 ; i < tabList.Items.Count ; i++)
			{
				if(((PageItem)portalPages[i]).ID == tabID)
				{
					if(tabList.SelectedItem != null) tabList.SelectedItem.Selected = false;
					tabList.Items[i].Selected = true;
					return;
				}
			}
			return;
		}

        /// <summary>
        /// GuidID
        /// </summary>
        public override Guid GuidID 
        {
            get
            {
				return new Guid("{1C575D94-70FC-4A83-80C3-2087F726CBB3}");
			}
        }

		# region Install / Uninstall Implementation
		public override void Install(IDictionary stateSaver)
		{
			string currentScriptName = Server.MapPath(this.TemplateSourceDirectory + "/Install.sql");
			ArrayList errors = DBHelper.ExecuteScript(currentScriptName, true);
			if (errors.Count > 0)
			{
				// Call rollback
				throw new Exception("Error occurred:" + errors[0].ToString());
			}
		}

		public override void Uninstall(IDictionary stateSaver)
		{
			//Cannot be uninstalled
			throw new Exception("This is an essential module that can be unistalled");
		}
		#endregion

		#region Web Form Designer generated code
		/// <summary>
		/// Raises OnInit Event
		/// </summary>
		/// <param name="e"></param>
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}

        private void InitializeComponent() 
        {
			this.upBtn.Click += new ImageClickEventHandler(this.UpDown_Click);
			this.downBtn.Click += new ImageClickEventHandler(this.UpDown_Click);
			this.addBtn.Click += new EventHandler(this.AddPage_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

    }
}
