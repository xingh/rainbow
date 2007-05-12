
		
//========================================================================
// This file was generated using the MyGeneration tool in combination
// with the Gentle.NET Business Entity template, $Rev: 44 $
//========================================================================
using System;
using System.Collections;
using Gentle.Framework;

namespace Rainbow.Data.GentleNET
{
	#region rb_Tasks
	/// <summary>
	/// This object represents the properties and methods of a Employee.
	/// </summary>
	[Serializable]
	[TableName("rb_Tasks")]
	public class rb_Tasks : Persistent
	{
		#region Members
		private bool _changed = false;
		private static bool invalidatedListAll = true;
		private static ArrayList listAllCache = null;
		[TableColumn("ItemID", NotNull=true), PrimaryKey(AutoGenerated=true)]
		protected int itemID;
		[TableColumn("ModuleID", NotNull=true), ForeignKey("rb_Modules", "ModuleID")]
		protected int moduleID;
		[TableColumn("CreatedByUser")]
		protected string createdByUser;
		[TableColumn("CreatedDate")]
		protected DateTime createdDate;
		[TableColumn("ModifiedByUser")]
		protected string modifiedByUser;
		[TableColumn("ModifiedDate")]
		protected DateTime modifiedDate;
		[TableColumn("AssignedTo")]
		protected string assignedTo;
		[TableColumn("Title", NotNull=true)]
		protected string title;
		[TableColumn("Description")]
		protected string description;
		[TableColumn("Status")]
		protected string status;
		[TableColumn("Priority")]
		protected string priority;
		[TableColumn("PercentComplete")]
		protected int percentComplete;
		[TableColumn("StartDate")]
		protected DateTime startDate;
		[TableColumn("DueDate")]
		protected DateTime dueDate;
		#endregion
			

		#region Constructors
	

		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public rb_Tasks( 
				int ModuleID, 
				string Title)
		{
			_changed = true;
			invalidatedListAll = true;
			itemID = 0;
			moduleID = ModuleID;
			title = Title;
		}


		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public rb_Tasks( 
				int ModuleID, 
				string CreatedByUser, 
				DateTime CreatedDate, 
				string ModifiedByUser, 
				DateTime ModifiedDate, 
				string AssignedTo, 
				string Title, 
				string Description, 
				string Status, 
				string Priority, 
				int PercentComplete, 
				DateTime StartDate, 
				DateTime DueDate)
		{
			_changed = true;
			invalidatedListAll = true;
			moduleID = ModuleID;
			createdByUser = CreatedByUser;
			createdDate = CreatedDate;
			modifiedByUser = ModifiedByUser;
			modifiedDate = ModifiedDate;
			assignedTo = AssignedTo;
			title = Title;
			description = Description;
			status = Status;
			priority = Priority;
			percentComplete = PercentComplete;
			startDate = StartDate;
			dueDate = DueDate;
		}

			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public rb_Tasks( 
				int ItemID, 
				int ModuleID, 
				string CreatedByUser, 
				DateTime CreatedDate, 
				string ModifiedByUser, 
				DateTime ModifiedDate, 
				string AssignedTo, 
				string Title, 
				string Description, 
				string Status, 
				string Priority, 
				int PercentComplete, 
				DateTime StartDate, 
				DateTime DueDate)
		{
			itemID = ItemID;
			moduleID = ModuleID;
			createdByUser = CreatedByUser;
			createdDate = CreatedDate;
			modifiedByUser = ModifiedByUser;
			modifiedDate = ModifiedDate;
			assignedTo = AssignedTo;
			title = Title;
			description = Description;
			status = Status;
			priority = Priority;
			percentComplete = PercentComplete;
			startDate = StartDate;
			dueDate = DueDate;
		}

		#endregion

		#region Public Properties
		
		public bool Changed
		{ get { return _changed; } }
		
		public int ItemID
		{
			get{ return itemID; }
		}
		
		public int ModuleID
		{
			get{ return moduleID; }
			set{ _changed |= moduleID != value; moduleID = value; invalidatedListAll =  _changed;}
		}
		
		public string CreatedByUser
		{
			get{ return createdByUser != null ?createdByUser.TrimEnd() : null; }
			set{ _changed |= createdByUser != value; createdByUser = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime CreatedDate
		{
			get{ return createdDate; }
			set{ _changed |= createdDate != value; createdDate = value; invalidatedListAll =  _changed;}
		}
		
		public string ModifiedByUser
		{
			get{ return modifiedByUser != null ?modifiedByUser.TrimEnd() : null; }
			set{ _changed |= modifiedByUser != value; modifiedByUser = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime ModifiedDate
		{
			get{ return modifiedDate; }
			set{ _changed |= modifiedDate != value; modifiedDate = value; invalidatedListAll =  _changed;}
		}
		
		public string AssignedTo
		{
			get{ return assignedTo != null ?assignedTo.TrimEnd() : null; }
			set{ _changed |= assignedTo != value; assignedTo = value; invalidatedListAll =  _changed;}
		}
		
		public string Title
		{
			get{ return title != null ?title.TrimEnd() : null; }
			set{ _changed |= title != value; title = value; invalidatedListAll =  _changed;}
		}
		
		public string Description
		{
			get{ return description != null ?description.TrimEnd() : null; }
			set{ _changed |= description != value; description = value; invalidatedListAll =  _changed;}
		}
		
		public string Status
		{
			get{ return status != null ?status.TrimEnd() : null; }
			set{ _changed |= status != value; status = value; invalidatedListAll =  _changed;}
		}
		
		public string Priority
		{
			get{ return priority != null ?priority.TrimEnd() : null; }
			set{ _changed |= priority != value; priority = value; invalidatedListAll =  _changed;}
		}
		
		public int PercentComplete
		{
			get{ return percentComplete; }
			set{ _changed |= percentComplete != value; percentComplete = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime StartDate
		{
			get{ return startDate; }
			set{ _changed |= startDate != value; startDate = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime DueDate
		{
			get{ return dueDate; }
			set{ _changed |= dueDate != value; dueDate = value; invalidatedListAll =  _changed;}
		}
		
	
		// generate a static property to retrieve all instances of a class that are stored in the database
		static public IList ListAll
		{
			get 
			{ 
				if( listAllCache == null || invalidatedListAll )
				{
					listAllCache = Broker.RetrieveList( typeof(rb_Tasks) ) as ArrayList;
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
	   
		public static rb_Tasks Retrieve(int id )
		{
	   
			// Return null if id is smaller than seed and/or increment for autokey
			if(id<0) 
			{
				return null;
			}
		  
			Key key = new Key( typeof(rb_Tasks), true, "ItemID", id );
			return Broker.RetrieveInstance( typeof(rb_Tasks), key ) as rb_Tasks;
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
		// Key: FK_Tasks_Modules primary table: rb_Modules primary column: ModuleID foreign column: ModuleID foreign table: rb_Tasks
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
		/// table "rb_Modules", using relation table "rb_Tasks"
		/// </summary>
		public IList referencedrb_Modules()
		{
			return new GentleList( typeof(rb_Modules), this, typeof(rb_Tasks));
		}
		#endregion

		#region ManualCode
/***PRESERVE_BEGIN MANUAL_CODE***//***PRESERVE_END MANUAL_CODE***/
		#endregion
	}

}
#endregion

