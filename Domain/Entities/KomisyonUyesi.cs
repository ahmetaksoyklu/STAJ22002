namespace Domain.Entities;

public class KomisyonUyesi : Entity<int>
{
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Eposta { get; set; } = string.Empty;
    public string Gorev { get; set; } = string.Empty;
    public bool AktifMi { get; set; }

    public ICollection<KomisyonKarari> KomisyonKararlari { get; set; } = new List<KomisyonKarari>();
}
