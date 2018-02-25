namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KodZamowienia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "KodZamowienia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zamowienie", "KodZamowienia");
        }
    }
}
