using ASOS.BL.DTOs;

namespace ASOS.BL.Managers.Order
{
    public interface IOrderManager
    {
        Task<object> CreateOrderAsync(Guid cartId, string address, string phoneNumber);
        Task<bool> CancelOrderAsync( Guid orderId);

        Task<object> CompleteOrderPaymentAsync( Guid orderId);

        Task<List<OrderDTO>> GetUserOrdersAsync(string userId);
        Task<OrderDTO> GetOrderByIdAsync(Guid orderId);
    }
}
