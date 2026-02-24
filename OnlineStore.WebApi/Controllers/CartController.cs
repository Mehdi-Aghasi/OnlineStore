using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Common.DTOs.Carts;
using OnlineStore.Application.Features.Carts.Commands.AddToCart;
using OnlineStore.Application.Features.Carts.Commands.RemoveFromCart;
using OnlineStore.Application.Features.Carts.Queries.GetCartByUserId;
using System.Security.Claims;

namespace OnlineStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetMyCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = new GetCartByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddToCart(AddToCartCommand command)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var secureCommand = command with { UserId = userId };

            await _mediator.Send(secureCommand);
            return Ok();
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<ActionResult> RemoveFromCart(long cartItemId)
        {
            var command = new RemoveFromCartCommand(cartItemId);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}