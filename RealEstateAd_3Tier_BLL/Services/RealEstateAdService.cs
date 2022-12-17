namespace RealEstateAd_3Tier_BLL.Services
{
    using RealEstateAd_3Tier_BLL.Contracts;
    using RealEstateAd_3Tier_DAL.Contracts;
    using RealEstateAd_3Tier_DAL.Entities.Enums;
    using RealEstateAd_3Tier_DAL.Entities.RealEstate;

    public class RealEstateAdService : IRealEstateAdService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RealEstateAdService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(RealEstateAd ad)
        {
            _unitOfWork.AdRepository.Insert(ad);
            _unitOfWork.Save();

            return ad.Id;
        }

        public void Publish(int adId)
        {
            var ad = _unitOfWork.AdRepository.GetByID(adId);

            if (ad is not null && ad.PublicationStatus == PublicationStatus.WaitingValidation)
            {
                ad.PublicationStatus = PublicationStatus.Published;
                _unitOfWork.AdRepository.Update(ad);
                _unitOfWork.Save();
            }
        }

        public RealEstateAd? GetById(int adId)
        {
            var ad = _unitOfWork.AdRepository.GetByID(adId);

            if (ad is not null && ad.PublicationStatus == PublicationStatus.Published)
            {
                return ad;
            }

            return null;
        }
    }
}
