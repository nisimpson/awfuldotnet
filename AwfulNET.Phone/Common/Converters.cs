using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public sealed class SortStyleTextConverter : CommonValueConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            if (value is AwfulNET.DataModel.BookmarkDataGroup.SortStyle)
            {
                switch((AwfulNET.DataModel.BookmarkDataGroup.SortStyle)value)
                {
                    case DataModel.BookmarkDataGroup.SortStyle.Awful:
                        return "awful style";

                    case DataModel.BookmarkDataGroup.SortStyle.Classic:
                        return "classic style";

                    default:
                        throw new InvalidOperationException("Unknown bookmark sort style: " + value);
                }
            }

            return value;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            throw new NotImplementedException();
        }
    }

}
