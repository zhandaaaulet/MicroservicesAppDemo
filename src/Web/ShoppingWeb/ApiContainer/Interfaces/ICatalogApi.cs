using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer.Interfaces
{
    public interface ICatalogApi
    {
        Task<IEnumerable<CatalogResponse>> GetCatalog();
        Task<IEnumerable<CatalogResponse>> GetCatalogByCategory(string category);
        Task<CatalogResponse> GetCatalog(string id);
        Task<CatalogResponse> CreateCatalog(CatalogResponse response);
    }
}
