using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Features.Pyments.Commands.RequestPayment;
using OnlineStore.Application.Features.Pyments.Commands.VerifyPayment;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("request/{orderId}")]
    public async Task<ActionResult<string>> RequestPayment(long orderId)
    {
        var result = await _mediator.Send(new RequestPaymentCommand(orderId));
        return Ok(result);
    }

    [HttpGet("verify")]
    public async Task<ActionResult> VerifyPayment([FromQuery] string Authority, [FromQuery] string Status)
    {
        var result = await _mediator.Send(new VerifyPaymentCommand(Authority, Status));
        if (result)
            return Ok("Payment Successful! Order Updated.");
        else
            return BadRequest("Payment Failed!");
    }
}