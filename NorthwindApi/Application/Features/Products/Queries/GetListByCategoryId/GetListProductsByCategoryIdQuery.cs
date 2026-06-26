using Application.Features.Products.Queries.GetList;
using MediatR;

namespace Application.Features.Products.Queries.GetListByCategoryId;

public class GetListProductsByCategoryIdQuery : IRequest<List<GetListProductListItem>>
{
    public int CategoryId { get; set; }
}
