using CountEZ.Models;

namespace CountEZ.Core.Contracts
{
    internal interface IThemeService
    {
        AppTheme CurrentTheme { get; }

        void Initialize();

        void SetTheme(AppTheme theme);
    }
}
