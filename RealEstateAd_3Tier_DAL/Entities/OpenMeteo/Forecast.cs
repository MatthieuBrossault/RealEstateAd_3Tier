namespace RealEstateAd_3Tier_DAL.Entities.OpenMeteo
{
    using Newtonsoft.Json;

    public class Forecast
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        [JsonProperty("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        [JsonProperty("utc_offset_seconds")]
        public long UtcOffsetSeconds { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }

        [JsonProperty("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
