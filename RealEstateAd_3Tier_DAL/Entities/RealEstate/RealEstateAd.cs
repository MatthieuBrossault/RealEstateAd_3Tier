namespace RealEstateAd_3Tier_DAL.Entities.RealEstate
{
    using RealEstateAd_3Tier_DAL.Entities.Common;
    using RealEstateAd_3Tier_DAL.Entities.Enums;

    public class RealEstateAd
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Location Location { get; set; } = new Location();
        public PropertyType PropertyType { get; set; }
        public PublicationStatus PublicationStatus { get; set; }
    }
}
