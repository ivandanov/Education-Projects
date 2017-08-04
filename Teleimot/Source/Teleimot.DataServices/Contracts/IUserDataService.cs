namespace Teleimot.DataServices.Contracts
{
    using System.Collections.Generic;
    using Teleimot.Models;

    public interface IUserDataService
    {
        User GetUserById(string id);

        User GetUserByName(string name);

        void RateUser(string userId, string ratedUserId, byte value);

        IEnumerable<User> TopTenUserByRating();
    }
}
