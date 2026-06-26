using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class FormSablonuRepository : EfRepositoryBase<FormSablonu, int, BaseDbContext>, IFormSablonuRepository
{
    public FormSablonuRepository(BaseDbContext context) : base(context) { }
}
