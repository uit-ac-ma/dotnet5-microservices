using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        public Task<BasketModel> GetBasketAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}