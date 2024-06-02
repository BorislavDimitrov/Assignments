using AutoMapper;
using DummyProject.Application.Contracts;
using DummyProject.Application.Features.Customer.Response;
using MediatR;
using Serilog;

namespace DummyProject.Application.Features.Customer.Commands
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
        {
            private readonly IRepository<Domain.Models.Customer> _customerRepository;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(IRepository<Domain.Models.Customer> customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var newCustomer = _mapper.Map<Domain.Models.Customer>(request);
                await _customerRepository.AddAsync(newCustomer);
                await _customerRepository.SaveChangesAsync();
                Log.Information($"Customer with id {newCustomer.Id} has been created.");

                return new CreateCustomerResponse { Id = newCustomer.Id };
            }
        }
    }
}
