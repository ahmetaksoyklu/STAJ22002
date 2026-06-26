using Application.Services.Repositories;
using Application.Features.HazirMesajlar.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.HazirMesajlar.Commands.Create;

public class CreateHazirMesajCommandHandler : IRequestHandler<CreateHazirMesajCommand, CreatedHazirMesajResponse>
{
    private readonly IHazirMesajRepository _hazirMesajRepository;
    private readonly HazirMesajBusinessRules _hazirMesajBusinessRules;
    private readonly IMapper _mapper;

    public CreateHazirMesajCommandHandler(
        IHazirMesajRepository hazirMesajRepository,
        HazirMesajBusinessRules hazirMesajBusinessRules,
        IMapper mapper)
    {
        _hazirMesajRepository = hazirMesajRepository;
        _hazirMesajBusinessRules = hazirMesajBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedHazirMesajResponse> Handle(CreateHazirMesajCommand request, CancellationToken cancellationToken)
    {
        await _hazirMesajBusinessRules.HazirMesajBasligiTekrarEdemez(request.Baslik, cancellationToken);
        await _hazirMesajBusinessRules.HazirMesajKonusuTekrarEdemez(request.Konu, cancellationToken);

        HazirMesaj hazirMesaj = _mapper.Map<HazirMesaj>(request);
        HazirMesaj createdHazirMesaj = await _hazirMesajRepository.AddAsync(hazirMesaj, cancellationToken);
        return _mapper.Map<CreatedHazirMesajResponse>(createdHazirMesaj);
    }
}
