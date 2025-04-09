using ASOS.BL.DTOs.Common;
using ASOS.BL.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ASOS.BL.Managers.WishList;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ASOS.APIs.Controllers.WishList
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class WishListController:ControllerBase
	{
		private readonly IWishListManager _wishListManager;

		public WishListController(IWishListManager wishListManager)
		{
			_wishListManager=wishListManager;
		}

		[HttpGet("products")]
		public async Task<Ok<GeneralResult<List<ProductDTO>>>> GetAsync()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var products= await _wishListManager.GetUserWishlistAsync(userId);
			return TypedResults.Ok(new GeneralResult<List<ProductDTO>>() { Data = products, Success = true, Errors = [] });
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[HttpPost("products/{productId}")]
		public async Task<Results<Ok<string>, UnauthorizedHttpResult, NotFound>>AddAsync(Guid productId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return TypedResults.Unauthorized();
			}
			var success = await _wishListManager.AddToWishListAsync(userId, productId);
			if (!success)
			{
				return TypedResults.NotFound();
			}

			return TypedResults.Ok("Product added to wishlist.");
		}

		///////////////////////////////////////////////////////////////////////////////////

		[HttpDelete("products/{productId}")]
		public async Task<Results<Ok<string>, UnauthorizedHttpResult,NotFound>>
			RemoveProduct(Guid productId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return TypedResults.Unauthorized();
			}

			var success=await _wishListManager.RemoveFromWishListAsync(userId, productId);
			if (!success)
			{
				return TypedResults.NotFound();
			}

			return TypedResults.Ok("Product removed from wishlist.");
		}

	}
}
