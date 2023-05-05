using OnlineShop.db.Models;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        private static int instanceCounter = 0;

        public int Id { get; set; }

        [Required(ErrorMessage = "Missing product name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Product name must be between 4 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Missing product price")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Description could not be empty")]
        public string Description { get; set; }

        public string[] ImagesPath { get; set; }

        public string ImagePath => ImagesPath.Length == 0 ? "/images/india.jpg" : ImagesPath[0];

        public static int GetNextId()
        {
            instanceCounter += 1;
            return instanceCounter;
        }

        public static ProductViewModel ConvertFromDbProduct(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
        }
    }

}
