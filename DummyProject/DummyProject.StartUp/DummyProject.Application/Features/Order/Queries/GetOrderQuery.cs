using AutoMapper;
using DummyProject.Application.Contracts;
using DummyProject.Application.Features.Order.Response;
using MediatR;

namespace DummyProject.Application.Features.Order.Queries
{
    public class GetOrderQuery : IRequest<GetOrderQueryResponse>
    {
        public string OrderId { get; set; }

        public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, GetOrderQueryResponse> 
        {
            private readonly IRepository<Domain.Models.Order> _orderRepository;
            private readonly IMapper _mapper;

            public GetOrderQueryHandler(IRepository<Domain.Models.Order> orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public Task<GetOrderQueryResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                var order = _orderRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.OrderId);
                var response = _mapper.Map<GetOrderQueryResponse>(order);
                return Task.FromResult(response);
            }
        }
    }
}
