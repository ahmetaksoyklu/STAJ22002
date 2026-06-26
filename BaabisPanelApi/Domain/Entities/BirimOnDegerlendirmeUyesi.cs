namespace Domain.Entities;

public class BirimOnDegerlendirmeUyesi : Entity<int>
{
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Eposta { get; set; } = string.Empty;
    public int BirimId { get; set; }
    public bool AktifMi { get; set; }

    public ICollection<BirimOnDegerlendirmeRaporu> Raporlar { get; set; } = new List<BirimOnDegerlendirmeRaporu>();
}
