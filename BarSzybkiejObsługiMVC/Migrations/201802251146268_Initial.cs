namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "TypPlatnosci", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zamowienie", "TypPlatnosci");
        }
    }
}
