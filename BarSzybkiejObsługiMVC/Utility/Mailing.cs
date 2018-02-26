using Postal;

namespace BarSzybkiejObsługiMVC.Utility
{
    public class Mailing
    {
        public void SendMail(string mailTo, string mailMessage)
        {
            dynamic email = new Email("Example");
            email.To = mailTo;
            email.Message = mailMessage;
            email.Send();
        }
    }
}