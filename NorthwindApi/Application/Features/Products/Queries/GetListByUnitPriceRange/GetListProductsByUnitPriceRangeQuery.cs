using Application.Features.Products.Queries.GetList;
using MediatR;

namespace Application.Features.Products.Queries.GetListByUnitPriceRange;

public class GetListProductsByUnitPriceRangeQuery : IRequest<List<GetListProductListItem>>
{
    public decimal Min { get; set; }
    public decimal Max { get; set; }
}
