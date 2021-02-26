using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer.Interfaces
{
    public interface IBasketApi
    {
        Task<BasketResponse> GetBasket(string userName);
        Task<BasketResponse> UpdateBasket(BasketResponse response);
        Task CheckoutBasket(BasketCheckoutResponse response);
    }
}
