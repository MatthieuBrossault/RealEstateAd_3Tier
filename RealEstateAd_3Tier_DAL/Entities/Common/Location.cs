namespace RealEstateAd_3Tier_DAL.Entities.Common
{
    using Microsoft.EntityFrameworkCore;

    [Owned]
    public class Location
    {
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; } = 52.52;
        public double Longitude { get; set; } = 13.41;
    }
}
