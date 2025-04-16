using ASOS.BL.DTOs.Common;
using ASOS.BL.DTOs;
using System.Security.Claims;
using ASOS.BL.Managers.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ASOS.BL.DTOs.ProductInCart;
using Microsoft.AspNetCore.Identity;
using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ASOS.APIs.Controllers.Cart
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class CartController:ControllerBase
	{
		private readonly ICartManager _cartManager;
		private readonly UserManager<User> _userManager;

		public CartController(ICartManager cartManager, UserManager<User> userManager)
		{
			_cartManager= cartManager;
			_userManager= userManager;
		}

		[HttpGet("products")]
		public async Task<Ok<GeneralResultCart<List<ProductInCartDto>>>> GetAsync()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await _userManager.Users
				.Include(u => u.Cart)
				.ThenInclude(c => c.CartItems)
				.FirstOrDefaultAsync(u => u.Id == userId);
			var products = await _cartManager.GetUserCartAsync(userId);
			var productsInCart= products.Select(p => new ProductInCartDto
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				Rate = p.Rate,
				Quantity = p.Quantity,
				Section = p.Section,

				UpdatedAt = p.UpdatedAt,
				CreatedAt = p.CreatedAt,
				BrandName = p.BrandName,
				CategoryName = p.CategoryName,
				ProductTypeName = p.ProductTypeName,
				ImageUrls = p.ImageUrls,
				QuantityInCart= user.Cart.CartItems.FirstOrDefault(ci => ci.ProductId == p.Id).Quantity
			}).ToList();
			decimal totalPrice = 0;
			foreach (var item in productsInCart)
			{
				totalPrice += (item.Price*item.QuantityInCart);
			}
			return TypedResults.Ok(new GeneralResultCart<List<ProductInCartDto>>() { Data = productsInCart,TotalCount=productsInCart.Count(),TotalPrice=totalPrice, Success = true, Errors = [] });
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[HttpPost("products/{productId}")]
		public async Task<Results<Ok<string>, UnauthorizedHttpResult, NotFound>> AddAsync(Guid productId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return TypedResults.Unauthorized();
			}
			var success = await _cartManager.AddToCartAsync(userId, productId);
			if (!success)
			{
				return TypedResults.NotFound();
			}

			return TypedResults.Ok("Product added to cart.");
		}

		///////////////////////////////////////////////////////////////////////////////////

		[HttpDelete("products/{productId}")]
		public async Task<Results<Ok<string>, UnauthorizedHttpResult, NotFound>>
			RemoveProduct(Guid productId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return TypedResults.Unauthorized();
			}

			var success = await _cartManager.RemoveFromCartAsync(userId, productId);
			if (!success)
			{
				return TypedResults.NotFound();
			}

			return TypedResults.Ok("Product removed from cart.");
		}
		///////////////////////////////////////////////////////////////////////////////////
		[HttpDelete("products")]
		public async Task<Results<Ok<string>, UnauthorizedHttpResult, NotFound>>
			ClearAsync()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return TypedResults.Unauthorized();
			}
			var success=await _cartManager.ClearCartAsync(userId);
			if (!success)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok("Cart has been cleared");
		}
		///////////////////////////////////////////////////////////////////////////////////
		[HttpPut("products/{productId}/{quantity}")]
		public async Task<Results<Ok<string>, UnauthorizedHttpResult, NotFound>>
			UpdateQuantityAsync(Guid productId,int quantity)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return TypedResults.Unauthorized();
			}
			var success=await _cartManager
				.UpdateCartProductQuantityAsync(userId, quantity,productId);
			if (!success)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok("Quantity updated");
		}
	}
}
