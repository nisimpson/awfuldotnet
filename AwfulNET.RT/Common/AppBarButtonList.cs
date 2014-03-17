using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AwfulNET.RT.Common
{
    public class AppBarButtonContainer
    {
        public List<ICommandBarElement> PrimaryCommands { get; set; }
        public List<ICommandBarElement> SecondaryCommands { get; set; }

        public AppBarButtonContainer()
        {
            PrimaryCommands = new List<ICommandBarElement>();
            SecondaryCommands = new List<ICommandBarElement>();
        }

    }
}
