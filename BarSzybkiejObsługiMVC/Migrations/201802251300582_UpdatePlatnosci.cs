namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlatnosci : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Platnosc", "DataPlatnosci", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Platnosc", "DataPlatnosci", c => c.DateTime(nullable: false));
        }
    }
}
