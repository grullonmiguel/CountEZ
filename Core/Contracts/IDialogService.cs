using CountEZ.Core.Base;

namespace CountEZ.Core.Contracts
{
    public interface IDialogService
    {
        event Action<bool> OnCloseDialog;
        event Action<IDialogViewModel, bool> OnDisplayDialog;

        bool IsShowing { get; set; }

        void CloseDialog(bool isModal = false);

        void ShowDialog(IDialogViewModel dialogViewModel, bool isModal = false);

        Task<bool> ShowDialogAsync(IDialogViewModel dialogViewModel, bool isModal = false);
    }
}
