using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Linq
{
    /// <summary>
    /// This interface is not available on the Windows RT platform.
    /// </summary>
    public interface INotifyPropertyChanging { }

    public delegate void PropertyChangingEventHandler(object sender, PropertyChangingEventArgs args);

    public sealed class PropertyChangingEventArgs : EventArgs
    {
        public PropertyChangingEventArgs(string propertyName) { }
    }
}
