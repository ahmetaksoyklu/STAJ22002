using MediatR;

namespace Application.Features.HazirMesajlar.Commands.Update;

public class UpdateHazirMesajCommand : IRequest<UpdatedHazirMesajResponse>
{
    public int Id { get; set; }
    public string Baslik { get; set; } = string.Empty;
    public string Konu { get; set; } = string.Empty;
    public string Icerik { get; set; } = string.Empty;
    public bool AktifMi { get; set; }
}
