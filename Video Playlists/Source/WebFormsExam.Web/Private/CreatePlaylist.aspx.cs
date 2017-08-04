using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace WebFormsExam.Web.Private
{
    public partial class CreatePlaylist : System.Web.UI.Page
    {
        [Inject]
        public IPlaylistsService PlaylistsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreatePlaylist_Click(object sender, EventArgs e)
        {
            var name = this.PlaylistTitle.Text;
            var desc = this.Description.Text;
            var url = this.VideoUrl.Text;
            var categoryName = this.CategoryName.Text;
            var userId = this.User.Identity.GetUserId();

            this.PlaylistsServices.Create(userId, name, desc, url, categoryName);
            IdentityHelper.RedirectToReturnUrl("/Private/AllPlaylists.aspx", Response);
        }
    }
}