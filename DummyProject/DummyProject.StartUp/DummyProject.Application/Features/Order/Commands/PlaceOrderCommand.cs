using DummyProject.Application.Contracts;
using DummyProject.Application.Features.Order.Response;
using DummyProject.Domain.Models;
using MediatR;
using Serilog;

namespace DummyProject.Application.Features.Order.Commands
{
    public class PlaceOrderCommand : IRequest<PlaceOrderResponse>
    {
        public string ProductId { get; set; }

        public string CustomerId { get; set; }

        public decimal CustomerPayingAmount { get; set; }

        public int Quantity { get; set; }

        public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository<Domain.Models.Order> _orderRepository;
            private readonly IRepository<OrderHistory> _orderHistoryRepository;
            private readonly IRepository<Domain.Models.Product> _productRepository;
            private readonly IRepository<OrderItem> _orderItemRepository;

            public PlaceOrderCommandHandler(IUnitOfWork unitOfWork,
                IRepository<Domain.Models.Order> ordersRepository,
                IRepository<Domain.Models.OrderHistory> orderHistoryRepository,
                IRepository<Domain.Models.Product> productRepository,
                IRepository<Domain.Models.OrderItem> orderItemRepository)
            {
                _unitOfWork = unitOfWork;
                _orderRepository = ordersRepository;
                _orderHistoryRepository = orderHistoryRepository;
                _productRepository = productRepository;
                _orderItemRepository = orderItemRepository;
            }

            public async Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
            {
                _unitOfWork.BeginTransaction();


                // Create new erder
                var newOrder = new Domain.Models.Order();
                try
                {
                    Log.Information("Begin placement order transaction.");

                    // Update inventory
                    var product =  _productRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.ProductId);
                    if (product.Quantity < request.Quantity)
                    {
                        Log.Error("Transaction failed due to insufficient stock of a product.");
                        throw new InvalidOperationException("Insufficient stock.");
                    }

                    product.Quantity -= request.Quantity;
                    _productRepository.Update(product);


                    newOrder.Id = Guid.NewGuid().ToString();
                    newOrder.CustomerId = request.CustomerId;
                    newOrder.OrderDate = DateTime.UtcNow;
                    newOrder.TotalAmount = product.Price * request.Quantity;
                    newOrder.OrderStatus = OrderStatus.New;
                    

                    //Update it to be tracked if transaction succeed
                    await _orderRepository.AddAsync(newOrder);

                    //Create new order item
                    var newOrderItem = new OrderItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        OrderId = newOrder.Id,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity,
                    };

                    await _orderItemRepository.AddAsync(newOrderItem);

                    if (request.CustomerPayingAmount < newOrder.TotalAmount)
                    {
                        Log.Error("Payment insufficient. Paid: {PaymentAmount}, Required: {ProductPrice}", newOrder.TotalAmount, request.CustomerPayingAmount);
                        throw new InvalidOperationException("Customer didnt pay enough money to place the order.");
                    }

                    // Add to order history
                    var orderHistory = new OrderHistory
                    {
                        OrderId = newOrder.Id,
                        Date = DateTime.UtcNow,
                        Status = "Order Placed"
                    };
                     await _orderHistoryRepository.AddAsync(orderHistory);

                    // Commit transaction
                     _unitOfWork.CommitTransactionAsync();
                }
                catch
                {
                    Log.Error("Transaction failed.");
                    // Rollback transaction in case of an error
                     _unitOfWork.RollbackTransactionAsync();
                    throw;
                }

                Log.Information("Transaction has passed successfully.");
                return new PlaceOrderResponse { Id = newOrder.Id };
            }
        }
    }
}
