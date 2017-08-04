using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Web.Private
{
    public partial class AllPlaylists : System.Web.UI.Page
    {
        private IQueryable<Playlist> playlists;

        [Inject]
        public IPlaylistsService PlaylistsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Playlist> gvPlaylists_GetData()
        {
            this.playlists = this.PlaylistsServices.GetAll();
            return playlists;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var value = this.tbSearch.Text;
            var result = this.PlaylistsServices.GetAll();

            if(!string.IsNullOrEmpty(value)) 
            {
                result = result.Where(p => 
                    p.Title.IndexOf(value) > -1 
                    || p.Description.IndexOf(value) > -1);
            }

            playlists = result;
            //TryUpdateModel(result.ToList());
            //this.gvPlaylists.DataBind();
            this.tbSearch.Text = String.Empty;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvPlaylists_DeleteItem(int id)
        {

        }
    }
}