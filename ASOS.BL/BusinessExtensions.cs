using ASOS.BL;
using ASOS.BL.Managers.Cart;
using ASOS.BL.Managers.Category;
using ASOS.BL.Managers.Order;
using ASOS.BL.Managers.Payment;
using ASOS.BL.Managers.Product;
using ASOS.BL.Managers.WishList;
using ASOS.BL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ASOS.DAL;

public static class BusinessExtensions
{
    public static void AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
    { 
         services.AddScoped<IWomanManager, WomanManager>(); 
        services.AddScoped<ICategoryManager, CategoryManager>();

        services.AddScoped<IMenManager, MenManager>();
        services.AddScoped<IProductManager, ProductManager>();
        services.AddScoped<IWishListManager, WishListManager>();
        services.AddScoped<ICartManager,CartManager>();
        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped<IPaymentManager, PaymentManager>();

        services.AddScoped<IOrderManager, OrderManager>();
    }
}
