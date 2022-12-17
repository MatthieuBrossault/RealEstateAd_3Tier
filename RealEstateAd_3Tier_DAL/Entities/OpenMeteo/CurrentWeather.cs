namespace RealEstateAd_3Tier_DAL.Entities.OpenMeteo
{
    using Newtonsoft.Json;
    public class CurrentWeather
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("weathercode")]
        public long Weathercode { get; set; }

        [JsonProperty("windspeed")]
        public double Windspeed { get; set; }

        [JsonProperty("winddirection")]
        public long Winddirection { get; set; }
    }
}
