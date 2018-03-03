namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        ProduktId = c.Int(nullable: false, identity: true),
                        NazwaProduktu = c.String(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CzasPrzygotowania = c.Int(nullable: false),
                        Polecany = c.Boolean(nullable: false),
                        Ukryty = c.Boolean(nullable: false),
                        NazwaPlikuObrazka = c.String(),
                        KategoriaId = c.Int(nullable: false),
                        OpisyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProduktId)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Opisy", t => t.OpisyId, cascadeDelete: true)
                .Index(t => t.KategoriaId)
                .Index(t => t.OpisyId);
            
            CreateTable(
                "dbo.Opisy",
                c => new
                    {
                        OpisyId = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        OpisKrotki = c.String(),
                    })
                .PrimaryKey(t => t.OpisyId);
            
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
            
            CreateTable(
                "dbo.Platnosc",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataPlatnosci = c.DateTime(),
                        TypPlatnosci = c.Int(nullable: false),
                        Kwota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CzyZaplacono = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zamowienie", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieId = c.Int(nullable: false, identity: true),
                        KodZamowienia = c.String(),
                        Komentarz = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        StanZamowienia = c.Int(nullable: false),
                        NaKiedy = c.DateTime(nullable: false),
                        KlientId = c.Int(nullable: false),
                        PlatnoscId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieId)
                .ForeignKey("dbo.Klient", t => t.KlientId, cascadeDelete: true)
                .Index(t => t.KlientId);
            
            CreateTable(
                "dbo.PozycjeZamowienia",
                c => new
                    {
                        PozycjeZamowieniaId = c.Int(nullable: false, identity: true),
                        ZamowienieId = c.Int(nullable: false),
                        ProduktId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaZakupu = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PozycjeZamowieniaId)
                .ForeignKey("dbo.Produkt", t => t.ProduktId, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieId, cascadeDelete: true)
                .Index(t => t.ZamowienieId)
                .Index(t => t.ProduktId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Platnosc", "Id", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjeZamowienia", "ZamowienieId", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjeZamowienia", "ProduktId", "dbo.Produkt");
            DropForeignKey("dbo.Zamowienie", "KlientId", "dbo.Klient");
            DropForeignKey("dbo.Produkt", "OpisyId", "dbo.Opisy");
            DropForeignKey("dbo.Produkt", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PozycjeZamowienia", new[] { "ProduktId" });
            DropIndex("dbo.PozycjeZamowienia", new[] { "ZamowienieId" });
            DropIndex("dbo.Zamowienie", new[] { "KlientId" });
            DropIndex("dbo.Platnosc", new[] { "Id" });
            DropIndex("dbo.Produkt", new[] { "OpisyId" });
            DropIndex("dbo.Produkt", new[] { "KategoriaId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PozycjeZamowienia");
            DropTable("dbo.Zamowienie");
            DropTable("dbo.Platnosc");
            DropTable("dbo.Klient");
            DropTable("dbo.Opisy");
            DropTable("dbo.Produkt");
            DropTable("dbo.Kategoria");
        }
    }
}
