﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWeb.ApiContainer.Interfaces;
using ShoppingWeb.Models;

namespace ShoppingWeb.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderApi _orderApi;

        public OrderModel(IOrderApi orderApi)
        {
            _orderApi = orderApi ?? throw new ArgumentNullException(nameof(orderApi));
        }

        public IEnumerable<OrderResponse> Orders { get; set; } = new List<OrderResponse>();

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderApi.GetOrdersByUsername("zhand");

            return Page();
        }
    }
}