using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class YayinRepository : EfRepositoryBase<Yayin, int, BaseDbContext>, IYayinRepository
{
    public YayinRepository(BaseDbContext context) : base(context) { }
}
