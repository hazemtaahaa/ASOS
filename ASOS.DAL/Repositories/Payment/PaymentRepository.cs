using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(StoreContext context) : base(context)
    {
    }
    public async Task<Payment> GetPaymentById(string paymentIntent)
    {
        return await _context.Payments
            .Include(p=>p.UserOrderPayment)
            .ThenInclude(u=>u.Order)
            .FirstOrDefaultAsync(p => p.StripPaymentId == paymentIntent);
    }
}

