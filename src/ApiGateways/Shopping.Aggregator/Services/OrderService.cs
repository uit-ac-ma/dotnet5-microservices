using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<OrderResponseModel>> GetOrdersByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}