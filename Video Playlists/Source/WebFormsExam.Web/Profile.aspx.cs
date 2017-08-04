using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace WebFormsExam.Web
{
    public partial class Profile : System.Web.UI.Page
    {
        [Inject]
        public IUsersService UsersService { get; set; }


        [Inject]
        public IPlaylistsService PlaylistsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public WebFormsExam.Models.ApplicationUser fvProfile_GetItem(string id)
        {
            var userid = this.User.Identity.GetUserId();
            var user = this.UsersService.GetById(userid);
            return user;
        }

        public IQueryable<WebFormsExam.Models.Playlist> gvPlaylists_GetData()
        {
            var userid = this.User.Identity.GetUserId();

            return this.PlaylistsService.GetAll().Where(p => p.CreatorId == userid);
        }
    }
}