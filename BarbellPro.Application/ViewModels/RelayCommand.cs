using System;
using System.Windows.Input;

namespace BarbellPro.Application.ViewModels
{
    public class RelayCommand : ICommand
    {
        // Fields
        private readonly Action<object> _execute; 
        private readonly Predicate<object>? _canExecute; 

        // Constructor
        public RelayCommand(Action<object> executeAction)
        {
            _execute = executeAction;
            _canExecute = null;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Events
        public event EventHandler? CanExecuteChanged
        {
            // Subscribe or unsubscribe the required suggested event as needed
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Methods
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
