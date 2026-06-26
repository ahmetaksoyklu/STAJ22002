namespace Domain.Entities;

public class HazirMesaj : Entity<int>
{
    public string Baslik { get; set; } = string.Empty;
    public string Konu { get; set; } = string.Empty;
    public string Icerik { get; set; } = string.Empty;
    public bool AktifMi { get; set; }
}
