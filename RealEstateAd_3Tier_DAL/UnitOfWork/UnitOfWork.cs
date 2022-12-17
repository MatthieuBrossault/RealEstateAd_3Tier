namespace RealEstateAd_3Tier_DAL.UnitOfWork
{
    using RealEstateAd_3Tier_DAL.Contracts;
    using RealEstateAd_3Tier_DAL.Data;
    using RealEstateAd_3Tier_DAL.Entities.RealEstate;
    using RealEstateAd_3Tier_DAL.Repositories;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RealEstateAdDb _dbContext;
        private IGenericRepository<RealEstateAd> _adRepository;

        public UnitOfWork(RealEstateAdDb dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<RealEstateAd> AdRepository
        {
            get { return _adRepository = _adRepository ?? new GenericRepository<RealEstateAd>(_dbContext); }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
