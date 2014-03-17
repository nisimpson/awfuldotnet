using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.Common
{
    public delegate void ExecutingEventHandler(object sender, ExecutingEventArgs args);

    public abstract class HaltableCommand : ICommand
    {
        public event ExecutingEventHandler Executing;

        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            var handler = Executing;
            bool cancel = false;
            if (handler != null)
            {
                var args = new ExecutingEventArgs(OnExecute, parameter);
                handler(this, args);
                cancel = args.Cancel;
            }

            if (!cancel)
                OnExecute(parameter);
        }

        protected abstract void OnExecute(object parameter);
    }

    public sealed class ExecutingEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public Action<object> ExecutionAction { get; private set; }
        public object ExecutionParameter { get; private set; }

        public ExecutingEventArgs(Action<object> onExecute, object parameter)
        {
            this.Cancel = false;
            this.ExecutionParameter = parameter;
            this.ExecutionAction = onExecute;
        }
    }
}
