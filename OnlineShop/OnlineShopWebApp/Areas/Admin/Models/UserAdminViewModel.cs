using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class UserAdminViewModel
    {
        [Required(ErrorMessage = "Your first name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters")]
        public string LastName { get; set; }

       [Required(ErrorMessage = "Enter email address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your address")]
      
        public string Address { get; set; }
        public string Phone { get; set; }
        public string AvatarPath { get; set; }
        public IFormFile UploadedImage { get; set; }
        
        public string TelegramUserId { get; set; }
        public string UserName { get; set; }

    }
}
