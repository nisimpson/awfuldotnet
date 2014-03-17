using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using AwfulNET.Views;

namespace AwfulNET.Common
{
    public partial class PageNavigator : UserControl
    {
        private PageNavigatorViewModel viewmodel;
        public PageNavigatorViewModel ViewModel { get { return this.viewmodel; } }
        public PageNavigator()
        {
            InitializeComponent();
            this.viewmodel = new PageNavigatorViewModel();
            this.DataContext = this.viewmodel;
        }
    }

    public sealed class PageNavigatorViewModel : BindableBase
    {
        private int maxValue = 1;
        private const int minValue = 1;
        private int currentValue = 1;
        private ICommand cancelCommand;
        private RelayCommand okCommand;
        private RelayCommand firstCommand;
        private RelayCommand lastCommand;
        private RelayCommand incrementCommand;
        private RelayCommand decrementCommand;
        private IProgress<string> progress;
        private IPaginationViewModelWithProgress<string> pagination;
        private IApplicationPage page;

        public PageNavigatorViewModel()
        {
            this.okCommand = new RelayCommand(NavigateToCurrentPage, CanNavigateToCurrentPage);
            this.incrementCommand = new RelayCommand(IncrementCurrentValue, CanIncrementCurrentValue);
            this.decrementCommand = new RelayCommand(DecrementCurrentValue, CanDecrementCurrentValue);
            this.firstCommand = new RelayCommand(SetCurrentValueToFirst);
            this.lastCommand = new RelayCommand(SetCurrentValueToLast);
        }

        private void SetCurrentValueToLast()
        {
            this.CurrentValue = this.maxValue;
        }

        private void SetCurrentValueToFirst()
        {
            this.CurrentValue = minValue;
        }

        public void SetNavigable(IPaginationViewModelWithProgress<string> pagination, 
            IProgress<string> progress,
            IApplicationPage page)
        {
            this.progress = progress;
            this.pagination = pagination;
            this.page = page;
            this.maxValue = pagination.LastPage;
            this.CurrentValue = pagination.CurrentPage.Value;
        }

        private bool CanDecrementCurrentValue()
        {
            if (this.pagination == null)
                return false;

            return this.currentValue > minValue;
        }

        private void DecrementCurrentValue()
        {
            this.CurrentValue = this.CurrentValue - 1;
        }

        private void IncrementCurrentValue()
        {
            this.CurrentValue = this.CurrentValue + 1;
        }

        private bool CanIncrementCurrentValue()
        {
            if (this.pagination == null)
                return false;

            return this.CurrentValue < this.maxValue;
        }

        private bool CanNavigateToCurrentPage()
        {
            return (this.pagination != null &&
                this.pagination.LastPage >= this.CurrentValue);
        }

        private async void NavigateToCurrentPage()
        {
            if (CancelCommand != null)
                CancelCommand.Execute(null);

            await this.pagination.GoToPageAsync(this.CurrentValue, this.page, this.progress);
        }

        public int CurrentValue
        {
            get { return this.currentValue; }
            set
            {
                if (this.SetProperty(ref this.currentValue, value))
                {
                    decrementCommand.RaiseCanExecuteChanged();
                    incrementCommand.RaiseCanExecuteChanged();
                    okCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand CancelCommand
        {
            get { return this.cancelCommand; }
            set { SetProperty(ref this.cancelCommand, value); }
        }

        public ICommand OkCommand
        {
            get { return this.okCommand; }
        }

        public ICommand FirstCommand
        {
            get { return this.firstCommand; }
        }

        public ICommand LastCommand
        {
            get { return this.lastCommand; }
        }

        public ICommand IncrementCommand
        {
            get { return this.incrementCommand; }
        }

        public ICommand DecrementCommand
        {
            get { return this.decrementCommand; }
        }
    }
}
