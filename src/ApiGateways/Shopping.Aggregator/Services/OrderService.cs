using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        public Task<IEnumerable<OrderResponseModel>> GetOrdersByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}