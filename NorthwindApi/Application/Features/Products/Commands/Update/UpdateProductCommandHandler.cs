using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
{
    
    
    private readonly IProductRepository _productRepository;
    private readonly ProductsBusinessRules _productsBusinessRules;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        ProductsBusinessRules productsBusinessRules,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _productsBusinessRules = productsBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        
        Product? product = await _productRepository.GetAsync(
            x => x.Id == request.Id,
            enableTracking: true,
            cancellationToken: cancellationToken);

        if (product is null)
            throw new KeyNotFoundException($"Product with id {request.Id} was not found.");

        await _productsBusinessRules.ProductNameMustBeUnique(request.ProductName, request.Id, cancellationToken);

        if (product.CategoryId != request.CategoryId)
            await _productsBusinessRules.CategoryProductCountMustBeBelowLimit(request.CategoryId, cancellationToken);

        _mapper.Map(request, product);
        Product updated = await _productRepository.UpdateAsync(product);
        return _mapper.Map<UpdatedProductResponse>(updated);
    }
}
