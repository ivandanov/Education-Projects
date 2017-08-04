namespace Teleimot.DataServices
{
    using System.Linq;
    using System.Collections.Generic;
    using Teleimot.Data;
    using Teleimot.DataServices.Contracts;
    using Teleimot.Models;
    using System;

    public class CommentsDataService : ICommentsDataService
    {
        private ITeleimotData data;

        public CommentsDataService(ITeleimotData data)
        {
            this.data = data;
        }

        public Comment CreateComment(string userId, int realEstateId, string content)
        {
            var user = this.data.Users.GetById(userId);
            var estate = this.data.RealEstates.GetById(realEstateId);

            if(user == null || estate == null)
            {
                return null;
            }

            var newComment = new Comment()
            {
                RealEstateId = estate.Id,
                Content = content,
                UserId = user.Id,
                CreatedOn = DateTime.Now
            };

            this.data.Comments.Add(newComment);
            this.data.SaveChanges();

            return newComment;
        }

        public IEnumerable<Comment> GetComments(int skip, int take)
        {
            return this.data.Comments.All()
                .OrderBy(c => c.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();
        }

        public IEnumerable<Comment> GetCommentsByUserId(string userId, int skip, int take)
        {
            return this.data.Comments.All()
                .Where(c => c.UserId == userId)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();
        }

        public IEnumerable<Comment> GetCommentsByRealStateId(int id, int skip, int take)
        {
            return this.data.Comments.All()
                .Where(c => c.RealEstateId == id)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();
        }
    }
}
