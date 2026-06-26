using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class SorunBildirimiRepository : EfRepositoryBase<SorunBildirimi, int, BaseDbContext>, ISorunBildirimiRepository
{
    public SorunBildirimiRepository(BaseDbContext context) : base(context) { }
}
