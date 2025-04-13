using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Payment
{
    public interface IPaymentManager
    {
        Task<bool> UpdatePaymentIntent(string PaymentIntent);
    }
}
