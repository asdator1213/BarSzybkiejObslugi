namespace BarSzybkiejObsługiMVC.Migrations
{
    using BarSzybkiejObsługiMVC.DAL;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BarSzybkiejObsługiMVC.DAL.BarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BarSzybkiejObsługiMVC.DAL.BarContext";
        }

        protected override void Seed(BarSzybkiejObsługiMVC.DAL.BarContext context)
        {
            BarInitializer.SeedBarData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



        }
    }
}
