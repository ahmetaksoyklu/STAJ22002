using Application.Services.Repositories;
using Application.Features.HazirMesajlar.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.HazirMesajlar.Commands.Delete;

public class DeleteHazirMesajCommandHandler : IRequestHandler<DeleteHazirMesajCommand, DeletedHazirMesajResponse>
{
    private readonly IHazirMesajRepository _hazirMesajRepository;
    private readonly HazirMesajBusinessRules _hazirMesajBusinessRules;
    private readonly IMapper _mapper;

    public DeleteHazirMesajCommandHandler(
        IHazirMesajRepository hazirMesajRepository,
        HazirMesajBusinessRules hazirMesajBusinessRules,
        IMapper mapper)
    {
        _hazirMesajRepository = hazirMesajRepository;
        _hazirMesajBusinessRules = hazirMesajBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeletedHazirMesajResponse> Handle(DeleteHazirMesajCommand request, CancellationToken cancellationToken)
    {
        HazirMesaj? hazirMesaj = await _hazirMesajRepository.GetAsync(
            predicate: x => x.Id == request.Id,
            enableTracking: true,
            withDeleted: true,
            cancellationToken: cancellationToken);

        _hazirMesajBusinessRules.HazirMesajMevcutOlmali(hazirMesaj, request.Id);
        _hazirMesajBusinessRules.SilinmisHazirMesajSilinemez(hazirMesaj!);

        HazirMesaj deletedHazirMesaj = await _hazirMesajRepository.DeleteAsync(hazirMesaj!, cancellationToken: cancellationToken);
        return _mapper.Map<DeletedHazirMesajResponse>(deletedHazirMesaj);
    }
}
