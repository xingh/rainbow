
		
//========================================================================
// This file was generated using the MyGeneration tool in combination
// with the Gentle.NET Business Entity template, $Rev: 44 $
//========================================================================
using System;
using System.Collections;
using Gentle.Framework;

namespace Rainbow.Data.GentleNET
{
	#region rb_Users
	/// <summary>
	/// This object represents the properties and methods of a Employee.
	/// </summary>
	[Serializable]
	[TableName("rb_Users")]
	public class rb_Users : Persistent
	{
		#region Members
		private bool _changed = false;
		private static bool invalidatedListAll = true;
		private static ArrayList listAllCache = null;
		[TableColumn("UserID", NotNull=true), PrimaryKey(AutoGenerated=true)]
		protected int userID;
		[TableColumn("PortalID", NotNull=true), ForeignKey("rb_Portals", "PortalID")]
		protected int portalID;
		[TableColumn("Name", NotNull=true)]
		protected string name;
		[TableColumn("Company")]
		protected string company;
		[TableColumn("Address")]
		protected string address;
		[TableColumn("City")]
		protected string city;
		[TableColumn("Zip")]
		protected string zip;
		[TableColumn("CountryID"), ForeignKey("rb_Countries", "CountryID")]
		protected string countryID;
		[TableColumn("StateID"), ForeignKey("rb_States", "StateID")]
		protected int stateID;
		[TableColumn("PIva")]
		protected string pIva;
		[TableColumn("CFiscale")]
		protected string cFiscale;
		[TableColumn("Phone")]
		protected string phone;
		[TableColumn("Fax")]
		protected string fax;
		[TableColumn("Password")]
		protected string password;
		[TableColumn("Email", NotNull=true)]
		protected string email;
		[TableColumn("SendNewsletter")]
		protected bool sendNewsletter;
		[TableColumn("MailChecked")]
		protected byte mailChecked;
		[TableColumn("LastSend")]
		protected DateTime lastSend;
		[TableColumn("user_last_visit", NotNull=true)]
		protected DateTime user_last_visit;
		[TableColumn("user_current_visit", NotNull=true)]
		protected DateTime user_current_visit;
		#endregion
			

		#region Constructors
	

		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public rb_Users( 
				int PortalID, 
				string Name, 
				string Email, 
				DateTime User_last_visit, 
				DateTime User_current_visit)
		{
			_changed = true;
			invalidatedListAll = true;
			userID = 0;
			portalID = PortalID;
			name = Name;
			email = Email;
			user_last_visit = User_last_visit;
			user_current_visit = User_current_visit;
		}


		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public rb_Users( 
				int PortalID, 
				string Name, 
				string Company, 
				string Address, 
				string City, 
				string Zip, 
				string CountryID, 
				int StateID, 
				string PIva, 
				string CFiscale, 
				string Phone, 
				string Fax, 
				string Password, 
				string Email, 
				bool SendNewsletter, 
				byte MailChecked, 
				DateTime LastSend, 
				DateTime User_last_visit, 
				DateTime User_current_visit)
		{
			_changed = true;
			invalidatedListAll = true;
			portalID = PortalID;
			name = Name;
			company = Company;
			address = Address;
			city = City;
			zip = Zip;
			countryID = CountryID;
			stateID = StateID;
			pIva = PIva;
			cFiscale = CFiscale;
			phone = Phone;
			fax = Fax;
			password = Password;
			email = Email;
			sendNewsletter = SendNewsletter;
			mailChecked = MailChecked;
			lastSend = LastSend;
			user_last_visit = User_last_visit;
			user_current_visit = User_current_visit;
		}

			
		/// <summary> 
		/// Create an object from an existing row of data. This will be used by Gentle to 
		/// construct objects from retrieved rows. 
		/// </summary> 
		public rb_Users( 
				int UserID, 
				int PortalID, 
				string Name, 
				string Company, 
				string Address, 
				string City, 
				string Zip, 
				string CountryID, 
				int StateID, 
				string PIva, 
				string CFiscale, 
				string Phone, 
				string Fax, 
				string Password, 
				string Email, 
				bool SendNewsletter, 
				byte MailChecked, 
				DateTime LastSend, 
				DateTime User_last_visit, 
				DateTime User_current_visit)
		{
			userID = UserID;
			portalID = PortalID;
			name = Name;
			company = Company;
			address = Address;
			city = City;
			zip = Zip;
			countryID = CountryID;
			stateID = StateID;
			pIva = PIva;
			cFiscale = CFiscale;
			phone = Phone;
			fax = Fax;
			password = Password;
			email = Email;
			sendNewsletter = SendNewsletter;
			mailChecked = MailChecked;
			lastSend = LastSend;
			user_last_visit = User_last_visit;
			user_current_visit = User_current_visit;
		}

		#endregion

		#region Public Properties
		
		public bool Changed
		{ get { return _changed; } }
		
		public int UserID
		{
			get{ return userID; }
		}
		
		public int PortalID
		{
			get{ return portalID; }
			set{ _changed |= portalID != value; portalID = value; invalidatedListAll =  _changed;}
		}
		
		public string Name
		{
			get{ return name != null ?name.TrimEnd() : null; }
			set{ _changed |= name != value; name = value; invalidatedListAll =  _changed;}
		}
		
		public string Company
		{
			get{ return company != null ?company.TrimEnd() : null; }
			set{ _changed |= company != value; company = value; invalidatedListAll =  _changed;}
		}
		
		public string Address
		{
			get{ return address != null ?address.TrimEnd() : null; }
			set{ _changed |= address != value; address = value; invalidatedListAll =  _changed;}
		}
		
		public string City
		{
			get{ return city != null ?city.TrimEnd() : null; }
			set{ _changed |= city != value; city = value; invalidatedListAll =  _changed;}
		}
		
		public string Zip
		{
			get{ return zip != null ?zip.TrimEnd() : null; }
			set{ _changed |= zip != value; zip = value; invalidatedListAll =  _changed;}
		}
		
		public string CountryID
		{
			get{ return countryID != null ?countryID.TrimEnd() : null; }
			set{ _changed |= countryID != value; countryID = value; invalidatedListAll =  _changed;}
		}
		
		public int StateID
		{
			get{ return stateID; }
			set{ _changed |= stateID != value; stateID = value; invalidatedListAll =  _changed;}
		}
		
		public string PIva
		{
			get{ return pIva != null ?pIva.TrimEnd() : null; }
			set{ _changed |= pIva != value; pIva = value; invalidatedListAll =  _changed;}
		}
		
		public string CFiscale
		{
			get{ return cFiscale != null ?cFiscale.TrimEnd() : null; }
			set{ _changed |= cFiscale != value; cFiscale = value; invalidatedListAll =  _changed;}
		}
		
		public string Phone
		{
			get{ return phone != null ?phone.TrimEnd() : null; }
			set{ _changed |= phone != value; phone = value; invalidatedListAll =  _changed;}
		}
		
		public string Fax
		{
			get{ return fax != null ?fax.TrimEnd() : null; }
			set{ _changed |= fax != value; fax = value; invalidatedListAll =  _changed;}
		}
		
		public string Password
		{
			get{ return password != null ?password.TrimEnd() : null; }
			set{ _changed |= password != value; password = value; invalidatedListAll =  _changed;}
		}
		
		public string Email
		{
			get{ return email != null ?email.TrimEnd() : null; }
			set{ _changed |= email != value; email = value; invalidatedListAll =  _changed;}
		}
		
		public bool SendNewsletter
		{
			get{ return sendNewsletter; }
			set{ _changed |= sendNewsletter != value; sendNewsletter = value; invalidatedListAll =  _changed;}
		}
		
		public byte MailChecked
		{
			get{ return mailChecked; }
			set{ _changed |= mailChecked != value; mailChecked = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime LastSend
		{
			get{ return lastSend; }
			set{ _changed |= lastSend != value; lastSend = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime User_last_visit
		{
			get{ return user_last_visit; }
			set{ _changed |= user_last_visit != value; user_last_visit = value; invalidatedListAll =  _changed;}
		}
		
		public DateTime User_current_visit
		{
			get{ return user_current_visit; }
			set{ _changed |= user_current_visit != value; user_current_visit = value; invalidatedListAll =  _changed;}
		}
		
	
		// generate a static property to retrieve all instances of a class that are stored in the database
		static public IList ListAll
		{
			get 
			{ 
				if( listAllCache == null || invalidatedListAll )
				{
					listAllCache = Broker.RetrieveList( typeof(rb_Users) ) as ArrayList;
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
	   
		public static rb_Users Retrieve(int id )
		{
	   
			// Return null if id is smaller than seed and/or increment for autokey
			if(id<0) 
			{
				return null;
			}
		  
			Key key = new Key( typeof(rb_Users), true, "UserID", id );
			return Broker.RetrieveInstance( typeof(rb_Users), key ) as rb_Users;
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
		// Key: UserID
		// List of foreign keys for this class table
		// Key: FK_rb_UserDesktop_rb_Users primary table: rb_Users primary column: UserID foreign column: UserID foreign table: rb_UserDesktop
		// Key: FK_rb_UserRoles_rb_Users primary table: rb_Users primary column: UserID foreign column: UserID foreign table: rb_UserRoles
		// Key: FK_rb_Users_rb_Countries primary table: rb_Countries primary column: CountryID foreign column: CountryID foreign table: rb_Users
		// Key: FK_rb_Users_rb_Portals primary table: rb_Portals primary column: PortalID foreign column: PortalID foreign table: rb_Users
		// Key: FK_rb_Users_rb_States primary table: rb_States primary column: StateID foreign column: StateID foreign table: rb_Users
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
		/// table "rb_Roles", using relation table "rb_UserRoles"
		/// </summary>
		public IList referencedrb_RolesUsingrb_UserRoles()
		{
			return new GentleList( typeof(rb_Roles), this, typeof(rb_UserRoles));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_UserDesktop", using relation table "rb_Users"
		/// </summary>
		public IList referencedrb_UserDesktopUsingrb_Users()
		{
			return new GentleList( typeof(rb_UserDesktop), this, typeof(rb_Users));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_UserRoles", using relation table "rb_Users"
		/// </summary>
		public IList referencedrb_UserRolesUsingrb_Users()
		{
			return new GentleList( typeof(rb_UserRoles), this, typeof(rb_Users));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Countries", using relation table "rb_Users"
		/// </summary>
		public IList referencedrb_CountriesUsingrb_Users()
		{
			return new GentleList( typeof(rb_Countries), this, typeof(rb_Users));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_Portals", using relation table "rb_Users"
		/// </summary>
		public IList referencedrb_PortalsUsingrb_Users()
		{
			return new GentleList( typeof(rb_Portals), this, typeof(rb_Users));
		}

		/// <summary>
		/// Return list of referenced objects from n:m relation with
		/// table "rb_States", using relation table "rb_Users"
		/// </summary>
		public IList referencedrb_StatesUsingrb_Users()
		{
			return new GentleList( typeof(rb_States), this, typeof(rb_Users));
		}
		#endregion

		#region ManualCode
		/***PRESERVE_BEGIN MANUAL_CODE***/
		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public rb_Users( 
			int PortalID, 
			string Name, 
			string Company, 
			string Address, 
			string City, 
			string Zip, 
			string CountryID, 
			int StateID, 
			string PIva, 
			string CFiscale, 
			string Phone, 
			string Fax, 
			string Password, 
			string Email, 
			bool SendNewsletter)
		{
			_changed = true;
			invalidatedListAll = true;
			portalID = PortalID;
			name = Name;
			company = Company;
			address = Address;
			city = City;
			zip = Zip;
			countryID = CountryID;
			stateID = StateID;
			pIva = PIva;
			cFiscale = CFiscale;
			phone = Phone;
			fax = Fax;
			password = Password;
			email = Email;
			sendNewsletter = SendNewsletter;
		}

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
		public rb_Users( 
			int PortalID, 
			string Name, 
			string Password, 
			string Email)
		{
			_changed = true;
			invalidatedListAll = true;
			portalID = PortalID;
			name = Name;
			password = Password;
			email = Email;
		}

		public static rb_Users Retrieve(string email)
		{
			if(email == null)
			{
				return null;
			}

			Key key = new Key( typeof(rb_Users),true,"Email",email);
			return Broker.RetrieveInstance( typeof(rb_Users), key) as rb_Users;
		}
		/***PRESERVE_END MANUAL_CODE***/
		#endregion
	}

}
#endregion

