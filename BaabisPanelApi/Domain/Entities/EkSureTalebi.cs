using Domain.Enums;

namespace Domain.Entities;

public class EkSureTalebi : Entity<int>
{
    public int ProjeId { get; set; }
    public int TalepEdilenSure { get; set; }
    public string Gerekce { get; set; } = string.Empty;
    public string DosyaYolu { get; set; } = string.Empty;
    public TalepDurumu Karar { get; set; }
    public DateTime? KararTarihi { get; set; }

    public Proje Proje { get; set; } = null!;
}
