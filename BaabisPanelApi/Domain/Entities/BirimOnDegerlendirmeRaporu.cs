using Domain.Enums;

namespace Domain.Entities;

public class BirimOnDegerlendirmeRaporu : Entity<int>
{
    public int ProjeId { get; set; }
    public int KurulUyesiId { get; set; }
    public string FormKodu { get; set; } = string.Empty;
    public string CevaplarJson { get; set; } = string.Empty;
    public DegerlendirmeSonucu DegerlendirmeSonucu { get; set; }
    public string Gerekce { get; set; } = string.Empty;
    public string DosyaYolu { get; set; } = string.Empty;

    public Proje Proje { get; set; } = null!;
    public BirimOnDegerlendirmeUyesi BirimOnDegerlendirmeUyesi { get; set; } = null!;
}
