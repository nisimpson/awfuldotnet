using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using AwfulNET.Core.Rest;
using System.Net;
using AwfulNET.Core.Common;
using AwfulNET.Common;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using AwfulNET.Core;
using AwfulNET.RT;
using AwfulNET.DataModel;

namespace AwfulNET.Data
{
    [DataContract]
    public class UserAccount
    {
        [DataMember]
        public string UserAccountId { get; set; }
        [DataMember]
        public string Username { get; set; }
        [IgnoreDataMember]
        public IList<UserToken> UserTokens { get; set; }
        [IgnoreDataMember]
        public IList<UserFavorite> UserFavorites { get; set; }

        private ForumAccessToken token;

        public UserAccount()
        {
            if (string.IsNullOrEmpty(UserAccountId))
                UserAccountId = Guid.NewGuid().ToString();
        }

        public UserAccount(ForumAccessToken token)
            : this()
        {
            this.Update(token);
        }

        public void Update(ForumAccessToken token)
        {
            this.token = token;
            this.Username = token.Username;
            this.UserTokens.Clear();
            foreach (var cookie in token.Cookies)
            {
                this.UserTokens.Add(new UserToken(cookie));
            }
        }

        public ForumAccessToken AsForumAccessToken()
        {
            if (this.token == null)
            {
                ForumAccessToken token = new ForumAccessToken();
                token.Username = this.Username;
                foreach (var userToken in this.UserTokens)
                {
                    token.Cookies.Add(userToken.ToCookie());
                }

                this.token = token;
            }

            return this.token;
        }

        public bool HasUserFavoriteWithId(string id)
        {
            if (UserFavorites != null)
                return UserFavorites.SingleOrDefault(item => item.ItemId.Equals(id)) != null;

            return false;
        }

        internal void AddFavorite(ThreadDataGroup thread)
        {
            if (!HasUserFavoriteWithId(thread.UniqueID))
                UserFavorites.Add(new UserFavorite(thread));
        }

        internal void RemoveFavorite(ThreadDataGroup thread)
        {
            var toRemove = UserFavorites.SingleOrDefault(item => item.ItemId.Equals(thread.UniqueID));
            if (toRemove != null)
                UserFavorites.Remove(toRemove);
        }
    }

    [DataContract]
    public class UserToken
    {
        [DataMember]
        public string UserTokenId { get; set; }
        [DataMember]
        public string Fk_UserAccountId { get; set; }
        [IgnoreDataMember]
        public UserAccount Account { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Domain { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public string Value { get; set; }

        public UserToken() 
        {
            if (string.IsNullOrEmpty(UserTokenId))
                UserTokenId = Guid.NewGuid().ToString();
        }

        public UserToken(Cookie cookie)
        {
            this.Name = cookie.Name;
            this.Path = cookie.Path;
            this.Domain = cookie.Domain;
            this.Value = cookie.Value;
        }

        public Cookie ToCookie()
        {
            return new Cookie()
            {
                Name = this.Name,
                Path = this.Path,
                Domain = this.Domain,
                Value = this.Value
            };
        }
    }

    [DataContract]
    public class UserFavorite
    {
        [DataMember]
        public string UserFavoriteId { get; set; }
        [DataMember]
        public string ItemId { get; set; }
        [DataMember]
        public string Fk_UserAccountId { get; set; }
        [IgnoreDataMember]
        public UserAccount Account { get; set; }

        public UserFavorite()
        {
            if (string.IsNullOrEmpty(UserFavoriteId))
                UserFavoriteId = Guid.NewGuid().ToString();
        }

        public UserFavorite(ThreadDataGroup thread) : this()
        {
            this.ItemId = thread.UniqueID;
        }
    }

    [DataContract]
    public class UserDataContext
    {
        [DataMember]
        public List<UserAccount> UserAccounts { get; set; }

        [DataMember]
        public List<UserToken> UserTokens { get; set; }

        [DataMember]
        public ObservableCollection<UserFavorite> UserFavorites { get; set; }

        public static string ConnectionString { get; set; }

        public UserDataContext()
        {
            UserAccounts = new List<UserAccount>();
            UserTokens = new List<UserToken>();
            UserFavorites = new ObservableCollection<UserFavorite>();
        }

        private static async void UserFavorites_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            await App.UserContext.SaveChangesAsync(App.CurrentAccount, SettingsModelFactory.GetSettingsModel());
        }

        public UserDataContext(string connectionString) { }

        public Task<bool> CreateIfNotExistsAsync()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            if (UserAccounts == null)
            {
                UserAccounts = new List<UserAccount>();
                UserTokens = new List<UserToken>();
                UserFavorites = new ObservableCollection<UserFavorite>();
                UserFavorites.CollectionChanged += UserFavorites_CollectionChanged;
                tcs.SetResult(true);
            }
            else { tcs.SetResult(false); }
            return tcs.Task;
        }

        private Task<UserAccount> AttachAssociationsAsync(UserAccount account)
        {
            var favorites = UserFavorites
                .Where(item => item.Fk_UserAccountId.Equals(account.UserAccountId))
                .ToList();

            var tokens = UserTokens
                .Where(item => item.Fk_UserAccountId.Equals(account.UserAccountId))
                .ToList();

            var accountFavorites = new ObservableCollection<UserFavorite>(favorites);
            accountFavorites.CollectionChanged += new NotifyCollectionChangedEventHandler((sender, e) => { OnAccountUserFavoritesChanged(account, e); });
            account.UserFavorites = accountFavorites;
            var accountTokens = new ObservableCollection<UserToken>(tokens);
            accountTokens.CollectionChanged += new NotifyCollectionChangedEventHandler((sender, e) => { OnAccountUserTokensChanged(account, e); });
            account.UserTokens = accountTokens;

            TaskCompletionSource<UserAccount> tcs = new TaskCompletionSource<UserAccount>();
            tcs.SetResult(account);
            return tcs.Task;
        }

        private void OnAccountUserTokensChanged(UserAccount account, NotifyCollectionChangedEventArgs args)
        {
            List<UserToken> toAdd = new List<UserToken>();
            List<UserToken> toRemove = new List<UserToken>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in args.NewItems)
                    {
                        var userToken = item as UserToken;
                        userToken.Fk_UserAccountId = account.UserAccountId;
                        toAdd.Add(userToken);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in args.OldItems)
                    {
                        var userToken = item as UserToken;
                        userToken.Fk_UserAccountId = "-1";
                        toRemove.Add(userToken);
                    }
                    break;
            }

            UserTokens.AddRange(toAdd);
            UserTokens.RemoveAll(item => toRemove.Contains(item));

            //return StorageModelFactory.GetStorageModel().SaveToStorageAsync(ConnectionString, this);
        }

        private void OnAccountUserFavoritesChanged(UserAccount account, NotifyCollectionChangedEventArgs args)
        {
            List<UserFavorite> toAdd = new List<UserFavorite>();
            List<UserFavorite> toRemove = new List<UserFavorite>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in args.NewItems)
                    {
                        var userFavorite = item as UserFavorite;
                        userFavorite.Fk_UserAccountId = account.UserAccountId;
                        toAdd.Add(userFavorite);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in args.OldItems)
                    {
                        var userFavorite = item as UserFavorite;
                        userFavorite.Fk_UserAccountId = "-1";
                        toRemove.Add(userFavorite);
                    }
                    break;
            }

            foreach (var item in toAdd)
                UserFavorites.Add(item);

            foreach (var item in toRemove)
                UserFavorites.Remove(item);
        }

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
            UserAccount selected = UserAccounts
                .Where(item => item.Username.Equals(username))
                .SingleOrDefault();

            if (selected == null)
            {
                selected = new UserAccount();
                selected = await AttachAssociationsAsync(selected);
                selected.Update(token);
                UserAccounts.Add(selected);
            }
            else
            {
                // update selected with token data
                selected = await AttachAssociationsAsync(selected);
                selected.Update(token);
                
            }

            // save changes
            await SaveChangesAsync(selected, SettingsModelFactory.GetSettingsModel());

            return selected;
        }

        public async Task SaveChangesAsync(UserAccount account, ISettingsModel settings)
        {
            if (!isLoggedOut && !string.IsNullOrEmpty(account.Username))
            {
                settings.AddOrUpdate("currentUser", account.Username);
                settings.SaveSettings();
                await StorageModelFactory.GetStorageModel().SaveToStorageAsync(ConnectionString, this);
            }
        }

        public async Task<UserAccount> LoadCurrentUser(ISettingsModel settings)
        {
            string currentUser = settings.GetValueOrDefault<string>("currentUser", string.Empty);
            UserAccount currentAccount = UserAccounts
                .Where(item => item.Username.Equals(currentUser))
                .SingleOrDefault();

            if (currentAccount == null)
            {
                // return an anonymous, public user.
                settings.AddOrUpdate("currentUser", string.Empty);
                settings.SaveSettings();
                currentAccount = new UserAccount();
            }
            else
            {
                // attach tokens and favorites
                currentAccount = await AttachAssociationsAsync(currentAccount);

                if (!currentAccount.AsForumAccessToken().IsActiveAccount)
                {
                    settings.AddOrUpdate("currentUser", string.Empty);
                    settings.SaveSettings();
                }
            }

            return currentAccount;
        }

        public void Logout(ISettingsModel settings)
        {
            isLoggedOut = true;
            bool result = settings.Remove("currentUser");
            settings.SaveSettings();
        }

        internal static UserDataContext Load(IStorageModel storage)
        {
            UserDataContext result = null;
            try { result = storage.LoadFromStorageAsync<UserDataContext>(ConnectionString).Result; }
            catch (Exception ex) 
            {
                var settings = SettingsModelFactory.GetSettingsModel();
                settings.AddOrUpdate("currentUser", string.Empty);
                settings.SaveSettings();
                result = new UserDataContext(); 
            }
            
            result.UserFavorites.CollectionChanged += UserFavorites_CollectionChanged;
            return result;
        }
    }
}

