using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProformaFaturaRepository : EfRepositoryBase<ProformaFatura, int, BaseDbContext>, IProformaFaturaRepository
{
    public ProformaFaturaRepository(BaseDbContext context) : base(context) { }
}
