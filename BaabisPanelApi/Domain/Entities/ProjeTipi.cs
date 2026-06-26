namespace Domain.Entities;

public class ProjeTipi : Entity<int>
{
    public string Ad { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public bool AktifMi { get; set; }
}
