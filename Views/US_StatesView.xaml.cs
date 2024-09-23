using CountEZ.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CountEZ.Views
{
    public partial class US_StatesView : UserControl
    {
        public US_StatesView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<US_StatesViewModel>();
        }
    }
}
