namespace RealEstateAd_3Tier_DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using RealEstateAd_3Tier_DAL.Entities.RealEstate;

    public class RealEstateAdDb : DbContext
    {
        public RealEstateAdDb(DbContextOptions<RealEstateAdDb> options)
            : base(options) { }

        public DbSet<RealEstateAd> Ads => Set<RealEstateAd>();
    }
}
