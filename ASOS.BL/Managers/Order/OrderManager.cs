using ASOS.BL.DTOs;
using ASOS.DAL;
using ASOS.DAL.Models;
namespace ASOS.BL.Managers.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateOrderAsync(Guid cartId, string address, string phoneNumber)
        {
            var cart = await _unitOfWork.Carts.GetCartByIdAsync(cartId);
            long totalAmount = 0;
            foreach (var item in cart.CartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                if (product == null) return false;
                totalAmount += (long)product.Price * item.Quantity;
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
        public async Task<bool> CancelOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return false;
            if (order.Status == OrderStatus.Cancelled) return false;
            if (order.Status == OrderStatus.Delivered) return false;
            if (order.Status == OrderStatus.Pending)
            {
                order.Status = OrderStatus.Cancelled;
                _unitOfWork.Orders.Update(order);
                return true;
            }
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        public Task<bool> CompleteOrderAsync(string userId, Guid orderId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<OrderDTO>> GetUserOrdersAsync(string userId)
        {
            var userOrderPayments = await _unitOfWork.UserOrderPayments.GetUserOrderPaymentByUserIdAsync(userId);
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
