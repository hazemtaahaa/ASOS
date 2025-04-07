//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    public class OrderController : BaseController<Order>
//    {
//        public OrderController(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllOrders()
//        {
//            return await GetAllAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetOrder(Guid id)
//        {
//            return await GetByIdAsync(id);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateOrder(Order order)
//        {
//            order.Date = DateTime.UtcNow;
//            order.Status = OrderStatus.Pending;
//            return await CreateAsync(order);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateOrder(Guid id, Order order)
//        {
//            return await UpdateAsync(id, order);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteOrder(Guid id)
//        {
//            return await DeleteAsync(id);
//        }

//        [HttpPut("{id}/status")]
//        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] OrderStatus status)
//        {
//            var order = await _unitOfWork.Orders.GetByIdAsync(id);
//            if (order == null)
//                return NotFound();

//            order.Status = status;
//            _unitOfWork.Orders.Update(order);
//            await _unitOfWork.CompleteAsync();
//            return NoContent();
//        }

//        [HttpGet("user/{userId}")]
//        public async Task<IActionResult> GetUserOrders(string userId)
//        {
//            var orders = await _unitOfWork.UserOrderPayments.GetUserOrders(userId);
//            return Ok(orders);
//        }

//        protected override Guid GetEntityId(Order entity)
//        {
//            return entity.Id;
//        }
//    }
//} 