
		
//========================================================================
// This file was generated using the MyGeneration tool in combination
// with the Gentle.NET Business Entity template, $Rev: 44 $
//========================================================================
using System;
using System.Collections;
using Gentle.Framework;

namespace Rainbow.Data.GentleNET
{
	#region rb_ContentManager
	/// <summary>
	/// This object represents the properties and methods of a Employee.
	/// </summary>
	[Serializable]
	[TableName("rb_ContentManager")]
	public class rb_ContentManager : Persistent
	{
		#region Members
		private bool _changed = false;
		private static bool invalidatedListAll = true;
		private static ArrayList listAllCache = null;
		[TableColumn("ItemID", NotNull=true), PrimaryKey(AutoGenerated=true)]
		protected int itemID;
		[TableColumn("GeneralModDefID", NotNull=true), ForeignKey("rb_GeneralModuleDefinitions", "GeneralModDefID")]
		protected Guid generalModDefID;
		[TableColumn("FriendlyName", NotNull=true)]
		protected string friendlyName;
		[TableColumn("SummarySproc", NotNull=true)]
		protected string summarySproc;
		[TableColumn("CopyItemSproc", NotNull=true)]
		protected string copyItemSproc;
		[TableColumn("MoveItemSproc", NotNull=true)]
		protected string moveItemSproc;
		[TableColumn("CopyAllSproc", NotNull=true)]
		protected string copyAllSproc;
		[TableColumn("DeleteItemSproc", NotNull=true)]
		protected string deleteItemSproc;
		#endregion
			

		#region Constructors
	

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public rb_ContentManager( 
				Guid GeneralModDefID, 
				string FriendlyName, 
				string SummarySproc, 
				string CopyItemSproc, 
				string MoveItemSproc, 
				string CopyAllSproc, 
				string DeleteItemSproc)
		{
			_changed = true;
			invalidatedListAll = true;
			generalModDefID = GeneralModDefID;
			friendlyName = FriendlyName;
			summarySproc = SummarySproc;
			copyItemSproc = CopyItemSproc;
			moveItemSproc = MoveItemSproc;
			copyAllSproc = CopyAllSproc;
			deleteItemSproc = DeleteItemSproc;
		}

			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public rb_ContentManager( 
				int ItemID, 
				Guid GeneralModDefID, 
				string FriendlyName, 
				string SummarySproc, 
				string CopyItemSproc, 
				string MoveItemSproc, 
				string CopyAllSproc, 
				string DeleteItemSproc)
		{
			itemID = ItemID;
			generalModDefID = GeneralModDefID;
			friendlyName = FriendlyName;
			summarySproc = SummarySproc;
			copyItemSproc = CopyItemSproc;
			moveItemSproc = MoveItemSproc;
			copyAllSproc = CopyAllSproc;
			deleteItemSproc = DeleteItemSproc;
		}

		#endregion

		#region Public Properties
		
		public bool Changed
		{ get { return _changed; } }
		
		public int ItemID
		{
			get{ return itemID; }
		}
		
		public Guid GeneralModDefID
		{
			get{ return generalModDefID; }
			set{ _changed |= generalModDefID != value; generalModDefID = value; invalidatedListAll =  _changed;}
		}
		
		public string FriendlyName
		{
			get{ return friendlyName != null ?friendlyName.TrimEnd() : null; }
			set{ _changed |= friendlyName != value; friendlyName = value; invalidatedListAll =  _changed;}
		}
		
		public string SummarySproc
		{
			get{ return summarySproc != null ?summarySproc.TrimEnd() : null; }
			set{ _changed |= summarySproc != value; summarySproc = value; invalidatedListAll =  _changed;}
		}
		
		public string CopyItemSproc
		{
			get{ return copyItemSproc != null ?copyItemSproc.TrimEnd() : null; }
			set{ _changed |= copyItemSproc != value; copyItemSproc = value; invalidatedListAll =  _changed;}
		}
		
		public string MoveItemSproc
		{
			get{ return moveItemSproc != null ?moveItemSproc.TrimEnd() : null; }
			set{ _changed |= moveItemSproc != value; moveItemSproc = value; invalidatedListAll =  _changed;}
		}
		
		public string CopyAllSproc
		{
			get{ return copyAllSproc != null ?copyAllSproc.TrimEnd() : null; }
			set{ _changed |= copyAllSproc != value; copyAllSproc = value; invalidatedListAll =  _changed;}
		}
		
		public string DeleteItemSproc
		{
			get{ return deleteItemSproc != null ?deleteItemSproc.TrimEnd() : null; }
			set{ _changed |= deleteItemSproc != value; deleteItemSproc = value; invalidatedListAll =  _changed;}
		}
		
	
		// generate a static property to retrieve all instances of a class that are stored in the database
		static public IList ListAll
		{
			get 
			{ 
				if( listAllCache == null || invalidatedListAll )
				{
					listAllCache = Broker.RetrieveList( typeof(rb_ContentManager) ) as ArrayList;
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
	   
		public static rb_ContentManager Retrieve(int id )
		{
	   
			// Return null if id is smaller than seed and/or increment for autokey
			if(id<0) 
			{
				return null;
			}
		  
			Key key = new Key( typeof(rb_ContentManager), true, "ItemID", id );
			return Broker.RetrieveInstance( typeof(rb_ContentManager), key ) as rb_ContentManager;
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
		// Key: ItemID
		// List of foreign keys for this class table
		// Key: FK_rbContentManager_GenModDefs primary table: rb_GeneralModuleDefinitions primary column: GeneralModDefID foreign column: GeneralModDefID foreign table: rb_ContentManager
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
		/// table "rb_GeneralModuleDefinitions", using relation table "rb_ContentManager"
		/// </summary>
		public IList referencedrb_GeneralModuleDefinitions()
		{
			return new GentleList( typeof(rb_GeneralModuleDefinitions), this, typeof(rb_ContentManager));
		}
		#endregion

		#region ManualCode
/***PRESERVE_BEGIN MANUAL_CODE***//***PRESERVE_END MANUAL_CODE***/
		#endregion
	}

}
#endregion


