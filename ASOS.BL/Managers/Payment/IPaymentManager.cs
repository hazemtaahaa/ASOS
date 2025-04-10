using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Payment
{
    public interface IPaymentManager
    {
        Task<CartDTO> CreateOrUpdatePaymentIntent(Guid cartId);
    }
}
