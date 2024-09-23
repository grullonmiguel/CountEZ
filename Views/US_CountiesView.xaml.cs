using CountEZ.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CountEZ.Views
{
    public partial class US_CountiesView : UserControl
    {
        public US_CountiesView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<US_CountiesViewModel>();
        }
    }
}
