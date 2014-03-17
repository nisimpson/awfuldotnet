using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Runtime.CompilerServices;

namespace AwfulNET.Common
{
    public abstract class BindableTable : BindableBase
    {
        protected bool SetEntityRef<T>(ref EntityRef<T> entity,
            T value,
            Action updateIdentity,
            [CallerMemberName] string propertyName = null)
            where T : class
        {
            if (object.Equals(entity.Entity, value)) return false;

            OnPropertyChanging(propertyName);
            entity.Entity = value;

            if (value != null)
            {
                updateIdentity();
            }

            OnPropertyChanging(propertyName);
            return true;
        }
    }
}
