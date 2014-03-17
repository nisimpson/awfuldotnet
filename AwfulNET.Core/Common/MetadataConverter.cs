
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwfulNET.Core.Common
{
    public abstract class HtmlConverter<T>
    {
        public abstract string ConvertToHtml(T item);
    }
}