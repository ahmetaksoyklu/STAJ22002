using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Seeding;

public static class DemoDataSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using IServiceScope scope = services.CreateScope();
        BaseDbContext context = scope.ServiceProvider.GetRequiredService<BaseDbContext>();

        if (context.Database.IsRelational())
            await context.Database.MigrateAsync();
        else
            await context.Database.EnsureCreatedAsync();

        if (await context.Projeler.AnyAsync(p => p.Id == 1))
            return;

        DateTime now = DateTime.UtcNow;

        User user = new()
        {
            Id = 1,
            Ad = "Demo",
            Soyad = "Yurutucu",
            Email = "demo.yurutucu@klu.edu.tr",
            Telefon = "5550000001",
            AktifMi = true,
            CreatedDate = now
        };

        ProjeTipi projeTipi = new()
        {
            Id = 1,
            Ad = "BAP Arastirma Projesi",
            Aciklama = "Demo proje tipi",
            AktifMi = true,
            CreatedDate = now
        };

        KomisyonUyesi komisyonUyesi = new()
        {
            Id = 1,
            Ad = "Demo",
            Soyad = "Komisyon Uyesi",
            Eposta = "demo.komisyon@klu.edu.tr",
            Gorev = "BAP Komisyonu",
            AktifMi = true,
            CreatedDate = now
        };

        Proje proje = new()
        {
            Id = 1,
            Baslik = "Demo BAP Projesi - Komisyon Son Karar Testi",
            Ozet = "Swagger uzerinden son komisyon karari endpoint testi icin ornek proje.",
            YurutucuUserId = 1,
            ProjeTipiId = 1,
            Durum = ProjeDurumu.HakemlikSonrasiBapKomisyonu,
            BaslangicTarihi = now,
            CreatedDate = now
        };

        if (context.Database.IsSqlServer())
        {
            await using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction =
                await context.Database.BeginTransactionAsync();

            try
            {
                if (!await context.Users.AnyAsync(u => u.Id == 1))
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_users ON");
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_users OFF");
                }

                if (!await context.ProjeTipleri.AnyAsync(p => p.Id == 1))
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_proje_tipleri ON");
                    context.ProjeTipleri.Add(projeTipi);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_proje_tipleri OFF");
                }

                if (!await context.KomisyonUyeleri.AnyAsync(k => k.Id == 1))
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_bapkomisyonu ON");
                    context.KomisyonUyeleri.Add(komisyonUyesi);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_bapkomisyonu OFF");
                }

                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_bapproje ON");
                context.Projeler.Add(proje);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT tbl_bapproje OFF");

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        else
        {
            if (!await context.Users.AnyAsync(u => u.Id == 1))
                context.Users.Add(user);

            if (!await context.ProjeTipleri.AnyAsync(p => p.Id == 1))
                context.ProjeTipleri.Add(projeTipi);

            if (!await context.KomisyonUyeleri.AnyAsync(k => k.Id == 1))
                context.KomisyonUyeleri.Add(komisyonUyesi);

            context.Projeler.Add(proje);
            await context.SaveChangesAsync();
        }
    }
}
