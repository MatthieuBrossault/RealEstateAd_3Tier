using RealEstateAd_3Tier_DAL.Entities.OpenMeteo;

namespace RealEstateAd_3Tier_BLL.Contracts
{
    public interface IOpenMeteoService
    {
        Task<Forecast?> GetForecast(double latitude, double longitude, string[] hourly);
    }
}
