using ASOS.BL.DTOs;
using ASOS.DAL;
using ASOS.DAL.Context;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace ASOS.BL.Managers.Payment
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;
       
        private readonly IConfiguration _configuration;
        

        public PaymentManager(IUnitOfWork unitOfWork ,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        public async Task<bool> UpdatePaymentIntent(string PaymentIntent)
        {

            var payment = await _unitOfWork.Payments.GetPaymentById(PaymentIntent);
         
            var order = await _unitOfWork.Orders.GetByIdAsync(payment.UserOrderPayment.OrderId); 

            payment.Status = PaymentStatus.Approved;

            order.Status = OrderStatus.Shipped;

            _unitOfWork.Payments.Update(payment);
            _unitOfWork.Orders.Update(order);
            _unitOfWork.CompleteAsync();

           return true;
        }

    }


}
