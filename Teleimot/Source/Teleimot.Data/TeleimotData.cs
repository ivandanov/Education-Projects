namespace Teleimot.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Teleimot.Data.Repositories;
    using Teleimot.Models;

    public class TeleimotData : ITeleimotData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public TeleimotData(TeleimotDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<RealEstate> RealEstates
        {
            get
            {
                return this.GetRepository<RealEstate>();
            }
        }

        public IRepository<Rating> Ratings
        {
            get
            {
                return this.GetRepository<Rating>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfGenericRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
