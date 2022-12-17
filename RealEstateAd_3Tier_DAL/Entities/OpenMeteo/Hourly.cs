namespace RealEstateAd_3Tier_DAL.Entities.OpenMeteo
{
    using Newtonsoft.Json;

    public class Hourly
    {
        [JsonProperty("time")]
        public string[] Time { get; set; }

        [JsonProperty("temperature_2m")]
        public double[] Temperature2M { get; set; }
    }
}
