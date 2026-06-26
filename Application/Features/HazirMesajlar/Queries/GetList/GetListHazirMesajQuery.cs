using MediatR;

namespace Application.Features.HazirMesajlar.Queries.GetList;

public class GetListHazirMesajQuery : IRequest<IReadOnlyList<GetListHazirMesajListItem>>
{
}
