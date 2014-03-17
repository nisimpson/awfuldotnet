using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.Common
{
    public delegate void CanExecuteRaisedEventHandler(object sender, CanExecuteEventArgs args);
    public delegate void ExecuteRaisedEventHandler(object sender, ExecuteEventArgs args);

    public class EventCommand : HaltableCommand
    {
        public event ExecuteRaisedEventHandler ExecuteRaised;
        public event CanExecuteRaisedEventHandler CanExecuteRaised;

        private void OnExecuteRaised(object parameter)
        {
            var handler = ExecuteRaised;
            if (handler != null)
                handler(this, new ExecuteEventArgs(parameter));
        }

        private bool OnCanExecuteRaised(object parameter)
        {
            bool canExecute = true;
            var handler = CanExecuteRaised;
            if (handler != null)
            {
                var args = new CanExecuteEventArgs(parameter);
                handler(this, args);
                canExecute = args.CanExecute;
            }

            return canExecute;
        }
        
        public override bool CanExecute(object parameter)
        {
            return OnCanExecuteRaised(parameter);
        }

        protected override void OnExecute(object parameter)
        {
            OnExecuteRaised(parameter);
        }
    }

    public class CanExecuteEventArgs : EventArgs
    {
        public object Parameter { get; private set; }
        public bool CanExecute { get; set; }
        public CanExecuteEventArgs(object parameter)
        {
            this.CanExecute = true;
            this.Parameter = parameter;
        }
    }

    public class ExecuteEventArgs : EventArgs
    {
        public object Parameter { get; private set; }
        public ExecuteEventArgs(object parameter)
        {
            this.Parameter = parameter;
        }
    }
}
