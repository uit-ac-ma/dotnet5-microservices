using System.Net;
using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// Get Basket by username Async
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasketAsync(string username)
        {
            var basket = await _basketRepository.GetBasket(username);

            return Ok(basket ?? new ShoppingCart(username));// If not, initialize new basket
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
            return Ok(await _basketRepository.UpdateBasket(basket));
        }

         /// <summary>
        /// Get Basket by username Async
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasketAsync(string username)
        {
            await _basketRepository.DeleteBasket(username);

            return NoContent();
        }

    }
}