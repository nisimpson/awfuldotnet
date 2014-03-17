using AwfulNET.Common;
using AwfulNET.Core.Common;
using AwfulNET.Core.Rest;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Data
{
    public class UserDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public UserDataContext(string connectionString) : base(connectionString)
        { }

        // Specify a table for the user accounts.
        public Table<UserAccount> Accounts;

        // Specify a table for a user's favorites.
        public Table<UserFavorite> UserFavorites;

        // Specify a table for a user's tokens.
        public Table<UserToken> UserTokens;

        private static bool isLoggedOut = false;

        /// <summary>
        /// Authenticate with the SomethingAwful forums.
        /// </summary>
        /// <param name="username">the account's username.</param>
        /// <param name="password">the account's password.</param>
        /// <returns>On success, a UserAccount object with the user's privledges.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<UserAccount> LoginAsync(string username, string password)
        {
            ForumAccessToken token = await AwfulWebClient.AuthenticateAsync(username, password);
            
            // find out if we already have an account under that username
            UserAccount selected = this.Accounts.SingleOrDefault(item => item.Username.Equals(username));
            if (selected == null)
            {
                selected = new UserAccount();
                this.Accounts.InsertOnSubmit(selected);
            }

            // update selected with token data
            selected.Update(token);
            // save changes
            SaveChanges(selected, SettingsModelFactory.GetSettingsModel());

            return selected;
        }

        public void SaveChanges(UserAccount account, ISettingsModel settings)
        {
            if (!isLoggedOut && !string.IsNullOrEmpty(account.Username))
            {
                settings.AddOrUpdate("currentUser", account.Username);
                settings.SaveSettings();
                this.SubmitChanges();
            }
        }

        public UserAccount LoadCurrentUser(ISettingsModel settings)
        {
            string currentUser = settings.GetValueOrDefault<string>("currentUser", string.Empty);
            UserAccount currentAccount = this.Accounts.SingleOrDefault(item => item.Username.Equals(currentUser));
            if (currentAccount == null)
                currentAccount = new UserAccount();

            return currentAccount;
        }

        public void Logout(ISettingsModel settings)
        {
            isLoggedOut = true;
            bool result = settings.Remove("currentUser");
            settings.SaveSettings();
        }

        internal void CreateIfNotExists()
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
    }
}
