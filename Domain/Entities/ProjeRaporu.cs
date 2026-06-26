using Domain.Enums;

namespace Domain.Entities;

public class ProjeRaporu : Entity<int>
{
    public int ProjeId { get; set; }
    public RaporKodu RaporKodu { get; set; }
    public string DosyaYolu { get; set; } = string.Empty;
    public bool HakemeGonderildiMi { get; set; }
    public DateTime? GonderimTarihi { get; set; }
    public bool? HakemOnayi { get; set; }

    public Proje Proje { get; set; } = null!;
}
