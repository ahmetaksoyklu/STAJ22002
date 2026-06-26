using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
{
    
    
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        
        Product? product = await _productRepository.GetAsync(
            x => x.Id == request.Id,
            enableTracking: true,
            cancellationToken: cancellationToken);

        if (product is null)
            throw new KeyNotFoundException($"Product with id {request.Id} was not found.");

        await _productRepository.DeleteAsync(product, permanent: true);
        return _mapper.Map<DeletedProductResponse>(product);
    }
}
