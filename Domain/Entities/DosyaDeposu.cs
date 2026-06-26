using Domain.Enums;

namespace Domain.Entities;

public class DosyaDeposu : Entity<int>
{
    public int SiraNo { get; set; }
    public string DosyaAdi { get; set; } = string.Empty;
    public string DosyaYolu { get; set; } = string.Empty;
    public DosyaTipi DosyaTipi { get; set; }
}
