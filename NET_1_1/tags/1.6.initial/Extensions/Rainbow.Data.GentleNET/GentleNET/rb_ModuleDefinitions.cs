
		
//========================================================================
// This file was generated using the MyGeneration tool in combination
// with the Gentle.NET Business Entity template, $Rev: 44 $
//========================================================================
using System;
using System.Collections;
using Gentle.Framework;

namespace Rainbow.Data.GentleNET
{
	#region rb_ModuleDefinitions
	/// <summary>
	/// This object represents the properties and methods of a Employee.
	/// </summary>
	[Serializable]
	[TableName("rb_ModuleDefinitions")]
	public class rb_ModuleDefinitions : Persistent
	{
		#region Members
		private bool _changed = false;
		private static bool invalidatedListAll = true;
		private static ArrayList listAllCache = null;
		[TableColumn("ModuleDefID", NotNull=true), PrimaryKey(AutoGenerated=true)]
		protected int moduleDefID;
		[TableColumn("PortalID", NotNull=true)]
		protected int portalID;
		[TableColumn("GeneralModDefID", NotNull=true), ForeignKey("rb_GeneralModuleDefinitions", "GeneralModDefID")]
		protected Guid generalModDefID;
		#endregion
			

		#region Constructors
	

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public rb_ModuleDefinitions( 
				int PortalID, 
				Guid GeneralModDefID)
		{
			_changed = true;
			invalidatedListAll = true;
			portalID = PortalID;
			generalModDefID = GeneralModDefID;
		}

			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public rb_ModuleDefinitions( 
				int ModuleDefID, 
				int PortalID, 
				Guid GeneralModDefID)
		{
			moduleDefID = ModuleDefID;
			portalID = PortalID;
			generalModDefID = GeneralModDefID;
		}

		#endregion

		#region Public Properties
		
		public bool Changed
		{ get { return _changed; } }
		
		public int ModuleDefID
		{
			get{ return moduleDefID; }
		}
		
		public int PortalID
		{
			get{ return portalID; }
			set{ _changed |= portalID != value; portalID = value; invalidatedListAll =  _changed;}
		}
		
		public Guid GeneralModDefID
		{
			get{ return generalModDefID; }
			set{ _changed |= generalModDefID != value; generalModDefID = value; invalidatedListAll =  _changed;}
		}
		
	
		// generate a static property to retrieve all instances of a class that are stored in the database
		static public IList ListAll
		{
			get 
			{ 
				if( listAllCache == null || invalidatedListAll )
				{
					listAllCache = Broker.RetrieveList( typeof(rb_ModuleDefinitions) ) as ArrayList;
					invalidatedListAll = false;
				}
				return listAllCache;
			}
		}
		
		#endregion

		#region Debug Properties
		/// <summary>
		/// Generated only when genDebug flag enabled in MyGeneration template UI
		/// Returns number of items in internal cache
		/// </summary>
		public static int CacheCount
		{
			get{ return listAllCache == null ? 0 : listAllCache.Count;}
		}
		
		#endregion

		#region Storage and retrieval
	   
		public static rb_ModuleDefinitions Retrieve(int id )
		{
	   
			// Return null if id is smaller than seed and/or increment for autokey
			if(id<0) 
			{
				return null;
			}
		  
			Key key = new Key( typeof(rb_ModuleDefinitions), true, "ModuleDefID", id );
			return Broker.RetrieveInstance( typeof(rb_ModuleDefinitions), key ) as rb_ModuleDefinitions;
		}

		//Gentle.NET Business Entity script: Generation of complex retrieve function (multiple primary keys) is not implemented yet.

		public override void Persist()
		{
			if( Changed || !IsPersisted )
			{
				base.Persist();
				_changed=false;
			}
		}

		public override void Remove()
		{
			base.Remove();
			invalidatedListAll = true;
		}
		#endregion

		#region Relations
		// List of primary keys for this class table
		// Key: ModuleDefID
		// List of foreign keys for this class table
		// Key: FK_rb_Modules_rb_ModuleDefinitions primary table: rb_ModuleDefinitions primary column: ModuleDefID foreign column: ModuleDefID foreign table: rb_Modules
		// Key: FK_rb_ModuleDefinitions_rb_GeneralModuleDefinitions primary table: rb_GeneralModuleDefinitions primary column: GeneralModDefID foreign column: GeneralModDefID foreign table: rb_ModuleDefinitions
		// List of selected relation tables for this database
		// Table: rb_Announcements
		// Table: rb_Announcements_st
		// Table: rb_Articles
		// Table: rb_Blacklist
		// Table: rb_BlogComments
		// Table: rb_Blogs
		// Table: rb_BlogStats
		// Table: rb_BookList
		// Table: rb_ComponentModule
		// Table: rb_Contacts
		// Table: rb_Contacts_st
		// Table: rb_ContentManager
		// Table: rb_Countries
		// Table: rb_Cultures
		// Table: rb_Discussion
		// Table: rb_Documents
		// Table: rb_Documents_st
		// Table: rb_EnhancedHtml
		// Table: rb_EnhancedHtml_st
		// Table: rb_EnhancedLinks
		// Table: rb_EnhancedLinks_st
		// Table: rb_Events
		// Table: rb_Events_st
		// Table: rb_FAQs
		// Table: rb_GeneralModuleDefinitions
		// Table: rb_HtmlText
		// Table: rb_HtmlText_st
		// Table: rb_Links
		// Table: rb_Links_st
		// Table: rb_Localize
		// Table: rb_Milestones
		// Table: rb_Milestones_st
		// Table: rb_ModuleDefinitions
		// Table: rb_Modules
		// Table: rb_ModuleSettings
		// Table: rb_Monitoring
		// Table: rb_Pictures
		// Table: rb_Pictures_st
		// Table: rb_Portals
		// Table: rb_PortalSettings
		// Table: rb_Roles
		// Table: rb_SolutionModuleDefinitions
		// Table: rb_Solutions
		// Table: rb_States
		// Table: rb_SurveyAnswers
		// Table: rb_SurveyOptions
		// Table: rb_SurveyQuestions
		// Table: rb_Surveys
		// Table: rb_Tabs
		// Table: rb_TabSettings
		// Table: rb_Tasks
		// Table: rb_UserDefinedData
		// Table: rb_UserDefinedFields
		// Table: rb_UserDefinedRows
		// Table: rb_UserDesktop
		// Table: rb_UserRoles
		// Table: rb_Users
		// Table: rb_Versions

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Announcements", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_AnnouncementsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Announcements), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Announcements_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_Announcements_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Announcements_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Articles", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_ArticlesUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Articles), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_BookList", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_BookListUsingrb_Modules()
		{
			return new GentleList( typeof(rb_BookList), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_ComponentModule", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_ComponentModuleUsingrb_Modules()
		{
			return new GentleList( typeof(rb_ComponentModule), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Contacts", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_ContactsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Contacts), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Contacts_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_Contacts_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Contacts_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Discussion", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_DiscussionUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Discussion), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Documents", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_DocumentsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Documents), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Documents_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_Documents_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Documents_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_EnhancedHtml", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_EnhancedHtmlUsingrb_Modules()
		{
			return new GentleList( typeof(rb_EnhancedHtml), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_EnhancedHtml_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_EnhancedHtml_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_EnhancedHtml_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_EnhancedLinks", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_EnhancedLinksUsingrb_Modules()
		{
			return new GentleList( typeof(rb_EnhancedLinks), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_EnhancedLinks_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_EnhancedLinks_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_EnhancedLinks_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Events", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_EventsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Events), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Events_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_Events_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Events_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_HtmlText", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_HtmlTextUsingrb_Modules()
		{
			return new GentleList( typeof(rb_HtmlText), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_HtmlText_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_HtmlText_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_HtmlText_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Links", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_LinksUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Links), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Links_st", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_Links_stUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Links_st), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Milestones", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_MilestonesUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Milestones), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_ModuleSettings", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_ModuleSettingsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_ModuleSettings), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Pictures", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_PicturesUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Pictures), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Surveys", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_SurveysUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Surveys), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Tasks", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_TasksUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Tasks), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_UserDefinedFields", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_UserDefinedFieldsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_UserDefinedFields), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_UserDefinedRows", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_UserDefinedRowsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_UserDefinedRows), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Tabs", using relation table "rb_Modules"
		/// </summary>
		public IList referencedrb_TabsUsingrb_Modules()
		{
			return new GentleList( typeof(rb_Tabs), this, typeof(rb_Modules));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Modules", using relation table "rb_ModuleDefinitions"
		/// </summary>
		public IList referencedrb_ModulesUsingrb_ModuleDefinitions()
		{
			return new GentleList( typeof(rb_Modules), this, typeof(rb_ModuleDefinitions));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_GeneralModuleDefinitions", using relation table "rb_ModuleDefinitions"
		/// </summary>
		public IList referencedrb_GeneralModuleDefinitionsUsingrb_ModuleDefinitions()
		{
			return new GentleList( typeof(rb_GeneralModuleDefinitions), this, typeof(rb_ModuleDefinitions));
		}
		#endregion

		#region ManualCode
/***PRESERVE_BEGIN MANUAL_CODE***//***PRESERVE_END MANUAL_CODE***/
		#endregion
	}

}
#endregion

