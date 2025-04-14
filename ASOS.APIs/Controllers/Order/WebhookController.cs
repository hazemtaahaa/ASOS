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

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            // Enable buffering to allow multiple reads of the request body
            Request.EnableBuffering();
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            HttpContext.Request.Body.Position = 0; // Reset position after reading

            const string webhookSecret = "whsec_c3e2dc065ff33fcae80fa44e226b5c5a602b7e2399000faae119b01d8a05e9db"; // Get from Stripe CLI or dashboard

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    webhookSecret
                );

                if (stripeEvent.Type == "payment_intent.succeeded")
                {
                    var intent = stripeEvent.Data.Object as PaymentIntent;
                    if (intent != null) // Fix: Check for null reference
                    {
                        Console.WriteLine($"✅ Payment for {intent.Amount} succeeded.");

                       await _paymentManager.UpdatePaymentIntent(intent.Id);  
                        // TODO: Update DB, send email, etc.
                    }
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
