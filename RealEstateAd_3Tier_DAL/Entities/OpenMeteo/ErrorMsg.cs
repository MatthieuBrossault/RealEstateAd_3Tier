namespace RealEstateAd_3Tier_DAL.Entities.OpenMeteo
{
    using Newtonsoft.Json;

    public class ErrorMsg
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
