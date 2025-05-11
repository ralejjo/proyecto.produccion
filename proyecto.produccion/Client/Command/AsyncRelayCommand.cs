using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class AsyncRelayCommand : ICommand
    {
        private Func<Task> _ExecuteAsync;
        private Func<bool> _CanExecuteAsync;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AsyncRelayCommand(Func<Task> executeAsync, Func<bool> canExecuteAsync)
        {
            _ExecuteAsync = executeAsync;
            _CanExecuteAsync = canExecuteAsync;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecuteAsync();
        }

        public void Execute(object parameter)
        {
            _ExecuteAsync();
        }
    }
}
