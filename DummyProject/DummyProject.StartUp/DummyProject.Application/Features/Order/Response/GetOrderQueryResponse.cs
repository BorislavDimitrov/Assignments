using DummyProject.Domain.Models;

namespace DummyProject.Application.Features.Order.Response
{
    public class GetOrderQueryResponse
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
