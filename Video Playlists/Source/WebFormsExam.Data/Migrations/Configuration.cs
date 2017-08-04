namespace WebFormsExam.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebFormsExam.Common;
    using WebFormsExam.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebFormsExam.Data.ApplicationDbContext context)
        {
            if(context.Roles.Any())
            {
                return; 
            }
            var adminRole = this.SeedAdminRole(context);
            var passwordHasher = new PasswordHasher();
            var randomGenerator = new RandomGenerator();

            this.SeedAdministrator(adminRole, passwordHasher, context);
            this.SeedUsers(passwordHasher, context);
            this.SeedCategories(randomGenerator, context);
            this.SeedPlaylists(randomGenerator, context);
            this.SeedVideos(randomGenerator, context);
        }

        private void SeedPlaylists(RandomGenerator randomGenerator, ApplicationDbContext context)
        {
            var categories = context.Categories.ToList();
            var users = context.Users.ToList();
            var videos = context.Videos.ToList();

            for (int i = 1; i <= 10; i++)
            {
                var playlist = new Playlist()
                {
                    Title = randomGenerator.RandomString(5, 10),
                    Description = randomGenerator.RandomString(10, 30),
                    CreationDate = DateTime.Now,
                    Creator = users[(users.Count - 1) % i],
                    Category = categories[(categories.Count - 1) % i]
                };
                
                for (byte k = 1; k <= 5; k++)
                {
                    playlist.Rating.Add(new Like()
                    {
                        Voter = users[(users.Count - 1) % k],
                        Value = k                        
                    });
                }

                context.Playlists.Add(playlist);
            }

            context.SaveChanges();
        }

        private void SeedVideos(RandomGenerator randomGenerator, ApplicationDbContext context)
        {
            var playlsit = context.Playlists.ToList();
            for (int i = 1; i <= 30; i++)
            {
                var url = string.Format("www.{0}.com", randomGenerator.RandomString(5, 10));
                var video = new Video()
                {
                    Url = url,
                    Playlist = playlsit[(playlsit.Count - 1) % i]
                };

                context.Videos.Add(video);
            }

            context.SaveChanges();
        }

        private void SeedCategories(RandomGenerator randomGenerator, ApplicationDbContext context)
        {
            for (int i = 0; i < 30; i++)
            {
                var category = new Category()
                {
                    Name = randomGenerator.RandomString(5, 20)
                };

                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        private void SeedUsers(PasswordHasher passwordHasher, ApplicationDbContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                var email = string.Format("user{0}@site.com", i);
                var pass = string.Format("user{0}", i);
                var user = new ApplicationUser()
                {
                    UserName = email,
                    Email = email,
                    PasswordHash = passwordHasher.HashPassword(pass)
                };

                context.Users.Add(user);
            }

            context.SaveChanges();
        }

        private IdentityRole SeedAdminRole(ApplicationDbContext context)
        {
            var role = new IdentityRole("Administrator");
            context.Roles.Add(role);
            context.SaveChanges();
            return role;
        }

        private ApplicationUser SeedAdministrator(IdentityRole adminRole, PasswordHasher passwordHasher, ApplicationDbContext context)
        {
            var admin = new ApplicationUser()
            {
                UserName = "admin@site.com",
                Email = "admin@site.com",
                PasswordHash = passwordHasher.HashPassword("admin"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            context.Users.Add(admin);
            context.SaveChanges();

            admin.Roles.Add(new IdentityUserRole()
            {
                RoleId = adminRole.Id,
                UserId = admin.Id
            });

            context.SaveChanges();

            return admin;
        }
    }
}
