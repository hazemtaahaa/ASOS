using ASOS.BL.Managers.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOS.APIs.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IConfiguration _configuration;

        public PaymentController(IPaymentManager paymentManager ,IConfiguration configuration)
        {
            _paymentManager = paymentManager;
            _configuration = configuration;
        }

        [HttpGet]
        public async  Task<ActionResult> GetAllPayments()
        {
            Console.WriteLine(_configuration["TestData"]);
            return await Task.FromResult(BadRequest());
        }
        
    }
}
