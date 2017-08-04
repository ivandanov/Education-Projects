namespace Teleimot.WepApi.App_Start
{
    using System.Data.Entity;
    using Teleimot.Data;
    using Teleimot.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDbContext, Configuration>());
        }
    }
}