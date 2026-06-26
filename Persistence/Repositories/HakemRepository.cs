using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class HakemRepository : EfRepositoryBase<Hakem, int, BaseDbContext>, IHakemRepository
{
    public HakemRepository(BaseDbContext context) : base(context) { }
}
