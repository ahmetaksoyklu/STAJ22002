using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class HarcamaRepository : EfRepositoryBase<Harcama, int, BaseDbContext>, IHarcamaRepository
{
    public HarcamaRepository(BaseDbContext context) : base(context) { }
}
