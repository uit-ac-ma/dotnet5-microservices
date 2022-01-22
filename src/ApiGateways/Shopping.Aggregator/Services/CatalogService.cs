using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        public Task<CatalogModel> GetCatalogAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogsByCategoryAsync(string category)
        {
            throw new System.NotImplementedException();
        }
    }
}