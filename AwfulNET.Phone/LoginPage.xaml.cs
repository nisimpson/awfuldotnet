using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AwfulNET.DataModel;
using AwfulNET.Common;
using AwfulNET.Data;

namespace AwfulNET.Phone
{
    public partial class LoginPage : PhoneApplicationPage
    {
        SignInDataModel datamodel;
        bool isNewInstance = false;
        public LoginPage()
        {
            InitializeComponent();
            datamodel = new SignInDataModel(App.UserContext, NavigateToMainPage, NotifyAndTryAgain);

            this.DataContext = datamodel;
            this.isNewInstance = true;
        }

        private void NotifyAndTryAgain(Exception ex)
        {
            MessageBox.Show("Please try again.", "Login Failed.", MessageBoxButton.OK);
        }

        private void NavigateToMainPage(UserAccount account)
        {
            if (account != null)
                App.CurrentAccount = account;
            
            this.NavigationService.Navigate(new Uri("/PivotView.xaml", UriKind.RelativeOrAbsolute));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.isNewInstance)
            {
                bool isSignedIn = SignInDataModel.IsSignedIn();
                if (isSignedIn)
                    NavigateToMainPage(null);
                else
                {
                    this.ContentPanel.Visibility = System.Windows.Visibility.Visible;
                }

                this.isNewInstance = false;
            }
        }

        private void publicForumsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(SignInDataModel.DISCLAIMER, SignInDataModel.DISCLAIMER_CAPTION, 
                MessageBoxButton.OKCancel)
                == MessageBoxResult.OK)
            {
                var pubAcct = App.UserContext.LoadCurrentUser(SettingsModelFactory.GetSettingsModel());
                this.NavigateToMainPage(pubAcct);
            }
        }
    }
}