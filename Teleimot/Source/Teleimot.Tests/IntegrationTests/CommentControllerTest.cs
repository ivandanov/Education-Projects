namespace Teleimot.Tests.IntegrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Teleimot.WepApi.Controllers;

    [TestClass]
    public class CommentControllerTest
    {
        [TestMethod]
        public void ByUserShouldReturnNotFoundWhenUserDoesntExist()
        {
            var controller = typeof(CommentsController);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var httpServer = new HttpServer(config);
            var httpInvoker = new HttpMessageInvoker(httpServer);

            using (httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/Comments/ByUser/fakeUser"),
                    Method = HttpMethod.Get
                };

                var result = httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(result);
                Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            }
        }
    }
}
