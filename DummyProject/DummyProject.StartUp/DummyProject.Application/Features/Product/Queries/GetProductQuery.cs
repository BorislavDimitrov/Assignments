using AutoMapper;
using DummyProject.Application.Contracts;
using DummyProject.Application.Features.Product.Response;
using MediatR;

namespace DummyProject.Application.Features.Product.Queries
{
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        public string ProductId { get; set; }

        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse> 
        {
            private readonly IRepository<Domain.Models.Product> _productsRepository;
            private readonly IMapper _mapper;

            public GetProductQueryHandler(IRepository<Domain.Models.Product> productsRepository, IMapper mapper)
            {
                _productsRepository = productsRepository;
                _mapper = mapper;
            }

            public Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = _productsRepository.AllAsNoTracking().FirstOrDefault( x => x.Id == request.ProductId);
                var response =  _mapper.Map<GetProductQueryResponse>(product);
                return Task.FromResult(response);
            }
        }
    }
}
