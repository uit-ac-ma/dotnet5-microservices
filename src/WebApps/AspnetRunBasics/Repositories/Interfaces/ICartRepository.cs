using AspnetRunBasics.Entities;
using System.Threading.Tasks;

namespace AspnetRunBasics.Repositories
{
    public interface ICartRepository
    {
        /// <summary>
        /// Get user Cart Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<Cart> GetCartByUserNameAsync(string userName);

        /// <summary>
        /// Add Item Async
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        Task AddItemAsync(string userName, int productId, int quantity = 1, string color = "Black");

        /// <summary>
        /// Remove Item Async
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
        Task RemoveItemAsync(int cartId, int cartItemId);

        /// <summary>
        /// Clear Cart Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task ClearCartAsync(string userName);
    }
}
