namespace Domain.Entities;

public class LogKaydi : Entity<int>
{
    public string Kullanici { get; set; } = string.Empty;
    public string Controller { get; set; } = string.Empty;
    public string Islem { get; set; } = string.Empty;
    public string IpAdresi { get; set; } = string.Empty;
}
