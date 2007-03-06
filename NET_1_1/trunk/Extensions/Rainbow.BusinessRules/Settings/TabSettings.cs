//This include provides to get CurrentUserInterface language from the current thread.
//WLF: using Rainbow.DesktopModules;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using Esperantus.WebControls;
using Rainbow.BusinessRules;
using Rainbow.Design;
using Rainbow.UI.DataTypes;
using Path = Rainbow.Settings.Path;

namespace Rainbow.Configuration
{
	/// <summary>
	/// TabSettings Class encapsulates the detailed settings 
	/// for a specific Tab in the Portal
	/// </summary>
	public class TabSettings
	{
		private string authorizedRoles;

		/// <summary>
		///     
		/// </summary>
		public string AuthorizedRoles
		{
			get { return authorizedRoles; }
			set { authorizedRoles = value; }
		}


		private string mobileTabName;

		/// <summary>
		///     
		/// </summary>
		public string MobileTabName
		{
			get { return mobileTabName; }
			set { mobileTabName = value; }
		}


		private ArrayList modules = new ArrayList();

		/// <summary>
		///     
		/// </summary>
		public ArrayList Modules
		{
			get { return modules; }
			set { modules = value; }
		}


		private int parentTabID;

		/// <summary>
		///     
		/// </summary>
		public int ParentTabID
		{
			get { return parentTabID; }
			set { parentTabID = value; }
		}


		private bool showMobile;

		/// <summary>
		///     
		/// </summary>
		public bool ShowMobile
		{
			get { return showMobile; }
			set { showMobile = value; }
		}


		private int tabID;

		/// <summary>
		///     
		/// </summary>
		public int TabID
		{
			get { return tabID; }
			set { tabID = value; }
		}


		private string tabLayout;

		/// <summary>
		///     
		/// </summary>
		public string TabLayout
		{
			get { return tabLayout; }
			set { tabLayout = value; }
		}


		private int tabOrder;

		/// <summary>
		///     
		/// </summary>
		public int TabOrder
		{
			get { return tabOrder; }
			set { tabOrder = value; }
		}


		/// <summary>
		///     
		/// </summary>
		private PortalSettings _portalSettings;

		/// <summary>
		///     
		/// </summary>
		private Hashtable customSettings;

		/// <summary>
		///     
		/// </summary>
		private string m_tabName;

		// Jes1111
		//		public int			TemplateId;
		/// <remarks>
		/// thierry (tiptopweb)
		/// to have dropdown list for the themes and layout, we need the data path for the portal (for private theme and layout)
		/// we need the portalPath here for this use and it has to be set from the current portalSettings before getting the
		/// CustomSettings for a tab
		/// </remarks>
		private string portalPath = null;

		/// <summary>
		/// The TabSettings.GetTabCustomSettings Method returns a hashtable of
		/// custom Tab specific settings from the database. This method is
		/// used by Portals to access misc Tab settings.
		/// </summary>
		/// <param name="tabID"></param>
		/// <returns></returns>
		public Hashtable GetTabCustomSettings(int tabID)
		{
			Page page = new Page();
			return page.CustomSettings;

			#region deprecated

			//			Hashtable _baseSettings;
			//
			//			if (!CurrentCache.Exists(Key.TabSettings(tabID)))
			//			{
			//				_baseSettings = GetTabBaseSettings();
			//				// Get Settings for this Tab from the database
			//				Hashtable _settings = new Hashtable();
			//
			//				// Create Instance of Connection and Command Object
			//				using (SqlConnection myConnection = PortalSettings.SqlConnectionString)
			//				{
			//					using (SqlCommand myCommand = new SqlCommand("rb_GetTabCustomSettings", myConnection))
			//					{
			//						// Mark the Command as a SPROC
			//						myCommand.CommandType = CommandType.StoredProcedure;
			//						// Add Parameters to SPROC
			//						SqlParameter parameterTabID = new SqlParameter("@TabID", SqlDbType.Int, 4);
			//						parameterTabID.Value = tabID;
			//						myCommand.Parameters.Add(parameterTabID);
			//						// Execute the command
			//						myConnection.Open();
			//						SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			//
			//						try
			//						{
			//							while (dr.Read())
			//								_settings[dr["SettingName"].ToString()] = dr["SettingValue"].ToString();
			//						}
			//
			//						finally
			//						{
			//							dr.Close(); //by Manu, fixed bug 807858
			//							myConnection.Close();
			//						}
			//					}
			//				}
			//
			//				// Thierry (Tiptopweb)
			//				// TODO : put back the cache in GetTabBaseSettings() and reset values not found in the database
			//				foreach (string key in _baseSettings.Keys)
			//				{
			//					if (_settings[key] != null)
			//					{
			//						SettingItem s = ((SettingItem) _baseSettings[key]);
			//
			//						if (_settings[key].ToString() != string.Empty)
			//							s.Value = _settings[key].ToString();
			//					}
			//
			//					else //by Manu
			//						// Thierry (Tiptopweb), see the comment in Hashtable GetTabBaseSettings()
			//						// this is not resetting key not found in the database
			//					{
			//						SettingItem s = ((SettingItem) _baseSettings[key]);
			//						//s.Value = string.Empty; 3_aug_2004 Cory Isakson.  This line caused an error with booleans
			//					}
			//				}
			//				CurrentCache.Insert(Key.TabSettings(tabID), _baseSettings);
			//			}
			//
			//			else
			//				_baseSettings = (Hashtable) CurrentCache.Get(Key.TabSettings(tabID));
			//			return _baseSettings;

			#endregion
		}


		/// <summary>
		/// Read Current Tab subtabs
		/// </summary>
		/// <param name="tabID"></param>
		[Obsolete("Replace me and move to DAL")]
		public static SqlDataReader GetTabSettings(int tabID)
		{
			// Create Instance of Connection and Command Object
			using (SqlConnection myConnection = PortalSettings.SqlConnectionString)
			{
				using (SqlCommand myCommand = new SqlCommand("rb_GetTabSettings", myConnection))
				{
					// Mark the Command as a SPROC
					myCommand.CommandType = CommandType.StoredProcedure;
					//TabID passed type FIXED by Bill Anderson (reedtek)
					//see: http://sourceforge.net/tracker/index.php?func=detail&aid=813789&group_id=66837&atid=515929
					// Add Parameters to SPROC
					SqlParameter parameterTabID = new SqlParameter("@TabID", SqlDbType.Int);
					parameterTabID.Value = tabID;
					myCommand.Parameters.Add(parameterTabID);
					// The new paramater "PortalLanguage" has been added to sp rb_GetTabSettings  
					// Onur Esnaf
					SqlParameter parameterPortalLanguage = new SqlParameter("@PortalLanguage", SqlDbType.NVarChar, 12);
					parameterPortalLanguage.Value = Thread.CurrentThread.CurrentUICulture.Name;
					myCommand.Parameters.Add(parameterPortalLanguage);
					// Open the database connection and execute the command
					myConnection.Open();
					SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
					return dr;
				}
			}
		}

		/// <summary>
		/// Read Current Tab subtabs
		/// </summary>
		/// <param name="TabID"></param>
		/// <returns>TabsBox</returns>
		public static PagesBox GetTabSettingsTabsBox(int tabID)
		{
			// Create Instance of Connection and Command Object
			using (SqlConnection myConnection = PortalSettings.SqlConnectionString)
			{
				using (SqlCommand myCommand = new SqlCommand("rb_GetTabSettings", myConnection))
				{
					// Mark the Command as a SPROC
					myCommand.CommandType = CommandType.StoredProcedure;
					//TabID passed type FIXED by Bill Anderson (reedtek)
					//see: http://sourceforge.net/tracker/index.php?func=detail&aid=813789&group_id=66837&atid=515929
					// Add Parameters to SPROC
					SqlParameter parameterTabID = new SqlParameter("@TabID", SqlDbType.Int);
					parameterTabID.Value = tabID;
					myCommand.Parameters.Add(parameterTabID);
					// The new paramater "PortalLanguage" has been added to sp rb_GetTabSettings  
					// Onur Esnaf
					SqlParameter parameterPortalLanguage = new SqlParameter("@PortalLanguage", SqlDbType.NVarChar, 12);
					parameterPortalLanguage.Value = Thread.CurrentThread.CurrentUICulture.Name;
					myCommand.Parameters.Add(parameterPortalLanguage);
					// Open the database connection and execute the command
					myConnection.Open();

					using (SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						PagesBox pages = new PagesBox();

						try
						{
							while (result.Read())
							{
								TabStripDetails tabDetails = new TabStripDetails();
								tabDetails.TabID = (int) result["TabID"];
								Hashtable cts = new TabSettings().GetTabCustomSettings(tabDetails.TabID);
								tabDetails.TabImage = cts["CustomMenuImage"].ToString();
								tabDetails.ParentTabID = Int32.Parse("0" + result["ParentTabID"]);
								tabDetails.TabName = (string) result["TabName"];
								tabDetails.TabOrder = (int) result["TabOrder"];
								tabDetails.AuthorizedRoles = (string) result["AuthorizedRoles"];
								pages.Add(tabDetails);
							}
						}

						finally
						{
							result.Close(); //by Manu, fixed bug 807858
						}
						return pages;
					}
				}
			}
		}

		/// <summary>
		/// Update Tab Custom Settings
		/// </summary>
		/// <param name="tabID"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void UpdateTabSettings(int tabID, String key, String value)
		{
			// Create Instance of Connection and Command Object
			using (SqlConnection myConnection = PortalSettings.SqlConnectionString)
			{
				using (SqlCommand myCommand = new SqlCommand("rb_UpdateTabCustomSettings", myConnection))
				{
					// Mark the Command as a SPROC
					myCommand.CommandType = CommandType.StoredProcedure;
					// Add Parameters to SPROC            
					SqlParameter parameterTabID = new SqlParameter("@TabID", SqlDbType.Int, 4);
					parameterTabID.Value = tabID;
					myCommand.Parameters.Add(parameterTabID);
					SqlParameter parameterKey = new SqlParameter("@SettingName", SqlDbType.NVarChar, 50);
					parameterKey.Value = key;
					myCommand.Parameters.Add(parameterKey);
					SqlParameter parameterValue = new SqlParameter("@SettingValue", SqlDbType.NVarChar, 1500);
					parameterValue.Value = value;
					myCommand.Parameters.Add(parameterValue);
					myConnection.Open();

					try
					{
						myCommand.ExecuteNonQuery();
					}

					finally
					{
						myConnection.Close();
					}
				}
			}

			//Invalidate cache
			if (CurrentCache.Exists(Key.TabSettings(tabID)))
				CurrentCache.Remove(Key.TabSettings(tabID));
		}

		/// <summary>
		///     
		/// </summary>
		/// 
		/// <returns>
		///     A System.Collections.Hashtable value...
		/// </returns>
		private Hashtable GetImageMenu()
		{
			Hashtable imageMenuFiles;

			if (!CurrentCache.Exists(Key.ImageMenuList(portalSettings.CurrentLayout)))
			{
				imageMenuFiles = new Hashtable();
				imageMenuFiles.Add("-Default-", string.Empty);
				string menuDirectory = string.Empty;
				LayoutManager layoutManager = new LayoutManager(PortalPath);
				menuDirectory = Path.WebPathCombine(layoutManager.PortalLayoutPath, portalSettings.CurrentLayout);

				if (Directory.Exists(menuDirectory))
					menuDirectory = Path.WebPathCombine(menuDirectory, "menuimages");

				else
					menuDirectory = Path.WebPathCombine(LayoutManager.Path, portalSettings.CurrentLayout, "menuimages");

				if (Directory.Exists(menuDirectory))
				{
					FileInfo[] menuImages = (new DirectoryInfo(menuDirectory)).GetFiles("*.gif");

					foreach (FileInfo fi in menuImages)

					{
						if (fi.Name != "spacer.gif" && fi.Name != "icon_arrow.gif")
							imageMenuFiles.Add(fi.Name, fi.Name);
					}
				}
				CurrentCache.Insert(Key.ImageMenuList(portalSettings.CurrentLayout), imageMenuFiles, null);
			}

			else
				imageMenuFiles = (Hashtable) CurrentCache.Get(Key.ImageMenuList(portalSettings.CurrentLayout));
			return imageMenuFiles;
		}

		/// <summary>
		/// Changed by Thierry@tiptopweb.com.au
		/// tabSettings are different for custom page layout an theme, this cannot be static
		/// Added by john.mandia@whitelightsolutions.com
		/// Cache by Manu
		/// non static function, Thierry : this is necessary for page custom layout and themes
		/// </summary>
		/// 
		/// <returns>
		///     A System.Collections.Hashtable value...
		/// </returns>
		private Hashtable GetTabBaseSettings()
		{
			//Define base settings
			Hashtable _baseSettings = new Hashtable();
			int _groupOrderBase;
			SettingItemGroup _Group;

			#region Navigation Settings

			// 2_aug_2004 Cory Isakson
			_groupOrderBase = (int) SettingItemGroup.NAVIGATION_SETTINGS;
			_Group = SettingItemGroup.NAVIGATION_SETTINGS;
			SettingItem TabPlaceholder = new SettingItem(new BooleanDataType());
			TabPlaceholder.Group = _Group;
			TabPlaceholder.Order = _groupOrderBase;
			TabPlaceholder.Value = "False";
			TabPlaceholder.EnglishName = "Act as a Placeholder?";
			TabPlaceholder.Description = "Allows this tab to act as a navigation placeholder only.";
			_baseSettings.Add("TabPlaceholder", TabPlaceholder);
			SettingItem TabLink = new SettingItem(new StringDataType());
			TabLink.Group = _Group;
			TabLink.Value = string.Empty;
			TabLink.Order = _groupOrderBase + 1;
			TabLink.EnglishName = "Static Link URL";
			TabLink.Description = "Allows this tab to act as a navigation link to any URL.";
			_baseSettings.Add("TabLink", TabLink);

			#endregion

			#region Metadata Management

			_groupOrderBase = (int) SettingItemGroup.META_SETTINGS;
			_Group = SettingItemGroup.META_SETTINGS;
			SettingItem TabTitle = new SettingItem(new StringDataType());
			TabTitle.Group = _Group;
			TabTitle.EnglishName = "Tab / Page Title";
			TabTitle.Description = "Allows you to enter a title (Shows at the top of your browser) for this specific Tab / Page. Enter something here to override the default portal wide setting.";
			_baseSettings.Add("TabTitle", TabTitle);
			SettingItem TabUrlKeyword = new SettingItem(new StringDataType());
			TabUrlKeyword.Group = _Group;
			TabUrlKeyword.EnglishName = "A Keyword To Identify This Tab / Page";
			TabUrlKeyword.Description = "Allows you to specify a keyword that would appear in your url.";
			_baseSettings.Add("TabUrlKeyword", TabUrlKeyword);
			SettingItem UrlPageName = new SettingItem(new StringDataType());
			UrlPageName.Group = _Group;
			UrlPageName.EnglishName = "Url Page Name";
			UrlPageName.Description = "This setting allows you to specify a name for this tab that will show up in the url instead of default.aspx";
			_baseSettings.Add("UrlPageName", UrlPageName);
			SettingItem TabMetaKeyWords = new SettingItem(new StringDataType());
			TabMetaKeyWords.Group = _Group;
			TabMetaKeyWords.EnglishName = "Tab / Page Keywords";
			TabMetaKeyWords.Description = "This setting is to help with search engine optimisation. Enter 1-15 Default Keywords that represent what this Tab / Page is about.Enter something here to override the default portal wide setting.";
			_baseSettings.Add("TabMetaKeyWords", TabMetaKeyWords);
			SettingItem TabMetaDescription = new SettingItem(new StringDataType());
			TabMetaDescription.Group = _Group;
			TabMetaDescription.EnglishName = "Tab / Page Description";
			TabMetaDescription.Description = "This setting is to help with search engine optimisation. Enter a description (Not too long though. 1 paragraph is enough) that describes this particular Tab / Page. Enter something here to override the default portal wide setting.";
			_baseSettings.Add("TabMetaDescription", TabMetaDescription);
			SettingItem TabMetaEncoding = new SettingItem(new StringDataType());
			TabMetaEncoding.Group = _Group;
			TabMetaEncoding.EnglishName = "Tab / Page Encoding";
			TabMetaEncoding.Description = "Every time your browser returns a page it looks to see what format it is retrieving. This allows you to specify the content type for this particular Tab / Page. Enter something here to override the default portal wide setting.";
			_baseSettings.Add("TabMetaEncoding", TabMetaEncoding);
			SettingItem TabMetaOther = new SettingItem(new StringDataType());
			TabMetaOther.Group = _Group;
			TabMetaOther.EnglishName = "Additional Meta Tag Entries";
			TabMetaOther.Description = "This setting allows you to enter new tags into this Tab / Page's HEAD Tag. Enter something here to override the default portal wide setting.";
			_baseSettings.Add("TabMetaOther", TabMetaOther);
			SettingItem TabKeyPhrase = new SettingItem(new StringDataType());
			TabKeyPhrase.Group = _Group;
			TabKeyPhrase.EnglishName = "Tab / Page Keyphrase";
			TabKeyPhrase.Description = "This setting can be used by a module or by a control. It allows you to define a message/phrase for this particular Tab / Page This can be used for search engine optimisation. Enter something here to override the default portal wide setting.";
			_baseSettings.Add("TabKeyPhrase", TabKeyPhrase);

			#endregion

			#region Layout and Theme

			// changed Thierry (Tiptopweb) : have a dropdown menu to select layout and themes
			_groupOrderBase = (int) SettingItemGroup.THEME_LAYOUT_SETTINGS;
			_Group = SettingItemGroup.THEME_LAYOUT_SETTINGS;
			// get the list of available layouts
			// changed: Jes1111 - 2004-08-06
			ArrayList layoutsList = new ArrayList(new LayoutManager(portalSettings.PortalPath).GetLayouts());
			LayoutItem _noCustomLayout = new LayoutItem();
			_noCustomLayout.Name = string.Empty;
			layoutsList.Insert(0, _noCustomLayout);
			// get the list of available themes
			// changed: Jes1111 - 2004-08-06
			ArrayList themesList = new ArrayList(new ThemeManager(portalSettings.PortalPath).GetThemes());
			ThemeItem _noCustomTheme = new ThemeItem();
			_noCustomTheme.Name = string.Empty;
			themesList.Insert(0, _noCustomTheme);
			// changed: Jes1111 - 2004-08-06
			SettingItem CustomLayout = new SettingItem(new CustomListDataType(layoutsList, "Name", "Name"));
			CustomLayout.Group = _Group;
			CustomLayout.Order = _groupOrderBase + 11;
			CustomLayout.EnglishName = "Custom Layout";
			CustomLayout.Description = "Set a custom layout for this tab only";
			_baseSettings.Add("CustomLayout", CustomLayout);
			//SettingItem CustomTheme = new SettingItem(new StringDataType());
			// changed: Jes1111 - 2004-08-06
			SettingItem CustomTheme = new SettingItem(new CustomListDataType(themesList, "Name", "Name"));
			CustomTheme.Group = _Group;
			CustomTheme.Order = _groupOrderBase + 12;
			CustomTheme.EnglishName = "Custom Theme";
			CustomTheme.Description = "Set a custom theme for the modules in this tab only";
			_baseSettings.Add("CustomTheme", CustomTheme);
			//SettingItem CustomThemeAlt = new SettingItem(new StringDataType());
			// changed: Jes1111 - 2004-08-06
			SettingItem CustomThemeAlt = new SettingItem(new CustomListDataType(themesList, "Name", "Name"));
			CustomThemeAlt.Group = _Group;
			CustomThemeAlt.Order = _groupOrderBase + 13;
			CustomThemeAlt.EnglishName = "Custom Alt Theme";
			CustomThemeAlt.Description = "Set a custom alternate theme for the modules in this tab only";
			_baseSettings.Add("CustomThemeAlt", CustomThemeAlt);
			SettingItem CustomMenuImage = new SettingItem(new CustomListDataType(GetImageMenu(), "Key", "Value"));
			CustomMenuImage.Group = _Group;
			CustomMenuImage.Order = _groupOrderBase + 14;
			CustomMenuImage.EnglishName = "Custom Image Menu";
			CustomMenuImage.Description = "Set a custom menu image for this tab";
			_baseSettings.Add("CustomMenuImage", CustomMenuImage);

			#endregion

			#region Language/Culture Management

			_groupOrderBase = (int) SettingItemGroup.CULTURE_SETTINGS;
			_Group = SettingItemGroup.CULTURE_SETTINGS;
			CultureInfo[] cultureList = LanguageSwitcher.GetLanguageList(true);
			//Localized tab title
			int counter = _groupOrderBase + 11;

			foreach (CultureInfo c in cultureList)
			{
				//Ignore invariant
				if (c != CultureInfo.InvariantCulture && !_baseSettings.ContainsKey(c.Name))
				{
					SettingItem LocalizedTabKeyPhrase = new SettingItem(new StringDataType());
					LocalizedTabKeyPhrase.Order = counter;
					LocalizedTabKeyPhrase.Group = _Group;
					LocalizedTabKeyPhrase.EnglishName = "Tab Key Phrase (" + c.Name + ")";
					LocalizedTabKeyPhrase.Description = "Key Phrase this Tab/Page for " + c.EnglishName + " culture.";
					_baseSettings.Add("TabKeyPhrase_" + c.Name, LocalizedTabKeyPhrase);
					SettingItem LocalizedTitle = new SettingItem(new StringDataType());
					LocalizedTitle.Order = counter;
					LocalizedTitle.Group = _Group;
					LocalizedTitle.EnglishName = "Title (" + c.Name + ")";
					LocalizedTitle.Description = "Set title for " + c.EnglishName + " culture.";
					_baseSettings.Add(c.Name, LocalizedTitle);
					counter++;
				}
			}

			#endregion

			return _baseSettings;
		}

		/// <summary>
		/// Tab Settings For Search Engines
		/// </summary>
		public Hashtable CustomSettings
		{
			get
			{
				if (customSettings == null)
					customSettings = GetTabCustomSettings(TabID);
				return customSettings;
			}
		}

		/// <summary>
		///     
		/// </summary>
		/// <value>
		///     <para>
		///         
		///     </para>
		/// </value>
		/// <remarks>
		///     
		/// </remarks>
		public string PortalPath
		{
			set
			{
				portalPath = value;

				if (!portalPath.EndsWith("/")) portalPath += "/";
			}
			get { return portalPath; }
		}

		/// <summary>
		/// Stores current portal settings 
		/// </summary>
		public PortalSettings portalSettings
		{
			get
			{
				if (_portalSettings == null)
				{
					// Obtain PortalSettings from Current Context
					if (HttpContext.Current != null)
						_portalSettings = (PortalSettings) HttpContext.Current.Items["PortalSettings"];
				}
				return _portalSettings;
			}
			set { _portalSettings = value; }
		}

		/// <summary>
		///     
		/// </summary>
		/// <value>
		///     <para>
		///         
		///     </para>
		/// </value>
		/// <remarks>
		///     
		/// </remarks>
		public string TabName
		{
			get { return m_tabName; }
			set { m_tabName = value; }
		}
	}
}