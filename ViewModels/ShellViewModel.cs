using CommunityToolkit.Mvvm.Input;
using CountEZ.Core.Base;
using CountEZ.Core.Contracts;
using CountEZ.Models;
using System.Windows;
using System.Windows.Input;

namespace CountEZ.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        #region Fields

        private readonly IDialogService _dialogService;

        #endregion

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

        public IDialogViewModel CurrentDialogViewModel
        {
            get => _currentDialogViewModel;
            set => SetProperty(ref _currentDialogViewModel, value);
        }
        private IDialogViewModel _currentDialogViewModel;

        public bool IsDialogVisible
        {
            get => _isDialogVisible;
            set => SetProperty(ref _isDialogVisible, value);
        }
        private bool _isDialogVisible;

        #endregion

        #region Constructor

        public ShellViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _dialogService.OnDisplayDialog += DisplayDialog;
            _dialogService.OnCloseDialog += CloseDialog;
            ActivePage = ActivePageType.US_States;
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

        private void DisplayDialog(IDialogViewModel viewModel, bool isModal = false)
        {
            if (CurrentDialogViewModel != null)
            {
                viewModel.PreviousDialog = CurrentDialogViewModel;
            }

            CurrentDialogViewModel = viewModel;

            IsDialogVisible = true;
        }

        private void CloseDialog(bool isModal = false)
        {
            if (CurrentDialogViewModel != null)
            {
                if (CurrentDialogViewModel.PreviousDialog == null)
                {
                    CurrentDialogViewModel.Dispose();
                    CurrentDialogViewModel = null;
                    IsDialogVisible = false;
                }
                else
                {
                    CurrentDialogViewModel = CurrentDialogViewModel.PreviousDialog;
                }
            }
        }

        #endregion
    }
}