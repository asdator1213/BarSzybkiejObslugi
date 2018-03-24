namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePracownikId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "PracownikId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zamowienie", "PracownikId");
        }
    }
}
