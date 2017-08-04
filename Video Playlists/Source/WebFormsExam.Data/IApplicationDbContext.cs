namespace WebFormsExam.Data
{
    
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Like> Ratings { get; set; }

        IDbSet<Playlist> Playlists { get; set; }

        IDbSet<Video> Videos { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
