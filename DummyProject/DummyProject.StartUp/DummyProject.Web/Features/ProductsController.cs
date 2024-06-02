using DummyProject.Application.Features.Product.Commands;
using DummyProject.Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DummyProject.Web.Features
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult> Get([FromRoute] GetProductQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
