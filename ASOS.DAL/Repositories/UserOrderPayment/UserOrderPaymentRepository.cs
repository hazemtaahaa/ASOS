using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL;

public class UserOrderPaymentRepository : GenericRepository<UserOrderPayment>, IUserOrderPaymentRepository
{
    public UserOrderPaymentRepository(StoreContext context) : base(context)
    {

    }

    public async Task<UserOrderPayment> GetUserOrderPaymentByIdAsync(Guid id)
    {
        return await _context.UserOrderPayments
            .Include(u => u.User)
            .Include(u => u.Order)
            .Include(u => u.Payment)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<UserOrderPayment>> GetUserOrderPaymentByOrderIdAsync(Guid orderId)
    {
        return await _context.UserOrderPayments
            .Where( u => u.OrderId == orderId)
            .Include(u => u.User)
            .Include(u => u.Order)
            .Include(u => u.Payment)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserOrderPayment>> GetUserOrderPaymentByPaymentIdAsync(Guid paymentId)
    {
        return await _context.UserOrderPayments
            .Where(u => u.PaymentId == paymentId)
            .Include(u => u.User)
            .Include(u => u.Order)
            .Include(u => u.Payment)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserOrderPayment>> GetUserOrderPaymentByUserIdAsync(string userId)
    {
        return await _context.UserOrderPayments
            .Where(u => u.UserId == userId)
            .Include(u => u.User)
            .Include(u => u.Order)
            .Include(u => u.Payment)
            .ToListAsync();
    }

}

