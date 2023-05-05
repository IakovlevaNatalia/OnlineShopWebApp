using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "New password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "please, confirm your new password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
    }
}
