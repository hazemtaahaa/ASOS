using ASOS.DAL.Models;
using ASOS.DAL.Repositories.Brand;
using ASOS.DAL.Repositories.Generic;

namespace ASOS.DAL;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository Brands { get; }
    ICartRepository Carts { get; }
    ICartItemRepository CartItems { get; }
    ICategoryRepository Categories { get; }
    IOrderRepository Orders { get; }
    IOrderItemRepository OrderItems { get; }
    IPaymentRepository Payments { get; }
    IProductRepository Products { get; }
    IProductImageRepository ProductImages { get; }
    IProductTypeRepository ProductTypes { get; }
    IUserOrderPaymentRepository UserOrderPayments { get; }
    IWishListRepository WishLists { get; }
    IWishListProductRepository WishListProducts { get; }
    IVerificationCodeRepository VerificationCodes { get; }
    Task<int> CompleteAsync();
 
}
