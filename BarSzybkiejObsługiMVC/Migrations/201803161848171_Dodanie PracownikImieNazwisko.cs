namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodaniePracownikImieNazwisko : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamowienie", "PracownikImieNazwisko", c => c.String());
            DropColumn("dbo.Zamowienie", "PracownikId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "PracownikId", c => c.String());
            DropColumn("dbo.Zamowienie", "PracownikImieNazwisko");
        }
    }
}
