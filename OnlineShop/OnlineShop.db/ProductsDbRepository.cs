using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineShop.db.Models;

namespace OnlineShop.db
{
    public class ProductsDbRepository : IProductDataSource
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return databaseContext.Products.Where(p => p.IsActive)
                .Include(x => x.Images).ToList();
        }
        public Product GetProductById(int id)
        {
            return databaseContext.Products.Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.IsActive = true;
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void RemoveProduct(int Id)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == Id);
            product.IsActive = false;
            databaseContext.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            var existing = GetProductById(product.Id);
            existing.Name = product.Name;
            existing.Cost = product.Cost;
            existing.Description = product.Description;
            databaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = databaseContext.Products
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;

            var existingImages = databaseContext.Image.Where(x => x.ProductId == product.Id).ToList();

            foreach (var image in product.Images)
            {
                if (existingImages.All(x => x.Url != image.Url))
                {
                    image.ProductId = product.Id;
                    databaseContext.Image.Add(image);
                }
            }

            databaseContext.SaveChanges();
        }

        public void RemoveImage(string url)
        {
            var existingImage = databaseContext.Image.FirstOrDefault(x => x.Url == url);
            
            if (existingImage != null)
            {
                databaseContext.Image.Remove(existingImage);
            }

            databaseContext.SaveChanges();

        }


    }
}
