using System.Collections.Generic;

namespace OnlineShop.db.Models
{
    public class Favorites
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public List<FavoriteProducts> FavoriteProducts { get; set; } = new();

    }
}
