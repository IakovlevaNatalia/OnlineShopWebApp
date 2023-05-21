using System.Linq;
using System.Collections.Generic;
using System;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public int? Id { get; set; }

        public UserViewModel User { get; set; }

        public OrderStatusViewModel Status { get; set; }

        public DateTime CreateDateTime { get; set; }

        public List<CartItemViewModel> CartItems { get; set; }

        public OrderViewModel()
        {
            Status = OrderStatusViewModel.Created;
            CreateDateTime = DateTime.Now;
            CartItems = new List<CartItemViewModel>();
        }

        public decimal Cost => CartItems.Sum(x => x.Cost);
    }
}
