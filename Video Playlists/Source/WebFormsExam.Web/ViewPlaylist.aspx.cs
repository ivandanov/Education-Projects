using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Web
{
    public partial class ViewPlaylist : System.Web.UI.Page
    {
        [Inject]
        public IPlaylistsService PlaylistsServices { get; set; }

        [Inject]
        public IVideoService VideoService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Playlist fvPlaylist_GetItem([QueryString]string id)
        {
            return this.PlaylistsServices.GetById(int.Parse(id));
        }

        public IEnumerable<Video> VideosRepeater_GetData()
        {
            var playlist = this.PlaylistsServices.GetById(int.Parse(this.Request.QueryString["id"]));
            return playlist.Videos;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
        }

        public void gvPlaylists_DeleteItem(int id)
        {
            this.VideoService.DeleteVideoById(id);
        }

        public ICollection<Video> gvPlaylists_GetData()
        {
            var playlist = this.PlaylistsServices.GetById(int.Parse(this.Request.QueryString["id"]));
            return playlist.Videos;
        }
    }
}