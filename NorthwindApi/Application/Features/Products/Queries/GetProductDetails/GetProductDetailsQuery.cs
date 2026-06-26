using MediatR;

namespace Application.Features.Products.Queries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<List<ProductDetailListItem>>
{
}
