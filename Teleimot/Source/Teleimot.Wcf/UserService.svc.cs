namespace Teleimot.Wcf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Teleimot.Data;
    using Teleimot.DataServices;
    using Teleimot.DataServices.Contracts;
    using Teleimot.Models;

    public class UserService : IUserService
    {
        private IUserDataService userService;

        public UserService()
            : this(new UserDataService(new TeleimotData(new TeleimotDbContext())))
        {
        }

        public UserService(IUserDataService userService)
        {
            this.userService = userService;
        }

        public IEnumerable<User> TopTenUserByRating()
        {
            var result = this.userService.TopTenUserByRating();
            return result;
        }

        IEnumerable<UserWcfModel> IUserService.TopTenUserByRating()
        {
            var result = this.userService
                .TopTenUserByRating()
                .Select(u => new UserWcfModel()
                {
                    Rating = u.Ratings.Count == 0 ? 0 : u.Ratings.Average(r => r.Value),
                    UserName = u.UserName
                })
                .ToList();

            return result;
        }
    }
}
