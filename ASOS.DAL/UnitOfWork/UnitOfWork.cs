using ASOS.DAL.Context;
using ASOS.DAL.Repositories.Brand;

namespace ASOS.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreContext _context;

    public IBrandRepository Brands { get; }
    public ICartRepository Carts { get; }
    public ICartItemRepository CartItems { get; }
    public ICategoryRepository Categories { get; }
    public IOrderRepository Orders { get; }
    public IOrderItemRepository OrderItems { get; }
    public IPaymentRepository Payments { get; }
    public IProductRepository Products { get; }
    public IProductImageRepository ProductImages { get; }
    public IProductTypeRepository ProductTypes { get; }
    public IUserOrderPaymentRepository UserOrderPayments { get; }
    public IWishListRepository WishLists { get; }
    public IWishListProductRepository WishListProducts { get; }

    public UnitOfWork(StoreContext context)
    {
        _context = context;

        Brands = new BrandRepository(context);
        Carts = new CartRepository(context);
        CartItems = new CartItemRepository(context);
        Categories = new CategoryRepository(context);
        Orders = new OrderRepository(context);
        OrderItems = new OrderItemRepository(context);
        Payments = new PaymentRepository(context);
        Products = new ProductRepository(context);
        ProductImages = new ProductImageRepository(context);
        ProductTypes = new ProductTypeRepository(context);
        UserOrderPayments = new UserOrderPaymentRepository(context);
        WishLists = new WishListRepository(context);
        WishListProducts = new WishListProductRepository(context);
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
