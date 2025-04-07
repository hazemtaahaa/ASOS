//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    public class WishListController : BaseController<WishList>
//    {
//        public WishListController(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllWishLists()
//        {
//            return await GetAllAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetWishList(Guid id)
//        {
//            return await GetByIdAsync(id);
//        }

//        [HttpGet("user/{userId}")]
//        public async Task<IActionResult> GetUserWishList(string userId)
//        {
//            var wishList = await _unitOfWork.WishLists.GetUserWishList(userId);
//            if (wishList == null)
//                return NotFound();
//            return Ok(wishList);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateWishList(WishList wishList)
//        {
//            return await CreateAsync(wishList);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateWishList(Guid id, WishList wishList)
//        {
//            return await UpdateAsync(id, wishList);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteWishList(Guid id)
//        {
//            return await DeleteAsync(id);
//        }

//        [HttpPost("{wishListId}/products")]
//        public async Task<IActionResult> AddProductToWishList(Guid wishListId, [FromBody] WishListProduct product)
//        {
//            var wishList = await _unitOfWork.WishLists.GetByIdAsync(wishListId);
//            if (wishList == null)
//                return NotFound();

//            product.WishListId = wishListId;
//            await _unitOfWork.WishListProducts.AddAsync(product);
//            await _unitOfWork.CompleteAsync();
//            return CreatedAtAction(nameof(GetWishList), new { id = wishListId }, product);
//        }

//        [HttpDelete("{wishListId}/products/{productId}")]
//        public async Task<IActionResult> RemoveProductFromWishList(Guid wishListId, Guid productId)
//        {
//            var product = await _unitOfWork.WishListProducts.GetByIdAsync(productId);
//            if (product == null || product.WishListId != wishListId)
//                return NotFound();

//            _unitOfWork.WishListProducts.Delete(product);
//            await _unitOfWork.CompleteAsync();
//            return NoContent();
//        }

//        protected override Guid GetEntityId(WishList entity)
//        {
//            return entity.Id;
//        }
//    }
//} 