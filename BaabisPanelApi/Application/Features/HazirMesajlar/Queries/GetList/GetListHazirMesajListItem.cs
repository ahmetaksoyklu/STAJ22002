namespace Application.Features.HazirMesajlar.Queries.GetList;

public class GetListHazirMesajListItem
{
    public int Id { get; set; }
    public string Baslik { get; set; } = string.Empty;
    public string Konu { get; set; } = string.Empty;
    public bool AktifMi { get; set; }
    public DateTime CreatedDate { get; set; }
}
