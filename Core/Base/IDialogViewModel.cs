namespace CountEZ.Core.Base
{
    public interface IDialogViewModel : IDisposable
    {
        event EventHandler RequestClose;

        bool IsAffirmative { get; set; }

        IDialogViewModel? PreviousDialog { get; set; }

        void OnRequestClose();
    }
}
