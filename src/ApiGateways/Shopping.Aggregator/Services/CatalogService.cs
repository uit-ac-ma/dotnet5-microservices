using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsAsync()
        {
            var response = await _httpClient.GetAsync("/api/v1/Catalog");
            return await response.ReadContentAsAsync<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalogAsync(string id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");
            return await response.ReadContentAsAsync<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategoryAsync(string category)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAsAsync<List<CatalogModel>>();
        }
    }
}