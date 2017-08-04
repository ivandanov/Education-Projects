using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Web
{
    public partial class _Default : Page
    {
        public const int TopPlaylistsDisplayCountByLikes = 10;

        [Inject]
        public IPlaylistsService PlaylistsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Playlist> PalylistRepeater_GetData()
        {
            return this.PlaylistsService.GetTop(TopPlaylistsDisplayCountByLikes);
        }
    }
}