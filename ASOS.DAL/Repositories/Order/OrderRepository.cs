using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Brand;
using ASOS.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(StoreContext context) : base(context)
    {
    }

    public async Task<Order> GetOrderByIdAsync(Guid id)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ThenInclude(p => p.ProductImages)
            .Include(o => o.UserOrderPayment)
            .ThenInclude(u=>u.User)      
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}

