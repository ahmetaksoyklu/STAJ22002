namespace Domain.Entities;

public class OturumKaydi : Entity<int>
{
    public string Email { get; set; } = string.Empty;
    public string IpAdresi { get; set; } = string.Empty;
    public bool BasariliMi { get; set; }
    public string Aciklama { get; set; } = string.Empty;
}
