using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProjeRepository : EfRepositoryBase<Proje, int, BaseDbContext>, IProjeRepository
{
    public ProjeRepository(BaseDbContext context) : base(context) { }
}
