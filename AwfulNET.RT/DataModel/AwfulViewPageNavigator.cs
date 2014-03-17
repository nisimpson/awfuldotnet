using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AwfulNET.Views;
using AwfulNET.Common;

namespace AwfulNET.DataModel
{
    /// <summary>
    /// Binding class for IAwfulView Page navigation.
    /// </summary>
    public class AwfulViewPageNavigator : BindableBase
    {
        private int value;
        private const int minValue = 1;
        private int maxValue;
        private IPaginationViewModelWithProgress<string> navigable;
        private IProgress<string> progress;
        private object view;
        
        private RelayCommand firstPageCommand;
        private RelayCommand lastPageCommand;
        private RelayCommand incrementPageCommand;
        private RelayCommand decrementPageCommand;
        private RelayCommand okCommand;
      
        public int PageValue
        {
            get { return this.value; }
            set { SetProperty(ref this.value, value); }
        }

        public ICommand FirstPageCommand { get { return this.firstPageCommand; } }
        public ICommand LastPageCommand { get { return this.lastPageCommand; } }
        public ICommand IncrementPageCommand { get { return this.incrementPageCommand; } }
        public ICommand DecrementPageCommand { get { return this.decrementPageCommand; } }
        public ICommand OkCommand { get { return this.okCommand; } }



        public AwfulViewPageNavigator(object view, IProgress<string> progress, int startValue = 0, int maxValue = 0)
        {
            this.view = view;
            this.value = startValue;
            this.maxValue = maxValue;
            this.progress = progress;
            this.firstPageCommand = new RelayCommand(SetValueAsFirstPage, IsEnabled);
            this.lastPageCommand = new RelayCommand(SetValueAsLastPage, IsEnabled);
            this.incrementPageCommand = new RelayCommand(IncrementValue, IsEnabled);
            this.decrementPageCommand = new RelayCommand(DecrementValue, IsEnabled);
            this.okCommand = new RelayCommand(OnNavConfirm, IsEnabled);
        }

        private async void OnNavConfirm()
        {
            if (this.navigable != null)
                await this.navigable.GoToPageAsync(this.PageValue, this.view, this.progress);
        }

        public void SetNavigable(IPaginationViewModelWithProgress<string> navigable)
        {
            this.navigable = navigable;
            if (navigable != null)
            {
                this.PageValue = navigable.CurrentPage.GetValueOrDefault(AwfulViewPageNavigator.minValue);
                this.maxValue = navigable.LastPage;
            }

            this.firstPageCommand.RaiseCanExecuteChanged();
            this.lastPageCommand.RaiseCanExecuteChanged();
            this.incrementPageCommand.RaiseCanExecuteChanged();
            this.decrementPageCommand.RaiseCanExecuteChanged();
        }

        private bool IsEnabled()
        {
            return this.navigable != null;
        }

        private void DecrementValue()
        {
            int newValue = value - 1;
            this.PageValue = Math.Max(minValue, newValue);
        }

        private void IncrementValue()
        {
            int newValue = value + 1;
            this.PageValue = Math.Min(newValue, maxValue);
        }

        private void SetValueAsLastPage()
        {
            this.PageValue = maxValue;
        }

        private void SetValueAsFirstPage()
        {
            this.PageValue = minValue;
        }
    }
}
