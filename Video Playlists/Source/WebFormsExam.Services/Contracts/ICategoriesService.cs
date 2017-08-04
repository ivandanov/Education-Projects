using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsExam.Models;

namespace WebFormsExam.Services.Contracts
{
    public interface ICategoriesService
    {
        Category GetById(int id);

        IQueryable<Category> GetAll();

        Category Update(int id, string newName);

        Category Create(string newCategoryName);

    }
}
