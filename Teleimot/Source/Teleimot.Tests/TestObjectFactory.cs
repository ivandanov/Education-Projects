namespace Teleimot.Tests
{
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Teleimot.DataServices.Contracts;
    using Teleimot.Models;

    public class TestObjectFactory
    {
        private User someUser;
        private IQueryable<Comment> comments;

        public TestObjectFactory()
        {
            this.someUser = new User() { UserName = "test", Id = "testId"};
            this.comments = new List<Comment>() 
            {
                new Comment()
                {
                    CreatedOn = new DateTime(2015, 11, 5, 23, 47, 12),
                    Content = "comment 1",
                    Id = 1,
                    User = someUser,
                    UserId = someUser.Id

                },
                new Comment()
                {
                    CreatedOn = new DateTime(2009, 11, 5, 23, 47, 12),
                    Content = "comment 2",
                    Id = 1,
                    User = someUser,
                    UserId = someUser.Id
                },
                new Comment()
                {
                    CreatedOn = new DateTime(1999, 11, 5, 23, 47, 12),
                    Content = "comment 3",
                    Id = 1,
                    User = someUser,
                    UserId = someUser.Id
                }
            }.AsQueryable();
        }

        public ICommentsDataService GetCommentsService()
        {
            var projectsService = new Mock<ICommentsDataService>();

            projectsService.Setup(pr => pr.GetCommentsByUserId(
                    It.Is<string>(s => s == "testId"),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(comments);

            return projectsService.Object;
        }

        public IUserDataService GetUserService()
        {
            var projectsService = new Mock<IUserDataService>();

            projectsService.Setup(pr => pr.GetUserByName(
                    It.Is<string>(s => s == "test")))
                .Returns(someUser);

            return projectsService.Object;
        }
    }
}
