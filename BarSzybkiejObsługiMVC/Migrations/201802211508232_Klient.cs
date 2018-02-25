namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Klient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Telefon = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Zamowienie", "KlientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zamowienie", "KlientId");
            AddForeignKey("dbo.Zamowienie", "KlientId", "dbo.Klient", "Id", cascadeDelete: true);
            DropColumn("dbo.Zamowienie", "Imie");
            DropColumn("dbo.Zamowienie", "Nazwisko");
            DropColumn("dbo.Zamowienie", "Telefon");
            DropColumn("dbo.Zamowienie", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "Email", c => c.String());
            AddColumn("dbo.Zamowienie", "Telefon", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Zamowienie", "Nazwisko", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Zamowienie", "Imie", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Zamowienie", "KlientId", "dbo.Klient");
            DropIndex("dbo.Zamowienie", new[] { "KlientId" });
            DropColumn("dbo.Zamowienie", "KlientId");
            DropTable("dbo.Klient");
        }
    }
}
