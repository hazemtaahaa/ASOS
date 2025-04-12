using ASOS.DAL.Context;
using ASOS.DAL.Repositories.Brand;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ASOS.DAL;

public static class DataAccessExtensions
{
    public static void AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        Console.WriteLine("CONN STRING: " + connectionString);
        services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));


        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        services.AddScoped<IUserOrderPaymentRepository, UserOrderPaymentRepository>();
        services.AddScoped<IWishListRepository, WishListRepository>();
        services.AddScoped<IWishListProductRepository, WishListProductRepository>();
        services.AddScoped<IVerificationCodeRepository, VerificationCodeRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
