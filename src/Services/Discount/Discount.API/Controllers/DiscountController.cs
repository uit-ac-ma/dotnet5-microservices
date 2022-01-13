using System.Net;
using System.Threading.Tasks;
using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get discount by productname Async
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscountAsync(string productName)
        {
            return Ok(await _repository.GetDiscount(productName));
        }

        /// <summary>
        /// Create discount Async
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Coupon>> CreateDiscountAsync([FromBody] Coupon coupon)
        {
            await _repository.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
        }

        /// <summary>
        /// Update discount Async
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateDiscountAsync([FromBody] Coupon coupon)
        {
            return Ok(await _repository.UpdateDiscount(coupon));
        }

        /// <summary>
        /// Delete discount for productname Async
        /// </summary>
        /// <remarks>Hard delete</remarks>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscountAsync(string productName)
        {
            return Ok(await _repository.DeleteDiscount(productName));
        }
    }
}