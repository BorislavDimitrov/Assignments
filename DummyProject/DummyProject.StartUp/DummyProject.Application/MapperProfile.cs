using AutoMapper;
using DummyProject.Application.Features.Customer.Commands;
using DummyProject.Application.Features.Order.Response;
using DummyProject.Application.Features.Product.Commands;
using DummyProject.Application.Features.Product.Response;
using DummyProject.Domain.Models;

namespace DummyProject.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, GetProductQueryResponse>();

            CreateMap<CreateProductCommand, Product>();

            CreateMap<CreateCustomerCommand,  Customer>();

            CreateMap<Order, GetOrderQueryResponse>()
                .ForMember(x => x.FirstName, y => y.MapFrom(v => v.Customer.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(v => v.Customer.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(v => v.Customer.Email))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(v => v.Customer.PhoneNumber))
                .ForMember(x => x.Address, y => y.MapFrom(v => v.Customer.Address))
                .ForMember(x => x.City, y => y.MapFrom(v => v.Customer.City))
                .ForMember(x => x.State, y => y.MapFrom(v => v.Customer.State))
                .ForMember(x => x.PostalCode, y => y.MapFrom(v => v.Customer.PostalCode));
        }
    }
}
