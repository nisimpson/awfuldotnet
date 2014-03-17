using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public partial class HtmlTextBoxControl : UserControl
    {
        private bool isDomReady = false;

        public HtmlTextBoxControl()
        {

            InitializeComponent();
            this.PART_Browser.IsScriptEnabled = true;
            this.PART_Browser.Navigating += PART_Browser_Navigating;
            this.PART_Browser.NavigationFailed += PART_Browser_NavigationFailed;
            this.PART_Browser.ScriptNotify += PART_Browser_ScriptNotify;
            this.PART_Browser.Navigate(new Uri("/Common/HtmlTextBox/htmltextbox.html", UriKind.RelativeOrAbsolute));
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
            base.OnKeyDown(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            this.SyncText();
            base.OnLostFocus(e);
        }

        void PART_Browser_ScriptNotify(object sender, NotifyEventArgs e)
        {
            switch (e.Value)
            {
                case "domready":
                    isDomReady = true;
                    Task.Delay(100).ContinueWith(
                        task => { this.UpdateText(this.Text); }, 
                        TaskScheduler.FromCurrentSynchronizationContext());
                    break;

                default:
                    // don't do any unnecessary binding if values are equal.
                    string text = GetValue(TextProperty) as string;
                    if (text != e.Value)
                        SetValue(TextProperty, e.Value);
                    break;
            }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(HtmlTextBoxControl),
            new PropertyMetadata(string.Empty, OnTextPropertyChanged));

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HtmlTextBoxControl control = d as HtmlTextBoxControl;
            string newValue = e.NewValue as string;
            if (e.NewValue != e.OldValue)
                control.UpdateText(newValue == null ? string.Empty : newValue);
        }

        public string Text
        {
            get { return this.GetValue(TextProperty) as string; }
            set { this.SetValue(TextProperty, value); }
        }

        string htmlText = string.Empty;

        void PART_Browser_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void PART_Browser_Navigating(object sender, NavigatingEventArgs e)
        {
            Debug.WriteLine("Navigating to " + e.Uri.ToString());
        }

        public bool SyncText()
        {
            if (this.isDomReady)
            {
                try
                {
                    string value = this.PART_Browser.InvokeScript("getText") as string;
                    this.Text = value;
                    return true;
                }
                catch (Exception) { }
            }
            return false;
        }

        private void UpdateText(string text)
        {
            if (this.isDomReady)
                this.PART_Browser.InvokeScript("setText", text);
        }
    }
}
