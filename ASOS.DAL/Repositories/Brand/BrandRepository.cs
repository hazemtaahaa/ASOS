using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(StoreContext context) : base(context)
    {
    }
}