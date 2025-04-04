using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
{
    public ProductTypeRepository(StoreContext context) : base(context)
    {
    }
}

