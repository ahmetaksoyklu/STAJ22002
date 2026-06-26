using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Products.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, List<ProductDetailListItem>>
{
    private readonly IProductRepository _productRepository;

    public GetProductDetailsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDetailListItem>> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductDetailsAsync(cancellationToken);
    }
}
