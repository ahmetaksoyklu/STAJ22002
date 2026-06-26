using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class EkButceTalebiRepository : EfRepositoryBase<EkButceTalebi, int, BaseDbContext>, IEkButceTalebiRepository
{
    public EkButceTalebiRepository(BaseDbContext context) : base(context) { }
}
