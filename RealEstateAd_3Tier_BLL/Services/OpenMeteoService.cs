namespace RealEstateAd_3Tier_BLL.Services
{
    using Microsoft.AspNetCore.WebUtilities;
    using Newtonsoft.Json;
    using RealEstateAd_3Tier_BLL.Contracts;
    using RealEstateAd_3Tier_DAL.Entities.OpenMeteo;
    using System.Globalization;

    public class OpenMeteoService : IOpenMeteoService
    {
        private readonly HttpClient _httpClient;

        public OpenMeteoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Forecast?> GetForecast(double latitude, double longitude, string[] hourly)
        {
            var uri = $"{_httpClient.BaseAddress}/forecast";

            var queryParams = new Dictionary<string, string>()
            {
                {"latitude", latitude.ToString(CultureInfo.GetCultureInfo("en-GB")) },
                {"longitude", longitude.ToString(CultureInfo.GetCultureInfo("en-GB")) },
            };

            uri = QueryHelpers.AddQueryString(uri, queryParams);

            foreach (var param in hourly)
            {
                uri = QueryHelpers.AddQueryString(uri, "hourly", param);
            }

            var responseString = await _httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<Forecast>(responseString);
        }
    }
}
