using CountEZ.Models;

namespace CountEZ.Core.Contracts
{
    public interface ISystemService
    {
        void OpenInWebBrowser(string url);

        void OpenWebSearch(string searchTerm);

        string GoogleMapUrl(string query, GoogleMapType mapType, int zoom);
    }
}
