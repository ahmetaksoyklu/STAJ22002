using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProjeArastirmacisiRepository : EfRepositoryBase<ProjeArastirmacisi, int, BaseDbContext>, IProjeArastirmacisiRepository
{
    public ProjeArastirmacisiRepository(BaseDbContext context) : base(context) { }
}
