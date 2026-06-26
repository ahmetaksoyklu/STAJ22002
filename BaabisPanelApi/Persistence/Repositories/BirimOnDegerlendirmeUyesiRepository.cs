using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class BirimOnDegerlendirmeUyesiRepository : EfRepositoryBase<BirimOnDegerlendirmeUyesi, int, BaseDbContext>, IBirimOnDegerlendirmeUyesiRepository
{
    public BirimOnDegerlendirmeUyesiRepository(BaseDbContext context) : base(context) { }
}
