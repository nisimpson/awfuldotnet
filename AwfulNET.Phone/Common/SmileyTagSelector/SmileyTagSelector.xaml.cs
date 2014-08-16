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
using AwfulNET.DataModel;
using System.Windows.Input;

namespace AwfulNET.Phone.Common
{
    public partial class SmileyTagSelector : UserControl
    {
        public event EventHandler TagSelected;

        private SmileyTagSelectorViewModel context;
        public SmileyTagSelector()
        {
            InitializeComponent();
            this.MainPivot.SelectionChanged += MainPivot_SelectionChanged;
            context = this.LayoutRoot.DataContext as SmileyTagSelectorViewModel;
        }

        private async void MainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivot = sender as Pivot;
            var selected = pivot.SelectedItem as PivotItem;
            if (selected != null && selected.DataContext is SmileyTagGroup)
                await context.Smilies.OnSelectedAsync(this, IProgressFactory.GenerateProgressToken());
        }

        private void SelectTag(object value)
        {
            CodeTagDataModel item = value as CodeTagDataModel;
            if (value != null)
            {
                // copy code to clipboard
                Clipboard.SetText(item.Code);

                // notify event listeners that we selected an item
                var handler = TagSelected;
                if (handler != null)
                    TagSelected(this, EventArgs.Empty);
            }
        }

        private void OnSelectItemCommandExecute(object sender, ExecuteEventArgs args)
        {
            SelectTag(args.Parameter);
        }

        private void OnSearchCommandExecuteRaised(object sender, ExecuteEventArgs args)
        {
            string text = args.Parameter as string;
            context.Smilies.ItemsSource = context.Smilies.Filter(text);
        }
    }

    public sealed class SmileyTagSelectorViewModel : BindableBase
    {
        private static readonly SmileyTagGroup smilies = new SmileyTagGroup();
        public SmileyTagGroup Smilies { get { return smilies; } }

        public string Title { get { return "select to copy code"; } }
    }
}
