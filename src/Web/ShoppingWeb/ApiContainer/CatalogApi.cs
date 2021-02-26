using Newtonsoft.Json;
using ShoppingWeb.ApiContainer.Infrastructure;
using ShoppingWeb.ApiContainer.Interfaces;
using ShoppingWeb.Models;
using ShoppingWeb.Settings;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer
{
    public class CatalogApi : BaseHttpClientWithFactory, ICatalogApi
    {
        private readonly IApiSettings _settings;

        public CatalogApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<CatalogResponse>> GetCatalog()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.CatalogPath)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await base.SendRequest<IEnumerable<CatalogResponse>>(message);
        }

        public async Task<CatalogResponse> GetCatalog(string id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)  //http://localhost:7000
                                .SetPath(_settings.CatalogPath)          //http://localhost:7000/Catalog   
                                .AddToPath(id)                           //http://localhost:7000/Catalog/id
                                .HttpMethod(HttpMethod.Get)              // GET http://localhost:7000/Catalog/id 
                                .GetHttpMessage();

            return await base.SendRequest<CatalogResponse>(message);
        }

        public async Task<IEnumerable<CatalogResponse>> GetCatalogByCategory(string category)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.CatalogPath)
                                .AddToPath("GetProductByCategory")
                                .AddToPath(category)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await base.SendRequest<IEnumerable<CatalogResponse>>(message);
        }


        public async Task<CatalogResponse> CreateCatalog(CatalogResponse response)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.CatalogPath)
                                .HttpMethod(HttpMethod.Post)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(response);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await base.SendRequest<CatalogResponse>(message);
        }

    }

}
