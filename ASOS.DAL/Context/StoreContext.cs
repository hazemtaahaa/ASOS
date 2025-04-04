using ASOS.DAL.Configurations;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL.Context
{
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<WishList> wishList { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<UserOrderPayment> UserOrderPayments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<WishListProduct> WishListProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all the configuration classes from the project the contains the StoreContext class
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);

        }

    }    
}
