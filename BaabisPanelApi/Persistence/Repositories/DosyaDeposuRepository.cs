using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class DosyaDeposuRepository : EfRepositoryBase<DosyaDeposu, int, BaseDbContext>, IDosyaDeposuRepository
{
    public DosyaDeposuRepository(BaseDbContext context) : base(context) { }
}
