using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProjeTipiRepository : EfRepositoryBase<ProjeTipi, int, BaseDbContext>, IProjeTipiRepository
{
    public ProjeTipiRepository(BaseDbContext context) : base(context) { }
}
