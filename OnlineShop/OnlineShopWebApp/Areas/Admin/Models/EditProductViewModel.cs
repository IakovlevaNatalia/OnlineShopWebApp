using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Range(1, 10000000, ErrorMessage = "Price must be between 1 and 1000000")]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        public List<string> ImagesPaths { get; set; }

        public IFormFile[] UploadFiles { get; set; }

    }
}
