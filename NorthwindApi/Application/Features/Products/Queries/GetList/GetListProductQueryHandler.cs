using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<GetListProductListItem>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListProductListItem>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetListAsync(
            orderBy: q => q.OrderBy(x => x.Id),
            enableTracking: false,
            cancellationToken: cancellationToken);

        return _mapper.Map<List<GetListProductListItem>>(products);
    }
}
