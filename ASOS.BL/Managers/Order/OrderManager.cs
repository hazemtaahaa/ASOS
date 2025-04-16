using ASOS.BL.DTOs;
using ASOS.DAL;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Issuing;
using System.Reflection.Metadata.Ecma335;
namespace ASOS.BL.Managers.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        

        public OrderManager(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        // Create Order
        public async Task<bool> CreateOrderAsync(Guid cartId, string address, string phoneNumber)
        {
            var cart = await _unitOfWork.Carts.GetCartByIdAsync(cartId);
            decimal totalAmount = 0;

            foreach (var item in cart.CartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);


                if (product == null) return false;

                totalAmount += (decimal)(product.Price * item.Quantity);
            }

            var order = new DAL.Models.Order
            {
                Id = Guid.NewGuid(),
                Address = address,
                PhoneNumber = phoneNumber,
                Status = OrderStatus.Pending,
                Date = DateTime.UtcNow,
                ArrivalDate = DateTime.UtcNow.AddDays(7), // Example: 7 days for delivery
                TotalAmount = totalAmount,
            };


            foreach (var item in cart.CartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                if (product == null) return false;
                var orderItem =new OrderItem
                {
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                    Quantity = item.Quantity,
                    TotalPrice = product.Price * item.Quantity,
                };
                await _unitOfWork.OrderItems.AddAsync(orderItem);

            }
            // add new order 
            await _unitOfWork.Orders.AddAsync(order);

            var payment = new DAL.Models.Payment
            {
                Id = Guid.NewGuid(),
                Amount = totalAmount,
                Status = PaymentStatus.Pending,
                Date = DateTime.UtcNow,
            };

            await _unitOfWork.Payments.AddAsync(payment);

            await _unitOfWork.UserOrderPayments.AddAsync(new UserOrderPayment
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                UserId = cart.UserId,
                PaymentId = payment.Id,
            });

            await _unitOfWork.CompleteAsync();

            return true;
        }

        // Cancel Order 
        public async Task<bool> CancelOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);

            if (order == null) return false;
            else if (order.Status == OrderStatus.Cancelled) return false;
            else if (order.Status == OrderStatus.Delivered) return false;
            else
            {
                order.Status = OrderStatus.Cancelled;
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.CompleteAsync();
                return true;
            }          
           
        }


        // Complete Order Payment
        public  async Task<object> CompleteOrderPaymentAsync( Guid orderId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSecretkey"];

            // Get the order by ID
            var order = await _unitOfWork.Orders.GetOrderByIdAsync(orderId);
            var payment = await _unitOfWork.Payments.GetByIdAsync(order.UserOrderPayment.PaymentId);

            if (order == null)
            {
                throw new Exception("Cart not found");

            }

            if (order.Status == OrderStatus.Cancelled)
            {
                throw new Exception("Order is cancelled");
            }

            if (order.Status == OrderStatus.Delivered)
            {
                throw new Exception("Order is already delivered");
            }

            // Check if the order is already paid
            if (payment.Status == PaymentStatus.Approved)
            {
                throw new Exception("Order is already paid");
            }

            // Create a payment intent
            PaymentIntent paymentIntent;

            PaymentIntentService service = new PaymentIntentService();

          
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)order.TotalAmount,
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                    {
                        "card"
                    },
                ReceiptEmail = order.UserOrderPayment.User.Email,
                Description = "Payment for Order",
            };

            paymentIntent = await service.CreateAsync(options);

            payment.StripPaymentId = paymentIntent.Id;

            
            payment.Status = PaymentStatus.Approved;
            payment.PaymentMethod = DAL.PaymentMethod.Card;
            _unitOfWork.Payments.Update(payment);
            await _unitOfWork.CompleteAsync();

            return paymentIntent.ClientSecret;
             

        }


        // Get User Orders
        public async Task<List<OrderDTO>> GetUserOrdersAsync(string userId)
        {
            var userOrderPayments = await _unitOfWork.UserOrderPayments.GetUserOrderPaymentByUserIdAsync(userId);
           
            if (userOrderPayments is null)
                return null; 

            var orderIds = userOrderPayments.Select(u => u.OrderId).ToList();

            var orders = new List<DAL.Models.Order>();
            foreach (var orderId in orderIds)
            {
                var order = await _unitOfWork.Orders.GetOrderByIdAsync(orderId);
                if (order == null) return null;
                orders.Add(order);
            }

            var orderDtos = orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                TotalAmount = (decimal)o.TotalAmount,
                Date = o.Date,
                ArrivalDate = o.ArrivalDate,
                Status = o.Status,
                UserId = userId,

                OrderItems = o.OrderItems.Select(oi => new OrderItemDTO
                {
                    ProductId = oi.ProductId,
                    Quantity = (int)oi.Quantity,
                    Price = (decimal)oi.TotalPrice ,
                }).ToList(),

                Payment = new PaymentDTO
                {
                    Id = o.UserOrderPayment.Payment.Id,
                    Amount = (decimal)o.UserOrderPayment.Payment.Amount,
                    Status = (PaymentStatus)o.UserOrderPayment.Payment.Status,
                    Date = o.UserOrderPayment.Payment.Date,
                }
            }).ToList();

            return orderDtos;
        }


        // Get Order By Id
        public async Task<OrderDTO> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetOrderByIdAsync(orderId);
            if (order == null) return null;
            var orderDto = new OrderDTO
            {
                Id = order.Id,
                TotalAmount = (decimal)order.TotalAmount,
                Date = order.Date,
                ArrivalDate = order.ArrivalDate,
                Status = order.Status,
                UserId = order.UserOrderPayment.UserId,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
                {
                    ProductId = oi.ProductId,
                    Quantity = (int)oi.Quantity,
                    Price = (decimal)oi.TotalPrice,
                }).ToList(),
                Payment = new PaymentDTO
                {
                    Id = order.UserOrderPayment.Payment.Id,
                    Amount = (decimal)order.UserOrderPayment.Payment.Amount,
                    Status = (PaymentStatus)order.UserOrderPayment.Payment.Status,
                    Date = order.UserOrderPayment.Payment.Date,
                }
            };
            return orderDto;
        }
    }

}
