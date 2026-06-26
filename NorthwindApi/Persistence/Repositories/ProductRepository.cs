using Application.Features.Products.Queries.GetProductDetails;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, int, NorthwindDbContext>, IProductRepository
{
    public ProductRepository(NorthwindDbContext context) : base(context)
    {
    }

    public async Task<List<ProductDetailListItem>> GetProductDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Products
            .AsNoTracking()
            .Select(product => new ProductDetailListItem
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                UnitsInStock = product.UnitsInStock
            })
            .ToListAsync(cancellationToken);
    }
}
