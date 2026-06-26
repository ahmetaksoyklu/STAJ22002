using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
{
    
    
    private readonly IProductRepository _productRepository;
    private readonly ProductsBusinessRules _productsBusinessRules;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        ProductsBusinessRules productsBusinessRules,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _productsBusinessRules = productsBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        
        await _productsBusinessRules.ProductNameMustBeUnique(request.ProductName, null, cancellationToken);
        await _productsBusinessRules.CategoryProductCountMustBeBelowLimit(request.CategoryId, cancellationToken);

        Product product = _mapper.Map<Product>(request);
        Product created = await _productRepository.AddAsync(product);
        return _mapper.Map<CreatedProductResponse>(created);
    }
}
