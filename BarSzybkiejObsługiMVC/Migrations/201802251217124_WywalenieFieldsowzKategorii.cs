namespace BarSzybkiejObsługiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WywalenieFieldsowzKategorii : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Kategoria", "OpisKategorii");
            DropColumn("dbo.Kategoria", "NazwaPlikuIkony");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoria", "NazwaPlikuIkony", c => c.String());
            AddColumn("dbo.Kategoria", "OpisKategorii", c => c.String());
        }
    }
}
