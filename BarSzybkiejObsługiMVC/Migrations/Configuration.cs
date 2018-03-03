namespace BarSzybkiejObsługiMVC.Migrations
{
    using BarSzybkiejObsługiMVC.DAL;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BarSzybkiejObsługiMVC.DAL.BarContext";
        }

        protected override void Seed(BarContext context)
        {
            BarInitializer.SeedBarData(context);
        }
    }
}
