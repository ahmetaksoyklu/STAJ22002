using Domain.Enums;

namespace Domain.Entities;

public class FormSorusu : Entity<int>
{
    public int FormSablonuId { get; set; }
    public string SoruMetni { get; set; } = string.Empty;
    public CevapTipi CevapTipi { get; set; }
    public int SiraNo { get; set; }
    public bool ZorunluMu { get; set; }

    public FormSablonu FormSablonu { get; set; } = null!;
}
