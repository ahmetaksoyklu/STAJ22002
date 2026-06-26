using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Products.Rules;

public class ProductsBusinessRules
{
    private const int MaxProductsPerCategory = 15;

    private readonly IProductRepository _productRepository;

    public ProductsBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ProductNameMustBeUnique(string productName, int? excludeProductId, CancellationToken cancellationToken)
    {
        bool exists = await _productRepository.AnyAsync(
            p => p.ProductName == productName && (excludeProductId == null || p.Id != excludeProductId),
            cancellationToken: cancellationToken);

        if (exists)
            throw new InvalidOperationException("A product with the same name already exists.");
    }

    public async Task CategoryProductCountMustBeBelowLimit(int categoryId, CancellationToken cancellationToken)
    {
        List<Product> products = await _productRepository.GetListAsync(
            p => p.CategoryId == categoryId,
            enableTracking: false,
            cancellationToken: cancellationToken);

        if (products.Count >= MaxProductsPerCategory)
            throw new InvalidOperationException("Category product limit exceeded.");
    }
}
