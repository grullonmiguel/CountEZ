using CountEZ.ViewModels;
using CountEZ.Views;
using System.Windows;

namespace CountEZ
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var view = new ShellView { DataContext = new ShellViewModel() };
            view.ShowDialog();
        }
    }

}
