namespace Domain.Entities;

public class Mesaj : Entity<int>
{
    public string Kimden { get; set; } = string.Empty;
    public string Kime { get; set; } = string.Empty;
    public string Konu { get; set; } = string.Empty;
    public string Icerik { get; set; } = string.Empty;
    public bool OkunduMu { get; set; }
    public bool SilindiMi { get; set; }
}
