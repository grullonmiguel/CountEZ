using CountEZ.Core.Contracts;
using CountEZ.Core.Services;
using CountEZ.ViewModels;
using CountEZ.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Threading;

namespace CountEZ
{
    public partial class App : Application
    {

        /// <summary>
        /// Gets the current <see cref="App"/> in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services
        /// </summary>
        public IServiceProvider? Services { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public App()
        {
            Services = ConfigureServices();
        }

        /// <summary>
        /// Configures the services for the application
        /// </summary>
        private static IServiceProvider? ConfigureServices()
        {
            var services = new ServiceCollection();

            // Core Services
            services.AddSingleton<IThemeService, ThemeService>();

            // Views/ViewModels
            services.AddTransient<ShellView>();
            services.AddTransient<ShellViewModel>();

            // Buid
            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Load current theme
            Current?.Services?.GetService<IThemeService>()?.Initialize();

            // Load the application's maiin window
            Current?.Services?.GetService<ShellView>()?.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Current.DispatcherUnhandledException += (s, e) =>
            {
                e.Handled = true;
            };
        }
    }
}