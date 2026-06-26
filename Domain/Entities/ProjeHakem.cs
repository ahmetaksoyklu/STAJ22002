using Domain.Enums;

namespace Domain.Entities;

public class ProjeHakem : Entity<int>
{
    public int ProjeId { get; set; }
    public int HakemId { get; set; }
    public HakemlikDurumu HakemlikDurumu { get; set; }
    public DateTime? DavetTarihi { get; set; }
    public DateTime? CevapTarihi { get; set; }
    public DateTime? DegerlendirmeTarihi { get; set; }

    public Proje Proje { get; set; } = null!;
    public Hakem Hakem { get; set; } = null!;
}
