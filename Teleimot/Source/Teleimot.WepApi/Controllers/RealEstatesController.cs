namespace Teleimot.WepApi.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Web.Http;
    using Teleimot.DataServices;
    using Teleimot.Models;
    using Teleimot.WepApi.Models;
    using Microsoft.AspNet.Identity;

    public class RealEstatesController : ApiController
    {
        private IRealEstatesDataService realEstatesDataService;

        public RealEstatesController(IRealEstatesDataService realEstatesDataService)
        {
            this.realEstatesDataService = realEstatesDataService;
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int skip = 0, int take = 10)
        {
            if (skip < 0 || take > 100)
            {
                return this.BadRequest();
            }

            var estates = this.realEstatesDataService
                .GetRealEstates(skip, take)
                .AsQueryable()
                .ProjectTo<RealEstateModel>();

            return Ok(estates);
        }

        [AllowAnonymous]
        [Route("api/RealEstates/{id}")]
        public IHttpActionResult GetDetails(int id)
        {
            var realEstate = this.realEstatesDataService.GetRealEstateDetails(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var isAuthenticated = this.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                var estate = Mapper.Map<RealEstate, RealEstatePrivateDetails>(realEstate);
                return Ok(estate);
            }
            else
            {
                var estate = Mapper.Map<RealEstate, RealEstatePublicDetails>(realEstate);
                return Ok(estate);
            }
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(RealStateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            var newRealEstate = this.realEstatesDataService.CreateRealEstate(
                userId,
                model.Title,
                model.Description,
                model.Address,
                model.Contact,
                model.ConstructionYear,
                model.SellingPrice,
                model.RentingPrice,
                model.Type
                );

            var result = Mapper.Map<RealEstate, RealEstateModel>(newRealEstate);

            return Ok(result);
        }
    }
}
