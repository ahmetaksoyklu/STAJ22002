namespace Domain.Entities;

public class Birim : Entity<int>
{
    public string BirimAdi { get; set; } = string.Empty;
    public string BirimKodu { get; set; } = string.Empty;
    public bool AktifMi { get; set; }
}
