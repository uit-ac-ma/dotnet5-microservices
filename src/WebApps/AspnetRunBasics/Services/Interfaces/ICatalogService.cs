using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Interfaces
{
    public interface ICatalogService
    {
        /// <summary>
        /// Get Catalogs Async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CatalogModel>> GetCatalogsAsync();

        /// <summary>
        /// Get Catalogs by category Async
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<CatalogModel>> GetCatalogsByCategoryAsync(string category);

        /// <summary>
        /// Get Catalog by Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CatalogModel> GetCatalogAsync(string id);

        /// <summary>
        /// Create Catalog Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CatalogModel> CreateCatalogAsync(CatalogModel model);
    }
}