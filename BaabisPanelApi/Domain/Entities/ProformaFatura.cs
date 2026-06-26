namespace Domain.Entities;

public class ProformaFatura : Entity<int>
{
    public int ProjeId { get; set; }
    public string FirmaAdi { get; set; } = string.Empty;
    public decimal Tutar { get; set; }
    public string DosyaYolu { get; set; } = string.Empty;

    public Proje Proje { get; set; } = null!;
}
