namespace Domain.Entities;

public class Hakem : Entity<int>
{
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Eposta { get; set; } = string.Empty;
    public string Unvan { get; set; } = string.Empty;
    public string Kurum { get; set; } = string.Empty;
    public string Telefon { get; set; } = string.Empty;

    public ICollection<ProjeHakem> ProjeHakemleri { get; set; } = new List<ProjeHakem>();
}
