using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public interface ICartRepository : IGenericRepository<Cart>
{
	Task<Cart> GetCartByIdAsync(Guid id);
}
