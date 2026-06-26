using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
{
    
    
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        
        Product? product = await _productRepository.GetAsync(
            x => x.Id == request.Id,
            enableTracking: false,
            cancellationToken: cancellationToken);

        if (product is null)
            throw new KeyNotFoundException($"Product with id {request.Id} was not found.");

        return _mapper.Map<GetByIdProductResponse>(product);
    }
}
