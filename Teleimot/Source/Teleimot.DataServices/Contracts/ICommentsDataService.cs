namespace Teleimot.DataServices.Contracts
{
    using System.Collections.Generic;
    using Teleimot.Models;

    public interface ICommentsDataService
    {
        IEnumerable<Comment> GetComments(int skip, int take);

        Comment CreateComment(string userId, int realEstateId, string content);

        IEnumerable<Comment> GetCommentsByUserId(string userId, int skip, int take);

        IEnumerable<Comment> GetCommentsByRealStateId(int id, int skip, int take);
    }
}
