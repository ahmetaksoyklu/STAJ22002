namespace Domain.Entities;

public class Yayin : Entity<int>
{
    public int ProjeId { get; set; }
    public string YayinBasligi { get; set; } = string.Empty;
    public string DergiAdi { get; set; } = string.Empty;
    public string Doi { get; set; } = string.Empty;
    public DateTime? YayinTarihi { get; set; }
    public string DosyaYolu { get; set; } = string.Empty;

    public Proje Proje { get; set; } = null!;
}
