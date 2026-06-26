using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class KomisyonKarariRepository : EfRepositoryBase<KomisyonKarari, int, BaseDbContext>, IKomisyonKarariRepository
{
    public KomisyonKarariRepository(BaseDbContext context) : base(context) { }
}
