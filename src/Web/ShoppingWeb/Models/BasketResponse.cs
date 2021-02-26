using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.Models
{
    public class BasketResponse
    {
        public string UserName { get; set; }
        public List<BasketItemResponse> Items { get; set; } = new List<BasketItemResponse>();
        public decimal TotalPrice { get; set; }

    }
}
