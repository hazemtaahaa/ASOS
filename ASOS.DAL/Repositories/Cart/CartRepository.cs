using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(StoreContext context) : base(context)
    {
    }
}

