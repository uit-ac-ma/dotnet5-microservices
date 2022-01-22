using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountgRPCService _discountgRPCService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, DiscountgRPCService discountgRPCService, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _discountgRPCService = discountgRPCService;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Basket by username Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasketAsync(string userName)
        {
            var basket = await _basketRepository.GetBasketAsync(userName);

            return Ok(basket ?? new ShoppingCart(userName));// If not, initialize new basket
        }

        /// <summary>
        /// Update Basket for username Async
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasketAsync(ShoppingCart basket)
        {
            // TODO : Communicate with Discount.Grpc
            // and Calculate latest prices of product into shopping cart
            // consume Discount Grpc
            foreach (var item in basket.Items)
            {
                var coupon = await _discountgRPCService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await _basketRepository.UpdateBasketAsync(basket));
        }

        /// <summary>
        /// Delete Basket by username Async
        /// </summary>
        /// <remarks>Hard delete</remarks>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasketAsync(string userName)
        {
            await _basketRepository.DeleteBasketAsync(userName);

            return NoContent();
        }

        /// <summary>
        /// Checkout Async
        /// </summary>
        /// <param name="basketCheckout"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckoutAsync([FromBody] BasketCheckout basketCheckout)
        {
            // get existing basket with total price
            var basket = await _basketRepository.GetBasketAsync(basketCheckout.UserName);
            if (basket == null) return BadRequest();

            // send BasketCheckoutEvent to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);

            // remove the basket
            await _basketRepository.DeleteBasketAsync(basket.UserName);

            return Accepted();// 202
        }

    }
}