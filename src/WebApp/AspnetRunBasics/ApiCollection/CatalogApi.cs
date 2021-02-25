using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class CatalogApi : BaseHttpClientWithFactory, ICatalogApi
    {
        private readonly IApiSettings _settings;

        public CatalogApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public Task<CatalogModel> CreateGatalog(CatalogModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetGatalog()
        {
            throw new NotImplementedException();
        }

        public Task<CatalogModel> GetGatalog(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetGatalogByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public override HttpRequestBuilder GetHttpRequestBuilder(string path)
        {
            throw new NotImplementedException();
        }
    }
}
