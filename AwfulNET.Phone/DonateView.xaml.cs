using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AwfulNET.Common;
using Windows.ApplicationModel.Store;

namespace AwfulNET.Phone
{
    public partial class DonateView : PhoneApplicationPage
    {
        private const string DOLLAR_DONATE_ID = "10000";

        public DonateView()
        {
            InitializeComponent();
        }

        private async void donateButton_Click(object sender, RoutedEventArgs e)
        {
            var progress = IProgressFactory.GenerateProgressToken();
            try
            {
                progress.Report("Please wait...");
                var listing = await CurrentApp.LoadListingInformationAsync();
                var dollarDonate = listing.ProductListings.FirstOrDefault(item => item.Value.ProductId.Equals(DOLLAR_DONATE_ID));
                var receipt = await CurrentApp.RequestProductPurchaseAsync(dollarDonate.Value.ProductId, true);

                if (CurrentApp.LicenseInformation.ProductLicenses[dollarDonate.Value.ProductId].IsActive)
                {
                    CurrentApp.ReportProductFulfillment(dollarDonate.Value.ProductId);
                    MessageBox.Show("Donation complete. Thanks again!", "Success!", MessageBoxButton.OK);
                }
            }
            catch (Exception) 
            { 
                MessageBox.Show(
                    "Could not complete the donation process at this time. Please try again later.",
                    "Oops! Something went wrong.", 
                    MessageBoxButton.OK); 
            }
            finally { progress.Report(null); }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}