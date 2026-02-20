using MediatR;

namespace OnlineStore.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(
        long Id
        ) :IRequest;
}
