using BarSzybkiejObsługiMVC.DAL;
using System.Linq;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class ZamowieniaController : Controller
    {
        private BarContext db = new BarContext();

        public ActionResult Index()
        {
            var zamowienia = db.Zamowienia.ToList();
            return View(zamowienia);
        }

        public ActionResult Szczegoly(int id)
        {
            var zamowienie = db.Zamowienia
                .Include("PozycjeZamowienia").SingleOrDefault(p=>p.ZamowienieId==id);
            return View(zamowienie);
        }
    }
}