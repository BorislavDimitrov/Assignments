using DummyProject.Application.Features.Order.Commands;
using DummyProject.Application.Features.Order.Queries;
using DummyProject.Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DummyProject.Web.Features
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlaceOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult> Get([FromRoute] GetOrderQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
