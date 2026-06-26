using MediatR;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductQuery : IRequest<List<GetListProductListItem>>
{
}
