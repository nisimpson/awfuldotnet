using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#if NETFX_CORE
using Windows.UI.Xaml;
#endif

namespace AwfulNET.Views
{
    public class LoadMoreItemsConverter : Common.CommonValueConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, Common.ILanguageInfo languageInfo)
        {
            IListViewModel list = value as IListViewModel;
            if (list != null)
            {
                if (targetType.Equals(typeof(Visibility)))
                    return ConvertToVisibility(list);

                else if (targetType.Equals(typeof(double)))
                    return ConvertToOpacity(list);

                else if (targetType.Equals(typeof(bool)))
                    return ConvertToBoolean(list);
            }

            return value;
        }

        private object ConvertToVisibility(IListViewModel list)
        {
            if (!list.HasMoreItems)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        private object ConvertToOpacity(IListViewModel list)
        {
            return list.HasMoreItems ? 1 : 0;
        }

        private object ConvertToBoolean(IListViewModel list)
        {
            if (list == null)
                return false;

            return list.HasMoreItems ? true : false;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, Common.ILanguageInfo languageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
