using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; }

    public BaseDbContext(DbContextOptions<BaseDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Proje> Projeler => Set<Proje>();
    public DbSet<ProjeArastirmacisi> ProjeArastirmacilari => Set<ProjeArastirmacisi>();
    public DbSet<DetayliButce> DetayliButceler => Set<DetayliButce>();
    public DbSet<TeknikSartname> TeknikSartnameler => Set<TeknikSartname>();
    public DbSet<ProformaFatura> ProformaFaturalar => Set<ProformaFatura>();
    public DbSet<Hakem> Hakemler => Set<Hakem>();
    public DbSet<ProjeHakem> ProjeHakemleri => Set<ProjeHakem>();

    public DbSet<KomisyonUyesi> KomisyonUyeleri => Set<KomisyonUyesi>();
    public DbSet<KomisyonKarari> KomisyonKararlari => Set<KomisyonKarari>();
    public DbSet<BirimOnDegerlendirmeUyesi> BirimOnDegerlendirmeUyeleri => Set<BirimOnDegerlendirmeUyesi>();
    public DbSet<BirimOnDegerlendirmeRaporu> BirimOnDegerlendirmeRaporlari => Set<BirimOnDegerlendirmeRaporu>();
    public DbSet<ProjeRaporu> ProjeRaporlari => Set<ProjeRaporu>();
    public DbSet<EkSureTalebi> EkSureTalepleri => Set<EkSureTalebi>();
    public DbSet<EkButceTalebi> EkButceTalepleri => Set<EkButceTalebi>();
    public DbSet<Yayin> Yayinlar => Set<Yayin>();
    public DbSet<Harcama> Harcamalar => Set<Harcama>();
    public DbSet<User> Users => Set<User>();

    public DbSet<Mesaj> Mesajlar => Set<Mesaj>();
    public DbSet<SorunBildirimi> SorunBildirimleri => Set<SorunBildirimi>();
    public DbSet<SorunYaniti> SorunYanitlari => Set<SorunYaniti>();
    public DbSet<HazirMesaj> HazirMesajlar => Set<HazirMesaj>();
    public DbSet<DosyaDeposu> DosyaDepolari => Set<DosyaDeposu>();
    public DbSet<LogKaydi> LogKayitlari => Set<LogKaydi>();
    public DbSet<OturumKaydi> OturumKayitlari => Set<OturumKaydi>();
    public DbSet<Birim> Birimler => Set<Birim>();
    public DbSet<ProjeTipi> ProjeTipleri => Set<ProjeTipi>();
    public DbSet<FormSablonu> FormSablonlari => Set<FormSablonu>();
    public DbSet<FormSorusu> FormSorulari => Set<FormSorusu>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);
    }
}
