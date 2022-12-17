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

        public RealEstateAdController(IRealEstateAdService realEstateAdService)
        {
            _realEstateAdService = realEstateAdService;
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
        public ActionResult<RealEstateAd> GetById(int id) => 
            _realEstateAdService.GetById(id) 
                is RealEstateAd ad
                    ? Ok(ad)
                    : NotFound();
    }
}
