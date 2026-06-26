using MediatR;

namespace Application.Features.HazirMesajlar.Commands.Delete;

public class DeleteHazirMesajCommand : IRequest<DeletedHazirMesajResponse>
{
    public int Id { get; set; }
}
