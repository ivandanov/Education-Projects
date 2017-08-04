namespace Teleimot.WepApi.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    
    using Teleimot.DataServices.Contracts;
    using Teleimot.WepApi.Models;
    using Teleimot.Models;

    public class CommentsController : ApiController
    {
        private ICommentsDataService commentsDataService;
        private IUserDataService userDataService;

        public CommentsController(ICommentsDataService commentsDataService, IUserDataService userDataService)
        {
            this.commentsDataService = commentsDataService;
            this.userDataService = userDataService;
        }

        [Authorize]
        [Route("api/Comments/{id}")]
        public IHttpActionResult Get(int id, int skip = 0, int take = 10)
        {
            if (skip < 0 || take > 100)
            {
                return this.BadRequest();
            }

            var estates = this.commentsDataService
                .GetCommentsByRealStateId(id, skip, take)
                .AsQueryable()
                .ProjectTo<CommentModel>();

            return Ok(estates);
        }

        [Authorize]
        [Route("api/Comments/ByUser/{userName}")]
        public IHttpActionResult GetByUser(string userName, int skip = 0, int take = 10)
        {
            if (skip < 0 || take > 100)
            {
                return this.BadRequest();
            }

            var user = userDataService.GetUserByName(userName);
            if(user == null)
            {
                return this.NotFound();
            }

            var estates = this.commentsDataService
                .GetCommentsByUserId(user.Id, skip, take)
                .AsQueryable()
                .ProjectTo<CommentModel>()
                .ToList();

            return Ok(estates);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateComment(CommentInputModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            
            var userId = this.User.Identity.GetUserId();

            var newComment = this.commentsDataService.CreateComment(
                userId,
                model.RealEstateId,
                model.Content);

            var result = Mapper.Map<Comment, CommentModel>(newComment);

            return Ok(result);
        }
    }
}
