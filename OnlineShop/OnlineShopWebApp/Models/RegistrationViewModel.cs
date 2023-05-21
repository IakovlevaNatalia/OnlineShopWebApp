using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RegistrationViewModel
    {
        public RegistrationViewModel()
        {

        }

        public RegistrationViewModel(string userName, string phone, string password, string confirmPassword, string login)
        {
            UserName = userName;
            Phone = phone;
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        [Required(ErrorMessage = "Missing name")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 25 characters")]
        public string UserName { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Missing e-mail")]
        [EmailAddress(ErrorMessage = "Please, check your e-mail")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Missing password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, confirm your password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]

        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

        public string ImagePath { get; set; }
    }
}
