using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    public class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> _equals;
        private Func<T, int> _hashCode;

        public GenericEqualityComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
        {
            if (equals == null)
                throw new ArgumentNullException("equals");
            this._equals = equals;

            if (hashCode == null)
                throw new ArgumentNullException("hashCode");
            this._hashCode = hashCode;
        }

        public bool Equals(T x, T y)
        {
            return _equals(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _hashCode(obj);
        }
    }
}
