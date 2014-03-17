using AwfulNET.Common;
using AwfulNET.Core.Rest;
using AwfulNET.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Data
{
    [Table]
    public sealed class UserAccount : BindableTable
    {
        private static object lockobj = new object();
        private ForumAccessToken token = null;

        public UserAccount()
        {
            this._userTokens = new EntitySet<UserToken>(OnUserTokenAdd, OnUserTokenRemove);
            this._userFavorites = new EntitySet<UserFavorite>(OnUserFavoriteAdd, OnUserFavoriteRemove);
            ThreadDataGroup.PinChanged += ThreadDataGroup_PinChanged;
        }

        public UserAccount(ForumAccessToken token) : this()
        {
            this.Update(token);
        }

        public void Update(ForumAccessToken token)
        {
            this.token = token;
            this.Username = token.Username;
            this.UserTokens.Clear();
            foreach(var cookie in token.Cookies)
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

        public void AddToFavorites(ThreadDataGroup forum)
        {
            UserFavorite selected = this.UserFavorites.SingleOrDefault(item => item.ItemId.Equals(forum.UniqueID));
            if (selected == null)
            {
                lock(lockobj)
                {
                    this.UserFavorites.Add(new UserFavorite(forum));
                }
            }
        }

        public bool RemoveFromFavorites(ThreadDataGroup forum)
        {
            bool removed = false;
            UserFavorite selected = this.UserFavorites.SingleOrDefault(item => item.ItemId.Equals(forum.UniqueID));
            if (selected != null)
            {
                lock(lockobj)
                {
                    removed = this.UserFavorites.Remove(selected);   
                }
            }
            return removed;
        }

        private void ThreadDataGroup_PinChanged(object sender, EventArgs e)
        {
            ThreadDataGroup forum = sender as ThreadDataGroup;
            if (forum.IsPinned)
                AddToFavorites(forum);
            else
                RemoveFromFavorites(forum);
        }

        private void OnUserFavoriteRemove(UserFavorite obj)
        {
            OnPropertyChanging("Account");
            obj.Account = null;
        }

        private void OnUserFavoriteAdd(UserFavorite obj)
        {
            OnPropertyChanging("Account");
            obj.Account = this;
        }

        private void OnUserTokenRemove(UserToken obj)
        {
            OnPropertyChanging("Account");
            obj.Account = null;
        }

        private void OnUserTokenAdd(UserToken obj)
        {
            OnPropertyChanging("Account");
            obj.Account = this;
        }

        [Column(IsVersion = true)]
        private Binary _version;

        private string username = string.Empty;
        [Column(CanBeNull = false)]
        public string Username
        {
            get { return this.username; }
            set { SetProperty(ref this.username, value); }
        }

        private int userAccountId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int UserAccountId
        {
            get { return this.userAccountId; }
            set { SetProperty(ref this.userAccountId, value); }
        }

        private EntitySet<UserToken> _userTokens;
        [Association(Storage = "_userTokens", ThisKey = "UserAccountId", OtherKey = "fk_userAccountId")]
        public EntitySet<UserToken> UserTokens
        {
            get { return this._userTokens; }
            set { this._userTokens.Assign(value); }
        }

        private EntitySet<UserFavorite> _userFavorites;
        [Association(Storage = "_userFavorites", ThisKey = "UserAccountId", OtherKey = "fk_userAccountId")]
        public EntitySet<UserFavorite> UserFavorites
        {
            get { return this._userFavorites; }
            set { this._userFavorites.Assign(value); }
        }

        internal bool HasUserFavoriteWithId(string id)
        {
            var selected = this.UserFavorites.SingleOrDefault(item => item.ItemId.Equals(id));
            return selected != null;
        }
    }

    [Table]
    public sealed class UserToken : BindableTable
    {
        public UserToken() { }

        public UserToken(System.Net.Cookie cookie) : this()
        {
            this.Name = cookie.Name;
            this.Value = cookie.Value;
            this.Path = cookie.Path;
            this.Domain = cookie.Domain;
        }

        [Column(IsVersion = true)]
        private Binary _version;

        private int userTokenId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int UserTokenId
        {
            get { return this.userTokenId; }
            set { SetProperty(ref this.userTokenId, value); }
        }

        private string name = string.Empty;
        [Column(CanBeNull = false)]
        public string Name
        {
            get { return this.name; }
            set { SetProperty(ref this.name, value); }
        }

        private string domain = string.Empty;
        [Column(CanBeNull = false)]
        public string Domain
        {
            get { return this.domain; }
            set { SetProperty(ref this.domain, value); }
        }

        private string path = string.Empty;
        [Column(CanBeNull = false)]
        public string Path
        {
            get { return this.path; }
            set { SetProperty(ref this.path, value); }
        }

        private string value = string.Empty;
        [Column(CanBeNull=false)]
        public string Value
        {
            get { return this.value; }
            set { SetProperty(ref this.value, value); }
        }

        [Column]
        internal int fk_userAccountId;

        private EntityRef<UserAccount> _account;
        [Association(Storage = "_account", DeleteOnNull = true, IsUnique = false, ThisKey = "fk_userAccountId", OtherKey = "UserAccountId", IsForeignKey = true)]
        public UserAccount Account
        {
            get { return this._account.Entity; }
            set
            {
                if (this.SetEntityRef(ref this._account, value,
                   () => { fk_userAccountId = value.UserAccountId; }))
                {
                    OnPropertyChanged();
                }
            }
        }

        internal System.Net.Cookie ToCookie()
        {
            var cookie = new System.Net.Cookie(
                this.Name,
                this.Value,
                this.Path,
                this.Domain);

            return cookie;
        }
    }

    [Table]
    public sealed class UserFavorite : BindableTable
    {
        public UserFavorite() { }
        public UserFavorite(ThreadDataGroup forum) : this()
        {
            this.ItemId = forum.UniqueID;
        }

        [Column(IsVersion = true)]
        private Binary _version;

        public string itemId = string.Empty;
        [Column(CanBeNull = false)]
        public string ItemId
        {
            get { return this.itemId; }
            set { SetProperty(ref this.itemId, value); }
        }

        private int userFavoriteId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int UserFavoriteId
        {
            get { return this.userFavoriteId; }
            set { SetProperty(ref this.userFavoriteId, value); }
        }

        [Column]
        internal int fk_userAccountId;

        private EntityRef<UserAccount> _account;
        [Association(Storage = "_account", ThisKey="fk_userAccountId", OtherKey="UserAccountId", DeleteOnNull = true, IsForeignKey = true)]
        public UserAccount Account
        {
            get { return this._account.Entity; }
            set
            {
                if (this.SetEntityRef(ref this._account, value,
                    () => { this.fk_userAccountId = value.UserAccountId; }))
                    OnPropertyChanged();
            }
        }
    }
}