using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Models;
using OnlineShop.db;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProductsCount
{
    public class CalcFavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly UserManager<User> userManager;

        public CalcFavoriteProductsCountViewComponent(IFavoriteRepository favoriteRepository, UserManager<User> userManager)
        {
            this.favoriteRepository = favoriteRepository;
            this.userManager= userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCount = 0;
            if (User.Identity.IsAuthenticated)
            {
                //TODO 
                string userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
                var favorites = favoriteRepository.TryGetByUserId(User.Identity.Name);
                productCount = favorites?.Products.Count ?? 0;
            }
            return View("CalcFavoriteProductsCount", productCount);
        }
    }
}
    

