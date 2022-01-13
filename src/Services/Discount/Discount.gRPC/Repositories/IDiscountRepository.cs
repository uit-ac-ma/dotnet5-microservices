using System.Threading.Tasks;
using Discount.gRPC.Entities;

namespace Discount.gRPC.Repositories
{
    public interface IDiscountRepository
    {
        /// <summary>
        /// Get discount by ProductName
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        Task<Coupon> GetDiscount(string productName);

        /// <summary>
        /// Create discount
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        Task<bool> CreateDiscount(Coupon coupon);

        /// <summary>
        /// Update discount
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        Task<bool> UpdateDiscount(Coupon coupon);

        /// <summary>
        /// Delete a discount for ProductName
        /// </summary>
        /// <remarks>Hard delete</remarks>
        /// <param name="productName"></param>
        /// <returns></returns>
        Task<bool> DeleteDiscount(string productName);
    }
}