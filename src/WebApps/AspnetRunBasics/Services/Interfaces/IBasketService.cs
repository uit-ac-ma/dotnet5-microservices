using System.Threading.Tasks;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services.Interfaces
{
    public interface IBasketService
    {
        /// <summary>
        /// Get user BasketAsync
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<BasketModel> GetBasketAsync(string userName);

        /// <summary>
        /// Update Basket Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<BasketModel> UpdateBasketAsync(BasketModel model);

        /// <summary>
        /// Checkout Basket Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CheckoutBasketAsync(BasketCheckoutModel model);
    }
}