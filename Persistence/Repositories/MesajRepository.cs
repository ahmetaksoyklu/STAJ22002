using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class MesajRepository : EfRepositoryBase<Mesaj, int, BaseDbContext>, IMesajRepository
{
    public MesajRepository(BaseDbContext context) : base(context) { }
}
