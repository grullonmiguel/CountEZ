﻿using System.Windows.Input;

namespace CountEZ.Core.Base
{
    internal class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        #endregion

        #region Constructor

        public RelayCommand(Action execute) : this(execute, null)
        { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new NullReferenceException("Execute");
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Methods

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) 
            => _canExecute == null ? true : _canExecute();

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        #endregion
    }
}
