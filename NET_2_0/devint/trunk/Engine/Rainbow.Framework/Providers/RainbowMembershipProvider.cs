using System;
using System.Web.Security;
using System.Web.Profile;
using Rainbow.Framework.BusinessObjects;
using Rainbow.Framework.Providers.Exceptions;

namespace Rainbow.Framework.Providers
{
    /// <summary>
    /// Rainbow-specific membership provider API, implements ASP.NET's membership plus extra funcionality Rainbow needs.
    /// </summary>
    public abstract class RainbowMembershipProvider : MembershipProvider 
    {
        ///<summary>
        /// Gets default configured membership provider
        /// Singleton pattern standard member
        ///</summary>
        ///<exception cref="RainbowMembershipProviderException"></exception>
        public static RainbowMembershipProvider Instance
        {
            get
            {
                if (!(Membership.Provider is RainbowMembershipProvider))
                {
                    throw new RainbowMembershipProviderException("The membership provider must be a RainbowMembershipProvider implementation");
                }
                return Membership.Provider as RainbowMembershipProvider;
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public string GetErrorMessage(MembershipCreateStatus status)
        {
            //TODO: [moudrick] use resource GetString here
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return
                        "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return
                        "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return
                        "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return
                        "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return
                        "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        /// <summary>
        /// Loads the user profile.
        /// </summary>
        /// <param name="user">The user.</param>
        protected virtual void LoadUserProfile(RainbowUser user)
        {
            ProfileBase profile = ProfileBase.Create(user.UserName);

            user.Name = profile.GetPropertyValue("Name").ToString();
            user.Company = profile.GetPropertyValue("Company").ToString();
            user.Address = profile.GetPropertyValue("Address").ToString();
            user.Zip = profile.GetPropertyValue("Zip").ToString();
            user.City = profile.GetPropertyValue("City").ToString();
            user.CountryID = profile.GetPropertyValue("CountryID").ToString();
            user.StateID = Convert.ToInt32(profile.GetPropertyValue("StateID"));
            user.Fax = profile.GetPropertyValue("Fax").ToString();
            user.Phone = profile.GetPropertyValue("Phone").ToString();
            user.SendNewsletter = Convert.ToBoolean(profile.GetPropertyValue("SendNewsletter"));
        }

        /// <summary>
        /// Saves the user profile.
        /// </summary>
        /// <param name="user">The user.</param>
        protected virtual void SaveUserProfile(RainbowUser user)
        {
            ProfileBase profile = ProfileBase.Create(user.UserName);

            profile.SetPropertyValue("Name", user.Name ?? string.Empty);
            profile.SetPropertyValue("Company", user.Company ?? string.Empty);
            profile.SetPropertyValue("Address", user.Address ?? string.Empty);
            profile.SetPropertyValue("Zip", user.Zip ?? string.Empty);
            profile.SetPropertyValue("City", user.City ?? string.Empty);
            profile.SetPropertyValue("CountryID", user.CountryID ?? string.Empty);
            profile.SetPropertyValue("StateID", user.StateID);
            profile.SetPropertyValue("Fax", user.Fax ?? string.Empty);
            profile.SetPropertyValue("Phone", user.Phone ?? string.Empty);
            profile.SetPropertyValue("SendNewsletter", user.SendNewsletter);
            profile.Save();
        }

        /// <summary>
        /// Deletes the user profile.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        protected virtual bool DeleteUserProfile(string userName)
        {
            return ProfileManager.DeleteProfile(userName);
        }

        /// <summary>
        /// Instanciates a new user.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="name">The name.</param>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <param name="email">The email.</param>
        /// <param name="passwordQuestion">The password question.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="isApproved">if set to <c>true</c> [is approved].</param>
        /// <param name="isLockedOut">if set to <c>true</c> [is locked out].</param>
        /// <param name="creationDate">The creation date.</param>
        /// <param name="lastLoginDate">The last login date.</param>
        /// <param name="lastActivityDate">The last activity date.</param>
        /// <param name="lastPasswordChangeDate">The last password change date.</param>
        /// <param name="lastLockoutDate">The last lockout date.</param>
        /// <returns></returns>
        protected virtual RainbowUser InstanciateNewUser(string providerName,
                                                         string name,
                                                         Guid providerUserKey,
                                                         string email,
                                                         string passwordQuestion,
                                                         string comment,
                                                         bool isApproved,
                                                         bool isLockedOut,
                                                         DateTime creationDate,
                                                         DateTime lastLoginDate,
                                                         DateTime lastActivityDate,
                                                         DateTime lastPasswordChangeDate,
                                                         DateTime lastLockoutDate)
        {
            return new RainbowUser(providerName,
                                   name,
                                   providerUserKey,
                                   email,
                                   passwordQuestion,
                                   comment,
                                   isApproved,
                                   isLockedOut,
                                   creationDate,
                                   lastLoginDate,
                                   lastActivityDate,
                                   lastPasswordChangeDate,
                                   lastLockoutDate);
        }

        /// <summary>
        /// Instanciates a new user.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        protected virtual RainbowUser InstanciateNewUser( string name ) {

            return new RainbowUser( name );
        }

        /// <summary>
        /// Takes, as input, a user name, password, e-mail address, and other information and adds a new user to the membership data source.
        /// CreateUser returns a MembershipUser object representing the newly created user. 
        /// Before creating a new user, CreateUser calls the provider's virtual OnValidatingPassword method to validate the supplied password. 
        /// It then creates the user or cancels the action based on the outcome of the call.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">New user's name</param>
        /// <param name="password">New user's password</param>
        /// <param name="email">New user's email</param>
        /// <param name="passwordQuestion">The password question</param>
        /// <param name="passwordAnswer">The password answer</param>
        /// <param name="isApproved">Whether the user is approved or not</param>
        /// <param name="status">An out parameter (in Visual Basic, ByRef) that returns a MembershipCreateStatus value indicating whether the user was 
        /// successfully created or, if the user was not created, the reason why.</param>
        /// <returns>A new <code>MembershipUser</code>. If the user was not created, CreateUser returns null.</returns>
        public abstract MembershipUser CreateUser(string portalAlias,
                                                  string username,
                                                  string password,
                                                  string email,
                                                  string passwordQuestion,
                                                  string passwordAnswer,
                                                  bool isApproved,
                                                  out MembershipCreateStatus status);

        /// <summary>
        /// Takes as an input a RainbowMembershipUser, a password and a passwordAnswer and creates a user saving its profile. 
        /// </summary>
        /// <param name="user">A <code>RainbowMembershipUser</code> with most of the user's data</param>
        /// <param name="password">the user's account password (it can't be passed in user)</param>
        /// <param name="passwordAnswer">the user's account password answer (it can't be passed in user)</param>
        /// <returns>A new <code>MembershipUser</code>. If the user was not created, CreateUser returns null.</returns>
        public virtual MembershipUser CreateUser(RainbowUser user,
                                                 string password,
                                                 string passwordAnswer)
        {
            MembershipCreateStatus status;
            RainbowUser membershipUser = (RainbowUser) CreateUser(user.UserName,
                           password,
                           user.Email,
                           user.PasswordQuestion,
                           passwordAnswer,
                           user.IsApproved,
                           user.ProviderUserKey,
                           out status);
            if (user != null)
            {
                SaveUserProfile(membershipUser);
            }
            return membershipUser;
        }

        /// <summary>
        /// Takes, as input, a user name, password, password question, and password answer and updates the password question and answer
        /// in the data source if the user name and password are valid. 
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="password">The user's password</param>
        /// <param name="newPasswordQuestion">The user's new password question</param>
        /// <param name="newPasswordAnswer">The user's new password answer</param>
        /// <returns>This method returns true if the password question and answer
        /// are successfully updated. It returns false if either the user name or password is invalid.</returns>
        public abstract bool ChangePasswordQuestionAndAnswer( string portalAlias, string username, string password, string newPasswordQuestion, string newPasswordAnswer );

        /// <summary>
        /// Takes, as input, a user name, a password (the user's current password), and a new password and updates
        /// the password in the membership data source. 
        /// Before changing a password, ChangePassword calls the provider's virtual OnValidatingPassword method to 
        /// validate the new password. It then changes the password or cancels the action based on the outcome of the call.
        /// If the user name, password, new password, or password answer is not valid, ChangePassword
        /// does not throw an exception; it simply returns false.
        /// Following a successful password change, ChangePassword updates the user's LastPasswordChangedDate.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="oldPassword">The user's old password</param>
        /// <param name="newPassword">The user's new password</param>
        /// <returns>ChangePassword returns true if the password was updated successfully.
        /// Otherwise, it returns false.</returns>
        public abstract bool ChangePassword( string portalAlias, string username, string oldPassword, string newPassword );

        /// <summary>
        /// Takes, as input, a user name and deletes that user from the membership data source. 
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="deleteAllRelatedData">Specifies whether 
        /// related data for that user should be deleted also. If deleteAllRelatedData is true, DeleteUser 
        /// should delete role data, profile data, and all other data associated with that user.</param>
        /// <returns>DeleteUser returns true if the user was successfully deleted. Otherwise, it returns false.</returns>
        public abstract bool DeleteUser( string portalAlias, string username, bool deleteAllRelatedData );

        /// <summary>
        /// The results returned by GetAllUsers are constrained by the pageIndex and pageSize input parameters. 
        /// pageSize specifies the maximum number of MembershipUser objects to return. pageIndex 
        /// identifies which page of results to return. Page indexes are 0-based.
        /// GetAllUsers also takes an out parameter (in Visual Basic, ByRef) named totalRecords that, on return, holds a count of all registered users.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <returns>Returns a MembershipUserCollection containing MembershipUser objects representing all registered users.
        /// If there are no registered users, GetAllUsers returns an empty MembershipUserCollection.</returns>
        public abstract MembershipUserCollection GetAllUsers( string portalAlias );

        /// <summary>
        /// The results returned by GetAllUsers are constrained by the pageIndex and pageSize input parameters. 
        /// pageSize specifies the maximum number of MembershipUser objects to return. pageIndex 
        /// identifies which page of results to return. Page indexes are 0-based.
        /// GetAllUsers also takes an out parameter (in Visual Basic, ByRef) named totalRecords that, on return, holds a count of all registered users.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="pageIndex">Page index to retrieve</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalRecords">Holds a count of all records.</param>
        /// <returns>Returns a MembershipUserCollection containing MembershipUser objects representing all registered users.
        /// If there are no registered users, GetAllUsers returns an empty MembershipUserCollection.</returns>
        public abstract MembershipUserCollection GetAllUsers( string portalAlias, int pageIndex, int pageSize, out int totalRecords );

        /// <summary>
        /// Returns a count of users that are currently online; that is, whose LastActivityDate is 
        /// greater than the current date and time minus the value of the membership service's 
        /// UserIsOnlineTimeWindow property, which can be read from Membership.UserIsOnlineTimeWindow.
        /// UserIsOnlineTimeWindow specifies a time in minutes and is set using the <code>&lt;membership&gt;</code>
        /// element's userIsOnlineTimeWindow attribute.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <returns>Returns a count of users that are currently online</returns>
        public abstract int GetNumberOfUsersOnline( string portalAlias );

        /// <summary>
        /// Takes, as input, a user name and a password answer and returns that user's password.
        /// Before retrieving a password, GetPassword verifies that EnablePasswordRetrieval is true. 
        /// GetPassword also checks the value of the RequiresQuestionAndAnswer property before retrieving a password. 
        /// If RequiresQuestionAndAnswer is true, GetPassword compares the supplied password answer to the stored password answer
        /// and throws a MembershipPasswordException if the two don't match. 
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="answer">The password answer</param>
        /// <exception cref="System.Configuration.Provider.ProviderException">If the user name is not valid, GetPassword throws a ProviderException.</exception>
        /// <exception cref="NotSupportedException">If EnablePasswordRetrieval is false, GetPassword throws a NotSupportedException.</exception>
        /// <exception cref="System.Configuration.Provider.ProviderException">If EnablePasswordRetrieval  is true but the password format is hashed, GetPassword throws a
        /// ProviderException since hashed passwords cannot, by definition, be retrieved.</exception>
        /// <exception cref="MembershipPasswordException">GetPassword also throws a MembershipPasswordException 
        /// if the user whose password is being retrieved is currently locked out.</exception>
        /// <exception cref="MembershipPasswordException">If RequiresQuestionAndAnswer is true, GetPassword compares the supplied password answer to the stored password answer
        /// and throws a MembershipPasswordException if the two don't match. </exception>
        /// <returns>Returns the user's password</returns>
        public abstract string GetPassword( string portalAlias, string username, string answer );

        /// <summary>
        /// Takes, as input, a user name or user ID (the method is overloaded) and a Boolean value indicating whether to
        /// update the user's LastActivityDate to show that the user is currently online. 
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="userIsOnline"></param>
        /// <returns>GetUser returns a
        /// MembershipUser object representing the specified user. If the user name or user ID is invalid (that is,
        /// if it doesn't represent a registered user) GetUser returns null (Nothing in Visual Basic).</returns>
        public abstract MembershipUser GetUser( string portalAlias, string username, bool userIsOnline );

        /// <summary>
        /// Unlocks (that is, restores login privileges for) the specified user. 
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <returns>UnlockUser returns true if the user is successfully 
        /// unlocked. Otherwise, it returns false. If the user is already unlocked, UnlockUser simply returns true.</returns>
        public abstract bool UnlockUser( string portalAlias, string username );

        /// <summary>
        /// Takes, as input, an e-mail address and returns the first registered user name whose e-mail address matches the one supplied.
        /// If it doesn't find a user with a matching e-mail address, GetUserNameByEmail returns an empty string.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="email"></param>
        /// <returns>The first registered user name whose e-mail address matches the one supplied.
        /// If it doesn't find a user with a matching e-mail address, GetUserNameByEmail returns an empty string.</returns>
        public abstract string GetUserNameByEmail( string portalAlias, string email );

        /// <summary>
        /// Takes, as input, a MembershipUser object representing a registered user and updates the information stored 
        /// for that user in the membership data source. 
        /// Note that UpdateUser is not obligated to allow all the data that can be encapsulated in a 
        /// MembershipUser object to be updated in the data source.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <exception cref="System.Configuration.Provider.ProviderException">If any of the input submitted in the MembershipUser object 
        /// is not valid, UpdateUser throws a ProviderException.</exception>
        /// <param name="user">A MembershipUser object representing a registered user</param>
        public abstract void UpdateUser( string portalAlias, MembershipUser user );

        /// <summary>
        /// Returns a MembershipUserCollection containing MembershipUser objects representing users whose user names match
        /// the usernameToMatch input parameter. Wildcard syntax is data source-dependent. MembershipUser objects in the 
        /// MembershipUserCollection are sorted by user name.
        /// For an explanation of the pageIndex, pageSize, and totalRecords parameters, see the GetAllUsers method.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="usernameToMatch"></param>
        /// <param name="pageIndex">Page index to retrieve</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalRecords">Holds a count of all records.</param>
        /// <returns>A <code>MembershipUserCollection</code>. If FindUsersByName finds no matching users, it returns an 
        /// empty MembershipUserCollection.</returns>
        public abstract MembershipUserCollection FindUsersByName( string portalAlias, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords );

        /// <summary>
        /// Returns a MembershipUserCollection containing MembershipUser objects representing users whose e-mail 
        /// addresses match the emailToMatch input parameter. Wildcard syntax is data source-dependent. MembershipUser 
        /// objects in the MembershipUserCollection are sorted by e-mail address.
        /// For an explanation of the pageIndex, pageSize, and totalRecords parameters, see the GetAllUsers method.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="emailToMatch"></param>
        /// <param name="pageIndex">Page index to retrieve</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalRecords">Holds a count of all records.</param>
        /// <returns>A <code>MembershipUserCollection</code>. If FindUsersByEmail finds no 
        /// matching users, it returns an empty MembershipUserCollection.</returns>
        public abstract MembershipUserCollection FindUsersByEmail( string portalAlias, string emailToMatch, int pageIndex, int pageSize, out int totalRecords );

        /// <summary>
        /// Takes, as input, a user name and a password answer and replaces the user's current password with a new, 
        /// random password.  A convenient mechanism for generating a random password is the Membership.GeneratePassword method.
        /// ResetPassword also checks the value of the RequiresQuestionAndAnswer property before resetting a password. 
        /// Before resetting a password, ResetPassword verifies that EnablePasswordReset is true. 
        /// Before resetting a password, ResetPassword calls the provider's virtual OnValidatingPassword method to 
        /// validate the new password. It then resets the password or cancels the action based on the outcome of 
        /// the call. 
        /// Following a successful password reset, ResetPassword updates the user's LastPasswordChangedDate.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="answer">The password answer</param>
        /// <exception cref="NotSupportedException">If EnablePasswordReset is false, ResetPassword throws a NotSupportedException. </exception>
        /// <exception cref="System.Configuration.Provider.ProviderException">If the user name is not valid, ResetPassword throws a ProviderException.</exception>
        /// <exception cref="System.Configuration.Provider.ProviderException">If the new password is invalid, ResetPassword throws a ProviderException.</exception>
        /// <exception cref="MembershipPasswordException">If the user whose password is being changed is currently locked out, ResetPassword throws a MembershipPasswordException.</exception>
        /// <exception cref="MembershipPasswordException">If RequiresQuestionAndAnswer is true, ResetPassword compares the supplied password 
        /// answer to the stored password answer and throws a MembershipPasswordException if the two don't match.</exception>
        /// <returns>ResetPassword then returns the new password.</returns>
        public abstract string ResetPassword( string portalAlias, string username, string answer );

        /// <summary>
        /// Takes, as input, a user name and a password and verifies that they are valid-that is, that the membership
        /// data source contains a matching user name and password. ValidateUser returns true if the user name and
        /// password are valid, if the user is approved (that is, if MembershipUser.IsApproved is true), and if the 
        /// user isn't currently locked out. Otherwise, it returns false.
        /// Following a successful validation, ValidateUser updates the user's LastLoginDate and fires an 
        /// AuditMembershipAuthenticationSuccess Web event. Following a failed validation, it fires an
        /// AuditMembershipAuthenticationFailure Web event.
        /// </summary>
        /// <param name="portalAlias">Rainbow's portal alias</param>
        /// <param name="username">The user's name</param>
        /// <param name="password">The user's password</param>
        /// <returns></returns>
        public abstract bool ValidateUser( string portalAlias, string username, string password );

        /// <summary>
        /// The GetUser method returns the collection of users.
        /// </summary>
        /// <returns></returns>
        public MembershipUserCollection GetUsers(string portalAlias)
        {
            int totalRecords;
            return GetAllUsers(portalAlias, 0, int.MaxValue, out totalRecords);
        }

        /// <summary>
        /// UpdateUser
        /// Autogenerated by CodeWizard 04/04/2003 17.55.40
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="company">The company.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="countryID">The country ID.</param>
        /// <param name="stateID">The state ID.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="email">The email.</param>
        /// <param name="sendNewsletter">if set to <c>true</c> [send newsletter].</param>
        public void UpdateUser(Guid userID,
                               string name,
                               string company,
                               string address,
                               string city,
                               string zip,
                               string countryID,
                               int stateID,
                               string phone,
                               string fax,
                               string email,
                               bool sendNewsletter)
        {
            RainbowUser user = GetUser(userID, true) as RainbowUser;
            if (user == null)
            {
                throw new RainbowMembershipProviderException("Could not load user");
            }
            user.Email = email;
            user.Name = name;
            user.Company = company;
            user.Address = address;
            user.Zip = zip;
            user.City = city;
            user.CountryID = countryID;
            user.StateID = stateID;
            user.Fax = fax;
            user.Phone = phone;
            user.SendNewsletter = sendNewsletter;

            UpdateUser(user);
        }

        /// <summary>
        /// Retrieves a <code>MembershipUser</code>.
        /// </summary>
        /// <param name="portalAlias">Portal alias</param>
        /// <param name="userName">the user's email</param>
        /// <returns></returns>
        public RainbowUser GetSingleUser(string portalAlias, string userName)
        {
            RainbowUser user = GetUser(portalAlias, userName, true) as RainbowUser;
            return user;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="portalAlias">Portal alias where user to be added</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        public Guid AddUser(string portalAlias, string email, string password, string fullName)
        {
            Guid newUserId = AddUser(portalAlias,
                                     email,
                                     string.Empty,
                                     string.Empty,
                                     string.Empty,
                                     string.Empty,
                                     string.Empty,
                                     0,
                                     string.Empty,
                                     string.Empty,
                                     password,
                                     email,
                                     false);
            RainbowUser user = GetUser(newUserId, false) as RainbowUser;
            if (user == null)
            {
                throw new RainbowMembershipProviderException("Could not load user");
            }
            user.Name = fullName;
            UpdateUser(user);
            return newUserId;
        }

        /// <summary>
        /// AddUser
        /// </summary>
        /// <param name="portalAlias">Portal alias where user to be added</param>
        /// <param name="name">The name.</param>
        /// <param name="company">The company.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="countryID">The country ID.</param>
        /// <param name="stateID">The state ID.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        /// <param name="sendNewsletter">if set to <c>true</c> [send newsletter].</param>
        /// <returns>The newly created ID</returns>
        public Guid AddUser(string portalAlias,
                            string name,
                            string company,
                            string address,
                            string city,
                            string zip,
                            string countryID,
                            int stateID,
                            string phone,
                            string fax,
                            string password,
                            string email,
                            bool sendNewsletter)
        {
            MembershipCreateStatus status;
            MembershipUser user = CreateUser(portalAlias,
                name,
                password,
                email,
                "vacia",
                "llena",
                true,
                out status);

            if (user == null)
            {
                //TODO: [moudrick] throw RainbowMembershipException here
                throw new ApplicationException(GetErrorMessage(status));
            }
            return (Guid)user.ProviderUserKey;
        }
    }
}