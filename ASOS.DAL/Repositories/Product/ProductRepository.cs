using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL;

public class ProductRepository : GenericRepository<Product> ,IProductRepository
{
    

    public ProductRepository(StoreContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllProductAsync()
    {
        return await _context.Products
            .Include(p => p.ProductImages)
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.ProductType)
            .ToListAsync();
    }
  

}


