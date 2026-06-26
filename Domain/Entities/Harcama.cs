namespace Domain.Entities;

public class Harcama : Entity<int>
{
    public int ProjeId { get; set; }
    public string ButceKalemi { get; set; } = string.Empty;
    public decimal Tutar { get; set; }
    public string Aciklama { get; set; } = string.Empty;
    public string BelgeYolu { get; set; } = string.Empty;
    public DateTime HarcamaTarihi { get; set; }

    public Proje Proje { get; set; } = null!;
}
