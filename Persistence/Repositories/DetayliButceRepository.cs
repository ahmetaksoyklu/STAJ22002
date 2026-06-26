using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class DetayliButceRepository : EfRepositoryBase<DetayliButce, int, BaseDbContext>, IDetayliButceRepository
{
    public DetayliButceRepository(BaseDbContext context) : base(context) { }
}
