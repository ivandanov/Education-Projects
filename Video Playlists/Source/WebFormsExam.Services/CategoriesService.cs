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
    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }


        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }

        public Category Update(int id, string newName)
        {
            var cat = this.categories.GetById(id);
            if (cat == null)
            {
                return null;
            }

            cat.Name = newName;
            this.categories.SaveChanges();
            return cat;
        }


        public Category Create(string newCategoryName)
        {
            var newCategory = new Category()
            {
                Name = newCategoryName
            };

            this.categories.Add(newCategory);

            this.categories.SaveChanges();

            return newCategory;
        }

    }
}
