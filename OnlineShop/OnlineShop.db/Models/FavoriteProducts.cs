namespace OnlineShop.db.Models
{
    public class FavoriteProducts
    {
        public int Id { get; set; }

        public int FavoriteId { get; set; }

        public int ProductId { get; set; }

        public Favorites Favorite { get; set; } = null;

        public Product Product { get; set; } = null;
    }
}
