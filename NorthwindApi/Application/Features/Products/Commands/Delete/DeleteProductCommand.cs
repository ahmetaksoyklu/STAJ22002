using MediatR;

namespace Application.Features.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<DeletedProductResponse>
{
    public int Id { get; set; }
}
