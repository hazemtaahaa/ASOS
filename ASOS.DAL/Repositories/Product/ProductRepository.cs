using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class ProductRepository : GenericRepository<Product> ,IProductRepository
{
    public ProductRepository(StoreContext context) : base(context)
    {
    }
}


