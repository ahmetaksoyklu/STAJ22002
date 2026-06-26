using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.HazirMesajlar.Rules;

public class HazirMesajBusinessRules
{
    private readonly IHazirMesajRepository _hazirMesajRepository;

    public HazirMesajBusinessRules(IHazirMesajRepository hazirMesajRepository)
    {
        _hazirMesajRepository = hazirMesajRepository;
    }

    public async Task HazirMesajBasligiTekrarEdemez(string baslik, CancellationToken cancellationToken)
    {
        bool exists = await _hazirMesajRepository.AnyAsync(
            predicate: x => x.Baslik == baslik,
            withDeleted: false,
            enableTracking: false,
            cancellationToken: cancellationToken);

        if (exists)
            throw new InvalidOperationException($"Ayni baslikta hazir mesaj zaten var. Baslik: {baslik}");
    }

    public async Task HazirMesajBasligiBaskaKayittaTekrarEdemez(int id, string baslik, CancellationToken cancellationToken)
    {
        bool exists = await _hazirMesajRepository.AnyAsync(
            predicate: x => x.Id != id && x.Baslik == baslik,
            withDeleted: false,
            enableTracking: false,
            cancellationToken: cancellationToken);

        if (exists)
            throw new InvalidOperationException($"Ayni baslik baska kayitta kullaniliyor. Baslik: {baslik}");
    }

    public async Task HazirMesajKonusuBaskaKayittaTekrarEdemez(int id, string konu, CancellationToken cancellationToken)
    {
        bool exists = await _hazirMesajRepository.AnyAsync(
            predicate: x => x.Id != id && x.Konu == konu,
            withDeleted: false,
            enableTracking: false,
            cancellationToken: cancellationToken);

        if (exists)
            throw new InvalidOperationException($"Ayni konu baska kayitta kullaniliyor. Konu: {konu}");
    }

    public async Task HazirMesajKonusuTekrarEdemez(string konu, CancellationToken cancellationToken)
    {
        bool exists = await _hazirMesajRepository.AnyAsync(
            predicate: x => x.Konu == konu,
            withDeleted: false,
            enableTracking: false,
            cancellationToken: cancellationToken);

        if (exists)
            throw new InvalidOperationException($"Ayni konuya sahip hazir mesaj zaten var. Konu: {konu}");
    }

    public void HazirMesajMevcutOlmali(HazirMesaj? hazirMesaj, int id)
    {
        if (hazirMesaj is null)
            throw new KeyNotFoundException($"HazirMesaj not found. Id: {id}");
    }

    public void SilinmisHazirMesajGuncellenemez(HazirMesaj hazirMesaj)
    {
        if (hazirMesaj.DeletedDate is not null)
            throw new InvalidOperationException($"Silinmis hazir mesaj guncellenemez. Id: {hazirMesaj.Id}");
    }

    public void SilinmisHazirMesajSilinemez(HazirMesaj hazirMesaj)
    {
        if (hazirMesaj.DeletedDate is not null)
            throw new InvalidOperationException($"Silinmis hazir mesaj tekrar silinemez. Id: {hazirMesaj.Id}");
    }
}
