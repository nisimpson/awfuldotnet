using AwfulNET.Common;
using AwfulNET.Core;
using AwfulNET.Core.Common;
using AwfulNET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.Storage;

namespace AwfulNET.DataModel
{
    public delegate void SignInSuccessDelegate(UserAccount account);

    public class SignInDataModel : BindableBase
    {
        private string username = string.Empty;
        private string password = string.Empty;
        private RelayCommand signInCommand;
        private bool isActive = false;
        private SignInSuccessDelegate onSuccess;
        private FailureDelegate onFail;
        private readonly UserDataContext userContext;
        
        public const string DISCLAIMER_CAPTION = "Listen Up.";
        public const string DISCLAIMER = "You are about to enter the SomethingAwful Forums, a comedy and satire message board on the INTERNET. " +
            "The content herein does not belong to the developer, and may contain:\n\n" +
            "\u2022 Mild Adult Language\n" +
            "\nUser discretion is advised. By clicking OK you hereby acknowledge the above, and are over the age of 18.";

        /// <summary>
        /// Gets or sets the backing field for username input.
        /// </summary>
        public string Username
        {
            get { return this.username; }
            set 
            {
                if (this.SetProperty(ref this.username, value))
                    signInCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the backing field for password input
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set 
            {
                if (this.SetProperty(ref this.password, value))
                    signInCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets the command binding for the sign in button.
        /// </summary>
        public ICommand SignInCommand
        {
            get { return this.signInCommand; }
        }

        /// <summary>
        /// Gets the backing field for the sign in progress indicator.
        /// </summary>
        public bool IsActive
        {
            get { return this.isActive; }
            private set
            {
                if (SetProperty(ref this.isActive, value))
                    OnPropertyChanged("IsEnabled");
            }
        }

        /// <summary>
        /// Get the backing field for enabling/disabling the login form.
        /// </summary>
        public bool IsEnabled
        {
            get { return !this.isActive; }
        }

        /// <summary>
        /// Creates a new SignInDataModel instance.
        /// </summary>
        /// <param name="success">callback on sign in success.</param>
        /// <param name="fail">callback on sign in failure.</param>
        public SignInDataModel(
            UserDataContext context,
            SignInSuccessDelegate success, 
            FailureDelegate fail)
        {
            if (success == null || fail == null)
                throw new ArgumentNullException("success | fail");

            this.userContext = context;
            this.onSuccess = success;
            this.onFail = fail;
            this.signInCommand = new RelayCommand(async () => { await SignInAsync(); }, CanSignIn);
        }

        public static bool IsSignedIn()
        {
          
            // load the current user from local settings.
            var settings = SettingsModelFactory.GetSettingsModel();

            try
            {
                string user = settings.GetValueOrDefault("currentUser", string.Empty);
                if (string.IsNullOrEmpty(user))
                    return false;

                return true;
            }
            catch(Exception ex)
            {
                // if anything goes wrong, wipe the current user, so we can login again.
                settings.Remove("currentUser");
                settings.SaveSettings();
            }

            return false;
        }

        /// <summary>
        /// Pre execution validation.
        /// </summary>
        private bool CanSignIn()
        {
            // we can only log in if both our username and password is nonempty.
            return !string.IsNullOrEmpty(this.Username) &&
                !string.IsNullOrEmpty(this.Password);
        }

        private async Task SignInAsync()
        {
            // kick off our login task
            var loginTask = userContext.LoginAsync(this.Username, this.Password);

            // start loading graphic
            this.IsActive = true;
            try
            {
                var account = await loginTask;
                if (account != null)
                {
                    // on success, save username to settings, load up root view model,
                    // and let the view notify user.

                    // throw up the disclaimer:
                    ConfirmDialogMessage dialog = new ConfirmDialogMessage(DISCLAIMER, DISCLAIMER_CAPTION);
                    NotificationService.Default.Notify<ConfirmDialogMessage>(this, dialog);
                    bool confirm = await dialog.ConfirmAsync;
                  
                    if (!confirm)
                        throw new Exception("User does not acknowledge the disclaimer.");

                    // if the user is not a babby:
                    onSuccess(account);
                }
            }

            // on failure, let view handle user notification.
            catch (Exception ex) {onFail(ex); }
            finally { IsActive = false; }
        }
    }
}
