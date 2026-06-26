namespace Domain.Entities;

public class TeknikSartname : Entity<int>
{
    public int ProjeId { get; set; }
    public string Baslik { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public string DosyaYolu { get; set; } = string.Empty;

    public Proje Proje { get; set; } = null!;
}
