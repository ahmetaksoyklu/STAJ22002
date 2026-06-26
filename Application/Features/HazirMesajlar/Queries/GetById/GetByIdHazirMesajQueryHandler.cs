using Application.Services.Repositories;
using Application.Features.HazirMesajlar.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.HazirMesajlar.Queries.GetById;

public class GetByIdHazirMesajQueryHandler : IRequestHandler<GetByIdHazirMesajQuery, GetByIdHazirMesajResponse>
{
    private readonly IHazirMesajRepository _hazirMesajRepository;
    private readonly HazirMesajBusinessRules _hazirMesajBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdHazirMesajQueryHandler(
        IHazirMesajRepository hazirMesajRepository,
        HazirMesajBusinessRules hazirMesajBusinessRules,
        IMapper mapper)
    {
        _hazirMesajRepository = hazirMesajRepository;
        _hazirMesajBusinessRules = hazirMesajBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdHazirMesajResponse> Handle(GetByIdHazirMesajQuery request, CancellationToken cancellationToken)
    {
        HazirMesaj? hazirMesaj = await _hazirMesajRepository.GetAsync(
            predicate: x => x.Id == request.Id,
            enableTracking: false,
            withDeleted: false,
            cancellationToken: cancellationToken);

        _hazirMesajBusinessRules.HazirMesajMevcutOlmali(hazirMesaj, request.Id);

        return _mapper.Map<GetByIdHazirMesajResponse>(hazirMesaj!);
    }
}
