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

namespace WebFormsExam.Web.Private
{
    public partial class ViewCategory : System.Web.UI.Page
    {

        [Inject]
        public ICategoriesService CategoriesServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public WebFormsExam.Models.Category fvCategory_GetItem([QueryString]string id)
        {
            return this.CategoriesServices.GetById(int.Parse(id));
        }
        
        public IEnumerable<Playlist> PlaylistRepeater_GetData()
        {
            var category = this.CategoriesServices.GetById(int.Parse(this.Request.QueryString["id"]));
            return category.Playlists;
        }
    }
}