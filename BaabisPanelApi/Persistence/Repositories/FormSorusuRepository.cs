using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class FormSorusuRepository : EfRepositoryBase<FormSorusu, int, BaseDbContext>, IFormSorusuRepository
{
    public FormSorusuRepository(BaseDbContext context) : base(context) { }
}
