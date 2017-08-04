namespace Teleimot.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Teleimot.Models;

    public class TeleimotDbContext : IdentityDbContext<User>
    {
        public TeleimotDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TeleimotDbContext Create()
        {
            return new TeleimotDbContext();
        }
        
        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<RealEstate> RealEstates { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }
    }
}
