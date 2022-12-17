namespace RealEstateAd_3Tier_DAL.Contracts
{
    using RealEstateAd_3Tier_DAL.Entities.RealEstate;

    public interface IUnitOfWork
    {
        IGenericRepository<RealEstateAd> AdRepository { get; }
        void Save();
        void Dispose();
    }
}
