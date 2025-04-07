//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ASOS.APIs.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class UserController : ControllerBase
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly UserManager<User> _userManager;

//        public UserController(IUnitOfWork unitOfWork, UserManager<User> userManager)
//        {
//            _unitOfWork = unitOfWork;
//            _userManager = userManager;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllUsers()
//        {
//            var users = await _userManager.Users.ToListAsync();
//            return Ok(users);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetUser(string id)
//        {
//            var user = await _userManager.FindByIdAsync(id);
//            if (user == null)
//                return NotFound();
//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateUser([FromBody] UserRegistrationModel model)
//        {
//            var user = new User
//            {
//                UserName = model.Email,
//                Email = model.Email,
//                Address = model.Address,
//                City = model.City,
//                Country = model.Country
//            };

//            var result = await _userManager.CreateAsync(user, model.Password);
//            if (!result.Succeeded)
//                return BadRequest(result.Errors);

//            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateModel model)
//        {
//            var user = await _userManager.FindByIdAsync(id);
//            if (user == null)
//                return NotFound();

//            user.Address = model.Address;
//            user.City = model.City;
//            user.Country = model.Country;

//            var result = await _userManager.UpdateAsync(user);
//            if (!result.Succeeded)
//                return BadRequest(result.Errors);

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(string id)
//        {
//            var user = await _userManager.FindByIdAsync(id);
//            if (user == null)
//                return NotFound();

//            var result = await _userManager.DeleteAsync(user);
//            if (!result.Succeeded)
//                return BadRequest(result.Errors);

//            return NoContent();
//        }

//        [HttpGet("{id}/orders")]
//        public async Task<IActionResult> GetUserOrders(string id)
//        {
//            var orders = await _unitOfWork.UserOrderPayments.GetUserOrders(id);
//            return Ok(orders);
//        }

//        [HttpGet("{id}/payments")]
//        public async Task<IActionResult> GetUserPayments(string id)
//        {
//            var payments = await _unitOfWork.UserOrderPayments.GetUserPayments(id);
//            return Ok(payments);
//        }

//        [HttpGet("{id}/cart")]
//        public async Task<IActionResult> GetUserCart(string id)
//        {
//            var cart = await _unitOfWork.Carts.GetUserCart(id);
//            if (cart == null)
//                return NotFound();
//            return Ok(cart);
//        }

//        [HttpGet("{id}/wishlist")]
//        public async Task<IActionResult> GetUserWishList(string id)
//        {
//            var wishList = await _unitOfWork.WishLists.GetUserWishList(id);
//            if (wishList == null)
//                return NotFound();
//            return Ok(wishList);
//        }
//    }

//    public class UserRegistrationModel
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public string Address { get; set; }
//        public string City { get; set; }
//        public string Country { get; set; }
//    }

//    public class UserUpdateModel
//    {
//        public string Address { get; set; }
//        public string City { get; set; }
//        public string Country { get; set; }
//    }
//} 