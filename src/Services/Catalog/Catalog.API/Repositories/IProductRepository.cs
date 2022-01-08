using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProduct(string id);

        /// <summary>
        /// Get Products by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsByName(string name);

        /// <summary>
        /// Get Products by Category
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryName);

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task CreateProduct(Product product);

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<bool> UpdateProduct(Product product);
        
        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>        
        Task<bool> DeleteProduct(string productId);
    }
}