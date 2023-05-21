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
                productCount = favoriteRepository.TryGetByUserId(User.Identity.Name).Count;
            }

            return View("CalcFavoriteProductsCount", productCount);
        }
    }
}
    

