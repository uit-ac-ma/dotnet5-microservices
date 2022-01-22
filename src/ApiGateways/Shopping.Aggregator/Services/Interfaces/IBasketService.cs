using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Interfaces
{
    public interface IBasketService
    {
        /// <summary>
        /// Get user Basket Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<BasketModel> GetBasketAsync(string userName);
    }
}