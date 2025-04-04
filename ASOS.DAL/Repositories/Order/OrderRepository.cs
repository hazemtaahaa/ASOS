using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Brand;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(StoreContext context) : base(context)
    {
    }
}

