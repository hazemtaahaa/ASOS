using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.WishList
{
	public interface IWishListManager
	{
		Task<List<ProductDTO>> GetUserWishlistAsync(string id);
		Task<bool> AddToWishListAsync(string userId, Guid productId);

		Task<bool> RemoveFromWishListAsync(string userId,Guid productId);
	}
}
