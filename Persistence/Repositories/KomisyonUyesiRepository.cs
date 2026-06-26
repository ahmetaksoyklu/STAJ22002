using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class KomisyonUyesiRepository : EfRepositoryBase<KomisyonUyesi, int, BaseDbContext>, IKomisyonUyesiRepository
{
    public KomisyonUyesiRepository(BaseDbContext context) : base(context) { }
}
