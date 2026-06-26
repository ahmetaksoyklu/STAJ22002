using Application.Services.Repositories;
using Application.Features.HazirMesajlar.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.HazirMesajlar.Commands.Update;

public class UpdateHazirMesajCommandHandler : IRequestHandler<UpdateHazirMesajCommand, UpdatedHazirMesajResponse>
{
    private readonly IHazirMesajRepository _hazirMesajRepository;
    private readonly HazirMesajBusinessRules _hazirMesajBusinessRules;
    private readonly IMapper _mapper;

    public UpdateHazirMesajCommandHandler(
        IHazirMesajRepository hazirMesajRepository,
        HazirMesajBusinessRules hazirMesajBusinessRules,
        IMapper mapper)
    {
        _hazirMesajRepository = hazirMesajRepository;
        _hazirMesajBusinessRules = hazirMesajBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdatedHazirMesajResponse> Handle(UpdateHazirMesajCommand request, CancellationToken cancellationToken)
    {
        HazirMesaj? hazirMesaj = await _hazirMesajRepository.GetAsync(
            predicate: x => x.Id == request.Id,
            enableTracking: true,
            withDeleted: true,
            cancellationToken: cancellationToken);

        _hazirMesajBusinessRules.HazirMesajMevcutOlmali(hazirMesaj, request.Id);
        _hazirMesajBusinessRules.SilinmisHazirMesajGuncellenemez(hazirMesaj!);
        await _hazirMesajBusinessRules.HazirMesajBasligiBaskaKayittaTekrarEdemez(request.Id, request.Baslik, cancellationToken);
        await _hazirMesajBusinessRules.HazirMesajKonusuBaskaKayittaTekrarEdemez(request.Id, request.Konu, cancellationToken);

        _mapper.Map(request, hazirMesaj!);
        HazirMesaj updatedHazirMesaj = await _hazirMesajRepository.UpdateAsync(hazirMesaj!, cancellationToken);

        return _mapper.Map<UpdatedHazirMesajResponse>(updatedHazirMesaj);
    }
}
