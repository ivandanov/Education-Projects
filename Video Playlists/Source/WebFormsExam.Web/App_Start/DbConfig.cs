namespace WebFormsExam.Web.App_Start
{
    using System.Data.Entity;
    using WebFormsExam.Data;
    using WebFormsExam.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            //ApplicationDbContext.Create().Database.Initialize(true);
        }
    }
}