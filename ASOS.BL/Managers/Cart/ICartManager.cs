using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Cart
{
	public interface ICartManager
	{
		Task<List<ProductDTO>> GetUserCartAsync(string id);
		Task<bool> AddToCartAsync(string userId, Guid productId);

		Task<bool> RemoveFromCartAsync(string userId, Guid productId);
	}
}
