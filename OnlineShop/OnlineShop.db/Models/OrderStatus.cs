using System.ComponentModel.DataAnnotations;

namespace OnlineShop.db.Models
{
    public enum OrderStatus
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
        Confirmed

    }
}