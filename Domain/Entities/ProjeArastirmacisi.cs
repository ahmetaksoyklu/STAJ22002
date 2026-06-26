namespace Domain.Entities;

public class ProjeArastirmacisi : Entity<int>
{
    public int ProjeId { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Eposta { get; set; } = string.Empty;
    public string Kurum { get; set; } = string.Empty;
    public string Gorev { get; set; } = string.Empty;
    public decimal KatkiOrani { get; set; }

    public Proje Proje { get; set; } = null!;
}
