using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<BasketModel> GetBasketAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}