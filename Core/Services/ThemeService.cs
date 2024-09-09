using CountEZ.Core.Contracts;
using CountEZ.Core.Helpers;
using CountEZ.Models;
using CountEZ.Properties;
using System.Windows;

namespace CountEZ.Core.Services
{
    internal class ThemeService : IThemeService
    {
        private const string DarkTheme = "pack://application:,,,/Styles/Themes/Dark.xaml";
        private const string LightTheme = "pack://application:,,,/Styles/Themes/Light.xaml";
        private const string MainStyle = "pack://application:,,,/Styles/Styles.xaml";

        public AppTheme CurrentTheme { get; private set; }

        private ResourceDictionary ThemeDictionary
        {
            get => Application.Current.Resources.MergedDictionaries[0];
            set => Application.Current.Resources.MergedDictionaries[0] = value;
        }

        public ThemeService()
        { }

        public void Initialize()
        {
            // Get the curret theme from local settings
            var theme = Settings.Default.ThemeName;

            // Default to dark theme if settings not found
            theme ??= AppTheme.Dark.ToString();

            // Convert to AppTheme and save
            SetTheme(theme.ToEnum<AppTheme>());
        }

        public void SetTheme(AppTheme theme)
        {
            CurrentTheme = theme;

            // Update Dictionary
            ThemeDictionary = new ResourceDictionary() {Source = new Uri(DarkTheme) };
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(MainStyle) });

            // Save theme name to local settings file
            Settings.Default.ThemeName = CurrentTheme.ToString();
            Settings.Default.Save();
        }
    }
}