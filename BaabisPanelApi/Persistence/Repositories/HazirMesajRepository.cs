using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class HazirMesajRepository : EfRepositoryBase<HazirMesaj, int, BaseDbContext>, IHazirMesajRepository
{
    public HazirMesajRepository(BaseDbContext context) : base(context) { }
}
