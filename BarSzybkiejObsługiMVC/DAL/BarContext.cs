using BarSzybkiejObsługiMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BarSzybkiejObsługiMVC.DAL
{
    public class BarContext: IdentityDbContext<ApplicationUser>
    {

        public BarContext() : base("BarContext") { }

        public DbSet<Opisy> Opisy { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Platnosc> Platnosci { get; set; }
        public DbSet<PozycjeZamowienia> PozycjeZamowienia { get; set; }

        static BarContext()
        {
            Database.SetInitializer(new BarInitializer()); 

        }

        public static BarContext Create()
        {
            return new BarContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}