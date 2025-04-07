using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(StoreContext context) : base(context)
    {
    }

    public Task<Category?> GetByNameAsync(string name)
    {
        return _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
    }
}

