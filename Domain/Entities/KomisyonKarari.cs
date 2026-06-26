using Domain.Enums;

namespace Domain.Entities;

public class KomisyonKarari : Entity<int>
{
    public int ProjeId { get; set; }
    public int KomisyonUyesiId { get; set; }
    public KomisyonKararTipi KararTipi { get; set; }
    public string KararMetni { get; set; } = string.Empty;
    public string Gerekce { get; set; } = string.Empty;
    public DateTime KararTarihi { get; set; }

    public Proje Proje { get; set; } = null!;
    public KomisyonUyesi KomisyonUyesi { get; set; } = null!;
}
