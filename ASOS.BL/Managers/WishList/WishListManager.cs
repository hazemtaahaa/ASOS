using ASOS.BL.Managers.Product;
using ASOS.DAL.Models;
using ASOS.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.WishList
{
	public class WishListManager : IWishListManager
	{
		private readonly UserManager<User> _userManager;
		private readonly IProductManager _productManager;
		private readonly IUnitOfWork _unitOfWork;

		public WishListManager(UserManager<User> userManager
			, IProductManager productManager
			, IUnitOfWork unitOfWork)
		{
			_userManager=userManager;
			_productManager=productManager;
			_unitOfWork=unitOfWork;
		}


		public async Task<List<ProductDTO>> GetUserWishlistAsync(string id)
		{
			var user = await _userManager.Users
		.Where(u => u.Id == id)
		.Include(u => u.WishList)
			.ThenInclude(w => w.WishListProducts)
				.ThenInclude(wp => wp.Product)
					.ThenInclude(p => p.Brand)
		.Include(u => u.WishList)
			.ThenInclude(w => w.WishListProducts)
				.ThenInclude(wp => wp.Product)
					.ThenInclude(p => p.Category)
		.Include(u => u.WishList)
			.ThenInclude(w => w.WishListProducts)
				.ThenInclude(wp => wp.Product)
					.ThenInclude(p => p.ProductType)
		.Include(u => u.WishList)
			.ThenInclude(w => w.WishListProducts)
				.ThenInclude(wp => wp.Product)
					.ThenInclude(p => p.ProductImages)
		.FirstOrDefaultAsync();


			var products = user.WishList.WishListProducts
				.Select(wp => wp.Product).ToList();
				
			var productsDto = products.Select(p => new ProductDTO
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = (decimal)p.Price,
				Rate = (decimal)p.Rate,
				Quantity = (int)p.Quantity,
				Section = p.Section,
				UpdatedAt = (DateTime)p.UpdatedAt,
				CreatedAt = p.CreatedAt,
				BrandName = p.Brand.Name,
				CategoryName = p.Category.Name,
				ProductTypeName = p.ProductType.Name,
				ImageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList()
			}).ToList();
			return productsDto;
		}


		////////////////////////////////////////////////////////////////////////////////////////
		public async Task<bool> AddToWishListAsync(string userId, Guid productId)
		{
			var user = await _userManager.Users
				.Include(u => u.WishList)
				.ThenInclude(w => w.WishListProducts)
				.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null)
			{
				return false;
			}
			
			var product = await _productManager.GetByIdAsync(productId);
			if (product == null)
			{
				return false;
			}

			var alreadyExists = user.WishList.WishListProducts
				.Any(wp => wp.ProductId == productId);

			if (alreadyExists)
			{
				return false;
			}
				

			var wishListProduct = new WishListProduct
			{
				ProductId = productId,
				WishListId = user.WishList.Id
			};
			await _unitOfWork.WishListProducts.AddAsync(wishListProduct);
			await _unitOfWork.CompleteAsync();
			return true;
		}

		///////////////////////////////////////////////////////////////////////////////
		public async Task<bool> RemoveFromWishListAsync(string userId, Guid productId)
		{
			var user = await _userManager.Users
			.Include(u => u.WishList)
				.ThenInclude(w => w.WishListProducts)
			.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null || user.WishList == null)
			{
				return false;
			}

			var productToRemove = user.WishList.WishListProducts
		   .FirstOrDefault(wp => wp.ProductId == productId);

			if (productToRemove == null)
			{
				return false;
			}

			_unitOfWork.WishListProducts.Delete(productToRemove);
			await _unitOfWork.CompleteAsync();
			return true;
		}
	}
}
