namespace Domain.Entities;

public class DetayliButce : Entity<int>
{
    public int ProjeId { get; set; }
    public string ButceKalemi { get; set; } = string.Empty;
    public decimal TalepEdilenTutar { get; set; }
    public string Aciklama { get; set; } = string.Empty;

    public Proje Proje { get; set; } = null!;
}
