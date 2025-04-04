using ASOS.DAL.Context;
using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public class UserOrderPaymentRepository : GenericRepository<UserOrderPayment>, IUserOrderPaymentRepository
{
    public UserOrderPaymentRepository(StoreContext context) : base(context)
    {
    }
}

