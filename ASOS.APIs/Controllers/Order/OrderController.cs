using ASOS.BL.DTOs;
using ASOS.BL.DTOs.Common;
using ASOS.BL.Managers.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromQuery] Guid cartId, [FromQuery] string address, [FromQuery] string phoneNumber)
        {
            var result = await _orderManager.CreateOrderAsync(cartId, address, phoneNumber);
            if (result)
            {
                return Ok(new { message = "Order created successfully." });
            }
            return BadRequest(new { message = "Failed to create order." });
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelOrder([FromQuery] Guid orderId)
        {
            var result = await _orderManager.CancelOrderAsync(orderId);
            if (result)
            {
                return Ok(new { message = "Order cancelled successfully." });
            }
            return BadRequest(new { message = "Failed to cancel order." });
        }

        [HttpPost("complete")]
        public async Task<IActionResult> CompleteOrder([FromQuery] Guid orderId)
        {
            var ClientSecret = await _orderManager.CompleteOrderPaymentAsync( orderId);
            
           return Ok(new GeneralResult<string> (){ Errors = [], Success = true, Data = (string)ClientSecret });
            return BadRequest(new { message = "Failed to complete order." });
        }

        [HttpGet("user-orders")]
        public async Task<IActionResult> GetUserOrders([FromQuery] string userId)
        {
            var orders = await _orderManager.GetUserOrdersAsync(userId);
            if (orders != null)
            {
                return Ok(new GeneralResult<List<OrderDTO>>() { Data = orders, Errors = [], Success = true });
            }
            return NotFound(new GeneralResult() { Errors = [new ResultError() { Message = "Orders not found"}], Success = false });
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrderById([FromQuery] Guid orderId)
        {
            var order = await _orderManager.GetOrderByIdAsync(orderId);
            if (order != null)
            {
                return Ok(new GeneralResult<OrderDTO>() { Data = order, Errors = [], Success = true });
            }
            return NotFound(new GeneralResult() { Errors = [new ResultError() { Message = "Order not found" }], Success = false });
        }


        

    }
}
