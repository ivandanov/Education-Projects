using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsExam.Data;
using WebFormsExam.Data.Repostiories;
using WebFormsExam.Models;
using WebFormsExam.Services.Contracts;

namespace WebFormsExam.Services
{
    public class UsersService : IUsersService
    {
        private IRepository<ApplicationUser> users;
        private IApplicationDbContext context;

        public UsersService(IApplicationDbContext context, IRepository<ApplicationUser> users)
        {
            this.users = users;
            this.context = context;
        }

        public ApplicationUser GetById(string id)
        {
            return this.context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
