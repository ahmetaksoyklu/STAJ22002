using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class EkSureTalebiRepository : EfRepositoryBase<EkSureTalebi, int, BaseDbContext>, IEkSureTalebiRepository
{
    public EkSureTalebiRepository(BaseDbContext context) : base(context) { }
}
