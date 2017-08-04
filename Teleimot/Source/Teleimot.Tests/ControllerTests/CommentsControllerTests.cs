namespace Teleimot.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http.Results;
    using Teleimot.DataServices.Contracts;
    using Teleimot.WepApi.Controllers;
    using Teleimot.WepApi.Models;

    [TestClass]
    public class CommentsControllerTests
    {
        private TestObjectFactory objectFactory;
        private ICommentsDataService commentService;
        private IUserDataService userService;

        [TestInitialize]
        public void Init()
        {
            this.objectFactory = new TestObjectFactory();
            this.commentService = objectFactory.GetCommentsService();
            this.userService = objectFactory.GetUserService();
        }

        [TestMethod]
        public void GetByUserShouldReturnOkResultWithThreeComments()
        {
            var controller = new CommentsController(this.commentService, this.userService);

            var result = controller.GetByUser("test");
            var okResult = result as OkNegotiatedContentResult<List<CommentModel>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(3, okResult.Content.Count);
        }

        [TestMethod]
        public void GetByUserShouldReturnBadRequestOnInvalidSkipeArgument()
        {
            var controller = new CommentsController(this.commentService, this.userService);
            controller.Request = new HttpRequestMessage();

            var result = controller.GetByUser("test", -1);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public void GetByUserShouldReturnBadRequestOnInvalidTakeArgument()
        {
            var controller = new CommentsController(this.commentService, this.userService);
            controller.Request = new HttpRequestMessage();

            var result = controller.GetByUser("test", 1, 1000);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }
    }
}
