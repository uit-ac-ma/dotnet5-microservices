using AspnetRunBasics.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get Products Async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsAsync();

        /// <summary>
        /// Get Product by ID Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Get Products by Name Async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);

        /// <summary>
        /// Get Products by Category Async
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);

        /// <summary>
        /// Get Categories Async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
