using Domain.Enums;

namespace Domain.Entities;

public class SorunBildirimi : Entity<int>
{
    public string Eposta { get; set; } = string.Empty;
    public string Konu { get; set; } = string.Empty;
    public string Mesaj { get; set; } = string.Empty;
    public string IpAdresi { get; set; } = string.Empty;
    public SorunDurumu Durum { get; set; }

    public ICollection<SorunYaniti> Yanitlar { get; set; } = new List<SorunYaniti>();
}
