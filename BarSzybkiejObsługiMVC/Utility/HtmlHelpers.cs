using BarSzybkiejObsługiMVC.DAL;
using System.Linq;
using System.Web;

namespace BarSzybkiejObsługiMVC.Utility
{
    public static class HtmlHelpers
    {
        public static IHtmlString PorzucZamowienie(int id, string name)
        { 
            var username = GetUserNameOfTakenOrder(name);
            var loggedUser = GetLoggedUserName();

            if(username==loggedUser)
            {
                return new HtmlString($"<a href='/Zamowienia/Porzuc/{id}' class='btn btn-danger'>Porzuć zamówienie</a>");
            }
            return null;
            
        }

        public static bool CheckIfOrderBelongsToCurrentUser(string name)
        {
            var username = GetUserNameOfTakenOrder(name);
            var loggedUser = GetLoggedUserName();
            if (username == loggedUser)
                return true;
            return false;
        }

        private static string GetLoggedUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        private static string GetUserNameOfTakenOrder(string name)
        {
            if (name == null)
                return null;
            var context = new BarContext();
            return context.Users.SingleOrDefault(p => p.Name == name).UserName;
        }
    }
}