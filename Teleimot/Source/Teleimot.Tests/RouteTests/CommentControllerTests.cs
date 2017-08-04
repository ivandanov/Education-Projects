namespace Teleimot.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Teleimot.WepApi.Controllers;
    
    [TestClass]
    public class CommentControllerTests
    {
        [TestMethod]
        public void GetByUserShouldMapToCorrectActionWithNoParameters()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Comments/ByUser/test")
                .To<CommentsController>(c => c.GetByUser("test", 0, 10));
        }

        [TestMethod]
        public void GetByUserShouldMapToCorrectActionWhitSkipParameter()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Comments/ByUser/test?skip=2")
                .To<CommentsController>(c => c.GetByUser("test", 2, 10));
        }

        [TestMethod]
        public void GetByUserShouldMapToCorrectActionWhitTakeParameter()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Comments/ByUser/test?take=10")
                .To<CommentsController>(c => c.GetByUser("test", 0, 10));
        }

        [TestMethod]
        public void GetByUserShouldMapToCorrectActionWhitAllParameter()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Comments/ByUser/test?skip=2&take=5")
                .To<CommentsController>(c => c.GetByUser("test", 2, 5));
        }
    }

}
