using ASOS.BL.DTOs;
using ASOS.DAL;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace ASOS.BL.Managers.Payment
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PaymentManager(IUnitOfWork unitOfWork ,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public Task<CartDTO> CreateOrUpdatePaymentIntent(Guid cartId)
        {
            throw new NotImplementedException();
        }
        //public async Task<CartDTO> CreateOrUpdatePaymentIntent(Guid cartId)
        //{
        //    StripeConfiguration.ApiKey = "pk_test_51RC6glQ8RaciZnLJ27ML29PDXDMNBdUEj6nIhdNkEWcvwM0hTXJ82Etv9Eapbd3lpHse7NoFX9C7veCWblmHLY6000u7j9chus";

        //    var cart = await _unitOfWork.Carts.GetByIdAsync(cartId);
        //    if (cart == null)
        //    {
        //        throw new Exception("Cart not found");
        //    }
        //    if (cart?.CartItems?.Count > 0)
        //    {
        //        var cartItems = cart.CartItems.ToList();

        //        decimal totalPrice = 0;
        //        // Check if all products exist in the database
        //        foreach (var item in cartItems)
        //        {
        //            var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
        //            if (product == null)
        //            {
        //                throw new Exception("Product not found");
        //            }

        //            totalPrice += (decimal)(product?.Price * item?.Quantity);

        //        }

        //        //var cartDto = new CartDTO
        //        //{
        //        //    Id = cart.Id,
        //        //    UserId = cart.UserId,
        //        //    CartItems = cartItems.Select(i => new CartItemDTO
        //        //    {
        //        //        ProductId = i.ProductId,
        //        //        Quantity = i.Quantity,
        //        //        Price = (decimal)i.Product.Price,
        //        //        ProductName = i.Product.Name,
        //        //        ProductImage = $"{_configuration["ApiBaseUrl"]}{i.Product.ProductImages.FirstOrDefault().ImageUrl}"
        //        //    }).ToList(),
        //        //    TotalAmount = totalPrice
        //        //};
        //        PaymentIntent paymentIntent;
        //        var options = new PaymentIntentCreateOptions
        //        {
        //            Amount = cart.CartItems.Sum(item => (item.Product.Price * 100) * (item.Quantity) * ),
        //            Currency = "usd",
        //            PaymentMethodTypes = new List<string>
        //            {
        //                "card"
        //            },
        //            ReceiptEmail = cart.User.Email,
        //            Description = "Payment for Cart",
        //            Metadata = new Dictionary<string, string>
        //            {
        //                { "cartId", cart.Id.ToString() }
        //            },
        //        };

        //    }
        //    else
        //    {
        //        throw new Exception("Cart is empty"); ;
        //    }
        //}
    }
}
