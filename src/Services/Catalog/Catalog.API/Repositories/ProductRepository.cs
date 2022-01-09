using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task CreateProduct(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Id, productId);

            var deleteProductResult = await _catalogContext.Products.DeleteOneAsync(filter);

            return deleteProductResult.IsAcknowledged &&
                    deleteProductResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext.Products.Find(product => product.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Name, name);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(product => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Category, categoryName);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var productId = product.Id;
            var updateProductResult = await _catalogContext.Products.ReplaceOneAsync(filter: product => product.Id == productId, replacement: product);

            return updateProductResult.IsAcknowledged &&
                    updateProductResult.ModifiedCount > 0;
        }
    }
}