using ASOS.BL.DTOs.Common;
using ASOS.BL.DTOs;
using System.Security.Claims;
using ASOS.BL.Managers.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Cart
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class CartController:ControllerBase
	{
		private readonly ICartManager _cartManager;

		public CartController(ICartManager cartManager)
		{
			_cartManager= cartManager;
		}

		[HttpGet("products")]
		public async Task<Ok<GeneralResult<List<ProductDTO>>>> GetAsync()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var products = await _cartManager.GetUserCartAsync(userId);
			return TypedResults.Ok(new GeneralResult<List<ProductDTO>>() { Data = products, Success = true, Errors = [] });
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
	}
}
