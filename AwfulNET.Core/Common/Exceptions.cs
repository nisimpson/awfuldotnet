using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
   public sealed class BannedAccountException : Exception
   {
       public BannedAccountException(string message) : base(message) { }
       public BannedAccountException(Exception inner) : base("This account has been banned.", inner) { }
   }
}
