using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Created")]
        Created,

        [Display(Name = "Confirmed")]
        Confirmed,

        [Display(Name = "Processed")]
        Processed,

        [Display(Name = "Canceled")]
        Canceled,

        [Display(Name = "Not confirmed")]
        NotConfirmed

    }
}