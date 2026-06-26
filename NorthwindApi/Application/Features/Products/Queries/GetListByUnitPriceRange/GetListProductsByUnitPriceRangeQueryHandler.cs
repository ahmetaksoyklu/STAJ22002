using Application.Features.Products.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetListByUnitPriceRange;

public class GetListProductsByUnitPriceRangeQueryHandler : IRequestHandler<GetListProductsByUnitPriceRangeQuery, List<GetListProductListItem>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetListProductsByUnitPriceRangeQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListProductListItem>> Handle(GetListProductsByUnitPriceRangeQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetListAsync(
            p => p.UnitPrice >= request.Min && p.UnitPrice <= request.Max,
            orderBy: q => q.OrderBy(x => x.UnitPrice),
            enableTracking: false,
            cancellationToken: cancellationToken);

        return _mapper.Map<List<GetListProductListItem>>(products);
    }
}
