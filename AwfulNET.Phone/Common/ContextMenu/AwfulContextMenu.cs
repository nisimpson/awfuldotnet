using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.Common
{
    public interface IContextMenu
    {
        IList<IContextMenuItem> Items { get; }
    }

    public interface IContextMenuItem
    {
        string Icon { get; set; }
        string Header { get; set; }
        ICommand Command { get; set; }
        object CommandParameter { get; set; }
    }

    public class AwfulContextMenu : BindableBase, IContextMenu
    {
        private List<IContextMenuItem> items = new List<IContextMenuItem>();
        public IList<IContextMenuItem> Items
        {
            get { return this.items; }
        }
    }

    public class AwfulContextMenuItem : BindableBase, IContextMenuItem
    {
        private string icon = string.Empty;
        public string Icon
        {
            get { return this.icon; }
            set { SetProperty(ref this.icon, value); }
        }

        private string header = string.Empty;
        public string Header
        {
            get
            {
                return this.header;
            }
            set
            {
                SetProperty(ref this.header, value);
            }
        }

        private ICommand command;
        public ICommand Command
        {
            get
            {
                return this.command;
            }
            set
            {
                SetProperty(ref this.command, value);
            }
        }

        private object commandParameter = null;
        public object CommandParameter
        {
            get { return this.commandParameter; }
            set { SetProperty(ref this.commandParameter, value); }
        }
    }
}
