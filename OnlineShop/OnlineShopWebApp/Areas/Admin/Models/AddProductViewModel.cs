using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Prise must be between 1 and 1 000 000")]

        public decimal Cost { get; set; }

        public IFormFile[] UploadFiles { get; set; }

        public string Description { get; set; }

    }
}
