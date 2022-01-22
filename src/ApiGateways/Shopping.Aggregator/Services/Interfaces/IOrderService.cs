using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Get user Orders Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserNameAsync(string userName);
    }
}