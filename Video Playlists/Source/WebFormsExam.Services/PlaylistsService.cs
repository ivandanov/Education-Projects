using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsExam.Data.Repostiories;
using WebFormsExam.Models;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Services
{
    public class PlaylistsService : IPlaylistsService
    {
        private IRepository<Playlist> playlists;
        private IRepository<Category> categories;

        public PlaylistsService(IRepository<Playlist> playlists, IRepository<Category> categories)
        {
            this.playlists = playlists;
            this.categories = categories;
        }

        public IQueryable<Playlist> GetTop(int count)
        {
            return this.playlists.All().OrderByDescending(x => x.Rating.Count()).Take(count);
        }

        public Playlist GetById(int id)
        {
            return this.playlists.GetById(id);
        }

        public Playlist Create(Playlist newArticle)
        {
            this.playlists.Add(newArticle);

            this.playlists.SaveChanges();

            return newArticle;
        }

        public Playlist UpdateById(int id, Playlist updatedArticle)
        {
            var articleToUpdate = this.playlists.GetById(id);

            articleToUpdate.CategoryId = updatedArticle.CategoryId;
            articleToUpdate.Description = updatedArticle.Description;
            articleToUpdate.Title = updatedArticle.Title;

            this.playlists.SaveChanges();

            return updatedArticle;
        }

        public void DeleteById(int id)
        {
            this.playlists.Delete(id);
            this.playlists.SaveChanges();
        }


        public IQueryable<Playlist> GetAll()
        {
            return this.playlists.All();
        }


        public void Create(string creatorId, string name, string desc, string url, string categoryName)
        {
            var category = this.categories.All().Where(c => c.Name == categoryName).FirstOrDefault();
            if (category == null)
            {
                category = new Category()
                {
                    Name = categoryName
                };

                this.categories.Add(category);
                this.categories.SaveChanges();
            }

            var newPlaylist = new Playlist()
            {
                Title = name,
                Description = desc,
                CategoryId = category.Id,
                CreatorId = creatorId,
                CreationDate = DateTime.Now
            };

            newPlaylist.Videos.Add(new Video()
                {
                    Url = url
                });

            this.playlists.Add(newPlaylist);
            this.playlists.SaveChanges();
        }


        public void DeleteVideoById(int id)
        {
            var video = this.playlists.GetById(id).Videos.Where(v => v.Id == id).FirstOrDefault();
            
            this.playlists.SaveChanges();
        }
    }
}
