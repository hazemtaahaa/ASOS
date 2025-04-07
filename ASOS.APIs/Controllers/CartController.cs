//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    public class CartController : BaseController<Cart>
//    {
//        public CartController(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllCarts()
//        {
//            return await GetAllAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetCart(Guid id)
//        {
//            return await GetByIdAsync(id);
//        }

//        [HttpGet("user/{userId}")]
//        public async Task<IActionResult> GetUserCart(string userId)
//        {
//            var cart = await _unitOfWork.Carts.GetUserCart(userId);
//            if (cart == null)
//                return NotFound();
//            return Ok(cart);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateCart(Cart cart)
//        {
//            return await CreateAsync(cart);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCart(Guid id, Cart cart)
//        {
//            return await UpdateAsync(id, cart);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCart(Guid id)
//        {
//            return await DeleteAsync(id);
//        }

//        [HttpPost("{cartId}/items")]
//        public async Task<IActionResult> AddItemToCart(Guid cartId, [FromBody] CartItem item)
//        {
//            var cart = await _unitOfWork.Carts.GetByIdAsync(cartId);
//            if (cart == null)
//                return NotFound();

//            item.CartId = cartId;
//            await _unitOfWork.CartItems.AddAsync(item);
//            await _unitOfWork.CompleteAsync();
//            return CreatedAtAction(nameof(GetCart), new { id = cartId }, item);
//        }

//        [HttpDelete("{cartId}/items/{itemId}")]
//        public async Task<IActionResult> RemoveItemFromCart(Guid cartId, Guid itemId)
//        {
//            var item = await _unitOfWork.CartItems.GetByIdAsync(itemId);
//            if (item == null || item.CartId != cartId)
//                return NotFound();

//            _unitOfWork.CartItems.Delete(item);
//            await _unitOfWork.CompleteAsync();
//            return NoContent();
//        }

//        protected override Guid GetEntityId(Cart entity)
//        {
//            return entity.Id;
//        }
//    }
//} 