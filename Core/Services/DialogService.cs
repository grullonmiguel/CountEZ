using CountEZ.Core.Base;
using CountEZ.Core.Contracts;

namespace CountEZ.Core.Services
{
    public class DialogService : IDialogService
    {
        private IDialogViewModel? _currentDialogViewModel;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0, 2);

        public event Action<bool>? OnCloseDialog;
        public event Action<IDialogViewModel, bool>? OnDisplayDialog;

        public bool IsShowing { get; set; }

        public void CloseDialog(bool isModal = false)
        {
            IsShowing = false;
            OnCloseDialog?.Invoke(isModal);
        }

        public void ShowDialog(IDialogViewModel dialogViewModel, bool isModal = false)
        {
            IsShowing = true;
            _currentDialogViewModel = dialogViewModel;
            _currentDialogViewModel.RequestClose += RequestCloseSync;

            OnDisplayDialog?.Invoke(dialogViewModel, isModal);
        }

        public async Task<bool> ShowDialogAsync(IDialogViewModel dialogViewModel, bool isModal = false)
        {
            _currentDialogViewModel = dialogViewModel;
            _currentDialogViewModel.RequestClose += RequestCloseAsync;

            OnDisplayDialog?.Invoke(dialogViewModel, isModal);

            await _semaphoreSlim.WaitAsync();

            return dialogViewModel.IsAffirmative;
        }

        private void RequestCloseSync(object? sender, EventArgs e)
        {
            _currentDialogViewModel!.RequestClose -= RequestCloseSync;
            CloseDialog();
        }

        private void RequestCloseAsync(object? sender, EventArgs e)
        {
            Close();
        }

        private void Close()
        {
            _currentDialogViewModel!.RequestClose -= RequestCloseAsync;
            _semaphoreSlim.Release();
            CloseDialog();
        }
    }
}
