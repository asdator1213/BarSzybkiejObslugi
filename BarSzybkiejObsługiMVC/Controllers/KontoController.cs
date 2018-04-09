using BarSzybkiejObsługiMVC.App_Start;
using BarSzybkiejObsługiMVC.DAL;
using BarSzybkiejObsługiMVC.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarSzybkiejObsługiMVC.Controllers
{
    public class KontoController : Controller
    {
        private BarContext db = new BarContext();


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public KontoController()
        {
        }

        public KontoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Konta()
        {
            var users = db.Users.ToList();
            var konta = new List<KontoVM>();
            foreach(var item in users)
            {
                konta.Add(new KontoVM
                {
                    NazwaUzytkownika = item.UserName,
                    Email = item.Email,
                    ImieNazwisko = item.Name,
                    Id = item.Id
                });
            }
            return View(konta);
        }

        public ActionResult Usun(string id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        public ActionResult PotwierdzUsun(string id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
            catch(Exception)
            {
                return RedirectToAction("Konta");
            }

            return RedirectToAction("Konta");
        }
    }
}
