namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NaKiedyZamowienie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "NaKiedy", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zamowienie", "NaKiedy");
        }
    }
}
