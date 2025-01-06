using CountEZ.Core.Contracts;
using CountEZ.Models;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace CountEZ.Core.Services
{
    public class SystemService : ISystemService
    {
        private string? contentType;

        public SystemService()
        { }

        public void OpenInWebBrowser(string url)
        {
            // For more info see https://github.com/dotnet/corefx/issues/10361
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        public void OpenWebSearch(string searchRequest)
        {
            OpenInWebBrowser("http://www.google.com.au/search?q=" + Uri.EscapeDataString(searchRequest));
        }

        /// <summary>
        /// Return a Google map URL.
        /// </summary>
        /// <param name="query">the query. If it begins with "loc:" then its latitude+longitude. Otherwise it's something like an address or place name.</param>
        /// <param name="map_type">map type</param>
        /// <param name="zoom">the zoom level, usually 1 - 20</param>
        public string GoogleMapUrl(string query, GoogleMapType mapType, int zoom)
        {
            // Start with the base map URL.
            string url = "http://maps.google.com/maps?";

            // Add the query.
            url += "q=" + HttpUtility.UrlEncode(query, Encoding.UTF8);

            // Add the type.
            var map_type = GoogleMapTypeCode(mapType);
            if (map_type != null) url += "&t=" + map_type;

            // Add the zoom level.
            if (zoom > 0) url += "&z=" + zoom.ToString();

            return url;
        }

        /// <summary>
        /// Return a Google map type code.
        /// </summary>
        private string GoogleMapTypeCode(GoogleMapType mapType)
        {
            // Insert the proper type.
            return mapType switch
            {
                GoogleMapType.Map => "m",
                GoogleMapType.Satellite => "k",
                GoogleMapType.Hybrid => "h",
                GoogleMapType.Terrain => "p",
                GoogleMapType.Earth => "e",
                _ => "m",
            };
        }

        /// <summary>
        ///  Website may expect an User-Agent header, which .NET doesn't send by default.
        /// </summary>
        /// <returns></returns>
        private string GetUserAgentHeader()
            => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
    }
}