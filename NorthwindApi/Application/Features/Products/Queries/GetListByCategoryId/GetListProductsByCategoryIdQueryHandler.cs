using Application.Features.Products.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetListByCategoryId;

public class GetListProductsByCategoryIdQueryHandler : IRequestHandler<GetListProductsByCategoryIdQuery, List<GetListProductListItem>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetListProductsByCategoryIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListProductListItem>> Handle(GetListProductsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetListAsync(
            p => p.CategoryId == request.CategoryId,
            orderBy: q => q.OrderBy(x => x.Id),
            enableTracking: false,
            cancellationToken: cancellationToken);

        return _mapper.Map<List<GetListProductListItem>>(products);
    }
}
