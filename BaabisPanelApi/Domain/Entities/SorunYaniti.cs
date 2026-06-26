namespace Domain.Entities;

public class SorunYaniti : Entity<int>
{
    public int SorunBildirimiId { get; set; }
    public string Yanitlayan { get; set; } = string.Empty;
    public string Yanit { get; set; } = string.Empty;

    public SorunBildirimi SorunBildirimi { get; set; } = null!;
}
