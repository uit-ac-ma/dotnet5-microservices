using AspnetRunBasics.Data;
using AspnetRunBasics.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly AspnetRunContext _dbContext;

        public OrderRepository(AspnetRunContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> CheckOutAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserNameAsync(string userName)
        {
            var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == userName)
                            .ToListAsync();

            return orderList;
        }
    }
}
