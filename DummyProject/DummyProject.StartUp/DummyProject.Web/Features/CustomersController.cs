using DummyProject.Application.Features.Customer.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DummyProject.Web.Features
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
