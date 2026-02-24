using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Common.DTOs.Orders;
using OnlineStore.Application.Features.Orders.Commands.CreateOrder;
using OnlineStore.Application.Features.Orders.Commands.UpdateOrderStatus;
using OnlineStore.Application.Features.Orders.Queries.GetOrderById;
using OnlineStore.Application.Features.Orders.Queries.GetOrderByUserId;
using System.Security.Claims;

namespace OnlineStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateOrder(CreateOrderCommand command)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var secureCommand = command with { UserId = userId };

            var orderId = await _mediator.Send(secureCommand);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(long id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetMyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = new GetOrdersByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")] 
        public async Task<ActionResult> UpdateStatus(long id, UpdateOrderStatusCommand command)
        {
            if (id != command.OrderId)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }
    }
}