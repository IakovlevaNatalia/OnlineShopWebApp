using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Created")]
        Created,

        [Display(Name = "Processed")]
        Processed,

        [Display(Name = "OnTheWay")]
        OnTheWay,

        [Display(Name = "Canceled")]
        Canceled,

        [Display(Name = "Confirmed")]
        Confirmed,

    }
}