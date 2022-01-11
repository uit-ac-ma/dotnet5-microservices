using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        /// <summary>
        /// Get Basket by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<ShoppingCart> GetBasket(string username);

        /// <summary>
        /// Update Basket
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

        /// <summary>
        /// Delete Basket by username
        /// </summary>
        /// <remarks>Hard delete</remarks>
        /// <param name="username"></param>
        /// <returns></returns>
        Task DeleteBasket(string username);
    }
}