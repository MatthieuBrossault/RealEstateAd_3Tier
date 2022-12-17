namespace RealEstateAd_3Tier.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RealEstateAd_3Tier_BLL.Contracts;
    using RealEstateAd_3Tier_DAL.Entities.RealEstate;

    [Route("api/ad")]
    [ApiController]
    public class RealEstateAdController : ControllerBase
    {
        private readonly IRealEstateAdService _realEstateAdService;
        private readonly IOpenMeteoService _openMeteoService;

        public RealEstateAdController(IRealEstateAdService realEstateAdService, IOpenMeteoService openMeteoService)
        {
            _realEstateAdService = realEstateAdService;
            _openMeteoService = openMeteoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RealEstateAd> Create(RealEstateAd ad)
        {
            var adid = _realEstateAdService.Create(ad);
            return CreatedAtAction(nameof(GetById), new { id = adid }, ad);
        }

        [HttpPut("{id}")]
        public ActionResult Publish(int id)
        {
            _realEstateAdService.Publish(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var ad = _realEstateAdService.GetById(id);

            if (ad is RealEstateAd)
            {
                var forecast = _openMeteoService.GetForecast(ad.Location.Latitude, ad.Location.Longitude, new[] { "temperature_2m" });

                return Ok(new {ad, forecast });
            }
            
            return NotFound();
        }           
    }
}
