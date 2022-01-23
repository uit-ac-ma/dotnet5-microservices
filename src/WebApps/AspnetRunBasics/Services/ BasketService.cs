using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketModel> GetBasketAsync(string userName)
        {
            var response = await _httpClient.GetAsync($"/Basket/{userName}");
            return await response.ReadContentAsAsync<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasketAsync(BasketModel model)
        {
            var response = await _httpClient.PostAsJsonAsync($"/Basket", model);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling api.");

            return await response.ReadContentAsAsync<BasketModel>();

        }

        public async Task CheckoutBasketAsync(BasketCheckoutModel model)
        {
            var response = await _httpClient.PostAsJsonAsync($"/Basket/Checkout", model);
            
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling api.");
        }
    }
}