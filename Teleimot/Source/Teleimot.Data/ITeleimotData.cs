namespace Teleimot.Data
{
    using Teleimot.Data.Repositories;
    using Teleimot.Models;

    public interface ITeleimotData
    {
        IRepository<User> Users { get; }

        IRepository<RealEstate> RealEstates { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Comment> Comments { get; }
        
        int SaveChanges();
    }
}
