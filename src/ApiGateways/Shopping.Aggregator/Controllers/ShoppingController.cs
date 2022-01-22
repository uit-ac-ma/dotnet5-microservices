using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService, IOrderService orderService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
            _orderService = orderService;
        }

        /// <summary>
        /// Get user shopping Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShoppingAsync(string userName)
        {
            // 1- Get basket with username
            var basket = await _basketService.GetBasketAsync(userName);

            // 2- Iterate basket items and consume products with basket item productId member
            foreach (var item in basket.Items)
            {
                // 3- Map product related members into basketitem dto with extended columns
                var product = await _catalogService.GetCatalogAsync(item.ProductId);

                // set additional product fields onto basket item
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            // 4- Consume ordering microservices in order to retrieve order list
            var orders = await _orderService.GetOrdersByUserNameAsync(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            // 5- return root ShoppngModel dto class which including all responses
            return Ok(shoppingModel);
        }
    }
}