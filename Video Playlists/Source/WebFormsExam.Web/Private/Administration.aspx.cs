using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Web.Private
{
    public partial class Administration : System.Web.UI.Page
    {
        [Inject]
        public ICategoriesService CategoriesServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<WebFormsExam.Models.Category> gvCategories_GetData()
        {
            return this.CategoriesServices.GetAll();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvCategories_UpdateItem(int id)
        {
            WebFormsExam.Models.Category item = this.CategoriesServices.GetById(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            var editTextBox = this.gvCategories.Rows[this.gvCategories.EditIndex].Controls[1].Controls[0] as TextBox;

            if (string.IsNullOrEmpty(editTextBox.Text))
            {
                ModelState.AddModelError("", String.Format("Name should not be empty", id));
                return;
            }

            var newCat = this.CategoriesServices.Update(id, editTextBox.Text);
            TryUpdateModel(newCat);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            var newCategoryName = this.tbInsertName.Text;
            

            this.CategoriesServices.Create(newCategoryName);

            this.tbInsertName.Text = "";
        }
    }
}