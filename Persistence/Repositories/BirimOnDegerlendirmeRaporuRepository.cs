using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class BirimOnDegerlendirmeRaporuRepository : EfRepositoryBase<BirimOnDegerlendirmeRaporu, int, BaseDbContext>, IBirimOnDegerlendirmeRaporuRepository
{
    public BirimOnDegerlendirmeRaporuRepository(BaseDbContext context) : base(context) { }
}
