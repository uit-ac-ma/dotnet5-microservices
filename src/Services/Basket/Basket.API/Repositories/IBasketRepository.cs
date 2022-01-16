using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        /// <summary>
        /// Get Basket by username Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ShoppingCart> GetBasketAsync(string userName);

        /// <summary>
        /// Update Basket Async
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);

        /// <summary>
        /// Delete Basket by username Async
        /// </summary>
        /// <remarks>Hard delete</remarks>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task DeleteBasketAsync(string userName);
    }
}