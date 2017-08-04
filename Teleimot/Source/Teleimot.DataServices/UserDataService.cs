namespace Teleimot.DataServices
{
    using System.Collections.Generic;
    using System.Linq;
    using Teleimot.Data;
    using Teleimot.DataServices.Contracts;
    using Teleimot.Models;

    public class UserDataService : IUserDataService
    {
        private ITeleimotData data;

        public UserDataService(ITeleimotData data)
        {
            this.data = data;
        }

        public User GetUserById(string id)
        {
            return this.data.Users.GetById(id);
        }

        public User GetUserByName(string name)
        {
            return this.data.Users.All()
                .Where(u => u.UserName == name)
                .FirstOrDefault();
        }
        
        public void RateUser(string userId, string ratedUserId, byte value)
        {
            var user = this.data.Users.GetById(userId);
            var ratedUser = this.data.Users.GetById(ratedUserId);

            if (user == null || ratedUser == null)
            {
                return;
            }

            var rate = new Rating()
            {
                Value = value,
                RatedUserId = ratedUser.Id
            };

            ratedUser.Ratings.Add(rate);

            this.data.SaveChanges();
        }

        public IEnumerable<User> TopTenUserByRating()
        {
            return this.data.Users.All()
                .OrderByDescending(u => u.Ratings.Average(r => r.Value))
                .Take(10)
                .ToList();
        }
    }
}
