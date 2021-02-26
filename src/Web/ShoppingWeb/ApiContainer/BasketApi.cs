using Newtonsoft.Json;
using ShoppingWeb.ApiContainer.Infrastructure;
using ShoppingWeb.ApiContainer.Interfaces;
using ShoppingWeb.Models;
using ShoppingWeb.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer
{
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _settings;

        public BasketApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public async Task<BasketResponse> GetBasket(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.BasketPath)
                                .AddQueryString("username", userName)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await base.SendRequest<BasketResponse>(message);
        }

        public async Task<BasketResponse> UpdateBasket(BasketResponse response)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.BasketPath)
                                .HttpMethod(HttpMethod.Post)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(response);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await base.SendRequest<BasketResponse>(message);
        }

        public async Task CheckoutBasket(BasketCheckoutResponse response)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .AddToPath("Checkout")
                                .SetPath(_settings.BasketPath)
                                .HttpMethod(HttpMethod.Post)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(response);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            await base.SendRequest<BasketCheckoutResponse>(message);
        }




    }
}
