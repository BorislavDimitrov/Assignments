using AutoMapper;
using DummyProject.Application.Contracts;
using DummyProject.Application.Features.Product.Response;
using MediatR;
using Serilog;

namespace DummyProject.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
        {
            private readonly IRepository<Domain.Models.Product> _repositoryProduct;
            private readonly IMapper _mapper;

            public CreateProductHandler(IRepository<Domain.Models.Product> repositoryProduct, IMapper mapper)
            {
                _repositoryProduct = repositoryProduct;
                _mapper = mapper;
            }

            public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var newProduct = _mapper.Map<Domain.Models.Product>(request);

                await _repositoryProduct.AddAsync(newProduct);
                await _repositoryProduct.SaveChangesAsync();

                Log.Information($"Product with id {newProduct.Id} has been created.");

                return new CreateProductResponse { Id = request.Id };
            }
        }
    }
}
