using MediatR;

namespace Application.Features.HazirMesajlar.Queries.GetById;

public class GetByIdHazirMesajQuery : IRequest<GetByIdHazirMesajResponse>
{
    public int Id { get; set; }
}
