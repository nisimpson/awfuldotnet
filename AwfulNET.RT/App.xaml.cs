using AwfulNET.Common;
using AwfulNET.Data;
using AwfulNET.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace AwfulNET.RT
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        private const string DB_CONNECTION_STRING = "userdb.dat";

        public static UserDataContext UserContext { get; private set; }

        public static MainDataModel Main { get; private set; }

        public static UserAccount CurrentAccount { get; set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            // Intialize User DB
            UserDataContext.ConnectionString = DB_CONNECTION_STRING;
            UserContext = UserDataContext.Load(WinRTStorageModel.Instance);
            var dbCreationResult = UserContext.CreateIfNotExistsAsync().Result;

            // Intialize Main ViewModel
            Main = new MainDataModel();

            // Register Notification Handlers
            NotificationService.Default.Register<ToastMessage>(OnToastMessage);
            NotificationService.Default.Register<DialogMessage>(OnDialogMessage);
            NotificationService.Default.Register<ConfirmDialogMessage>(OnConfirmDialogMessage);
            NotificationService.Default.Register<NetworkDetectionMessage>(OnNetworkDetectionMessage);
            NotificationService.Default.Register<AccessTokenMessage>(OnAccessTokenMessage);
        }

        private void OnAccessTokenMessage(INotification<AccessTokenMessage> obj)
        {
            if (CurrentAccount != null)
                obj.Value.Token = CurrentAccount.AsForumAccessToken();
        }

        internal static void OnSettingsPaneCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(App.CreatePrivateSettingsCommand());
        }

        private static SettingsCommand CreatePrivateSettingsCommand()
        {
            SettingsCommand privacy = new SettingsCommand("GeneralSettings", "Privacy Policy",
                async (cmd) =>
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("1. A member account is required to use this application. Awful does not store your account information, and will not ban your account on Something Awful.");
                    builder.AppendLine(string.Empty);
                    builder.AppendLine("2. Awful does not collect or use any of your personal information.");
                    MessageDialog dialog = new MessageDialog(builder.ToString(), "Privacy Policy");
                    await dialog.ShowAsync();
                });

            return privacy;
        }

        private void OnNetworkDetectionMessage(INotification<NetworkDetectionMessage> obj)
        {
            var netProfile = NetworkInformation.GetInternetConnectionProfile();
            obj.Value.IsNetworkActive = netProfile != null;
        }

        private void OnToastMessage(INotification<ToastMessage> obj)
        {
            AwfulNET.RT.Common.ToastGenerator.ShowToast(obj.Value.Message);
        }

        private async void OnDialogMessage(INotification<DialogMessage> obj)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(obj.Value.Message, obj.Value.Caption);
            await dialog.ShowAsync();
        }

        private async void OnConfirmDialogMessage(INotification<ConfirmDialogMessage> obj)
        {
            string message = obj.Value.Message;
            string caption = obj.Value.Caption;

            bool result = false;
            var dialog = new Windows.UI.Popups.MessageDialog(message, caption);
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK", (cmd) => { result = true; }));
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel", (cmd) => { result = false; }));
            await dialog.ShowAsync();
            obj.Value.Confirm(result);
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            if (CurrentAccount == null)
                CurrentAccount = await UserContext.LoadCurrentUser(SettingsModelFactory.GetSettingsModel());

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Load a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                //rootFrame.Navigate(typeof(MainPage), e.Arguments);

                // should we go to the login page, or our start page?
                Func<bool> navToLogin = new Func<bool>(() => { return rootFrame.Navigate(typeof(MainPage), string.Empty); });
                Func<bool> navToHome = new Func<bool>(() => { return rootFrame.Navigate(typeof(ClassicPage), string.Empty); });
                Func<bool> nav = SignInDataModel.IsSignedIn() ? navToHome : navToLogin;
                nav();
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            
            // save user db
            UserContext.SaveChanges(CurrentAccount, SettingsModelFactory.GetSettingsModel());

            deferral.Complete();
        }
    }
}
