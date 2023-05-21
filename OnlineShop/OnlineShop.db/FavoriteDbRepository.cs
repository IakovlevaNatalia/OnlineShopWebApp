using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

namespace OnlineShop.db
{
    public class FavoriteDbRepository : IFavoriteRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(string userId, Product product)
        {
            var fav = GetForUser(userId);

            if (fav.FavoriteProducts.Any(x => x.Product.Id == product.Id))
                return;

            fav.FavoriteProducts.Add(new FavoriteProducts
            {
                FavoriteId = fav.Id,
                ProductId = product.Id
            });

            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var fav = GetForUser(userId);
            fav.FavoriteProducts.Clear();
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.Favorites.FirstOrDefault(x => x.UserId == userId)?.FavoriteProducts.Select(x => x.Product).ToList();
        }

        public void Remove(string userId, int productId)
        {
            var fav = GetForUser(userId);
            var favProduct = fav.FavoriteProducts.First(x => x.ProductId == productId);
            fav.FavoriteProducts.Remove(favProduct);
            databaseContext.SaveChanges();
        }

        public Favorites GetForUser(string userId)
        {
            var fav = databaseContext.Favorites.FirstOrDefault(u => u.UserId == userId);

            if (fav == null)
            {
                fav = new Favorites() { UserId = userId };
                databaseContext.Favorites.Add(fav);
                databaseContext.SaveChanges();
            }

            return fav;
        }

        public List<FavoriteProducts> TryGetByUserId(string userId)
        {
            return databaseContext.Favorites
                .Include(x=>x.FavoriteProducts)
                .FirstOrDefault(x => x.UserId == userId)?
                .FavoriteProducts ?? new List<FavoriteProducts>();
        }
    }
}
