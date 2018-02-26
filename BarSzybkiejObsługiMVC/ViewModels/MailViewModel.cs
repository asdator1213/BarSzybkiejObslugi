using Postal;

namespace BarSzybkiejObsługiMVC.ViewModels
{
    public class MailViewModel:Email
    {
        public ZamowienieViewModel Zamowienie { get; set; }
    }
}