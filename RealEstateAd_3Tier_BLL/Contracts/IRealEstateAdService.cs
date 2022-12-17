namespace RealEstateAd_3Tier_BLL.Contracts
{
    using RealEstateAd_3Tier_DAL.Entities.RealEstate;

    public interface IRealEstateAdService
    {
        public int Create(RealEstateAd ad);
        void Publish(int adId);
        RealEstateAd? GetById(int adId);
    }
}
