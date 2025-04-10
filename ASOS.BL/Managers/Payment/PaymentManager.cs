using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Payment
{
    public class PaymentManager : IPaymentManager
    {
        public Task<CartDTO> CreateOrUpdatePaymentIntent(Guid cartId)
        {
            throw new NotImplementedException();
        }
    }
}
