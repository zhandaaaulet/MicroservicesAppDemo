using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface ICatalogApi
    {
        Task<IEnumerable<CatalogModel>> GetGatalog();
        Task<IEnumerable<CatalogModel>> GetGatalogByCategory(string category);
        Task<CatalogModel> GetGatalog(string id);
        Task<CatalogModel> CreateGatalog(CatalogModel model);
    }
}
