using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProjeHakemRepository : EfRepositoryBase<ProjeHakem, int, BaseDbContext>, IProjeHakemRepository
{
    public ProjeHakemRepository(BaseDbContext context) : base(context) { }
}
