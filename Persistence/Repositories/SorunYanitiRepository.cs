using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class SorunYanitiRepository : EfRepositoryBase<SorunYaniti, int, BaseDbContext>, ISorunYanitiRepository
{
    public SorunYanitiRepository(BaseDbContext context) : base(context) { }
}
