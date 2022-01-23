using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
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
            var response = await _httpClient.GetAsync("/Catalog");
            return await response.ReadContentAsAsync<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalogAsync(string id)
        {
            var response = await _httpClient.GetAsync($"/Catalog/{id}");
            return await response.ReadContentAsAsync<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategoryAsync(string category)
        {
            var response = await _httpClient.GetAsync($"/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAsAsync<List<CatalogModel>>();
        }

        public async Task<CatalogModel> CreateCatalogAsync(CatalogModel model)
        {
            var response = await _httpClient.PostAsJsonAsync($"/Catalog", model);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling api.");

            return await response.ReadContentAsAsync<CatalogModel>();
        }
    }
}