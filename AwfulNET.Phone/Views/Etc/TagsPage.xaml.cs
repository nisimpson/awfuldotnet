using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AwfulNET.Phone
{
    public partial class TagsPage : PhoneApplicationPage
    {
        public TagsPage()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TagSelector_TagSelected(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}