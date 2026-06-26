namespace Domain.Entities;

public class FormSablonu : Entity<int>
{
    public string Kod { get; set; } = string.Empty;
    public string Ad { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public bool AktifMi { get; set; }

    public ICollection<FormSorusu> Sorular { get; set; } = new List<FormSorusu>();
}
