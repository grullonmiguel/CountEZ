using CountEZ.Core.Base;
using System.Windows;
using System.Windows.Input;

namespace CountEZ.ViewModels
{
    internal class ShellViewModel : Observable
    {
        #region Commands

        public ICommand MinimizeCommand => new RelayCommand(OnMinimize);
        public ICommand MaximizeCommand => new RelayCommand(OnMaximize);
        public ICommand CloseCommand => new RelayCommand(OnClose);

        #endregion

        #region Constructor

        public ShellViewModel()
        {
            
        }

        #endregion

        #region Methods

        private void OnMinimize(object parameter)
        {
            if (parameter is Window window)
                window.WindowState = WindowState.Minimized;
        }

        private void OnMaximize(object parameter)
        {
            if (parameter is Window window)
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void OnClose(object parameter)
        {
            if (parameter is Window window)
                window.Close();
        }

        #endregion
    }
}