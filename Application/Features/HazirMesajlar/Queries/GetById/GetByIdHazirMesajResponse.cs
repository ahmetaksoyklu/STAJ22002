namespace Application.Features.HazirMesajlar.Queries.GetById;

public class GetByIdHazirMesajResponse
{
    public int Id { get; set; }
    public string Baslik { get; set; } = string.Empty;
    public string Konu { get; set; } = string.Empty;
    public string Icerik { get; set; } = string.Empty;
    public bool AktifMi { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
