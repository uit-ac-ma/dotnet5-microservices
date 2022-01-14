using System.Threading.Tasks;
using Discount.gRPC.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountgRPCService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountgRPCService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        /// <summary>
        /// Get discount for product
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}