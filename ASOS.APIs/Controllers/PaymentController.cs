//using ASOS.DAL;
//using ASOS.DAL.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace ASOS.APIs.Controllers
//{
//    public class PaymentController : BaseController<Payment>
//    {
//        public PaymentController(IUnitOfWork unitOfWork) : base(unitOfWork)
//        {
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllPayments()
//        {
//            return await GetAllAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetPayment(Guid id)
//        {
//            return await GetByIdAsync(id);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreatePayment(Payment payment)
//        {
//            payment.Date = DateTime.UtcNow;
//            payment.Status = PaymentStatus.Pending;
//            return await CreateAsync(payment);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdatePayment(Guid id, Payment payment)
//        {
//            return await UpdateAsync(id, payment);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePayment(Guid id)
//        {
//            return await DeleteAsync(id);
//        }

//        [HttpPut("{id}/status")]
//        public async Task<IActionResult> UpdatePaymentStatus(Guid id, [FromBody] PaymentStatus status)
//        {
//            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
//            if (payment == null)
//                return NotFound();

//            payment.Status = status;
//            _unitOfWork.Payments.Update(payment);
//            await _unitOfWork.CompleteAsync();
//            return NoContent();
//        }

//        [HttpGet("order/{orderId}")]
//        public async Task<IActionResult> GetOrderPayments(Guid orderId)
//        {
//            var payments = await _unitOfWork.UserOrderPayments.GetOrderPayments(orderId);
//            return Ok(payments);
//        }

//        [HttpGet("user/{userId}")]
//        public async Task<IActionResult> GetUserPayments(string userId)
//        {
//            var payments = await _unitOfWork.UserOrderPayments.GetUserPayments(userId);
//            return Ok(payments);
//        }

//        protected override Guid GetEntityId(Payment entity)
//        {
//            return entity.Id;
//        }
//    }
//} 