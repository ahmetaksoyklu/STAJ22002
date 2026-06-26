using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class LogKaydiRepository : EfRepositoryBase<LogKaydi, int, BaseDbContext>, ILogKaydiRepository
{
    public LogKaydiRepository(BaseDbContext context) : base(context) { }
}
