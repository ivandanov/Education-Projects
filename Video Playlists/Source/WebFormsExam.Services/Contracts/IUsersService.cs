namespace WebFormsExam.Services.Contracts
{
    using WebFormsExam.Models;

    public interface IUsersService
    {
        ApplicationUser GetById(string id);
    }
}
