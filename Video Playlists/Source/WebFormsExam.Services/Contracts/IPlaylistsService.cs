namespace WebFormsExam.Services.Contracts
{
    using System.Linq;
    using WebFormsExam.Models;

    public interface IPlaylistsService
    {
        IQueryable<Playlist> GetTop(int count);

        IQueryable<Playlist> GetAll();

        Playlist UpdateById(int id, Playlist updatedArticle);

        void DeleteById(int id);

        Playlist GetById(int id);

        Playlist Create(Playlist newArticle);

        void Create(string creatorId, string name, string desc, string url, string categoryName);

        void DeleteVideoById(int id);
    }
}
