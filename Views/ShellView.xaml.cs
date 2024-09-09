using Microsoft.Extensions.DependencyInjection;
using CountEZ.ViewModels;
using System.Windows;

namespace CountEZ.Views
{
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<ShellViewModel>();
        }
    }
}
