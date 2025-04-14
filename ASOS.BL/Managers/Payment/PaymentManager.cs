using ASOS.BL.DTOs;
using ASOS.BL.Managers.Cart;
using ASOS.DAL;
using ASOS.DAL.Context;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace ASOS.BL.Managers.Payment
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartManager _cartManager;
        private readonly IConfiguration _configuration;
        

        public PaymentManager(IUnitOfWork unitOfWork, ICartManager cartManager ,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _cartManager = cartManager;
            _configuration = configuration;
        }


        public async Task<bool> UpdatePaymentIntent(string PaymentIntent)
        {

            var payment = await _unitOfWork.Payments.GetPaymentById(PaymentIntent);
         
            var order = await _unitOfWork.Orders.GetByIdAsync(payment.UserOrderPayment.OrderId); 


            payment.Status = PaymentStatus.Approved;

            order.Status = OrderStatus.Shipped;

            await _cartManager.ClearCartAsync(payment.UserOrderPayment.UserId);
            _unitOfWork.Payments.Update(payment);
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.CompleteAsync();

           return true;
        }

    }


}
