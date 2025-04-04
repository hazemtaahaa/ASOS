using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

internal class WishListProductRepository : GenericRepository<WishListProduct>, IWishListProductRepository
{
    public WishListProductRepository(StoreContext context) : base(context)
    {
    }
}
