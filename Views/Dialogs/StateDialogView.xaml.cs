using CountEZ.Core.Helpers;
using System.Windows.Controls;

namespace CountEZ.Views.Dialogs
{
    public partial class StateDialogView : UserControl
    {
        public StateDialogView()
        {
            InitializeComponent();
            Loaded += async (o, e) =>
            {
                await root.SlideFrom(AnimationType.SlideFromTop, 0.3f);
                root.Margin = new System.Windows.Thickness(250);
            };
        }
    }
}
