using ASOS.BL.Managers.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace ASOS.APIs.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public WebhookController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("{paymentIntentId}")]
        public async Task<IActionResult> Post(string paymentIntentId)
        {
            Console.WriteLine("Webhook received: " + paymentIntentId);
            await _paymentManager.UpdatePaymentIntent(paymentIntentId);

                return Ok();

        }
    }
}
