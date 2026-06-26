using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.HazirMesajlar.Queries.GetList;

public class GetListHazirMesajQueryHandler : IRequestHandler<GetListHazirMesajQuery, IReadOnlyList<GetListHazirMesajListItem>>
{
    private readonly IHazirMesajRepository _hazirMesajRepository;
    private readonly IMapper _mapper;

    public GetListHazirMesajQueryHandler(IHazirMesajRepository hazirMesajRepository, IMapper mapper)
    {
        _hazirMesajRepository = hazirMesajRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GetListHazirMesajListItem>> Handle(GetListHazirMesajQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<HazirMesaj> hazirMesajlar = await _hazirMesajRepository.GetListAsync(
            orderBy: q => q.OrderByDescending(x => x.CreatedDate),
            withDeleted: false,
            enableTracking: false,
            cancellationToken: cancellationToken);

        return _mapper.Map<IReadOnlyList<GetListHazirMesajListItem>>(hazirMesajlar);
    }
}
