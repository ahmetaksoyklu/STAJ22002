using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProjeRaporuRepository : EfRepositoryBase<ProjeRaporu, int, BaseDbContext>, IProjeRaporuRepository
{
    public ProjeRaporuRepository(BaseDbContext context) : base(context) { }
}
