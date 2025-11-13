using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneSystemApp
{
    public class PhoneCallCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<PhoneSystem> mAction;

        public PhoneCallCommand(Action<PhoneSystem> action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction.Invoke(parameter as PhoneSystem);
        }
    }
}
