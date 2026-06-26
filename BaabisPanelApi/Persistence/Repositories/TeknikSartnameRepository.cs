using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class TeknikSartnameRepository : EfRepositoryBase<TeknikSartname, int, BaseDbContext>, ITeknikSartnameRepository
{
    public TeknikSartnameRepository(BaseDbContext context) : base(context) { }
}
