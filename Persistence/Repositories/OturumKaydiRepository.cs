using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class OturumKaydiRepository : EfRepositoryBase<OturumKaydi, int, BaseDbContext>, IOturumKaydiRepository
{
    public OturumKaydiRepository(BaseDbContext context) : base(context) { }
}
