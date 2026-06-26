using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        services.AddScoped<IProjeRepository, ProjeRepository>();
        services.AddScoped<IProjeArastirmacisiRepository, ProjeArastirmacisiRepository>();
        services.AddScoped<IDetayliButceRepository, DetayliButceRepository>();
        services.AddScoped<ITeknikSartnameRepository, TeknikSartnameRepository>();
        services.AddScoped<IProformaFaturaRepository, ProformaFaturaRepository>();
        services.AddScoped<IHakemRepository, HakemRepository>();
        services.AddScoped<IProjeHakemRepository, ProjeHakemRepository>();

        services.AddScoped<IKomisyonUyesiRepository, KomisyonUyesiRepository>();
        services.AddScoped<IKomisyonKarariRepository, KomisyonKarariRepository>();
        services.AddScoped<IBirimOnDegerlendirmeUyesiRepository, BirimOnDegerlendirmeUyesiRepository>();
        services.AddScoped<IBirimOnDegerlendirmeRaporuRepository, BirimOnDegerlendirmeRaporuRepository>();
        services.AddScoped<IProjeRaporuRepository, ProjeRaporuRepository>();
        services.AddScoped<IEkSureTalebiRepository, EkSureTalebiRepository>();
        services.AddScoped<IEkButceTalebiRepository, EkButceTalebiRepository>();
        services.AddScoped<IYayinRepository, YayinRepository>();
        services.AddScoped<IHarcamaRepository, HarcamaRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IMesajRepository, MesajRepository>();
        services.AddScoped<ISorunBildirimiRepository, SorunBildirimiRepository>();
        services.AddScoped<ISorunYanitiRepository, SorunYanitiRepository>();
        services.AddScoped<IHazirMesajRepository, HazirMesajRepository>();
        services.AddScoped<IDosyaDeposuRepository, DosyaDeposuRepository>();
        services.AddScoped<ILogKaydiRepository, LogKaydiRepository>();
        services.AddScoped<IOturumKaydiRepository, OturumKaydiRepository>();
        services.AddScoped<IBirimRepository, BirimRepository>();
        services.AddScoped<IProjeTipiRepository, ProjeTipiRepository>();
        services.AddScoped<IFormSablonuRepository, FormSablonuRepository>();
        services.AddScoped<IFormSorusuRepository, FormSorusuRepository>();

        return services;
    }
}
