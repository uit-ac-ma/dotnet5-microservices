using AspnetRunBasics.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Checkout Async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> CheckOutAsync(Order order);

        /// <summary>
        /// Get user Orders Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetOrdersByUserNameAsync(string userName);
    }
}
