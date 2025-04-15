using ASOS.BL.DTOs;
using ASOS.BL.Managers.Product;
using ASOS.DAL.Models;
using ASOS.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASOS.BL.Managers.Cart
{
	public class CartManager : ICartManager
	{
		private readonly UserManager<User> _userManager;
		private readonly IProductManager _productManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public CartManager(UserManager<User> userManager
			, IProductManager productManager
			, IUnitOfWork unitOfWork
			,IConfiguration configuration)
		{
			_userManager = userManager;
			_productManager = productManager;
			_unitOfWork = unitOfWork;
			_configuration= configuration;
		}
		public async Task<List<ProductDTO>> GetUserCartAsync(string id)
		{
			var user=await _userManager.Users
				.Where(u=>u.Id == id)
				.Include(u=>u.Cart)
				.ThenInclude(c=>c.CartItems)
				.ThenInclude(ci=>ci.Product)
				.ThenInclude(p=>p.Brand)

				.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
				.ThenInclude(ci => ci.Product)
				.ThenInclude(p => p.Category)

				.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
				.ThenInclude(ci => ci.Product)
				.ThenInclude(p => p.ProductType)

				.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
				.ThenInclude(ci => ci.Product)
				.ThenInclude(p => p.ProductImages)
				.FirstOrDefaultAsync();

			var products = user.Cart.CartItems
				.Select(ci => ci.Product).ToList();

			var productsDto = products.Select(p => new ProductDTO
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = (decimal)p.Price,
				Rate = (decimal)p.Rate,
				Quantity = (int)p.Quantity,
				Section = p.Section,

				UpdatedAt = p.UpdatedAt,
				CreatedAt = p.CreatedAt,
				BrandName = p.Brand?.Name ?? string.Empty,
				CategoryName = p.Category?.Name ?? string.Empty,
				ProductTypeName = p.ProductType?.Name ?? string.Empty,
				ImageUrls = p.ProductImages?.Select(i => $"{_configuration["ApiBaseUrl"]}{i.ImageUrl}").ToList() ?? new List<string>()
			}).ToList();
			return productsDto;
		}
		/////////////////////////////////////////////////////////////////////
		public async Task<bool> AddToCartAsync(string userId, Guid productId)
		{
			var user = await _userManager.Users
				.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
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

			var alreadyExists = user.Cart.CartItems
				.Any(ci => ci.ProductId == productId);

			if (alreadyExists)
			{
				user.Cart.CartItems.FirstOrDefault(ci=>ci.ProductId == productId)
					.Quantity++;
				await _unitOfWork.CompleteAsync();
				return true;
			}
			var cartProduct = new CartItem
			{
				ProductId = productId,
				CartId = user.Cart.Id
			};
			await _unitOfWork.CartItems.AddAsync(cartProduct);
			await _unitOfWork.CompleteAsync();
			return true;
		}

		/////////////////////////////////////////////////////////////////////
		public async Task<bool> RemoveFromCartAsync(string userId, Guid productId)
		{
			var user = await _userManager.Users
			.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
			.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null || user.Cart == null)
			{
				return false;
			}

			var productToRemove = user.Cart.CartItems
		   .FirstOrDefault(ci => ci.ProductId == productId);

			if (productToRemove == null)
			{
				return false;
			}

			_unitOfWork.CartItems.Delete(productToRemove);
			await _unitOfWork.CompleteAsync();
			return true;
		}


		/////////////////////////////////////////////////////////////////////
		public async Task<bool> ClearCartAsync(string userId)
		{
			var user = await _userManager.Users
			.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
			.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null || user.Cart == null)
			{
				return false;
			}
			user.Cart.CartItems.Clear();
			await _unitOfWork.CompleteAsync();
			return true;
		}
		/////////////////////////////////////////////////////////////////////
		public async Task<bool> UpdateCartProductQuantityAsync(string userId, int quantity, Guid productId)
		{
			var user = await _userManager.Users
				.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
				.FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null)
			{
				return false;
			}
			var alreadyExists = user.Cart.CartItems
				.Any(ci => ci.ProductId == productId);

			if (!alreadyExists)
			{
				return false ;
			}
			user.Cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId)
					.Quantity=quantity;
			await _unitOfWork.CompleteAsync();
			return true;
		}
	}
}
