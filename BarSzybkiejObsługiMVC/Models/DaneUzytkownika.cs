using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarSzybkiejObsługiMVC.Models
{
    [ComplexType]
    public class DaneUzytkownika
    {
        public string Imie { get; set; }
        public string Nazwisko{ get; set; }
        
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        public string Email { get; set; }
    }
}