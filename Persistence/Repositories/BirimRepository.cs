using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class BirimRepository : EfRepositoryBase<Birim, int, BaseDbContext>, IBirimRepository
{
    public BirimRepository(BaseDbContext context) : base(context) { }
}
