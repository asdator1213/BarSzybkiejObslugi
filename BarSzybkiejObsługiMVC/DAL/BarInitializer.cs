using BarSzybkiejObsługiMVC.Migrations;
using BarSzybkiejObsługiMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace BarSzybkiejObsługiMVC.DAL
{
    public class BarInitializer : MigrateDatabaseToLatestVersion<BarContext, Configuration>
    {
        public static void SeedBarData(BarContext context)
        {

            context.Opisy.AddOrUpdate(o=>o.Opis,
                new Opisy { Opis = "Opis.1", OpisKrotki = "Opis krótki.1" },
                new Opisy { Opis = "Opis.2", OpisKrotki = "Opis krótki.2" },
                new Opisy { Opis = "Opis.3", OpisKrotki = "Opis krótki.3" },
                new Opisy { Opis = "Opis.4", OpisKrotki = "Opis krótki.4" },
                new Opisy { Opis = "Opis.5", OpisKrotki = "Opis krótki.5" },
                new Opisy { Opis = "Opis.6", OpisKrotki = "Opis krótki.6" },
                new Opisy { Opis = "Opis.7", OpisKrotki = "Opis krótki.7" },
                new Opisy { Opis = "Opis.8", OpisKrotki = "Opis krótki.8" },
                new Opisy { Opis = "Opis.9", OpisKrotki = "Opis krótki.9" },
                new Opisy { Opis = "Opis.0", OpisKrotki = "Opis krótki.0" },
                new Opisy { Opis = "Opis.11", OpisKrotki = "Opis krótki.11" },
                new Opisy { Opis = "Opis.12", OpisKrotki = "Opis krótki.12" },
                new Opisy { Opis = "Opis13", OpisKrotki = "Soczysta ryba w towarzystwie duszonych warzyw." },
                new Opisy { Opis = "Opis.14", OpisKrotki = "Tortilla z kurczakiem, kapustą i warzywami." },
                new Opisy { Opis = "Opis.15", OpisKrotki = "Solone frytki z ketchupem." },
                new Opisy { Opis = "Opis.16", OpisKrotki = "Przepyszna drobiowa parówka w bułce z prażoną cebulą." }
                );
            context.SaveChanges();

            context.Kategorie.AddOrUpdate(k => k.NazwaKategorii,
                new Kategoria { NazwaKategorii = "Danie obiadowe"},
                new Kategoria { NazwaKategorii = "Fast food"},
                new Kategoria { NazwaKategorii = "Przystawka"},
                new Kategoria { NazwaKategorii = "Napoje"}
                );

            context.SaveChanges();

            context.Produkty.AddOrUpdate(k => k.NazwaProduktu,
                new Produkt { NazwaProduktu = "Schab w sosie musztardowym", OpisyId = 1, Cena = 12.00M, CzasPrzygotowania = 45, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "schab_musztardowy.jpg" },
                new Produkt { NazwaProduktu = "Kurczak z pesto", OpisyId = 2, Cena = 12.00M, CzasPrzygotowania = 45, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "kurczak_pesto.jpeg" },
                new Produkt { NazwaProduktu = "Ryba po grecku", OpisyId = 3, Cena = 13.50M, CzasPrzygotowania = 45, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "ryba_po_grecku.jpeg" },
                new Produkt { NazwaProduktu = "Tortilla z kurczakiem", OpisyId = 5, Cena = 10.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "tortilla.jpg" },
                new Produkt { NazwaProduktu = "Frytki 400g", OpisyId = 6, Cena = 6.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "frytki.jpg" },
                new Produkt { NazwaProduktu = "Hamburger z wołowiną", OpisyId = 7, Cena = 7.50M, CzasPrzygotowania = 20, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "hamburger.jpg" },
                new Produkt { NazwaProduktu = "Hot-dog", OpisyId = 8, Cena = 4.50M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "hotdog.jpg" },
                new Produkt { NazwaProduktu = "Zapiekanka z kawałkami wołowiny i warzywami", OpisyId = 9, Cena = 5.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "zapiekanka.jpeg" },
                new Produkt { NazwaProduktu = "Paszteciki z mięsem", OpisyId = 10, Cena = 8.50M, CzasPrzygotowania = 25, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "pasztecik.jpeg" },
                new Produkt { NazwaProduktu = "Opiekana kukurydza", OpisyId = 11, Cena = 7.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "kukurydza.jpg" },
                new Produkt { NazwaProduktu = "Szpinak na ostro ", OpisyId = 12, Cena = 5.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "szpinak.jpg" },
                new Produkt { NazwaProduktu = "Nadziewane serowe kulki w panierce", OpisyId = 13, Cena = 8.50M, CzasPrzygotowania = 20, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "serowe_kulki.jpg" },
                new Produkt { NazwaProduktu = "Woda gazowana 500ml", OpisyId = 14, Cena = 2.50M, CzasPrzygotowania = 0, Polecany = true, KategoriaId = 4, NazwaPlikuObrazka = "woda.jpg" },
                new Produkt { NazwaProduktu = "Cola", OpisyId = 15, Cena = 3.00M, CzasPrzygotowania = 0, Polecany = true, KategoriaId = 4, NazwaPlikuObrazka = "cola.jpg" },
                new Produkt { NazwaProduktu = "Gorąca herbata", OpisyId = 16, Cena = 2.00M, CzasPrzygotowania = 5, Polecany = true, KategoriaId = 4, NazwaPlikuObrazka = "herbata.jpg" }

            );

            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            CreateAdmin(roleManager, userManager);
            CreateUsers(roleManager, userManager);
        }


        private static void CreateAdmin(RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager)
        {
            var roleManager = _roleManager;
            var userManager = _userManager;

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var createUserResult = userManager.Create(user, "Admin123***");

                //Add default User to Role Admin   
                if (createUserResult.Succeeded)
                {
                    var addToRoleResult = userManager.AddToRole(user.Id, "Admin");
                }
            }
        }

        private static void CreateUsers(RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager)
        {
            var roleManager = _roleManager;
            var userManager = _userManager;

            if(!roleManager.RoleExists("Pracownik"))
            {
                var role = new IdentityRole("Pracownik");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Pracownik1";
                user.Email = "pracownik1@pracownik.com";

                var createUserResult = userManager.Create(user, "Pracownik1***");
                if(createUserResult.Succeeded)
                {
                    var addToRoleResult = userManager.AddToRole(user.Id, "Pracownik");
                }
            }
        }
    }
}