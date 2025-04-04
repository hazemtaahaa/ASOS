using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class WishListRepository : GenericRepository<WishList>, IWishListRepository
{
    public WishListRepository(StoreContext context) : base(context)
    {
    }
}
