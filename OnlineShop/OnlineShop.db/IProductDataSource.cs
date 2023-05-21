using System.Collections.Generic;
using System.Security.Policy;
using OnlineShop.db.Models;

namespace OnlineShop.db
{ 
    public interface IProductDataSource
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        void AddProduct(Product product);

        public void RemoveProduct(int Id);

        public void EditProduct(Product product);

        public void Update(Product product);

        public void RemoveImage (string url);
    }
}