namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaPlatnosc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platnosc",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataPlatnosci = c.DateTime(nullable: false),
                        TypPlatnosci = c.Int(nullable: false),
                        Kwota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CzyZaplacono = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zamowienie", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Zamowienie", "PlatnoscId", c => c.Int(nullable: false));
            DropColumn("dbo.Zamowienie", "TypPlatnosci");
            DropColumn("dbo.Zamowienie", "WartoscZamowienia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "WartoscZamowienia", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Zamowienie", "TypPlatnosci", c => c.Int(nullable: false));
            DropForeignKey("dbo.Platnosc", "Id", "dbo.Zamowienie");
            DropIndex("dbo.Platnosc", new[] { "Id" });
            DropColumn("dbo.Zamowienie", "PlatnoscId");
            DropTable("dbo.Platnosc");
        }
    }
}
