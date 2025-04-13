using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public interface IUserOrderPaymentRepository : IGenericRepository<UserOrderPayment>
{
    Task<UserOrderPayment> GetUserOrderPaymentByIdAsync(Guid id);
    Task<IEnumerable<UserOrderPayment>> GetUserOrderPaymentByUserIdAsync(string userId);
    Task<IEnumerable<UserOrderPayment>> GetUserOrderPaymentByOrderIdAsync(Guid orderId);
    Task<IEnumerable<UserOrderPayment>> GetUserOrderPaymentByPaymentIdAsync(Guid paymentId);
}
