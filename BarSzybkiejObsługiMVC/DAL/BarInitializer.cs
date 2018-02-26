using BarSzybkiejObsługiMVC.Migrations;
using BarSzybkiejObsługiMVC.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace BarSzybkiejObsługiMVC.DAL
{
    public class BarInitializer : MigrateDatabaseToLatestVersion<BarContext, Configuration>
    {
        public static void SeedBarData(BarContext context)
        {

            context.Opisy.AddOrUpdate(o => o.OpisKrotki,
                new Opisy { Opis = "Opis.", OpisKrotki = "Opis krótki." },
                new Opisy { Opis = "Opis", OpisKrotki = "Soczysta ryba w towarzystwie duszonych warzyw." },
                new Opisy { Opis = "Opis.", OpisKrotki = "Tortilla z kurczakiem, kapustą i warzywami." },
                new Opisy { Opis = "Opis.", OpisKrotki = "Solone frytki z ketchupem." },
                new Opisy { Opis = "Opis.", OpisKrotki = "Przepyszna drobiowa parówka w bułce z prażoną cebulą." }
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
                new Produkt { NazwaProduktu = "Kurczak z pesto", OpisyId = 1, Cena = 12.00M, CzasPrzygotowania = 45, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "kurczak_pesto.jpg" },
                new Produkt { NazwaProduktu = "Pulpeciki w sosie pomidorowym", OpisyId = 1, Cena = 13.00M, CzasPrzygotowania = 35, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "pulpety_pomidorowy.jpg" },
                new Produkt { NazwaProduktu = "Ryba po grecku", OpisyId = 2, Cena = 13.50M, CzasPrzygotowania = 45, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "ryba_po_grecku.jpg" },
                new Produkt { NazwaProduktu = "Barszcz czerwony z uszkami", OpisyId = 1, Cena = 12.00M, CzasPrzygotowania = 30, Polecany = true, KategoriaId = 1, NazwaPlikuObrazka = "barszcz_uszka.jpg" },
                new Produkt { NazwaProduktu = "Tortilla z kurczakiem", OpisyId = 3, Cena = 10.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "tortilla.jpg" },
                new Produkt { NazwaProduktu = "Frytki 400g", OpisyId = 4, Cena = 6.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "frytki.jpg" },
                new Produkt { NazwaProduktu = "Hamburger z wołowiną", OpisyId = 1, Cena = 7.50M, CzasPrzygotowania = 20, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "hamburger.jpg" },
                new Produkt { NazwaProduktu = "Hot-dog", OpisyId = 5, Cena = 4.50M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "hotdog.jpg" },
                new Produkt { NazwaProduktu = "Zapiekanka z kawałkami wołowiny i warzywami", OpisyId = 1, Cena = 5.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 2, NazwaPlikuObrazka = "zapiekanka.jpeg" },
                new Produkt { NazwaProduktu = "Paszteciki z mięsem", OpisyId = 1, Cena = 8.50M, CzasPrzygotowania = 25, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "pasztecik.jpeg" },
                new Produkt { NazwaProduktu = "Opiekana kukurydza", OpisyId = 1, Cena = 7.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "kukurydza.jpg" },
                new Produkt { NazwaProduktu = "Szpinak na ostro ", OpisyId = 1, Cena = 5.0M, CzasPrzygotowania = 15, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "szpinak.jpg" },
                new Produkt { NazwaProduktu = "Nadziewane serowe kulki w panierce", OpisyId = 1, Cena = 8.50M, CzasPrzygotowania = 20, Polecany = true, KategoriaId = 3, NazwaPlikuObrazka = "serowe_kulki.jpg" },
                new Produkt { NazwaProduktu = "Woda gazowana 500ml", OpisyId = 1, Cena = 2.50M, CzasPrzygotowania = 0, Polecany = true, KategoriaId = 4, NazwaPlikuObrazka = "woda.jpg" },
                new Produkt { NazwaProduktu = "Cola", OpisyId = 1, Cena = 3.00M, CzasPrzygotowania = 0, Polecany = true, KategoriaId = 4, NazwaPlikuObrazka = "cola.jpg" },
                new Produkt { NazwaProduktu = "Gorąca herbata", OpisyId = 1, Cena = 2.00M, CzasPrzygotowania = 5, Polecany = true, KategoriaId = 4, NazwaPlikuObrazka = "herbata.jpg" }

            );

            context.SaveChanges();
        }
    }
}