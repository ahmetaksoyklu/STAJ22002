using Application.Features.Products.Queries.GetProductDetails;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, int>
{
    Task<List<ProductDetailListItem>> GetProductDetailsAsync(CancellationToken cancellationToken = default);
}
