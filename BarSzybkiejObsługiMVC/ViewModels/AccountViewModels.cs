using System.ComponentModel.DataAnnotations;

namespace BarSzybkiejObsługiMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić nazwę użytkownika.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło.")]
        [DataType(DataType.Password)]
        [Display(Name="Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie.")]
        public bool RememberMe { get; set; }

    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić imię i nazwisko użytkownika")]
        [Display(Name = "Imię i nazwisko")]
        public string Name { get; set; }

        [Display(Name ="Nazwa użytkownika")]
        [Required(ErrorMessage ="Musisz wprowadzić nazwę użytkownika")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Musisz podać adres e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Podane hasła nie są identyczne.")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        public string ConfirmPassword { get; set; }
    }

}