using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

namespace OnlineShop.db
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Favorites> Favorites { get; set; }

        public DbSet<FavoriteProducts> FavoriteProducts { get; set; }

        public DbSet<Image> Image { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            this.Database.SetCommandTimeout(300);
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            var product1Id = 1;
            var product2Id = 2;
            var product3Id = -3;
            var product4Id = -4;
            var product5Id = -5;
            var product6Id = -6;
            var product7Id = -7;
            var product8Id = -8;
            var product9Id = -9;
            var product10Id = -10;
            var product11Id = -11;
            var product12Id = -12;

            var image1 = new Image
            {
                Id=product1Id,
                Url = "/images/turkey.jpg",
                ProductId = product1Id
            };
            var image2 = new Image
            {
                Id = product2Id,
                Url = "/images/greece.jpg",
                ProductId = product2Id
            };
            var image3 = new Image
            {
                Id = product3Id,
                Url = "/images/bulgary.jpg",
                ProductId = product3Id
            };
            var image4 = new Image
            {
                Id = product4Id,
                Url = "/images/aruba.jpg",
                ProductId = product4Id
            };
            var image5 = new Image
            {
                Id = product5Id,
                Url = "/images/mexico.jpg",
                ProductId = product5Id
            };
            var image6 = new Image
            {
                Id = product6Id,
                Url = "/images/bali.jpg",
                ProductId = product6Id
            };
            var image7 = new Image
            {
                Id = product7Id,
                Url = "/images/egypt.jpg",
                ProductId = product7Id
            };
            var image8 = new Image
            {
                Id = product8Id,
                Url = "/images/uae.jpg",
                ProductId = product8Id
            };
            var image9 = new Image
            {
                Id = product9Id,
                Url = "/images/seyshels.jpg",
                ProductId = product9Id
            };
            var image10 = new Image
            {
                Id = product10Id,
                Url = "/images/jamaica.jpg",
                ProductId = product10Id
            };
            var image11 = new Image
            {
                Id = product11Id,
                Url = "/images/india.jpg",
                ProductId = product11Id
            };
            var image12 = new Image
            {
                Id = product12Id,
                Url = "/images/thailand.jpg",
                ProductId = product12Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4, image5, image6, image7, image8, image9,
                image10, image11, image12);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id,"Tour to Turkey", 1000,  "Best tour to Turkey"),
                new Product(product2Id,"Tour to Greece", 1100, "Best tour to Greece"),
                new Product(product3Id,"Tour to Bulgaria", 1200, "Best tour to Bulgaria"),
                new Product(product4Id,"Tour to Aruba", 1300, "Best tour to Aruba"),
                new Product(product5Id,"Tour to Mexico", 1400, "Best tour to Mexico"),
                new Product(product6Id,"Tour to Bali", 1500, "Best tour to Bali"),
                new Product(product7Id,"Tour to Egypt", 1600, "Best tour to to Egypt"),
                new Product(product8Id,"Tour to UAE", 1700, "Best tour to UAE"),
                new Product(product9Id,"Tour to Seychelles", 1800, "Best tour to Seychelles"),
                new Product(product10Id,"Tour to Jamaica", 1900, "Best tour to Jamaica"),
                new Product(product11Id,"Tour to India", 2000, "Best tour to India"),
                new Product(product12Id,"Tour to Thailand", 2210, "Best tour to Thailand")
            });
        }
    }
}

