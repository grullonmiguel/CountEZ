using CommunityToolkit.Mvvm.Input;
using CountEZ.Core.Base;
using CountEZ.Models;
using System.Windows;
using System.Windows.Input;

namespace CountEZ.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        #region Commands

        public ICommand MinimizeCommand => new RelayCommand<object>(OnMinimize);
        public ICommand MaximizeCommand => new RelayCommand<object>(OnMaximize);
        public ICommand CloseCommand => new RelayCommand<object>(OnClose);
        public ICommand ViewCommand => new RelayCommand<ActivePageType>(UpdateView);

        #endregion

        #region Properties

        public ActivePageType ActivePage
        {
            get => _activePage;
            set => SetProperty(ref _activePage, value);
        }
        private ActivePageType _activePage;

        #endregion

        #region Constructor

        public ShellViewModel()
        {
            ActivePage = ActivePageType.Welcome;
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

        private void UpdateView(ActivePageType activePage)
            => ActivePage = activePage;

        #endregion
    }
}