﻿using System.Windows.Input;

namespace CountEZ.Core.Base
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object>? _execute;
        private readonly Func<object, bool>? _canExecute;

        public RelayCommand(Action<object>? execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter) 
            => _execute(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
