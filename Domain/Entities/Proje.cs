using Domain.Enums;

namespace Domain.Entities;

public class Proje : Entity<int>
{
    public string Baslik { get; set; } = string.Empty;
    public string Ozet { get; set; } = string.Empty;
    public int YurutucuUserId { get; set; }
    public int ProjeTipiId { get; set; }
    public ProjeDurumu Durum { get; set; }
    public DateTime BaslangicTarihi { get; set; }
    public DateTime? BitisTarihi { get; set; }

    public ICollection<ProjeArastirmacisi> Arastirmacilar { get; set; } = new List<ProjeArastirmacisi>();
    public ICollection<DetayliButce> DetayliButceler { get; set; } = new List<DetayliButce>();
    public ICollection<TeknikSartname> TeknikSartnameler { get; set; } = new List<TeknikSartname>();
    public ICollection<ProformaFatura> ProformaFaturalar { get; set; } = new List<ProformaFatura>();
    public ICollection<ProjeHakem> ProjeHakemleri { get; set; } = new List<ProjeHakem>();

    public ICollection<KomisyonKarari> KomisyonKararlari { get; set; } = new List<KomisyonKarari>();
    public ICollection<ProjeRaporu> Raporlar { get; set; } = new List<ProjeRaporu>();
    public ICollection<EkSureTalebi> EkSureTalepleri { get; set; } = new List<EkSureTalebi>();
    public ICollection<EkButceTalebi> EkButceTalepleri { get; set; } = new List<EkButceTalebi>();
    public ICollection<Yayin> Yayinlar { get; set; } = new List<Yayin>();
    public ICollection<Harcama> Harcamalar { get; set; } = new List<Harcama>();
}
