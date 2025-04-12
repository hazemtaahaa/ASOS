using ASOS.BL.DTOs;
using ASOS.DAL;
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

        public Task<CartDTO> CreateOrUpdatePaymentIntent(Guid cartId)
        {
            throw new NotImplementedException();
        }
       
    }
}
