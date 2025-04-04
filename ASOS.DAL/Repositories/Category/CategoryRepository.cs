using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(StoreContext context) : base(context)
    {
    }
}

