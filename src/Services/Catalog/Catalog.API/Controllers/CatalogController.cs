using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get Products Async
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProdutsAsync()
        {

            var products = await _productRepository.GetProducts();

            return Ok(products);
        }

        /// <summary>
        /// Get Product by Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductByIdAsync(string id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product != null) return Ok(product);

            _logger.LogError($"Product with id: {id}, not found.");
            return NotFound();
        }

        /// <summary>
        /// Get Products by Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategoryAsync(string category)
        {
            var products = await _productRepository.GetProductsByCategory(category);
            return Ok(products);
        }

        /// <summary>
        /// Create Product Async
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Update Product Async
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            await _productRepository.UpdateProduct(product);
            return NoContent();
        }

        /// <summary>
        /// Delete Product Async
        /// </summary>
        /// <remarks>Hard delete</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProductAsync(string id)
        {
            await _productRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}