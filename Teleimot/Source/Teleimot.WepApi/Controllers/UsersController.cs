namespace Teleimot.WepApi.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using Microsoft.AspNet.Identity;

    using Teleimot.DataServices.Contracts;
    using Teleimot.Models;
    using Teleimot.WepApi.Models;

    public class UsersController : ApiController
    {
        private IUserDataService userDataService;

        public UsersController(IUserDataService userDataService)
        {
            this.userDataService = userDataService;
        }

        [AllowAnonymous]
        [Route("api/Users/{userName}")]
        public IHttpActionResult GetUser(string userName)
        {
            var user = this.userDataService.GetUserByName(userName);
            if(user == null)
            {
                return NotFound();
            }

            var result = Mapper.Map<User, UserModel>(user);

            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [Route("api/Users/Rate")]
        public IHttpActionResult RateUser(RateInput model)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            if (userId == model.UserId)
            {
                return BadRequest("Users cannot rate themselves");
            }

            this.userDataService.RateUser(userId, model.UserId, model.Value);

            return Ok();
        }
    }
}
