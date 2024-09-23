using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CountEZ.Views
{
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
            //Loaded += OnViewLoaded;
        }

        private void OnViewLoaded(object sender, RoutedEventArgs e)
            => welcomeRoot.BeginAnimation(HeightProperty, SlideAnimation());

        private DoubleAnimation SlideAnimation()
            => new()
            {
                From = 0,
                To = ActualHeight,
                Duration = TimeSpan.FromSeconds(.3)
            };
    }
}
